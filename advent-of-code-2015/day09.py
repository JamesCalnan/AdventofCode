from itertools import permutations

def processInput():
  lines = {}

  locations = []

  for line in open("file1.txt"):
    splitLine = line.strip().split(" ")

    start = splitLine[0]
    end = splitLine[2]

    distance = int(splitLine[4])

    lines[tuple(sorted([start,end]))] = distance
    
    locations.extend([start, end])

  return lines, list(set(locations))

def part1():
  distances, locations = processInput()

  possiblePaths = list(permutations(locations))

  shortestDistance = 99999999

  for path in possiblePaths:
    total = 0
    for i in range(len(path)-1):
      sortedLocations = tuple(sorted([path[i-1], path[i]]))

      total += distances[sortedLocations]

    shortestDistance = min(total, shortestDistance)

  return shortestDistance

def part2():
  distances, locations = processInput()

  possiblePaths = list(permutations(locations))

  largestDistance = 0

  for path in possiblePaths:
    total = 0
    for i in range(len(path)-1):
      sortedLocations = tuple(sorted([path[i-1], path[i]]))

      total += distances[sortedLocations]

    largestDistance = max(total, largestDistance)

  return largestDistance