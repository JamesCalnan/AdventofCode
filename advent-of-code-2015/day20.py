import numpy as np

bignum = 1000000

goal = 33100000
houses_a = np.zeros(bignum)
houses_b = np.zeros(bignum)

for elf in range(1, bignum):
    houses_a[elf::elf] += 10 * elf
    houses_b[elf:(elf+1)*50:elf] += 11 * elf

print(np.nonzero(houses_a >= goal)[0][0])

print(np.nonzero(houses_b >= goal)[0][0])