Imports System.Drawing
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.IO

Module N_Body_Problem
    Function part1()

        Dim newPoint As New Point3D(1, 1, 1)


        Dim stepNumber = getPoints()


    End Function
    Function getPoints()
        Dim pointList As New List(Of Point3D)
        Using reader = New StreamReader("C:\Users\James\Documents\GitHub\AdventofCode\Advent of Code\Advent of Code\Day 12\data.txt")
            Do Until reader.EndOfStream
                Dim currentLine = reader.ReadLine
                Dim splitLine = currentLine.Split(",")
                Dim splitOnEqual = splitLine(0).Split("=")
                Console.WriteLine(Join(splitOnEqual, " "))
                Console.WriteLine(splitOnEqual(splitOnEqual.Count - 1))

                Console.ReadKey()
                Dim x, y, z As String
                Dim intPos As Integer = 0
                For i = 0 To currentLine.Count - 1
                    If currentLine(i) = "=" Then
                        For j = i + 1 To currentLine.Count - 2
                            If currentLine(j) = "," Then
                                intPos += 1
                                Exit For
                            End If
                            If intPos = 0 Then x += currentLine(j)
                            If intPos = 1 Then y += currentLine(j)
                            If intPos = 2 Then z += currentLine(j)
                        Next
                    End If
                Next
                Console.WriteLine($"x: {x}  y: {y}  z: {z}")
                pointList.Add(New Point3D(Int(x), Int(y), Int(z)))
            Loop
        End Using
        Return pointList
    End Function
End Module
