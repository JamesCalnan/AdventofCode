from rich.console import Console
c = Console()


def parse_input() -> list[list[tuple]]:
    return [
        [tuple(x.split(",")) for x in line.split(" -> ")]
        for line in open("test_input.txt", "r").read().split("\n")
    ]

def part1():
    puzzle = parse_input()
    
    all_points = {} #position : times_visited
    
    for p in puzzle:
        c.print(p)
        x1, y1 = int(p[0][0]), int(p[0][1])
        x2, y2 = int(p[1][0]), int(p[1][1])
        
        if x1 > x2:
            x1, x2 = x2, x1
        if y1 > y2:
            y1, y2 = y2, y1
        
        for x in range(x1, x2 + 1):
            for y in range(y1, y2 + 1):
                if (x, y) not in all_points:
                    all_points[(x, y)] = 0
                all_points[(x, y)] += 1
        
    c.print(all_points)

part1()