Imports System.Linq
Module Amplification_Circuit
    Function intcodeComputer(data() As Integer, inputValue() As Integer)
        Dim instructions() As Integer = data '{3, 225, 1, 225, 6, 6, 1100, 1, 238, 225, 104, 0, 1101, 37, 61, 225, 101, 34, 121, 224, 1001, 224, -49, 224, 4, 224, 102, 8, 223, 223, 1001, 224, 6, 224, 1, 224, 223, 223, 1101, 67, 29, 225, 1, 14, 65, 224, 101, -124, 224, 224, 4, 224, 1002, 223, 8, 223, 101, 5, 224, 224, 1, 224, 223, 223, 1102, 63, 20, 225, 1102, 27, 15, 225, 1102, 18, 79, 224, 101, -1422, 224, 224, 4, 224, 102, 8, 223, 223, 1001, 224, 1, 224, 1, 223, 224, 223, 1102, 20, 44, 225, 1001, 69, 5, 224, 101, -32, 224, 224, 4, 224, 1002, 223, 8, 223, 101, 1, 224, 224, 1, 223, 224, 223, 1102, 15, 10, 225, 1101, 6, 70, 225, 102, 86, 40, 224, 101, -2494, 224, 224, 4, 224, 1002, 223, 8, 223, 101, 6, 224, 224, 1, 223, 224, 223, 1102, 25, 15, 225, 1101, 40, 67, 224, 1001, 224, -107, 224, 4, 224, 102, 8, 223, 223, 101, 1, 224, 224, 1, 223, 224, 223, 2, 126, 95, 224, 101, -1400, 224, 224, 4, 224, 1002, 223, 8, 223, 1001, 224, 3, 224, 1, 223, 224, 223, 1002, 151, 84, 224, 101, -2100, 224, 224, 4, 224, 102, 8, 223, 223, 101, 6, 224, 224, 1, 224, 223, 223, 4, 223, 99, 0, 0, 0, 677, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1105, 0, 99999, 1105, 227, 247, 1105, 1, 99999, 1005, 227, 99999, 1005, 0, 256, 1105, 1, 99999, 1106, 227, 99999, 1106, 0, 265, 1105, 1, 99999, 1006, 0, 99999, 1006, 227, 274, 1105, 1, 99999, 1105, 1, 280, 1105, 1, 99999, 1, 225, 225, 225, 1101, 294, 0, 0, 105, 1, 0, 1105, 1, 99999, 1106, 0, 300, 1105, 1, 99999, 1, 225, 225, 225, 1101, 314, 0, 0, 106, 0, 0, 1105, 1, 99999, 108, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 329, 101, 1, 223, 223, 1107, 677, 226, 224, 102, 2, 223, 223, 1006, 224, 344, 101, 1, 223, 223, 8, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 359, 101, 1, 223, 223, 1008, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 374, 101, 1, 223, 223, 7, 226, 677, 224, 1002, 223, 2, 223, 1006, 224, 389, 1001, 223, 1, 223, 1007, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 404, 1001, 223, 1, 223, 7, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 419, 1001, 223, 1, 223, 1008, 677, 226, 224, 1002, 223, 2, 223, 1005, 224, 434, 1001, 223, 1, 223, 1107, 226, 677, 224, 102, 2, 223, 223, 1005, 224, 449, 1001, 223, 1, 223, 1008, 226, 226, 224, 1002, 223, 2, 223, 1006, 224, 464, 1001, 223, 1, 223, 1108, 677, 677, 224, 102, 2, 223, 223, 1006, 224, 479, 101, 1, 223, 223, 1108, 226, 677, 224, 1002, 223, 2, 223, 1006, 224, 494, 1001, 223, 1, 223, 107, 226, 226, 224, 1002, 223, 2, 223, 1006, 224, 509, 1001, 223, 1, 223, 8, 226, 677, 224, 102, 2, 223, 223, 1006, 224, 524, 1001, 223, 1, 223, 1007, 226, 226, 224, 1002, 223, 2, 223, 1006, 224, 539, 1001, 223, 1, 223, 107, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 554, 1001, 223, 1, 223, 1107, 226, 226, 224, 102, 2, 223, 223, 1005, 224, 569, 101, 1, 223, 223, 1108, 677, 226, 224, 1002, 223, 2, 223, 1006, 224, 584, 1001, 223, 1, 223, 1007, 677, 226, 224, 1002, 223, 2, 223, 1005, 224, 599, 101, 1, 223, 223, 107, 226, 677, 224, 102, 2, 223, 223, 1005, 224, 614, 1001, 223, 1, 223, 108, 226, 226, 224, 1002, 223, 2, 223, 1005, 224, 629, 101, 1, 223, 223, 7, 677, 226, 224, 102, 2, 223, 223, 1005, 224, 644, 101, 1, 223, 223, 8, 677, 226, 224, 102, 2, 223, 223, 1006, 224, 659, 1001, 223, 1, 223, 108, 677, 226, 224, 102, 2, 223, 223, 1005, 224, 674, 1001, 223, 1, 223, 4, 223, 99, 226}
        Dim i = 0
        Dim output = -1
        Dim input_ = 0
        While 1
            Dim instructionInput = instructions(i)
            If instructionInput = 99 Then Return output
            Dim parseInstruction As New List(Of Integer) '= (From thing In instructions(i).ToString() Select Int(thing.ToString())).Cast(Of Integer)().ToList()
            For Each thing In instructionInput.ToString()
                parseInstruction.Add(Int(thing.ToString()))
            Next
            parseInstruction.Reverse()
            Dim opcode = parseInstruction(0)
            Dim mode As New List(Of Integer)
            If parseInstruction.Count > 2 Then
                mode.AddRange(parseInstruction.GetRange(2, parseInstruction.Count - 2))
            End If
            While mode.Count < 3
                mode.Add(0)
            End While
            If opcode = 1 Then
                instructions(If(mode(2) = 1, i + 3, instructions(i + 3))) = instructions(If(mode(0) = 1, i + 1, instructions(i + 1))) + instructions(If(mode(1) = 1, i + 2, instructions(i + 2)))
                i += 4
            ElseIf opcode = 2 Then
                instructions(If(mode(2) = 1, i + 3, instructions(i + 3))) = instructions(If(mode(0) = 1, i + 1, instructions(i + 1))) * instructions(If(mode(1) = 1, i + 2, instructions(i + 2)))
                i += 4
            ElseIf opcode = 3 Then
                instructions(If(mode(0) = 1, i + 1, instructions(i + 1))) = inputValue(input_)
                input_ += 1
                i += 2
            ElseIf opcode = 4 Then
                output = (instructions(If(mode(0) = 1, i + 1, instructions(i + 1))))
                i += 2
            ElseIf opcode = 5 Then
                If instructions(If(mode(0) = 1, i + 1, instructions(i + 1))) <> 0 Then
                    i = instructions(If(mode(1) = 1, i + 2, instructions(i + 2)))
                Else
                    i += 3
                End If
            ElseIf opcode = 6 Then
                If instructions(If(mode(0) = 1, i + 1, instructions(i + 1))) = 0 Then
                    i = instructions(If(mode(1) = 1, i + 2, instructions(i + 2)))
                Else
                    i += 3
                End If
            ElseIf opcode = 7 Then
                If instructions(If(mode(0) = 1, i + 1, instructions(i + 1))) < instructions(If(mode(1) = 1, i + 2, instructions(i + 2))) Then
                    instructions(If(mode(2) = 1, i + 3, instructions(i + 3))) = 1
                Else
                    instructions(If(mode(2) = 1, i + 3, instructions(i + 3))) = 0
                End If
                i += 4
            ElseIf opcode = 8 Then
                If instructions(If(mode(0) = 1, i + 1, instructions(i + 1))) = instructions(If(mode(1) = 1, i + 2, instructions(i + 2))) Then
                    instructions(If(mode(2) = 1, i + 3, instructions(i + 3))) = 1
                Else
                    instructions(If(mode(2) = 1, i + 3, instructions(i + 3))) = 0
                End If
                i += 4
            End If
        End While
    End Function
    Sub intcodeComputerPart2(data() As Integer, ByRef q As List(Of Integer), ByRef i As Integer, ByRef newIP As Integer, ByRef newVal As Integer)
        Dim instructions() As Integer = data '{3, 225, 1, 225, 6, 6, 1100, 1, 238, 225, 104, 0, 1101, 37, 61, 225, 101, 34, 121, 224, 1001, 224, -49, 224, 4, 224, 102, 8, 223, 223, 1001, 224, 6, 224, 1, 224, 223, 223, 1101, 67, 29, 225, 1, 14, 65, 224, 101, -124, 224, 224, 4, 224, 1002, 223, 8, 223, 101, 5, 224, 224, 1, 224, 223, 223, 1102, 63, 20, 225, 1102, 27, 15, 225, 1102, 18, 79, 224, 101, -1422, 224, 224, 4, 224, 102, 8, 223, 223, 1001, 224, 1, 224, 1, 223, 224, 223, 1102, 20, 44, 225, 1001, 69, 5, 224, 101, -32, 224, 224, 4, 224, 1002, 223, 8, 223, 101, 1, 224, 224, 1, 223, 224, 223, 1102, 15, 10, 225, 1101, 6, 70, 225, 102, 86, 40, 224, 101, -2494, 224, 224, 4, 224, 1002, 223, 8, 223, 101, 6, 224, 224, 1, 223, 224, 223, 1102, 25, 15, 225, 1101, 40, 67, 224, 1001, 224, -107, 224, 4, 224, 102, 8, 223, 223, 101, 1, 224, 224, 1, 223, 224, 223, 2, 126, 95, 224, 101, -1400, 224, 224, 4, 224, 1002, 223, 8, 223, 1001, 224, 3, 224, 1, 223, 224, 223, 1002, 151, 84, 224, 101, -2100, 224, 224, 4, 224, 102, 8, 223, 223, 101, 6, 224, 224, 1, 224, 223, 223, 4, 223, 99, 0, 0, 0, 677, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1105, 0, 99999, 1105, 227, 247, 1105, 1, 99999, 1005, 227, 99999, 1005, 0, 256, 1105, 1, 99999, 1106, 227, 99999, 1106, 0, 265, 1105, 1, 99999, 1006, 0, 99999, 1006, 227, 274, 1105, 1, 99999, 1105, 1, 280, 1105, 1, 99999, 1, 225, 225, 225, 1101, 294, 0, 0, 105, 1, 0, 1105, 1, 99999, 1106, 0, 300, 1105, 1, 99999, 1, 225, 225, 225, 1101, 314, 0, 0, 106, 0, 0, 1105, 1, 99999, 108, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 329, 101, 1, 223, 223, 1107, 677, 226, 224, 102, 2, 223, 223, 1006, 224, 344, 101, 1, 223, 223, 8, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 359, 101, 1, 223, 223, 1008, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 374, 101, 1, 223, 223, 7, 226, 677, 224, 1002, 223, 2, 223, 1006, 224, 389, 1001, 223, 1, 223, 1007, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 404, 1001, 223, 1, 223, 7, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 419, 1001, 223, 1, 223, 1008, 677, 226, 224, 1002, 223, 2, 223, 1005, 224, 434, 1001, 223, 1, 223, 1107, 226, 677, 224, 102, 2, 223, 223, 1005, 224, 449, 1001, 223, 1, 223, 1008, 226, 226, 224, 1002, 223, 2, 223, 1006, 224, 464, 1001, 223, 1, 223, 1108, 677, 677, 224, 102, 2, 223, 223, 1006, 224, 479, 101, 1, 223, 223, 1108, 226, 677, 224, 1002, 223, 2, 223, 1006, 224, 494, 1001, 223, 1, 223, 107, 226, 226, 224, 1002, 223, 2, 223, 1006, 224, 509, 1001, 223, 1, 223, 8, 226, 677, 224, 102, 2, 223, 223, 1006, 224, 524, 1001, 223, 1, 223, 1007, 226, 226, 224, 1002, 223, 2, 223, 1006, 224, 539, 1001, 223, 1, 223, 107, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 554, 1001, 223, 1, 223, 1107, 226, 226, 224, 102, 2, 223, 223, 1005, 224, 569, 101, 1, 223, 223, 1108, 677, 226, 224, 1002, 223, 2, 223, 1006, 224, 584, 1001, 223, 1, 223, 1007, 677, 226, 224, 1002, 223, 2, 223, 1005, 224, 599, 101, 1, 223, 223, 107, 226, 677, 224, 102, 2, 223, 223, 1005, 224, 614, 1001, 223, 1, 223, 108, 226, 226, 224, 1002, 223, 2, 223, 1005, 224, 629, 101, 1, 223, 223, 7, 677, 226, 224, 102, 2, 223, 223, 1005, 224, 644, 101, 1, 223, 223, 8, 677, 226, 224, 102, 2, 223, 223, 1006, 224, 659, 1001, 223, 1, 223, 108, 677, 226, 224, 102, 2, 223, 223, 1005, 224, 674, 1001, 223, 1, 223, 4, 223, 99, 226}
        Dim output = -1
        Dim input_ = 0
        While 1
            Dim instructionInput = instructions(i)
            If instructionInput = 99 Then

                newIP = i
                newVal = Nothing
                Return
            End If
            Dim parseInstruction As New List(Of Integer) '= (From thing In instructions(i).ToString() Select Int(thing.ToString())).Cast(Of Integer)().ToList()
            For Each thing In instructionInput.ToString()
                parseInstruction.Add(Int(thing.ToString()))
            Next
            parseInstruction.Reverse()
            Dim opcode = parseInstruction(0)
            Dim mode As New List(Of Integer)
            If parseInstruction.Count > 2 Then
                mode.AddRange(parseInstruction.GetRange(2, parseInstruction.Count - 2))
            End If
            While mode.Count < 3
                mode.Add(0)
            End While
            If opcode = 1 Then
                instructions(If(mode(2) = 1, i + 3, instructions(i + 3))) = instructions(If(mode(0) = 1, i + 1, instructions(i + 1))) + instructions(If(mode(1) = 1, i + 2, instructions(i + 2)))
                i += 4
            ElseIf opcode = 2 Then
                instructions(If(mode(2) = 1, i + 3, instructions(i + 3))) = instructions(If(mode(0) = 1, i + 1, instructions(i + 1))) * instructions(If(mode(1) = 1, i + 2, instructions(i + 2)))
                i += 4
            ElseIf opcode = 3 Then
                instructions(If(mode(0) = 1, i + 1, instructions(i + 1))) = If(q.Count > 0, q(0), 0)
                If q.Count > 0 Then q.RemoveAt(0)
                i += 2
            ElseIf opcode = 4 Then
                output = (instructions(If(mode(0) = 1, i + 1, instructions(i + 1))))
                i += 2
            ElseIf opcode = 5 Then
                If instructions(If(mode(0) = 1, i + 1, instructions(i + 1))) <> 0 Then
                    i = instructions(If(mode(1) = 1, i + 2, instructions(i + 2)))
                Else
                    i += 3
                End If
            ElseIf opcode = 6 Then
                If instructions(If(mode(0) = 1, i + 1, instructions(i + 1))) = 0 Then
                    i = instructions(If(mode(1) = 1, i + 2, instructions(i + 2)))
                Else
                    i += 3
                End If
            ElseIf opcode = 7 Then
                If instructions(If(mode(0) = 1, i + 1, instructions(i + 1))) < instructions(If(mode(1) = 1, i + 2, instructions(i + 2))) Then
                    instructions(If(mode(2) = 1, i + 3, instructions(i + 3))) = 1
                Else
                    instructions(If(mode(2) = 1, i + 3, instructions(i + 3))) = 0
                End If
                i += 4
            ElseIf opcode = 8 Then
                If instructions(If(mode(0) = 1, i + 1, instructions(i + 1))) = instructions(If(mode(1) = 1, i + 2, instructions(i + 2))) Then
                    instructions(If(mode(2) = 1, i + 3, instructions(i + 3))) = 1
                Else
                    instructions(If(mode(2) = 1, i + 3, instructions(i + 3))) = 0
                End If
                i += 4
            End If
        End While
    End Sub
    Sub heapPermutation(a() As Integer, size As Integer, n As Integer, returnLIST As List(Of List(Of Integer)))
        If size = 1 Then
            returnLIST.Add(New List(Of Integer))
            For Each number In a
                returnLIST.Last().Add(number)
            Next
            Return
        End If
        For i = 0 To size - 1
            heapPermutation(a, size - 1, n, returnLIST)

            If size Mod 2 = 1 Then
                Dim temp = a(0)
                a(0) = a(size - 1)
                a(size - 1) = temp
            Else
                Dim temp = a(i)
                a(i) = a(size - 1)
                a(size - 1) = temp
            End If
        Next
    End Sub
    Sub part1()
        Dim instructions() As Integer = {3, 8, 1001, 8, 10, 8, 105, 1, 0, 0, 21, 38, 59, 84, 97, 110, 191, 272, 353, 434, 99999, 3, 9, 1002, 9, 2, 9, 101, 4, 9, 9, 1002, 9, 2, 9, 4, 9, 99, 3, 9, 102, 5, 9, 9, 1001, 9, 3, 9, 1002, 9, 5, 9, 101, 5, 9, 9, 4, 9, 99, 3, 9, 102, 5, 9, 9, 101, 5, 9, 9, 1002, 9, 3, 9, 101, 2, 9, 9, 1002, 9, 4, 9, 4, 9, 99, 3, 9, 101, 3, 9, 9, 1002, 9, 3, 9, 4, 9, 99, 3, 9, 102, 5, 9, 9, 1001, 9, 3, 9, 4, 9, 99, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 99, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 1001, 9, 1, 9, 4, 9, 3, 9, 1001, 9, 1, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 99, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 1001, 9, 1, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 99, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 99, 3, 9, 1001, 9, 1, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 1001, 9, 1, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 99}
        Dim possiblePhaseSettings() As Integer = {0, 1, 2, 3, 4}
        Dim permutationList As New List(Of List(Of Integer))
        Dim code
        heapPermutation(possiblePhaseSettings, possiblePhaseSettings.Count(), possiblePhaseSettings.Count(), permutationList)
        Dim m = 0
        For Each list In permutationList
            Dim o = 0
            For Each phase In list
                o = intcodeComputer(instructions, {phase, o})
            Next
            If o > m Then
                m = o
                code = list
            End If
        Next
        Console.Write(m)
    End Sub
    Function part2()
        Dim instructions() As Integer = {3, 8, 1001, 8, 10, 8, 105, 1, 0, 0, 21, 38, 59, 84, 97, 110, 191, 272, 353, 434, 99999, 3, 9, 1002, 9, 2, 9, 101, 4, 9, 9, 1002, 9, 2, 9, 4, 9, 99, 3, 9, 102, 5, 9, 9, 1001, 9, 3, 9, 1002, 9, 5, 9, 101, 5, 9, 9, 4, 9, 99, 3, 9, 102, 5, 9, 9, 101, 5, 9, 9, 1002, 9, 3, 9, 101, 2, 9, 9, 1002, 9, 4, 9, 4, 9, 99, 3, 9, 101, 3, 9, 9, 1002, 9, 3, 9, 4, 9, 99, 3, 9, 102, 5, 9, 9, 1001, 9, 3, 9, 4, 9, 99, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 99, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 1001, 9, 1, 9, 4, 9, 3, 9, 1001, 9, 1, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 99, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 1001, 9, 1, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 99, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 101, 2, 9, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 99, 3, 9, 1001, 9, 1, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 3, 9, 1002, 9, 2, 9, 4, 9, 3, 9, 1001, 9, 1, 9, 4, 9, 3, 9, 102, 2, 9, 9, 4, 9, 3, 9, 1001, 9, 2, 9, 4, 9, 3, 9, 101, 1, 9, 9, 4, 9, 99}
        Dim initPhase As New List(Of List(Of Integer))
        heapPermutation({0, 1, 2, 3, 4}, {0, 1, 2, 3, 4}.Count(), {0, 1, 2, 3, 4}.Count(), initPhase)
        Dim feedbackPhase As New List(Of List(Of Integer))
        heapPermutation({5, 6, 7, 8, 9}, {0, 1, 2, 3, 4}.Count(), {0, 1, 2, 3, 4}.Count(), feedbackPhase)

        Dim m = 0

        For Each perm In feedbackPhase
            Dim IP(perm.Count) As Integer
            Dim VAL(perm.Count) As Integer
            Dim QUE As New List(Of List(Of Integer))
            For i = 0 To perm.Count - 1
                QUE.Add(New List(Of Integer) From {perm(i)})
            Next
            QUE(0).Add(0)

            Dim seq = instructions

            Dim done = False

            While Not done
                For i = 0 To perm.Count - 1
                    Dim newIP
                    Dim newVal
                    intcodeComputerPart2(seq, QUE(i), IP(i), newIP, newVal)
                    If IsNothing(VAL) Then
                        If VAL(-1) > m Then
                            m = newVal
                        End If
                        done = True
                        Exit While
                    End If
                    IP(i) = newIP
                    VAL(i) = newVal
                    If QUE.Count = 5 Then done = True
                Next

            End While
        Next
        Return m

    End Function

End Module
