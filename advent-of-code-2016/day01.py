import math

def processInput():
  instru = []

  for line in open("file.txt"):
    instru = (line.split(", "))

  return instru

def getNewDir(direction, move, availabledir):
  return availabledir[(availabledir.index(direction) + 3) % len(availabledir)] if move == "L" else availabledir[(availabledir.index(direction) + 1) % len(availabledir)]

def part1(instructions):
  directions = {"N" : (0,1), "E" : (1,0), "S" : (0,-1), "W" : (-1,0)}
  ad = ["N", "E", "S", "W"]
  x,y = 0,0
  direction = "N"
  for instruction in instructions:
    direction = getNewDir(direction, instruction[0], ad)
    for _ in range(int(instruction[1:])):
      x, y = (x + directions[direction][0], y + directions[direction][1])

  return abs(x) + abs(y)

def part2(instructions):
  directions = {"N" : (0,1), "E" : (1,0), "S" : (0,-1), "W" : (-1,0)}
  ad = ["N", "E", "S", "W"]
  previousLocations = []
  x,y = 0,0
  direction = "N"
  for instruction in instructions:
    direction = getNewDir(direction, instruction[0], ad)
    for _ in range(int(instruction[1:])):
      x, y = (x + directions[direction][0], y + directions[direction][1])
      if (x,y) in previousLocations:
        return abs(x) + abs(y)
      previousLocations.append((x,y))
      
  return abs(x) + abs(y)

print(part2(processInput()))