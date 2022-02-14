import re
class Password:
  def __init__(self, required_character, lower_bound, upper_bound, pwd):
    self.char = required_character
    self.low = int(lower_bound)
    self.high = int(upper_bound)
    self.pwd = pwd

def processInput():
  lines = []

  for line in open("day02/file.txt"):
    low, high, char, pwd = re.match("(\d+)-(\d+) (\w): (\w*)", line).groups()

    lines.append(Password(char, low, high, pwd))

  return lines

def part1():
  return len([data for data in processInput() if data.pwd.count(data.char) in range(data.low, data.high + 1)])

def part2():
  return len([data for data in processInput() if (data.pwd[data.low-1] == data.char) ^ (data.pwd[data.high-1] == data.char)])

print(part1())
print(part2())