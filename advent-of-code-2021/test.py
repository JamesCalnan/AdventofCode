from rich.console import Console
import heapq

c = Console()


def parse_input():
    data = open("test_input.txt", "r").read().split("\n")
    
    positional_map = {}
    
    for y, line in enumerate(data):
        for x, item in enumerate(line):
            positional_map[(x, y)] = int(item)

    return positional_map  

pos_map = parse_input()

#init

Q = []
for k in pos_map.keys():
    Q.append((k, 99999))



c.print(pos_map)
input()

heapq.heapify(Q)

c.print(Q)