def process_input():

    puzzle_input = open(f"day16/file.txt").read().split("\n")

    ranges = []
    nearby_tickets = []
    
    your_ticket = ""
    ticket_next = 0
    
    for values in puzzle_input:
        if values == "":
            continue
        elif "or" in values:
            split_on_spaces = values.split(" ")

            first_range = [int(x) for x in split_on_spaces[-1].split("-")]
            second_range = [int(x) for x in split_on_spaces[-3].split("-")]

            ranges.append(range(first_range[0], first_range[1] + 1))
            ranges.append(range(second_range[0], second_range[1] + 1))
        elif ticket_next == 1:
            your_ticket = [int(i) for i in values.split(",")]
            ticket_next = 2
            
        elif values == "your ticket:":
            ticket_next = 1
            
        elif ticket_next == 2 and values != "nearby tickets:":
            nearby_tickets.append([int(x) for x in values.split(",")])

    return ranges, your_ticket, nearby_tickets

def part1(result = False):
    ranges, your_ticket, nearby_tickets = process_input()
    
    total = 0
    valid_tickets = []
    
    for ticket_row in nearby_tickets:
        valid_row = []
        for ticket in ticket_row:
            in_range = True
            for r in ranges:
                if ticket in r:
                    in_range = True
                    break
                else:
                    in_range = False
            if not in_range:
                total += ticket
            else:
                valid_row.append(ticket)
        valid_tickets.append(valid_row)
        
    return total if not result else valid_tickets

def get_ranges_with_titles():
    puzzle_input = open(f"day16/file.txt").read().split("\n\n")[0].split("\n")
    ranges = {}
    for values in puzzle_input:
        
        split_on_spaces = values.split(" ")

        name = values.split(":")[0]

        first_range = [int(x) for x in split_on_spaces[-1].split("-")]
        second_range = [int(x) for x in split_on_spaces[-3].split("-")]
        
        ranges[name] = [range(first_range[0], first_range[1] + 1), range(second_range[0], second_range[1] + 1)]
    
    return ranges

def part2():
    r, your_ticket, n = process_input()
    
    ranges_with_titles = get_ranges_with_titles()
    
    valid_tickets = part1(True)
    
    data = []
    
    for x in range(len(your_ticket)):
        temp_list = []
        for y in range(len(valid_tickets)):
            if x > len(valid_tickets[y]) - 1:
                continue
            temp_list.append(valid_tickets[y][x])
        
        data.append(temp_list)
    
    results = []
    
    for v in ranges_with_titles.values():
        tests = []
        for sample in data:
            result = all([x in v[0] or x in v[1] for x in sample])
            tests.append(result)
        results.append(tests)

    found = 0
    
    while found < len(ranges_with_titles):
        for id in range(len(results)):
            f = results[id]
            if not isinstance(f,list):
                continue
            if f.count(True) == 1:
                found = found + 1
                taken = f.index(True)
                results[id] = taken

                for other in results:
                    if isinstance(other,list):
                        other[taken] = False
    product = 1

    for id in range(len(ranges_with_titles)):
        if 'departure' in list(ranges_with_titles.keys())[id]:
            product *= your_ticket[results[id]]
            
    return product

print(part2())