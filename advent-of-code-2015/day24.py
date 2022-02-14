from itertools import combinations
from operator import mul
from functools import reduce

weights = [int(l) for l in open("file.txt")]


def findLowest(c):
  ds = sum(weights) / c
  for size in range(len(weights)):
    for comb in combinations(weights, size):
      if sum(comb) == ds:
        return reduce(mul, comb)

for c in [3, 4]:
  print(c, findLowest(c))