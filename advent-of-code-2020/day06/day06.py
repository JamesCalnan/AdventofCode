def process_input_p1():
  things = []
  
  temp_list = []
  
  file = open("day06/file.txt", "r").read().split("\n\n")
  
  for group in file:
    temp = group
    while "\n" in temp:
      temp = temp.replace("\n","")
    temp_list.append(temp)
    
  for group in temp_list:
    temp_set = set()
    for letter in group:
      temp_set.add(letter)
    things.append(list(sorted(temp_set)))
    
  return things

def process_input_p2():
  temp_list = []
  
  file = open("file.txt", "r").read().split("\n\n")
  
  for group in file:
    temp = group
    number_of_people = temp.count("\n") + 1
    while "\n" in temp:
      temp = temp.replace("\n", "")
    temp_list.append({number_of_people : temp})
  
  return temp_list

def part1():
  puzzle_input = process_input_p1()
  
  total = 0
  
  for group in puzzle_input:
    total += len(group)
    
  return total

def part2():
  puzzle_input = process_input_p2()
  
  total = 0
  for group in puzzle_input:
    for k, v in group.items():
      for letter in set(v):
        if v.count(letter) == k:
          total += 1

  return total

print(part2())