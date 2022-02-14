translation_map = {'F': 0, 'B': 1, 'L': 0, 'R': 1}

def compute_seat_number(seat_code):
  for k, v in translation_map.items():
    seat_code = seat_code.replace(k, str(v))
  
  return int(seat_code, 2)
  
def part1():
  return max([compute_seat_number(seat_code) for seat_code in [line.strip() for line in open("file.txt")]])
  
def part2():
  results = [compute_seat_number(seat_code) for seat_code in [line.strip() for line in open("file.txt")]]
    
  for i in range(max(results)):
    if i not in results:
      if i - 1 in results and i + 1 in results:
        return i