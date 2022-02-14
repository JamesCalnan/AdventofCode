def process_input():
  return_map = {}

  for line in open("day07/file.txt", "r"):
    [outer, inner] = line.strip().split(' contain ')
    outer = outer.replace(' bags', '')
    inner = inner.strip('.').split(', ')
    return_map[outer] = [col.replace(' bags', '').replace(' bag', '') for col in inner]

  return return_map

def check1(ruledict, col):
  count = 0
  for rule in list(ruledict):
    print(f"rule: {rule}")
    input()
    if any(col in bag for bag in ruledict[rule]) and not any('flag' in bag for bag in ruledict[rule]):
      print("here")
      ruledict[rule].append('flag')
      count += 1 + check1(ruledict, rule)
  return count        

def check2(ruledict, col):
  count = 0
  for bag in ruledict[col]:
    if bag != "no other":
      count += int(bag[0]) * (1 + check2(ruledict, bag[2:]))
  return count           

def part1():
  return check1(process_input(), 'shiny gold')

def part2():
  return check2(process_input(), 'shiny gold')

