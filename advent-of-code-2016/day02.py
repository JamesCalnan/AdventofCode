def processInput():
  lines = []
  for line in open("file.txt"):
    lines.append([l for l in line.strip()])

  return lines

def returnMapPart1():
  return {
    (-1, -1) : 1,
    (0, -1) : 2,
    (1, -1) : 3,
    (-1, 0) : 4,
    (0,  0) : 5,
    (1,  0) : 6,
    (-1, 1) : 7,
    (0,  1) : 8,
    (1,  1) : 9
  }

def returnMapPart2():
  return {
    (0, 0) : 5,
    
    (1, 0) : 6,
    (1, -1): 2,
    (1, 1) : "A",

    (2, 0) : 7,
    (2, -1): 3,
    (2, 1) : "B",

    (2, -2): 2,
    (2, 2) : "D",

    (3, 0) : 8,
    (3, -1): 4,
    (3, 1) : "C",

    (4, 0) : 9
  }


def question(part):
  keyMap = returnMapPart2() if part == 2 else returnMapPart1()
  inp = processInput()

  moveMap = {"U":(0, -1), "R":(1, 0), "D":(0,1), "L":(-1,0)}
  code = ""

  x,y = 0,0
  for line in inp:
    for instruction in line:
      if (x + moveMap[instruction][0], y + moveMap[instruction][1]) in keyMap.keys():
        x += moveMap[instruction][0]
        y += moveMap[instruction][1]

    code += str(keyMap[(x,y)])

  return code

print(question(1))
