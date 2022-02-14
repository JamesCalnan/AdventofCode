from itertools import combinations
def process_input():
  return [int(number.strip()) for number in open("day09/file.txt", "r")]

def check_sum(previous_numbers, number_to_make, l, h):
  for combo in list(combinations([previous_numbers[i] for i in range(l, h)], 2)):
    if sum(combo) == number_to_make:
      return True
  
  return False

def part1():
  puzzle_input = process_input()
  number_range = 25
  l = number_range

  while True:
    if not check_sum(puzzle_input, puzzle_input[l], l - number_range, l):
      return puzzle_input[l]
    else:
      l += 1

def part2():
  puzzle_input = process_input()
  target = part1()

  total, i, j = 0, 0, 0

  while i < len(puzzle_input):
    if total == target and i + 1 < j:
      return min(puzzle_input[i:j]) + max(puzzle_input[i:j])
    elif total < target and j < len(puzzle_input):
      total += puzzle_input[j]
      j += 1
    else:
      total -= puzzle_input[i]
      i += 1