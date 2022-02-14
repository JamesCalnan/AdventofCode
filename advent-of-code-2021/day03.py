def parse_input():
    file = open("input.txt", "r").read().split("\n")
    return file

def part1():
    p_input = parse_input()

    averages = []
    for i in range(len(p_input[0])):
        bits = [int(x[i]) for x in p_input]
        averages.append(sum(bits) / len(bits))

    gamma = int(''.join(['1' if x > .5 else '0' for x in averages]), 2)
    epsilon = int(''.join(['1' if x < .5 else '0' for x in averages]), 2)

    return gamma * epsilon


def part2_operation(p_input, oxygen=True):
    available_numbers = p_input.copy()

    while len(available_numbers) != 1:
        for i in range(len(p_input[0])):
            if len(available_numbers) <= 1: break
            bits = [int(x[i]) for x in available_numbers]
            average = (sum(bits) / len(bits))

            if oxygen:
                desired_bit = 1 if average >= .5 else 0
            else:
                desired_bit = 1 if average < .5 else 0

            available_numbers = [b for b in available_numbers if int(b[i]) == desired_bit]

    return int(available_numbers[0], 2)


def part2():
    p_input = parse_input()
    return part2_operation(p_input) * part2_operation(p_input, False)
