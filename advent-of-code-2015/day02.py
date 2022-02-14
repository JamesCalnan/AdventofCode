def processInput():
  lines = []

  for line in open("file.txt","r"):
    lines.append([int(l) for l in line.strip().split("x")])

  return lines


def part1():
  lines = processInput()
  total = 0
  for l in lines:
    first =  2 * l[0] * l[1]
    second = 2 * l[1] * l[2]
    third =  2 * l[0] * l[2]
    excess = int(min([first/2, second/2, third/2]))
    total +=  first + second + third + excess
    print(f"first: {first}\nseconrd: {second}\nthird: {third}\nexcess: {excess}\ntotal: {total}")

  return total

def part2():
  lines = processInput()
  total = 0
  for l in lines:
    perimeter1 = 2 * l[0] + 2 * l[1]
    perimeter2 = 2 * l[1] + 2 * l[2]
    perimeter3 = 2 * l[0] + 2 * l[2]
    smallest = min([perimeter1, perimeter2, perimeter3])
    bow = l[0] * l[1] * l[2]
    total += bow + smallest

  return total

