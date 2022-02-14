def solve(final = 2020):
  puzzle_input = [1,0,16,5,17,4]
  turn_num = {l : [] for l in puzzle_input}

  for i, num in enumerate(puzzle_input):
    turn_num[num] = [i + 1]
  
  previous_number = puzzle_input[-1]

  for i in range(len(puzzle_input) + 1, final + 1):
    if len(turn_num[previous_number]) == 1:
      previous_number = 0

    else:
      new = turn_num[previous_number][-1] - turn_num[previous_number][-2]

      turn_num[previous_number] = turn_num[previous_number][-2:]

      previous_number = new
    
    turn_num[previous_number] = turn_num[previous_number] + [i] if previous_number in turn_num else [i]

  return previous_number

#0.002 p1
#55 seconds p2