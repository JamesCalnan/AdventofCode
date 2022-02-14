def process_input():
  return [line.strip() for line in open("day03/file.txt", "r")]

def part1():
  return sum([line[y * 3 % len(line)] == "#" for y, line in enumerate(process_input())])

def part2():
  puzzle_input = process_input()
  total = 1

  for pairs in [(1,1), (3, 1), (5, 1), (7, 1), (1, 2)]:
    trees_hit, x, y = 0, 0, 0

    while y < len(puzzle_input):

      trees_hit += 1 if puzzle_input[y][x % len(puzzle_input[y])] == "#" else 0

      x += pairs[0]
      y += pairs[1]

    total *= trees_hit

  return total