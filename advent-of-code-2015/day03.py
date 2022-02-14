def processInput():
  file = open("file1.txt", "r")

  finalMoves = []

  for line in file:
    moves = []
    for m in line:
      if m == ">":
        moves.append((1,0))
      elif m == "v":
        moves.append((0,1))
      elif m == "<":
        moves.append((-1,0))
      elif m == "^":
        moves.append((0,-1))
    finalMoves.append(moves)  
  
  return finalMoves

def part1():
  moves = processInput()
  houses = {}

  x,y = 0,0
  houses[(x,y)] = 1
  for line in moves:
  
    for move in line:
      x += move[0]
      y += move[1]

      houses[(x,y)] = houses[(x,y)] + 1 if (x,y) in houses else 1

  
  return len(houses.values())

def part2():
  moves = processInput()
  houses = {}

  x,y = 0,0
  x1,y1 = 0,0

  houses[(x,y)] = 1
  houses[(x1,y1)] = 1
  for line in moves:
    i = 1
    for move in line:
      if i % 2 == 0:
        x,y = move[0] + x, move[1] + y
        houses[(x,y)] = houses[(x,y)] + 1 if (x,y) in houses else 1
      else:
        x1,y1 = move[0] + x1, move[1] + y1
        houses[(x1,y1)] = houses[(x1,y1)] + 1 if (x1,y1) in houses else 1
      i += 1

      
  return len(houses.values())
