Module Program_alarm
    Function part1()
        Dim instructions() As Integer = {1, 12, 2, 3, 1, 1, 2, 3, 1, 3, 4, 3, 1, 5, 0, 3, 2, 1, 6, 19, 1, 19, 5, 23, 2, 13, 23, 27, 1, 10, 27, 31, 2, 6, 31, 35, 1, 9, 35, 39, 2, 10, 39, 43, 1, 43, 9, 47, 1, 47, 9, 51, 2, 10, 51, 55, 1, 55, 9, 59, 1, 59, 5, 63, 1, 63, 6, 67, 2, 6, 67, 71, 2, 10, 71, 75, 1, 75, 5, 79, 1, 9, 79, 83, 2, 83, 10, 87, 1, 87, 6, 91, 1, 13, 91, 95, 2, 10, 95, 99, 1, 99, 6, 103, 2, 13, 103, 107, 1, 107, 2, 111, 1, 111, 9, 0, 99, 2, 14, 0, 0}
        For i = 0 To instructions.Count - 1 Step 4
            Dim opcode = instructions(i)
            If opcode = 99 Then Exit For
            Dim position = instructions(i + 3)
            Dim result As Integer
            If opcode = 1 Then
                result = instructions(instructions(i + 1)) + instructions(instructions(i + 2))
            Else
                result = instructions(instructions(i + 1)) * instructions(instructions(i + 2))
            End If
            instructions(position) = result
        Next
        Return instructions(0)
    End Function
    Function part2()
        For noun = 0 To 99
            For verb = 0 To 99
                Dim instructions() As Integer = {1, noun, verb, 3, 1, 1, 2, 3, 1, 3, 4, 3, 1, 5, 0, 3, 2, 1, 6, 19, 1, 19, 5, 23, 2, 13, 23, 27, 1, 10, 27, 31, 2, 6, 31, 35, 1, 9, 35, 39, 2, 10, 39, 43, 1, 43, 9, 47, 1, 47, 9, 51, 2, 10, 51, 55, 1, 55, 9, 59, 1, 59, 5, 63, 1, 63, 6, 67, 2, 6, 67, 71, 2, 10, 71, 75, 1, 75, 5, 79, 1, 9, 79, 83, 2, 83, 10, 87, 1, 87, 6, 91, 1, 13, 91, 95, 2, 10, 95, 99, 1, 99, 6, 103, 2, 13, 103, 107, 1, 107, 2, 111, 1, 111, 9, 0, 99, 2, 14, 0, 0}
                For i = 0 To instructions.Count - 1 Step 4
                    Dim opcode = instructions(i)
                    If opcode = 99 Then Exit For
                    Dim position = instructions(i + 3)
                    Dim result As Integer
                    If opcode = 1 Then
                        result = instructions(instructions(i + 1)) + instructions(instructions(i + 2))
                    Else
                        result = instructions(instructions(i + 1)) * instructions(instructions(i + 2))
                    End If
                    instructions(position) = result
                Next
                If instructions(0) = 19690720 Then Return 100 * noun + verb
            Next
        Next
        Return 0
    End Function
End Module
