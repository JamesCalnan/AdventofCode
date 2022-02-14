import json

# read file
with open('file.txt', 'r') as f:
  data=json.load(f)

# parse file


def goIntoFile(data):
  if isinstance(data, list):
    return sum([goIntoFile(i) for i in data])
    
  if isinstance(data, dict):
    return sum(goIntoFile(i) for i in data.values())

  if isinstance(data, int):
    return data

  return 0

def goIntoFilep2(data):

  if isinstance(data, list):
    return sum([goIntoFilep2(i) for i in data])
    
  if isinstance(data, dict):
    if "red" in data.values():
      return 0

    return sum(goIntoFilep2(i) for i in data.values())

  if isinstance(data, int):
    return data

  return 0



final = goIntoFile(data)

print(goIntoFile(data) == 119433)
print(goIntoFilep2(data) == 68466)