from itertools import combinations
from numpy import prod

def part1():
  return prod([combo for combo in list(combinations([int(i.strip()) for i in open("day01/file.txt")], 2)) if sum(combo) == 2020])

def part2():
  return prod([combo for combo in list(combinations([int(i.strip()) for i in open("day01/file.txt")], 3)) if sum(combo) == 2020])