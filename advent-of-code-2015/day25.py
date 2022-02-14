"""
this can be fixed by just not having a dictionary and just 
storing the previous value to compute the next value 
and then checking to see if the row/col match the goal
"""
def computeCode(previousValue):
  newValue = previousValue * 252533

  return newValue % 33554393


row, col = 2981, 3075

positions = {}

firstCode = 20151125

positions[(1,1)] = firstCode

currentColumn = 1
currentRow = 2

previousResult = firstCode

i = 0

while (row,col) not in positions:
  tempCol = 1
  tempRow = currentRow

  while tempRow > 0:
    newValue = computeCode(previousResult)

    positions[(tempRow, tempCol)] = newValue

    previousResult = newValue

    tempRow -= 1
    tempCol += 1

    i += 1

  
  currentRow += 1

print(i)
print(positions[(row,col)])
input()