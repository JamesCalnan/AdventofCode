from functools import reduce

def part1():
  earliest_time = open("day13/file.txt", "r").read().split("\n")
  goal, buses = int(earliest_time[0]), {int(num) : 0 for num in earliest_time[1].split(",") if num.isnumeric()}

  for k,v in buses.items():
    bus_id, c_time = k, 0

    while c_time <= goal:
      c_time += bus_id
    
    buses[bus_id] = c_time

  bus_id, waiting = 0, 999999999

  for k,v in buses.items():
    if v > goal and v - goal < waiting:
      bus_id = k
      waiting = v - goal

  return bus_id * waiting

def part2():
  bus_IDs = [(int(i), (int(i) - index) % (int(i)), index) for index,i in enumerate(open("day13/file.txt", "r").read().split("\n")[1].split(",")) if i != 'x']

  N = reduce(lambda x,y: x*y,[bus[0] for bus in bus_IDs])

  x = 0

  for n_i, b_i, i in bus_IDs:
    N_i = N // n_i
    x_i = pow(N_i, -1, n_i)
    x += b_i * x_i * N_i

  return int(x%N)