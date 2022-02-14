from __future__ import print_function
import numpy as np
class ingredient():

  def __init__(self, name, capacity, durability, flavour, texture):
    self.name = name
    self.capacity = capacity
    self.durability = durability
    self.flavour = flavour
    self.texture = texture

  def computeAmount(self, n):
    return self.capacity * n + self.durability * n + self.flavour * n + self.texture * n

  def anyDonuts(self):
    return True if self.capacity < 0 or self.durability < 0 or self.flavour < 0 or self.texture < 0 else False

def processInput():
  ingredients = []

  for line in open("file1.txt", "r"):
    splitLine = line.split(" ")

    name = splitLine[0].replace(":", "")
    capacity = int(splitLine[2].replace(",",""))
    durability = int(splitLine[4].replace(",",""))
    flavour = int(splitLine[6].replace(",",""))
    texture = int(splitLine[8].replace(",",""))

    ingredients.append(ingredient(name, capacity, durability, flavour, texture))

  return ingredients

def part1():
  ingredients = processInput()

  maxScore = 0
  positives = []
  for ingredient1 in ingredients:
    for ingredient2 in ingredients:
      if ingredient1.name == ingredient2.name:
        continue
      for i1 in range(101):
        for i2 in range(0, 101-i1):

          capacity = i1 * ingredient1.capacity + i2 * ingredient2.capacity

          durability = i1 * ingredient1.durability + i2 * ingredient2.durability

          flavour = i1 * ingredient1.flavour + i2 * ingredient2.flavour

          texture = i1 * ingredient1.texture + i2 * ingredient2.texture

          #print(f"{i1} * {ingredient1.capacity} + {i2} * {ingredient2.capacity}")
          #print(f"{i1} * {ingredient1.durability} + {i2} * {ingredient2.durability}")
          #print(f"{i1} * {ingredient1.flavour} + {i2} * {ingredient2.flavour}")
          #print(f"{i1} * {ingredient1.texture} + {i2} * {ingredient2.texture}")
          #input()

          capacity = max(0,capacity)
          durability = max(0, durability)
          flavour = max(0, flavour)
          texture = max(0, texture)

          result = capacity * durability * flavour * texture
          if result > 0:
            positives.append(result)

          maxScore = max(maxScore, result)

  print(positives)
  return maxScore



c0prop = np.array([5, -1,  0, 0, 5])  # Frosting
c1prop = np.array([-1,  3, 0, 0, 1])  # Candy
c2prop = np.array([0, -1,  4, 0, 6])  # Butterscotch
c3prop = np.array([-1,  0, 0, 2, 8])  # Sugar

max_score = 0
max_500_score = 0
for c0 in range(101):
    for c1 in range(0, 101-c0):
        remain = 100 - c0 - c1
        c2 = np.arange(remain + 1)
        c3 = remain - c2

        sums_of_prop = (c0*c0prop + c1*c1prop +
                        np.outer(c2, c2prop) + np.outer(c3, c3prop))
        calories = sums_of_prop[:, -1]
        sums_of_prop = sums_of_prop[:, :-1]  # remove calories
        sums_of_prop[sums_of_prop < 0] = 0   # replace negatives with zeros

        max_score = max(np.prod(sums_of_prop, axis=1).max(), max_score)

        # part B, find all the cookies with 500 calories
        cal_500_prop = sums_of_prop[calories == 500]
        if len(cal_500_prop) == 0:
            continue
        max_500_score = max(np.prod(cal_500_prop, axis=1).max(), max_500_score)

print(max_score)
print(max_500_score)
print(part1())