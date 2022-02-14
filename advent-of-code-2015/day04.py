import hashlib 
  
str2hash = "bgvyzdsv"

def part1():
  for i in range(0, 1000000):
    m = hashlib.md5()
    m.update((str2hash + str(i)).encode())
    
    if str(m.hexdigest()).startswith("00000"):
      return i

def part2():
  for i in range(0, 10000000):
    m = hashlib.md5()
    m.update((str2hash + str(i)).encode())

    if str(m.hexdigest()).startswith("000000"):
      return i