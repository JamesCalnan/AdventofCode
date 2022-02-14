def processInput():
  lines = []

  for line in open("file1.txt"):
    lines.append(line.strip())

  return lines

import numpy as np

def part1():
  lines = processInput()

  lightGrid = np.zeros((1000, 1000), 'int32')

  for line in lines:
    splitLine = line.split(" ")

    if splitLine[0] == "toggle":
      x1 = int(splitLine[1].split(",")[0])
      y1 = int(splitLine[1].split(",")[1])

      x2 = int(splitLine[3].split(",")[0])
      y2 = int(splitLine[3].split(",")[1])

      lightGrid[x1:x2+1, y1:y2+1] = np.logical_not(lightGrid[x1:x2+1, y1:y2+1])
    else:
      x1 = int(splitLine[2].split(",")[0])
      y1 = int(splitLine[2].split(",")[1])

      x2 = int(splitLine[4].split(",")[0])
      y2 = int(splitLine[4].split(",")[1])

      lightGrid[x1:x2+1, y1:y2+1] = 1 if splitLine[1] == "on" else 0
  
  return np.sum(lightGrid)

def part2():
  lines = processInput()

  lightGrid = np.zeros((1000, 1000), 'int32')

  for line in lines:
    splitLine = line.split(" ")

    if splitLine[0] == "toggle":
      x1 = int(splitLine[1].split(",")[0])
      y1 = int(splitLine[1].split(",")[1])

      x2 = int(splitLine[3].split(",")[0])
      y2 = int(splitLine[3].split(",")[1])

      lightGrid[x1:x2+1, y1:y2+1] += 2
    else:
      x1 = int(splitLine[2].split(",")[0])
      y1 = int(splitLine[2].split(",")[1])

      x2 = int(splitLine[4].split(",")[0])
      y2 = int(splitLine[4].split(",")[1])

      if splitLine[1] == "on":
        lightGrid[x1:x2+1, y1:y2+1] += 1
      else:
        lightGrid[x1:x2+1, y1:y2+1] -= 1
        lightGrid[lightGrid < 0] = 0
  
  return np.sum(lightGrid)

#377891
def part1WithoutNumPY():
  lines = processInput()

  lightGrid = {}

  for i in range(0,999):
    for j in range(0,999):
      lightGrid[(i,j)] = 0

  count = 0

  prev = 0
  prev1 = 0

  for line in lines:
    splitLine = line.split(" ")

    prev = round(count/len(lines) *100)
    if not prev == prev1:
      print(f"{prev}% complete")
    prev1 = round(count/len(lines) *100)

    if splitLine[0] == "toggle":
      x1 = int(splitLine[1].split(",")[0])
      y1 = int(splitLine[1].split(",")[1])

      x2 = int(splitLine[3].split(",")[0])
      y2 = int(splitLine[3].split(",")[1])

      for i in range(x1, x2+1):
        for j in range(y1, y2+1):
          lightGrid[(i,j)] = not lightGrid[(i,j)]

    else:
      x1 = int(splitLine[2].split(",")[0])
      y1 = int(splitLine[2].split(",")[1])

      x2 = int(splitLine[4].split(",")[0])
      y2 = int(splitLine[4].split(",")[1])

      for i in range(x1, x2+1):
        for j in range(y1, y2+1):
          lightGrid[(i,j)] = 1 if splitLine[1] == "on" else 0
    count += 1
  lightsOn = 0

  for v in lightGrid.values():
    lightsOn += 1 if v else 0

  return lightsOn
