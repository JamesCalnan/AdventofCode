def part1():
    file = [int(x) for x in open("input.txt", "r").read().split("\n")]
    return len([x for x in range(len(file)) if file[x] > file[x - 1]])


def part2():
    file = [int(x) for x in open("input.txt", "r").read().split("\n")]
    return len([x for x in range(len(file)) if sum(file[x:x+3]) < sum(file[x+1:x+4])])