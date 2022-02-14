def initialiseDictionary():
  return {chr(i + ord("a")) : i+1 for i in range(26)}

doubles = [chr(i + ord("a"))*2 for i in range(26)]

def validPassword(pwd, isPart1 = True):
  if not isPart1 and pwd == "vzbxxyzz":
    return False
  if "i" in pwd or "o" in pwd or "l" in pwd:
    return False

  if sum([d in pwd for d in doubles]) < 2:
    return False
  
  bad = False
  for i in range(len(pwd)-2):
    if ord(pwd[i]) == ord(pwd[i+1]) - 1 == ord(pwd[i+2]) - 2:
      bad = True

  return bad

def increment(position, letterValues, password):
  letterAtPosition = password[position]

  numericalEquivalent = letterValues[letterAtPosition]

  if numericalEquivalent == 26:
    numericalEquivalent = 1

    newValue = chr(int(numericalEquivalent) - 1 + int(ord("a")))

    password[position] = newValue
    return increment(position-1, letterValues, password)
  else:
    numericalEquivalent += 1
    
    newValue = chr(int(numericalEquivalent) - 1 + int(ord("a")))
    password[position] = newValue

  return password

def part1():
  letterValues = initialiseDictionary()

  password = [l for l in "vzbxkghb"]

  while validPassword("".join(password)) == False:
    password = increment(len(password)-1, letterValues, password)

  return "".join(password)

def part2():
  letterValues = initialiseDictionary()

  password = [l for l in "vzbxkghb"]

  while validPassword("".join(password), False) == False:
    password = increment(len(password)-1, letterValues, password)

  return "".join(password)