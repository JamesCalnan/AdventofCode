Imports System.IO
Module Slam_Shuffle
    Function incrementN(inputList As List(Of Integer), N As Integer)
        Dim outputArray(inputList.Count - 1) As Integer
        Dim copyList As New List(Of Integer)
        copyList.AddRange(inputList)
        Dim i = 0
        While copyList.Count > 0
            Dim value = copyList.First
            copyList.RemoveAt(0)
            outputArray(i Mod outputArray.Count) = value
            i += N
        End While
        Return outputArray.ToList
    End Function

    Sub dealIntoNewStack(ByRef inputList As List(Of Integer))
        inputList.Reverse()
    End Sub

    Function cutN(inputList As List(Of Integer), N As Integer)
        Dim outputlist As New List(Of Integer)
        If N > 0 Then
            outputlist.AddRange(inputList.GetRange(0, N))
            outputlist.InsertRange(0, inputList.GetRange(N, inputList.Count - N))
        ElseIf N < 0 Then
            outputlist.AddRange(inputList.GetRange(Math.Abs(inputList.Count - Math.Abs(N)), Math.Abs(N)))
            outputlist.AddRange(inputList.GetRange(0, Math.Abs(inputList.Count - Math.Abs(N))))
        End If
        Return outputlist
    End Function

    Function returnInstructions() As List(Of String)
        Dim instructions As New List(Of String)
        Using reader = New StreamReader("C:\Users\James\Documents\GitHub\AdventofCode\Advent of Code\Advent of Code\Day 22\data.txt")
            Do Until reader.EndOfStream
                instructions.Add(reader.ReadLine.ToString)
            Loop
        End Using
        Return instructions
    End Function
    Function interpretInstruction(instruction As String) As instructionValue
        Dim instructionAsArray = instruction.Split(" ")
        If instructionAsArray(instructionAsArray.Count - 2) = "increment" Then
            Return New instructionValue("increment", instructionAsArray.Last)
        ElseIf instructionAsArray(instructionAsArray.Count - 2) = "cut" Then
            Return New instructionValue("cut", instructionAsArray.Last)
        ElseIf instructionAsArray.Last = "stack" Then
            Return New instructionValue("stack", Nothing)
        End If
        Return Nothing
    End Function

    'deal with increment 7
    'cut 6
    'deal into New stack
    'deal into New stack

    Sub Part1runnerCode()
        'Dim inputList As New List(Of Integer) From {0, 1, 2, 3, 4, 5, 6, 7, 8, 9}
        Dim inputList As New List(Of Integer)
        For i = 0 To 119315717514047 - 1
            inputList.Add(i)
        Next
        Dim instructions = returnInstructions()
        Dim timer As Stopwatch = Stopwatch.StartNew
        For i = 0 To 101741582076661
            For Each instruction In instructions
                Dim interprettedInstruction = interpretInstruction(instruction)
                If interprettedInstruction.instruction = "increment" Then
                    inputList = incrementN(inputList, interprettedInstruction.value)
                ElseIf interprettedInstruction.instruction = "cut" Then
                    inputList = cutN(inputList, interprettedInstruction.value)
                ElseIf interprettedInstruction.instruction = "stack" Then
                    inputList.Reverse()
                End If
            Next
            Console.WriteLine($"{i / 101741582076661 * 100}%")
        Next

        Console.WriteLine(inputList(2020))
        Console.WriteLine($"time taken: {timer.Elapsed.TotalSeconds}")
        'inputList = incrementN(inputList, 3)

        'Console.WriteLine()
        'Console.WriteLine()
        '6289
        '8941
        Console.ReadKey()

    End Sub

    Function initialiseList(n As Integer) As List(Of Integer)
        Dim outputlist As New List(Of Integer)
        For i = 0 To n - 1
            outputlist.Add(i)
        Next
        Return outputlist
    End Function

    Sub printList(inputList As List(Of Integer))
        Console.Write("Result: ")
        For Each thing In inputList
            Console.Write(thing)
            If thing <> inputList.Last Then Console.Write(" ")
        Next

    End Sub

End Module
Class instructionValue
    Public instruction As String
    Public value As String
    Public Sub New(instr As String, val As Integer)
        instruction = instr
        value = val
    End Sub

End Class