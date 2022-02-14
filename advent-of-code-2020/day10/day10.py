def process_input():
  joltages = list(map(int, open("day10/file2.txt").read().split()))
  return [0] + sorted(joltages) + [max(joltages) + 3]

def part1():
  joltages = process_input()

  jump1 = jump3 = 0
  
  for previous, current in zip(joltages, joltages[1:]):
    jump1 += (current - previous) == 1
    jump3 += (current - previous) == 3

  return jump1 * jump3

def part2():
  joltages = process_input()

  ways = [1] + [0] * (len(joltages) - 1)

  for i in range(1, len(joltages)):
    for j in range(1, 4):
      if i - j >= 0:
        if joltages[i] - joltages[i-j] <= 3:
          ways[i] += ways[i-j]

          
  return ways[-1]