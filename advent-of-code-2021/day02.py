def parse_input():
    return [(x.split(" ")[0], int(x.split(" ")[1])) for x in open("input.txt", "r").read().split("\n")]


def part1():
    puzzle_input = parse_input()
    horizontal, depth = 0, 0

    for instruction in puzzle_input:
        if instruction[0][0] == "f":
            horizontal += instruction[1]
        elif instruction[0][0] == "d":
            depth += instruction[1]
        elif instruction[0][0] == "u":
            depth -= instruction[1]

    return horizontal * depth


def part2():
    puzzle_input = parse_input()
    horizontal, depth, aim = 0, 0, 0

    for instruction in puzzle_input:
        if instruction[0][0] == "f":
            horizontal += instruction[1]
            depth += aim * instruction[1]
        elif instruction[0][0] == "d":
            aim += instruction[1]
        elif instruction[0][0] == "u":
            aim -= instruction[1]

    return horizontal * depth
