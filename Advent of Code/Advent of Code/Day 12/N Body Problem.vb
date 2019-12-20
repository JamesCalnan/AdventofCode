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
                Dim x = splitLine(0).Split("=")
                Dim y = splitLine(1).Split("=")
                Dim z = splitLine(2).Split("=")
                z = z(z.Count - 1).Split(">")
                pointList.Add(New Point3D(Int(x(x.Count - 1)), Int(y(y.Count - 1)), Int(z(0))))
            Loop
        End Using
        Return pointList
    End Function
End Module
