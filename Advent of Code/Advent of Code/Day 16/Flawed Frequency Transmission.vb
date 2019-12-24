Module Flawed_Frequency_Transmission


    Function returnInputData() As List(Of Integer)
        Dim input = My.Computer.FileSystem.ReadAllText("C:\Users\James\Documents\GitHub\AdventofCode\Advent of Code\Advent of Code\Day 16\test.txt")
        Dim inputValueList As New List(Of Integer)
        For Each value As String In input
            inputValueList.Add(Int(value))
        Next
        Return inputValueList
    End Function

    Function returnRepeatedList(basePattern As List(Of Integer), repeatingAmount As Integer, n As Integer, offset As Integer) As List(Of Integer)
        Dim returnPattern As New List(Of Integer)
        For Each value In basePattern
            For i = 1 To repeatingAmount
                returnPattern.Add(value)
            Next
        Next
        Dim offsetValues As New List(Of Integer)
        For i = 1 To offset
            offsetValues.Add(returnPattern.First)
            returnPattern.RemoveAt(0)
        Next
        Dim copyList As New List(Of Integer)
        For Each value In offsetValues
            copyList.Add(value)
        Next
        For Each value In returnPattern
            copyList.Add(value)
        Next

        Do
            returnPattern.AddRange(copyList)
        Loop Until returnPattern.Count > n
        Return returnPattern
    End Function

    Sub main()
        Dim values = returnInputData()
        Dim basePattern As New List(Of Integer) From {0, 1, 0, -1}
        Dim startingCount = values.Count
        Console.CursorVisible = False
        For k = 1 To 100
            Dim outputValues As New List(Of Integer)
            For i = 1 To values.Count
                Dim repeatAmount = i
                Dim pattern = returnRepeatedList(basePattern, repeatAmount, values.Count, 1)
                Dim total As Integer = 0
                For j = 0 To values.Count - 1
                    total += values(j) * pattern(j)
                Next
                Dim totalString As String = total.ToString
                Dim lastValue = Int32.Parse(totalString.Last)
                outputValues.Add(lastValue)
            Next
            values = outputValues
            Console.SetCursorPosition(0, 0)
            Console.Write($"{k}% complete")
        Next
        Console.SetCursorPosition(0, 0)


        printList(values)




        Console.ReadKey()
    End Sub

    Sub printList(values As List(Of Integer))
        For i = 0 To 7
            Console.Write($"{values(i)}")
            If i <> 7 Then Console.Write(", ")
        Next
    End Sub

End Module
