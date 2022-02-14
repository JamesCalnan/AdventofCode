class Wire(object):

    def __init__(self, line):
        self._line = line
        self.parseLine(line)

    def parseLine(self, line):
        lline = line.split()
        self.output = lline[-1]

        left = lline[:-2]
        self.op = 'ASSIGN'
        for op in ['NOT', 'AND', 'OR', 'LSHIFT', 'RSHIFT']:
            if op in left:
                self.op = op
                left.remove(op)
        self.inputs = [int(i) if i.isdigit() else i for i in left]

    def reset(self):
        self.parseLine(self._line)

    def evaluate(self):
        if self.op == 'ASSIGN':
            return int(self.inputs[0])
        elif self.op == 'NOT':
            return int(65535 - self.inputs[0])
        elif self.op == 'AND':
            return int(self.inputs[0] & self.inputs[1])
        elif self.op == 'OR':
            return int(self.inputs[0] | self.inputs[1])
        elif self.op == 'LSHIFT':
            return int(self.inputs[0] << self.inputs[1])
        elif self.op == 'RSHIFT':
            return int(self.inputs[0] >> self.inputs[1])
        else:
            raise ValueError('invalid operator')

    def fillInputs(self, signals):
        self.inputs = [signals[i] if i in signals else i for i in self.inputs]

    def isComplete(self):
        return all([isinstance(i, int) for i in self.inputs])


with open('file.txt') as f:
    wires = [Wire(line) for line in f]


def evaluateCircuit(wires, signals):
    localWires = list(wires)
    while len(localWires) != 0:
        newWires = []
        for wire in wires:
            if wire.isComplete():
                signals[wire.output] = wire.evaluate()
            else:
                wire.fillInputs(signals)
                newWires.append(wire)
        localWires = newWires
    return signals


signals = evaluateCircuit(wires, {})
print('a', signals['a'])

[wire.reset() for wire in wires]
wires = [wire for wire in wires if wire.output != 'b']
signals = evaluateCircuit(wires, {'b': signals['a']})
print('a', signals['a'])