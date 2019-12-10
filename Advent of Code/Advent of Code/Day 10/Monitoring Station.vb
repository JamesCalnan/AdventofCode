Imports System.IO
Imports System.Drawing
Module Monitoring_Station

    Function loadData() As List(Of Point)
        Dim asteriodPoints As New List(Of Point)
        Dim x = 0
        Dim y = 0
        Using reader = New StreamReader("C:\Users\James\Documents\GitHub\AdventofCode\Advent of Code\Advent of Code\Day 10\test data 2.txt")
            Do Until reader.EndOfStream
                For Each point In reader.ReadLine
                    If point = "#" Then asteriodPoints.Add(New Point(x, y))
                    x += 1
                Next
                x = 0
                y += 1
            Loop
        End Using
        Return asteriodPoints
    End Function
    Function part1()

        Dim asteroids = loadData()

        For Each point In asteroids
            Console.SetCursorPosition(point.X, point.Y)
            Console.Write("X")
        Next
        Return Nothing
    End Function


End Module
