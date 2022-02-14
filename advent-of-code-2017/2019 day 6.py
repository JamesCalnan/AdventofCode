#https://adventofcode.com/2019/day/6

def createAL():
  file = open("file test p1.txt")
  al = {}
  for line in file:
    key = line.split(")")[0]
    value = line.split(")")[1].strip().replace("\n","")
    

    if key not in al:
      al[key] = [value]
    else:
      al[key] += [value]

    if value not in al:
      al[value] = [key]
    else:
      al[value] += [key]

  return al

def bfs(root, goal, adjacencyList):
  Q = [] 

  discovered = {key : False for key in adjacencyList.keys()} 
  cameFrom = {key : None for key in adjacencyList.keys()}
  
  discovered[root] = True 
  Q.append(root)

  while len(Q) > 0:
    v = Q.pop(0)

    if v == goal:
      return cameFrom

    for w in adjacencyList[v]:
      if w in discovered and not discovered[w]:
        cameFrom[w] = v
        discovered[w] = True
        Q.append(w)

  return False

def lettersInMap(adjacencyList):
  returnList = []

  for k,v in adjacencyList.items():
    returnList.append(k)
    for values in v:
      returnList.append(values)

  return returnList

def getPathLength(node1, node2, pathMap):
  current = node1

  count = 0
  path = []
  while not current == node2:
    path.append(current)
    current = pathMap[current]
    count += 1

  
  #this line will print the path to the console
  if len(path) > 0:
    print(f"{node2} -> {' -> '.join(reversed(path))}")

  return len(path)

def part1():
  adjacencyList = createAL()
  keys = lettersInMap(adjacencyList)
  total = 0

  for key in sorted(set(keys)):

    pathMap = bfs("COM", key, createAL())

    if not pathMap == False:
      total += getPathLength(key,"COM", pathMap)

  return total


def part2():
  pathMap = bfs("SAN", "YOU", createAL())

  total = getPathLength("YOU", "SAN", pathMap) - 2

  return total
  

print(part1())
