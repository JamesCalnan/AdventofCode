def process_input_p1():
  return [set([letter for letter in group]) for group in [group.replace("\n","") for group in open("day06/file.txt", "r").read().split("\n\n")]]

def process_input_p2():
  return [{group.count("\n") + 1 : group.replace("\n", "")} for group in open("day06/file.txt", "r").read().split("\n\n")]

def part1():
  return sum([len(group) for group in process_input_p1()])

def part2():
  total = 0
  for group in process_input_p2():
    for k, v in group.items():
      total += len([letter for letter in set(v) if v.count(letter) == k])

  return total