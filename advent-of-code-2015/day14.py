class Reindeer():
  def __init__(self, name, speed, flightTime, rest):
    self.name = name
    self.speed = speed
    self.flightTime = flightTime
    self.rest = rest
  
  def distance(self, inputTime):
    cycleTime = self.flightTime + self.rest

    cycles, r = divmod(inputTime, cycleTime)

    dist = cycles * self.speed * self.flightTime

    if r > self.flightTime:
      dist += self.speed * self.flightTime
    else:
      dist += r * self.speed

    return dist


def processInput():

  barn = []
  for line in open("file.txt", "r"):
    splitLine = line.split(" ")
    name = splitLine[0]
    speed = int(splitLine[3])
    timeFlying = int(splitLine[6])
    rest = int(splitLine[-2])

    barn.append(Reindeer(name,speed,timeFlying,rest))

  return barn

def part1():
  barn = processInput()

  return max([Reindeer.distance(2503) for Reindeer in barn])

def part2():
  barn = processInput()

  for reindeer in barn:
    reindeer.points = 0
  
  for time in range(1, 2504):
    dist = [reindeer.distance(time) for reindeer in barn]
    maxDist = max(dist)
    for i, reindeer in enumerate(barn):
      if dist[i] == maxDist:
        reindeer.points += 1
  
  return max([reindeer.points for reindeer in barn])
    


print(part2())

#Vixen can fly 8 km/s for 8 seconds, but then must rest for 53 seconds.