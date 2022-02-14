def processInput():
  positionsAndStates = {}

  for y, lines in enumerate(open("day11/file.txt", "r")):
    for x, letter in enumerate(lines):
      positionsAndStates[(int(x),int(y))] = letter

  return positionsAndStates

def neighbour_count(grid,i,j):
  return sum([grid[(i+x,j+y)] == "#" if not (x == 0 and y == 0) and (i+x,j+y) in grid else False for y in range(-1, 2) for x in range(-1 , 2)])

def compute_seats(seat_map, part1 = True):
  new_grid = seat_map.copy()

  maximumXValue, maximumYValue = max(k for k in seat_map.keys())

  for i in range(0,maximumXValue):
    for j in range(0, maximumYValue+2):
      if not seat_map[(i,j)] == ".":
        count = neighbour_count(seat_map, i, j) if part1 else neighbour_count_p2(seat_map, i, j)

        if (i,j) in seat_map and seat_map[(i,j)] == "L":
          if count == 0:
            new_grid[(i,j)] = "#"

        elif (i,j) in seat_map and seat_map[(i,j)] == "#":
          if count >= (4 if part1 else 5):
            new_grid[(i,j)] = "L"
  
  return new_grid

def solve(part1 = True):

  grid = processInput()
  previous_grid = grid.copy()
  while True:
    grid = compute_seats(grid, part1)
    if grid == previous_grid:
      break
    previous_grid = grid.copy()
    
  return list(grid.values()).count("#")

def neighbour_count_p2(grid,i,j):
  neighbour_count = 0
  
  for direction in [(-1, -1), (0, -1), (1, -1), (-1, 0), (1, 0), (-1, 1), (0, 1), (1, 1)]:
    distance = 0
    while True:
      distance += 1

      y = direction[0] * distance + j
      x = direction[1] * distance + i

      if not (x,y) in grid:
        break
      elif grid[(x,y)] == "#":
        neighbour_count += 1
        break
      elif grid[(x,y)] == "L":
        break

  return neighbour_count

#both solutions take 20 seconds on repl, but with i5-4570 they only take 2 seconds