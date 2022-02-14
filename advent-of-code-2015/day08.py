from __future__ import print_function
import re

def sizeInMemory(string):
    assert string[0] == '"'
    assert string[-1] == '"'
    inMemory = string[1:-1]
    inMemory = inMemory.replace("\\\\", "x")
    inMemory = inMemory.replace("\\\"", "x")
    inMemory, _ = re.subn('\\\\x..', 'x', inMemory)
    return len(inMemory)


def sizeEscaped(string):
    escaped = string
    escaped = escaped.replace("\\", "\\\\")
    escaped = escaped.replace('"', '\\"')
    escaped = '"' + escaped + '"'
    return len(escaped)


f = open('file.txt')

totalCharsCode = 0
totalCharsMemory = 0
totalCharsEscaped = 0

for line in f:
    line = line.strip()

    chars = len(line)
    inMemory = sizeInMemory(line)
    escaped = sizeEscaped(line)

    totalCharsCode += len(line)
    totalCharsMemory += sizeInMemory(line)
    totalCharsEscaped += escaped


print(totalCharsCode - totalCharsMemory)
print(totalCharsEscaped - totalCharsCode)