def processInput(location):
  positionsAndStates = {}

  f = open(location)

  for y, lines in enumerate(f):
    for x, letter in enumerate(lines):
      positionsAndStates[(int(x),int(y))] = 1 if letter == "#" else 0

  return positionsAndStates



def printGrid(grid):
  maximumXValue = 0
  for k,v in grid.items():
    maximumXValue = max(maximumXValue, k[0])

  line = ""
  for i, (k, v) in enumerate(grid.items()):
    line += "#" if v == 1 else "."
    if k[0] == maximumXValue:
      print(line)
      line = "" 
  print(line)


def returnNeighbourCount(grid,i,j):
  neighbourCount = 0

  for x in range(-1, 2):
    for y in range(-1, 2):
      if x == 0 and y == 0:
        continue
      if (i+x,j+y) in grid and grid[(i+x,j+y)]:
        neighbourCount += 1

  return neighbourCount


def computeStep(grid, part1=True):

  maximumXValue = 0
  maximumYValue = 0
  for k,v in grid.items():
    maximumXValue = max(maximumXValue, k[0])
    maximumYValue = max(maximumYValue, k[1])
  if not part1:
    for coord in [(0,0),(maximumXValue-1, 0), (0, maximumYValue),(maximumXValue-1, maximumYValue)]:
      grid[coord] = 1
    

  newGrid = grid.copy()

  for i in range(0,maximumXValue):
    for j in range(0, maximumYValue+1):

      neighbourCount = returnNeighbourCount(grid, i, j)

      if (i,j) in grid and grid[(i,j)] == 1:
        if neighbourCount == 2 or neighbourCount == 3:
          newGrid[(i,j)] = 1
        else:
          newGrid[(i,j)] = 0
      elif (i,j) in grid:
        if neighbourCount == 3:
          newGrid[(i,j)] = 1
          
  if not part1:
    for coord in [(0,0),(maximumXValue-1, 0), (0, maximumYValue),(maximumXValue-1, maximumYValue)]:
      grid[coord] = 1

  return newGrid


def part1():
  grid = processInput("file1.txt")
  for i in range(100):
    grid = computeStep(grid)
  
  return sum(grid.values())


def part2():
  grid = processInput("file1.txt")
  for i in range(100):
    grid = computeStep(grid, False)
    
  return sum(grid.values()) 


print(part1())
print(part2())
