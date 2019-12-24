Imports System.IO
Imports System.Drawing


Module Planet_of_Discord
    Function readData(path As String) As Dictionary(Of Point, String)
        Dim pointValues As New Dictionary(Of Point, String)
        Dim x = 0
        Dim y = 0
        Using reader = New StreamReader(path) '"C:\Users\James\Documents\GitHub\AdventofCode\Advent of Code\Advent of Code\Day 20\test data2.txt")
            Do Until reader.EndOfStream
                Dim currentLine = reader.ReadLine
                For Each value In currentLine
                    pointValues.Add(New Point(x, y), value)
                    x += 1
                Next
                x = 0
                y += 1
            Loop
        End Using
        Return pointValues
    End Function

    Sub printMap(pointValues As Dictionary(Of Point, String))
        For Each point In pointValues
            print(point.Key, point.Value)
        Next
    End Sub
    Function countNeighbours(currentPoint As Point, map As Dictionary(Of Point, String)) As Integer

        Dim adjacentPoints As New List(Of Point) From {
            New Point(currentPoint.X - 1, currentPoint.Y),
            New Point(currentPoint.X + 1, currentPoint.Y),
            New Point(currentPoint.X, currentPoint.Y - 1),
            New Point(currentPoint.X, currentPoint.Y + 1)}

        Dim aliveNeighbours = 0

        For Each point In adjacentPoints
            If map.ContainsKey(point) Then
                If map(point) = "#" Then aliveNeighbours += 1
            End If
        Next
        Return aliveNeighbours
    End Function

    Function isAlive(map As Dictionary(Of Point, String), curPoint As Point)
        If map(curPoint) = "#" Then
            Return True
        End If
        Return False
    End Function
    Function isDead(map As Dictionary(Of Point, String), curPoint As Point)
        If map(curPoint) = "." Then
            Return True
        End If
        Return False
    End Function

    Function getNextGeneration(currentMap As Dictionary(Of Point, String)) As Dictionary(Of Point, String)
        Dim newMap As New Dictionary(Of Point, String)
        For Each point In currentMap
            Dim currentPoint = point.Key
            Dim noOfNeighbours = countNeighbours(currentPoint, currentMap)
            If currentMap(currentPoint) = "#" AndAlso noOfNeighbours = 1 Then
                newMap.Add(currentPoint, "#")
            ElseIf currentMap(currentPoint) = "#" AndAlso noOfNeighbours <> 1 Then
                newMap.Add(currentPoint, ".")
            ElseIf currentMap(currentPoint) = "." AndAlso noOfNeighbours = 1 OrElse noOfNeighbours = 2 Then
                newMap.Add(currentPoint, "#")
            Else
                newMap.Add(currentPoint, currentMap(currentPoint))
            End If
        Next
        Return newMap
    End Function
    Function calculateTileValue(x As Integer)
        Return x ^ 2
    End Function
    Function calculateBiodiversity(map As Dictionary(Of Point, String))
        Dim total As Integer = 0
        Dim multiple = 1
        For y = 0 To 4
            For x = 0 To 4
                If map(New Point(x, y)) = "#" Then
                    total += multiple
                End If
                multiple *= 2
            Next
        Next
        Return total
    End Function
    Sub runnerCode()

        Dim map = readData("C:\Users\James\Documents\GitHub\AdventofCode\Advent of Code\Advent of Code\Day 24\full data.txt")
        Dim biodiversities As New List(Of Integer)
        Console.CursorVisible = False

        Dim currentBiodiversity As Integer

        Do

            map = getNextGeneration(map)
            currentBiodiversity = calculateBiodiversity(map)
            If biodiversities.Contains(currentBiodiversity) Then Exit Do
            biodiversities.Add(currentBiodiversity)
        Loop

        My.Computer.Clipboard.SetText(calculateBiodiversity(map))
        Console.WriteLine(calculateBiodiversity(map))
        Console.ReadKey()
    End Sub



End Module
