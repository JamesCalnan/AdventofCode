from rich.console import Console

c = Console()

def parse_input():
    data = open("input.txt", "r").read().split("\n")
    
    positional_map = {}
    
    for y, line in enumerate(data):
        for x, item in enumerate(line):
            positional_map[(x, y)] = item

    return positional_map    

def get_min(Q, dist):

    cheapest_index = 0
    cheapest_pos = Q[0]
    for i, pos in enumerate(Q):
        if dist[pos] <= dist[cheapest_pos]:
            cheapest_index = i
            cheapest_pos = pos

    return Q[cheapest_index]
    

def get_neighbours(Q, u):
    potential_positions = [(u[0] + 1, u[1]),
                           (u[0] - 1, u[1]),
                           (u[0], u[1] - 1),
                           (u[0], u[1] + 1)]
    
    confirmed_positions = []
    
    for position in potential_positions:
        if position in Q:
            confirmed_positions.append(position)
    
    return confirmed_positions


def part1():
    INFINITY = 9999999
    pos_map = parse_input()
    
    dist = {}
    prev = {}
    Q = []
    
    source = list(pos_map.keys())[0]
    goal = list(pos_map.keys())[-1]
    
    for vertex in pos_map.keys():
        dist[vertex] = INFINITY
        prev[vertex] = None
        Q.append(vertex)
    
    
    dist[source] = int(pos_map[source])
    
    while len(Q) > 0:
        u = get_min(Q, dist)

        Q.remove(u)

        if u == goal:
            S = [goal]
            u = goal
            while u is not None:
                u = prev[u]
                S.append(u)

            return sum([int(pos_map[pos]) for pos in S[:-2] if pos is not None])
            #' -> '.join([pos_map[pos] for pos in S[::-1] + [goal]])

        for v in get_neighbours(Q, u):
            alt = dist[u] + int(pos_map[u])
            if alt < dist[v]:
                dist[v] = alt
                prev[v] = u

    return "[red]failure"
        
    


c.print(part1())    