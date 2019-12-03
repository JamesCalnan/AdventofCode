Imports System.Collections.Generic
Imports System.IO
Imports System.Drawing
Imports System.Linq
Module Crossed_wires

    Function getPoints(filePath As String) As List(Of Point)
        Dim directions() = My.Computer.FileSystem.ReadAllText(filePath).Split(",")
        Dim newWire As New List(Of Point) From {
            New Point(0, 0)
        }

        For Each direction In directions
            Dim currentPoint = newWire.Last()
            Dim amount = Int(direction.Substring(1))
            Dim yOffset = 0
            Dim xOffset = 0
            Select Case direction(0)
                Case "U"
                    yOffset = -1
                Case "D"
                    yOffset = 1
                Case "L"
                    xOffset = -1
                Case "R"
                    xOffset = 1
            End Select
            For x = 1 To amount
                currentPoint = New Point(currentPoint.X + xOffset, currentPoint.Y + yOffset)
                newWire.Add(currentPoint)
            Next
        Next
        Return newWire
    End Function

    Function part1()
        Dim wire1 = getPoints("H:\AoC\Advent of Code\Advent of Code\Day 3\data1.txt")
        Dim wire2 = getPoints("H:\AoC\Advent of Code\Advent of Code\Day 3\data2.txt")
        Dim intersections = wire1.Intersect(wire2).Where(Function(p) p.X <> 0 And p.Y <> 0)

        Dim enumerable As IEnumerable(Of Point) = intersections.ToList()
        For Each wire In enumerable
            Console.WriteLine(Math.Abs(wire.X) + Math.Abs(wire.Y))
        Next

        Dim closest = enumerable.OrderBy(Function(p) Math.Abs(p.X) + Math.Abs(p.Y)).First()

        Dim distance = Math.Abs(closest.X) + Math.Abs(closest.Y)



        Return distance
    End Function
    Function calculateManhattenDistance(inputPoint As point)
        Return Math.Abs(inputPoint.X) + Math.Abs(inputPoint.Y)
    End Function
End Module
