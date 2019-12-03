Imports System.IO
Module Rocket_Equation

    Function part1()
        Dim value As New List(Of Double)
        Using reader = New StreamReader("S:\Advent of Code\Advent of Code\Day 1\data.txt")
            Do Until reader.EndOfStream
                value.Add(Math.Floor(Int(reader.ReadLine) / 3) - 2)
            Loop
        End Using
        Return value.Sum
    End Function

    Function part2()
        Dim values As New List(Of Double)
        Using reader = New StreamReader("S:\Advent of Code\Advent of Code\Day 1\data.txt")
            Do Until reader.EndOfStream
                Dim moduleValue As New List(Of Double)
                Dim value = Int(reader.ReadLine())
                Do
                    If Math.Floor(value / 3) - 2 > 0 Then
                        moduleValue.Add(Math.Floor(value / 3) - 2)
                    Else
                        Exit Do
                    End If
                    value = moduleValue.Last()
                Loop Until value = 2
                values.Add(moduleValue.Sum())
            Loop
        End Using
        Return values.Sum
    End Function

End Module
