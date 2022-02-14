import enum
from os import linesep
from rich.console import Console
c = Console()

def remove_whitespace(l1:list):
    new_list = []
    for x in l1:
        t2 = {}
        for y in x:
            if y != "":
                t2[int(y)] = False
        new_list.append(t2)
    return new_list

def check_elements(line):
    for item in line:
        if item != True:
            return False
    return True

def check_win(boards, completed_idx =[]):
    #check horizontal
    for i, board in enumerate(boards):
        if i in completed_idx: continue
        #horizontal win
        for line in board:
            if check_elements(line.values()):
                c.print(f"horizontal: {list(line.values())}")
                return i, "true horizontal"
        #check verticle
        for x in range(5):
            values = []
            for k, item in enumerate([list(line)[x] for line in board]):
                values.append(board[k][item])
            if check_elements(values):
                c.print(f"verticle: {i} {list(values)}")
                return i, "true verticle"
    return False

def parse_input():
    file = open("input.txt", "r").read().split("\n")
    numbers = list(map(int, file[0].split(",")))
    boards = file[2:]
    temp_list = []
    split_boards = []    
    for line in boards:
        if line == "":
            split_boards.append(remove_whitespace(temp_list))
            temp_list.clear()
        else:
            temp_list.append(line.split(" "))
    split_boards.append(remove_whitespace(temp_list))

    return numbers, split_boards    

def get_total(board):
    total = 0
    for line in board:
        total += sum(list([k for k,v in line.items() if v is not True]))
    return total

def part1():
    numbers, boards = parse_input()
    
    for number in numbers:
        for board in boards:
            for line in board:
                if number in list(line.keys()):
                    line[number] = True
        value = check_win(boards)
        if value is not False:
            return number * get_total(boards[value[0]])
    return None

def remove_boards(boards, idx):
    new_boards = []
    for i, board in enumerate(boards):
        if i not in idx:
            new_boards.append(board)
    
    return new_boards

def part2():
    final = 0
    results = []
    numbers, boards = parse_input()
    complete_boards = []
    for number in numbers:
        for board in boards:
            for line in board:
                if number in list(line.keys()):
                    line[number] = True
        value = check_win(boards, complete_boards)
        if value is not False and value[0] not in complete_boards:
            complete_boards.append(value[0])
            results.append(number * get_total(boards[value[0]]))
        t_boards = remove_boards(boards, complete_boards)
        c.print(boards, number, len(t_boards))
        input()
        if len(t_boards) == 0:
            final = number * get_total(boards[0])
            break
        boards = remove_boards(boards, complete_boards)
        
    return final

c.print(f"\n\n{part2()}")