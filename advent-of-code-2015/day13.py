from itertools import permutations

def processInput():
  people = []

  keyPairvalues = {}

  for line in open("file.txt","r"):
    splitLine = line.replace(".","").strip().split(" ")
    firstPerson = splitLine[0]
    secondperson = splitLine[-1]

    positiveHappiness = 1 if splitLine[2] == "gain" else -1

    sortedTuple = tuple([firstPerson, secondperson])

    keyPairvalues[sortedTuple] = int(splitLine[3]) * positiveHappiness
    people.extend([firstPerson, secondperson])

  return keyPairvalues, list(set(people))

def part1():
  keyPairValues, people = processInput()
  possibleCombos = list(permutations(people)) 
  happiness = 0

  for combo in possibleCombos:
    total = 0

    for i in range(len(combo)-1):
      total += keyPairValues[tuple([combo[i], combo[i+1]])]
      total += keyPairValues[tuple([combo[i+1], combo[i]])]

    total += keyPairValues[tuple([combo[0], combo[-1]])]
    total += keyPairValues[tuple([combo[-1], combo[0]])]

    happiness = max(total, happiness)

  return happiness

def part2():
  keyPairValues, people = processInput()
  happiness = 0

  for person in people:
    keyPairValues[tuple(["James", person])] = 0
    keyPairValues[tuple([person, "James"])] = 0

  people.append("James")

  possibleCombos = list(permutations(people)) 

  for combo in possibleCombos:
    total = 0

    for i in range(len(combo)-1):
      total += keyPairValues[tuple([combo[i], combo[i+1]])]
      total += keyPairValues[tuple([combo[i+1], combo[i]])]

    total += keyPairValues[tuple([combo[0], combo[-1]])]
    total += keyPairValues[tuple([combo[-1], combo[0]])]

    happiness = max(total, happiness)

  return happiness

print(part2())