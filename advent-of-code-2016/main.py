def processInput():
  lines = []
  for line in open("file.txt"):

    thing = line.strip().split(" ")

    lines.append([int(num) for num in thing if not num == ""])

  return lines

def check(line):
  return line[0] + line[1] > line[2] and line[1] + line[2] > line[0] and line[2] + line[0] > line[1]



def part1():
  inp = processInput()

  #print(inp)

  total = 0
  for line in inp:
        
    total += 1 if check(line) else 0
  
  return total

def part2():
  inp = processInput()

  #print(inp)

  total = 0
  for i, line in enumerate(inp):
    #newLine = [line[i], line[(i + 3) % len(inp)], line[(i + 6) % len(inp)]]
    print(line)

    #print(newLine)

    input()

    total += 1 if check(line) else 0
  
  return total

print(part1())
print(part2())