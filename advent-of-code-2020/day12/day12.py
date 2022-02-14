def process_input():
  return [(line.strip()[0], int(line.strip()[1:])) for line in open("day12/file.txt", "r")]

def part1():
  puzzle_input = process_input()

  angle_to_direction = {0: "E", 90: "N", 180: "W", 270: "S"}
  position = {"N": 0, "S": 0, "E": 0, "W": 0}

  curr_angle = 0

  for instruction, value in puzzle_input:

    if instruction == "L":
      curr_angle = (curr_angle + value) % 360
    elif instruction == "R":
      curr_angle = (curr_angle - value) % 360
    elif instruction == "F":
      position[angle_to_direction[curr_angle]] += value
    else:
      position[instruction] += value
    
  y_axis = abs(position["N"] - position["S"])
  x_axis = abs(position["W"] - position["E"])

  return x_axis + y_axis

def part2():
  puzzle_input = process_input()

  waypoint = [1, 10]
  curr_pos = [0, 0]
  delta_ns = {"N": 1, "S": -1, "E": 0, "W": 0}
  delta_ew = {"N": 0, "S": 0, "E": 1, "W": -1}

  for drxn, val in puzzle_input:
    if drxn == "F":
      curr_pos = [curr_pos[0] + waypoint[0] * val, curr_pos[1] + waypoint[1] * val]
    elif drxn == "L":
      ccw = {90: [waypoint[1], -waypoint[0]], 180: [-waypoint[0], -waypoint[1]], 270: [-waypoint[1], waypoint[0]]}
      waypoint = ccw[val]
    elif drxn == "R":
      cw = {90: [-waypoint[1], waypoint[0]], 180: [-waypoint[0], -waypoint[1]], 270: [waypoint[1], -waypoint[0]]}
      waypoint = cw[val]
    else:
      waypoint = [waypoint[0] + delta_ns[drxn] * val, waypoint[1] + delta_ew[drxn] * val]

  return abs(curr_pos[0]) + abs(curr_pos[1])

print(part2())