"""
Python program that uses Breadth-first and Depth-first search
to solve day 12 of advent of code 2017
"""
#https://en.wikipedia.org/wiki/Adjacency_list
def createAL():
  file = open("file.txt")
  adjacencyList = {}

  for line in file:
    processedLine = line.replace(" ", "").replace("\n","").split("<->")
    key = processedLine[0]
    value = processedLine[1].split(",")
    adjacencyList[key] = value

  return adjacencyList

#https://en.wikipedia.org/wiki/Depth-first_search
#uses a stack data structure which is a FILO (first in last out), meaning that values are taken from the stack from the end of the stack
def dfs(root, adjacencyList):
  S = [] #make an empty list
  discovered = {key : False for key in adjacencyList.keys()} #make a dictionary where the key is the adjacency list keys and the value is false because we havent visited the node yet

  S.append(root) #add the root node to the list

  while len(S) > 0: #loop while there is items in the stack
    v = S.pop() #get the value from the end of the stack and set v equal to it

    if v == "0": #if v equals 0 then we have reached the goal and can return true
      return True
      
    if not discovered[v]: #if the node hasnt been visited yet then
      discovered[v] = True #set the current node to be visited
      for w in adjacencyList[v]: #this is using the adjacency list to find the adjacent/connected nodes to the current node (v)
        S.append(w) #add the adjancent node to the end of the stack/list
  return False


#https://en.wikipedia.org/wiki/Breadth-first_search
#uses a Queue data structure meaning that the first thing in is the first out, also known as FIFO (first in first out)
def bfs(root, adjacencyList):
  Q = [] #make an empty list

  discovered = {key : False for key in adjacencyList.keys()} #make a dictionary where the key is the adjacency list keys and the value is false because we havent visited the node yet
  
  discovered[root] = True #set the root/starting node to be discovered cus we start there
  Q.append(root) #add the root node to the list

  while len(Q) > 0: #while there is still items in the list/queue
    v = Q.pop(0) #take the value at the from of the list, remove it from the list and set v equal to it

    if v == "0": #if v equals 0 then we have reached the goal and can return true
      return True

    for w in adjacencyList[v]: #this is using the adjacency list to find the adjacent/connected nodes to the current node (v)
      if not discovered[w]: #if we havent visited the node yet
        discovered[w] = True #set the node to be visited
        Q.append(w) #add the node to the end of the list
  return False

#https://adventofcode.com/2017/day/12
def part1():
  al = createAL()

  count = 0

  for key in al.keys():
    if dfs(key, al):
      count += 1
    #input()
  return count

print(part1())
