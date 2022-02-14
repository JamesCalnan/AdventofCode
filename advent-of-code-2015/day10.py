def part1():
  puzzleInput = "1321131112"

  for i in range(40):
    puzzleInput = look_and_say(puzzleInput)
  return len(puzzleInput)

def part2():
  puzzleInput = "1321131112"
  
  for i in range(50):
    puzzleInput = look_and_say(puzzleInput)
  return len(puzzleInput)

def look_and_say(puzzleInput):
  c = 1
  result = ""
  for i in range(len(puzzleInput)-1):
    if puzzleInput[i] != puzzleInput[i + 1]:
      result += f"{c}{puzzleInput[i]}"
      c = 1
    else:
      c += 1

  return result + f"{c}{puzzleInput[-1]}"