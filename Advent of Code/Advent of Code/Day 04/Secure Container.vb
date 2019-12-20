Module Secure_Container
    Function returnAmountOfPasswords()
        Dim input = My.Computer.FileSystem.ReadAllText("S:\AoC\Advent of Code\Advent of Code\Day 4\data.txt").Split("-")
        Dim count As Integer = 0
        For i = Int(input(0)) To Int(input(1))
            If isAscending(i) AndAlso hasAdjacentNumbers(i) Then count += 1
        Next
        Return count
    End Function
    Function hasAdjacentNumbers(number As String)
        For i = 0 To number.Count() - 2
            If number(i) = number(i + 1) Then Return True
        Next
        Return False
    End Function
    Function isAscending(number As String)
        For i = 0 To number.Count() - 2
            If Int(number(i).ToString()) > Int(number(i + 1).ToString()) Then Return False
        Next
        Return True
    End Function
    Function part1()
        Return returnAmountOfPasswords()
    End Function
    Function containsDoubleNumber(number As String)
        Dim numberAmount As New Dictionary(Of String, Integer)
        For Each letter In number
            numberAmount(letter) = 0
        Next
        For i = 0 To number.Count() - 1
            numberAmount(number(i)) += 1
        Next
        Return numberAmount.Values.Any(Function(dictValue) dictValue = 2)
    End Function
    Function returnAmountOfPasswordsp2()
        Dim input = My.Computer.FileSystem.ReadAllText("S:\AoC\Advent of Code\Advent of Code\Day 4\data.txt").Split("-")
        Dim count = 0
        For i = Int(input(0)) To Int(input(1))
            If isAscending(i) AndAlso containsDoubleNumber(i) Then count += 1
        Next
        Return count
    End Function
    Function part2()
        Return returnAmountOfPasswordsp2()
    End Function
End Module
