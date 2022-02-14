def process_input():
  return [line.strip().split(" ") for line in open("day08/file.txt", "r")]

def part1(input_code):
  i, accumulator, previous_locations = 0, 0, [0]

  while True:
    instruction, amount = input_code[i]

    if instruction == "acc":
      accumulator += int(amount)
      i += 1
    elif instruction == "jmp":
      i += int(amount)
    elif instruction == "nop":
      i += 1

    if i in previous_locations:
      return accumulator, False
    elif i >= len(input_code):
      return accumulator, True

    previous_locations.append(i) 

def part2():
  for index in [i for i, x in enumerate(process_input()) if x[0] == "nop"]:
    copy_input = [item for item in process_input()]
    
    copy_input[index][0] = "jmp"
    
    accu, terminated = part1(copy_input)

    if terminated:
      return accu
  
  for index in [i for i, x in enumerate(process_input()) if x[0] == "jmp"]:
    copy_input = [item for item in process_input()]

    copy_input[index][0] = "nop"

    accu, terminated = part1(copy_input)

    if terminated:
      return accu

print(part2())