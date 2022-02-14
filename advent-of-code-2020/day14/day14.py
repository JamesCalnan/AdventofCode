import itertools
p1, p2 = "day14/part 1 test.txt", "day14/part 2 test.txt"

def binary_to_decimal(mask):
  re_str = ""
  for l in mask:
    if l == "X":
      re_str += "0"
    else:
      re_str += l

  return int(re_str, 2)

def apply_to_mask(mask, val):
  re_val = ""
  for i, l in enumerate(mask):
    if l == "X":
      re_val += val[i]
    else:
      re_val += l

  return re_val

def decimal_to_binary(deci):
  return format(int(deci), '036b')
  
def split_things(thing):
  groups = []
  for i, group in enumerate(thing):
    if group[0] == "":
      continue
   
    mask = group[0].split(" ")[-1]
    instr = []

    in_gro = group[1:]

    if group[-1] != "":
      in_gro = group[1:]
    else:
      in_gro = group[1:][:-1]

    for sub_group in in_gro:
      split_group = sub_group.split(" = ")
      mem = split_group[0]
      
      val = int(split_group[1])  

      instr.append((mem, val))

    groups.append((mask, instr))

  return groups

def part1():
  file = [thing.split("\n") for thing in open(p1).read().split("mask")]
  puzzle_input = split_things(file)
  memory_addresses = {}

  for group in puzzle_input:
    mask, values = group    
    for value in values:
      k, v = value

      memory_addresses[k] = binary_to_decimal(apply_to_mask(mask, decimal_to_binary(v)))

  return sum(memory_addresses.values())

def process_key(k):
  return int(k.split("[")[1][:-1])

def apply_to_mask_p2(mask, val):
  re_val = ""
  for i, l in enumerate(mask):
    if l == "X":
      re_val += "X"
    elif l == "0":
      re_val += val[i]
    elif l == "1":
      re_val += "1"

  return re_val

def part2():
  file = [thing.split("\n") for thing in open(p2).read().split("mask")]

  puzzle_input = split_things(file)

  memory_addresses = {}

  for group in puzzle_input:
    mask, values = group    
    for value in values:
      k, v = value

      k = process_key(k)

      result = apply_to_mask_p2(mask, decimal_to_binary(k))

      perms = list(itertools.product("01", repeat=result.count("X")))

      potential_mem_addr = []

      for perm in perms:
        new_addr = [l for l in result]
        for replacement in perm:
          
          replacement_index = new_addr.index("X")
          new_addr[replacement_index] = replacement

        potential_mem_addr.append("".join(new_addr))

      for thing in potential_mem_addr:
        memory_addresses[binary_to_decimal(thing)] = v

  return sum(memory_addresses.values())