def solve(final = 2020):
  puzzle_input = [1,0,16,5,17,4]
  last_seen = [0] * final

  for i, num in enumerate(puzzle_input[:-1], 1):
    last_seen[num] = i
  
  previous_number = puzzle_input[-1]

  for i in range(len(puzzle_input), final):
    current_num = i - last_seen[previous_number]

    if current_num == i:
      current_num = 0
    
    last_seen[previous_number] = i

    previous_number = current_num

  return previous_number
#0.00009 seconds for p1
#6 seconds for p2