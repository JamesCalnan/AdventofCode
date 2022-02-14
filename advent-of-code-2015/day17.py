def processInput():
  return [int(i.strip()) for i in open("file.txt")]

containers = [20, 15, 10, 5, 5]

#need to store 25 litres

"""
input: 25 litres
what is the max i can put in the first container
in this case it is 20
  remaining litres is 5

  container 1 is full so go to container 2
  all i have left is 5




"""

def computeTotal(containers, goal, remainingTotal=0):
  if len(containers) == 0:
    return 0

  
  firstContainer = containers[0]
  remaining = containers[1:]

  if firstContainer > goal:
    remainingTotal = 0

  elif firstContainer == goal:
    #sizes.append(remainingTotal + 1)
    remainingTotal = 1
  else:
    remainingTotal = computeTotal(remaining, goal - firstContainer)

  return remainingTotal + computeTotal(remaining, goal)

print(computeTotal(processInput(), 150))

def sum_to(containers, goal, values_in_goal=0):
    """
    Find all sets of containers which sum to goal, store the number of
    containers used to reach the goal in the sizes variable.
    """
    if len(containers) == 0:
        return 0

    first = containers[0]
    remain = containers[1:]

    if first > goal:
        with_first = 0
    elif first == goal:
        sizes.append(values_in_goal + 1)
        with_first = 1
    else:
        with_first = sum_to(remain, goal-first, values_in_goal + 1)

    return with_first + sum_to(remain, goal, values_in_goal)

sizes = []
containers = processInput()
print(sum_to(containers, 150))
print(sum(min(sizes) == size for size in sizes))