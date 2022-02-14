def processInput():
  string = [line for line in open("file1.txt")][0]

  return string

def part1():
  instructions = processInput()

  floor = 0

  for instruction in instructions: floor += 1 if instruction == "(" else -1
  
  return floor

def part2():
  instructions = processInput()

  floor = 0

  for i, instruction in enumerate(instructions):
    floor += 1 if instruction == "(" else -1
    
    if floor < 0:
      return i + 1
