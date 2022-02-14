def processInput():
  return [line for line in open("file1.txt")]

def containsDoubleCharacter(inp):
  for i in range(1, len(inp)):
    if inp[i-1] == inp[i]:
      return True
  return False


def contains3Vowels(inp):
  c = 0

  for letter in inp:
    c += 1 if letter in "aeiou" else 0

  return True if c >= 3 else False

def doesntContainSome(inp):
  return False if "ab" in inp or "cd" in inp or "pq" in inp or "xy" in inp else True

def all3(inp):
  return True if doesntContainSome(inp) and contains3Vowels(inp) and containsDoubleCharacter(inp) else False

def part1():
  lines = processInput()
  c = 0
  for line in lines:
    if all3(line):
      c += 1
  return c

def isNice(string):
  if not any([string[i] == string[i+2] for i in range(len(string)-2)]):
    return False

  if any([(string.count(string[i:i+2])>=2) for i in range(len(string)-2)]):
    return True
    
  return False

def part2():
  lines = processInput()
  c = 0
  for line in lines:
    if isNice(line):
      c += 1
  return c
