class INSRUCTION():
  
  def __init__(self, command, register=None, offset=None):
    self.command = command
    self.register = None
    self.offset = None
    if register != None:
      self.register = register
    if offset != None:
      self.offset = int(offset)

def processInput():
  lines = []

  registers = set()

  for line in open("file1.txt"):
    splitLine = line.strip().split(" ")

    command = splitLine[0]

    register = splitLine[1][0]
    
    offset = None
    
    if command in ["jio", "jie"]:
      offset = int(splitLine[2])

    if command == "jmp":
      offset = int(splitLine[1])
      register = None
      
    thing = INSRUCTION(command, register, offset)
    
    if not register == None:
      registers.add(register)
    
    lines.append(thing)
    
    

  return lines, {r: 0 for r in registers}



def solve(part1=True):
  instructions, registers = processInput()

  if not part1:
    registers["a"] = 1

  i = 0

  while i < len(instructions):
    currentInstruction = instructions[i]

    command = currentInstruction.command
    
    currentRegister = currentInstruction.register

    if command == "hlf":
      registers[currentRegister] = int(registers[currentRegister] / 2)
      i += 1
    elif command == "tpl":
      registers[currentRegister] *= 3
      i += 1
    elif command == "inc":
      registers[currentRegister] += 1
      i += 1
    elif command == "jmp":
      i += currentInstruction.offset
    elif command == "jie":
      if registers[currentRegister] % 2 == 0:
        i += currentInstruction.offset
      else:
        i += 1
    elif command == "jio":
      if registers[currentRegister] == 1:
        i += currentInstruction.offset
      else:
        i += 1

  return registers["b"]


print(solve(False))