Imports System.IO
Imports System.Drawing
Module Donut_Maze
    Function readMap() As Dictionary(Of Point, String)
        Dim pointValues As New Dictionary(Of Point, String)
        Dim x = 5
        Dim y = 0
        Using reader = New StreamReader("C:\Users\James\Documents\GitHub\AdventofCode\Advent of Code\Advent of Code\Day 20\test data2.txt")
            Do Until reader.EndOfStream
                Dim currentLine = reader.ReadLine
                For Each value In currentLine
                    pointValues.Add(New Point(x, y), value)
                    x += 1
                Next
                x = 5
                y += 1
            Loop
        End Using
        Return pointValues
    End Function

    Function amendedMap(map As Dictionary(Of Point, String)) As Dictionary(Of Point, String)

        Dim adjacencyList As New Dictionary(Of Point, List(Of Point))

        Dim amendedMapOutput As New Dictionary(Of Point, String)

        For Each pointValue In map
            amendedMapOutput.Add(New Point(pointValue.Key.X, pointValue.Key.Y), pointValue.Value)
        Next


        Dim combinedPointValues As New List(Of String)
        For Each pointValue In map
            If pointValue.Value = "#" Or pointValue.Value = "." Or pointValue.Value = " " Then Continue For
            Dim surroundingPoints As New List(Of Point) From {
                New Point(pointValue.Key.X - 1, pointValue.Key.Y),
                New Point(pointValue.Key.X + 1, pointValue.Key.Y),
                New Point(pointValue.Key.X, pointValue.Key.Y - 1),
                New Point(pointValue.Key.X, pointValue.Key.Y + 1)}
            Dim centreValue = pointValue.Value
            Dim adjacentValue As KeyValuePair(Of Point, String) = New KeyValuePair(Of Point, String)(New Point(-1, -1), "X")

            Dim isNextToADot = False

            For Each point In surroundingPoints
                If Not map.ContainsKey(point) Then Continue For
                If map(point) = "." Then isNextToADot = True
                If map(point) <> "." And map(point) <> "#" And map(point) <> " " Then
                    adjacentValue = New KeyValuePair(Of Point, String)(point, map(point))
                End If
            Next
            If isNextToADot Then
                Dim combinedValue = pointValue.Value + adjacentValue.Value
                If Not combinedPointValues.Contains(combinedValue) Then
                    combinedValue = StrReverse(combinedValue)
                End If
                combinedPointValues.Add(combinedValue)
                amendedMapOutput(adjacentValue.Key) = " "
                amendedMapOutput(pointValue.Key) = combinedValue 'pointValue.Value + adjacentValue.Value
            End If
        Next
        Return amendedMapOutput
    End Function

    Function validNeighbours(currentPoint As Point, map As Dictionary(Of Point, String))
        Dim surroundingPoints As New List(Of Point) From {
               New Point(currentPoint.X - 1, currentPoint.Y),
               New Point(currentPoint.X + 1, currentPoint.Y),
               New Point(currentPoint.X, currentPoint.Y - 1),
               New Point(currentPoint.X, currentPoint.Y + 1)}
        Dim validPoints As New List(Of Point)
        For Each point In surroundingPoints
            'Console.ForegroundColor = ConsoleColor.Green
            'Console.SetCursorPosition(point.X, point.Y)
            'Console.Write("X")
            If map(point) = "#" Or map(point) = " " Then Continue For
            validPoints.Add(point)
        Next
        Return validPoints
    End Function

    Function returnCoord(adjacencyList As Dictionary(Of Point, List(Of Point)), map As Dictionary(Of Point, String), targetValue As String)
        For Each point In adjacencyList.Keys
            If map(point) = targetValue Then Return point
        Next
        Return Nothing
    End Function
    Function findAdjacentPoint(newmap As Dictionary(Of Point, String), w As Point)
        Dim currentPortal = newmap(w)
        Dim reversedPoint = StrReverse(currentPortal)
        For Each point In newmap
            If point.Key.Equals(w) Then Continue For 'its the same point
            If point.Value = currentPortal Or point.Value = reversedPoint Then
                Dim surroundingPoints As New List(Of Point) From {
                    New Point(point.Key.X - 1, point.Key.Y),
                    New Point(point.Key.X + 1, point.Key.Y),
                    New Point(point.Key.X, point.Key.Y - 1),
                    New Point(point.Key.X, point.Key.Y + 1)}
                For Each ValidPoint In surroundingPoints
                    If newmap(ValidPoint) = "." Then
                        Return ValidPoint
                    End If
                Next
            End If
        Next
        Return Nothing
    End Function
    Function returnAdjacentPoint(newmap As Dictionary(Of Point, String), w As Point)
        Dim surroundingPoints As New List(Of Point) From {
                    New Point(w.X - 1, w.Y),
                    New Point(w.X + 1, w.Y),
                    New Point(w.X, w.Y - 1),
                    New Point(w.X, w.Y + 1)}
        For Each point In surroundingPoints
            If newmap(point) = "." Then Return point
        Next
        Return Nothing
    End Function
    Function part1()
        printMap()
        Dim newMap = amendedMap(readMap)
        Dim adjacencyList = constructAdjacencyList(newMap)
        Dim Q As New Queue(Of Point)
        Dim discovered As New Dictionary(Of Point, Boolean)
        Dim start_V As Point = returnAdjacentPoint(newMap, returnCoord(adjacencyList, newMap, "AA"))
        Dim target As Point = returnAdjacentPoint(newMap, returnCoord(adjacencyList, newMap, "ZZ"))

        Dim cameFrom As New Dictionary(Of Point, Point)
        For Each point In newMap.Keys
            discovered(point) = False
        Next
        Q.Enqueue(start_V)
        discovered(start_V) = True
        Dim y = 1
        Dim portalsUsed = 0
        While Q.Count > 0
            Dim v = Q.Dequeue
            If v.Equals(target) Then Exit While
            For Each w As Point In validNeighbours(v, newMap)

                If newMap(w) = "." Then
                    If Not discovered(w) Then
                        discovered(w) = True
                        cameFrom(w) = v
                        Q.Enqueue(w)
                    End If
                ElseIf newMap(w).Length = 2 Then
                    If newMap(w) = "AA" Or newMap(w) = "ZZ" Then
                        discovered(w) = True
                        Continue For
                    End If
                    Dim teleportedNeighbour = findAdjacentPoint(newMap, w)
                    If Not discovered(teleportedNeighbour) Then
                        discovered(teleportedNeighbour) = True
                        cameFrom(teleportedNeighbour) = v
                        Q.Enqueue(teleportedNeighbour)
                    End If
                End If
            Next
        End While
        Dim tempV As Point = target
        Dim path As New List(Of Point)
        Console.ForegroundColor = ConsoleColor.Green
        path.Add(tempV)
        Do
            tempV = cameFrom(tempV)
            path.Add(tempV)
        Loop Until tempV.Equals(start_V)
        path.Reverse()

        For Each point In path
            print(point)
        Next

        Console.SetCursorPosition(Console.WindowWidth / 2, 0)
        Console.ForegroundColor = ConsoleColor.White
        Console.Write($"path length: {path.Count - 1 - portalsUsed}")

        Console.ReadKey()
    End Function
    Sub print(point As Point)
        Console.SetCursorPosition(point.X, point.Y)
        Console.Write("X")
    End Sub
    Function printMap()
        Console.ReadKey()
        Dim pointValues = readMap()
        Console.ForegroundColor = ConsoleColor.White
        For Each pointValue In pointValues
            Console.SetCursorPosition(pointValue.Key.X, pointValue.Key.Y)
            Console.Write(pointValue.Value)
        Next
        Console.ReadKey()
    End Function

End Module
