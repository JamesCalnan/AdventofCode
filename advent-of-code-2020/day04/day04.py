def parse(data):
  return dict(field.split(':') for field in data.split())

def passportComplete(passport):
  return all(f in passport for f in ['byr', 'iyr', 'eyr', 'hgt', 'hcl', 'ecl', 'pid'])

def passportValid(passport):
  return passportComplete(passport) and all(fieldValid(*field) for field in passport.items())

def fieldValid(field, value):
  if field == 'byr':
    return len(value) == 4 and value.isdigit() and 1920 <= int(value) <= 2002

  if field == 'iyr':
    return len(value) == 4 and value.isdigit() and 2010 <= int(value) <= 2020

  if field == 'eyr':
    return len(value) == 4 and value.isdigit() and 2020 <= int(value) <= 2030

  if field == 'hgt':
    if value.endswith('cm'):
        number = value[:-2]
        return number.isdigit() and 150 <= int(number) <= 193

    if value.endswith('in'):
        number = value[:-2]
        return number.isdigit() and 59 <= int(number) <= 76

    return False

  if field == 'hcl':
    return len(value) == 7 \
        and value[0] == '#' \
        and all(c in "0123456789abcdef" for c in value[1:])

  if field == 'ecl':
    return value in ['amb', 'blu', 'brn', 'gry', 'grn', 'hzl', 'oth']

  if field == 'pid':
    return len(value) == 9 and value.isdigit()

  return True

passports = [parse(fields) for fields in open("file.txt").read().split('\n\n')]

def part1():
  return sum(passportComplete(p) for p in passports)

def part2():
  return sum(passportValid(p) for p in passports)

print(part1())
print(part2())