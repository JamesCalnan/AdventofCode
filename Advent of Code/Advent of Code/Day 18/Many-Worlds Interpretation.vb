Imports System.IO
Imports System.Drawing

Module Many_Worlds_Interpretation
    Dim pathTotal As Integer = 0
    Function readMap() As Dictionary(Of Point, String)
        Dim pointValues As New Dictionary(Of Point, String)
        Dim x = 5
        Dim y = 2
        Using reader = New StreamReader("C:\Users\James\Documents\GitHub\AdventofCode\Advent of Code\Advent of Code\Day 18\data.txt")
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

    Function validNeighbours(currentPoint As Point, map As Dictionary(Of Point, String))
        Dim surroundingPoints As New List(Of Point) From {
               New Point(currentPoint.X - 1, currentPoint.Y),
               New Point(currentPoint.X + 1, currentPoint.Y),
               New Point(currentPoint.X, currentPoint.Y - 1),
               New Point(currentPoint.X, currentPoint.Y + 1)}
        Dim validPoints As New List(Of Point)
        For Each point In surroundingPoints
            If map(point) = "#" Or isUpperCaseLetter(map(point)) Then Continue For
            validPoints.Add(point)
        Next
        Return validPoints
    End Function

    Function getStartingPoint(map As Dictionary(Of Point, String))
        For Each point In map
            If point.Value = "@" Then Return point.Key
        Next
        Return Nothing
    End Function
    Function getAvailableKeys(map As Dictionary(Of Point, String)) As Dictionary(Of Point, String)
        Dim keys As New Dictionary(Of Point, String)
        For Each point In map
            If isLowerCaseLetter(point.Value) Then
                keys.Add(point.Key, point.Value)
            End If
        Next
        Return keys
    End Function
    Function breadthFirstSearch(map As Dictionary(Of Point, String), start As Point)
        Dim discovered As New Dictionary(Of Point, Boolean)
        Dim cameFrom As New Dictionary(Of Point, Point)
        For Each point In map.Keys
            discovered(point) = False
        Next
        Dim Q As New Queue(Of Point)
        discovered(start) = True
        Q.Enqueue(start)
        Dim target As Point
        Dim availableKeys = getAvailableKeys(map)
        Console.ForegroundColor = ConsoleColor.Red
        While Q.Count > 0
            Dim v = Q.Dequeue
            If availableKeys.Values.Contains(map(v)) Then
                'if it is a key
                target = v
                Exit While
            End If
            For Each w In validNeighbours(v, map)
                If Not discovered(w) Then
                    discovered(w) = True
                    cameFrom(w) = v
                    Q.Enqueue(w)
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
        Loop Until tempV.Equals(start)
        For Each point In path
            print(point)
        Next
        pathTotal += path.Count - 1
        Return map(target)
    End Function
    Function isUpperCaseLetter(value As String)
        Return Asc(value) >= 65 And Asc(value) <= 90
    End Function
    Function isLowerCaseLetter(value As String)
        Return Asc(value) >= 97 And Asc(value) <= 122
    End Function
    Sub runningCode()
        Dim map = readMap()
        printMap(map)


        Do
            Dim start = getStartingPoint(map)
            returnReachableKeys(map)
            Dim keyFound = breadthFirstSearch(map, start)
            map = removeKeyAndDoorChangeStart(map, keyFound)

            Console.SetCursorPosition(0, 0)
            Console.WriteLine($"key found: {keyFound},      current total path length: {pathTotal}")
            printMap(map)
        Loop Until Not keysLeft(map)
        Console.ForegroundColor = ConsoleColor.Red
        Console.SetCursorPosition(0, 1)
        Console.Write("done")
    End Sub
    Function removeKeyAndDoorChangeStart(map As Dictionary(Of Point, String), key As String)
        Dim copyMap As New Dictionary(Of Point, String)
        For Each thing In map
            copyMap.Add(thing.Key, thing.Value)
        Next
        For Each thing In map
            If thing.Value = "@" Then copyMap(thing.Key) = "."
        Next
        For Each thing In map
            If thing.Value = key Then copyMap(thing.Key) = "@"
        Next
        For Each thing In map
            If thing.Value = key.ToUpper Then copyMap(thing.Key) = "."
        Next
        Return copyMap
    End Function

    Function keysLeft(map As Dictionary(Of Point, String))
        For Each thing In map
            If isLowerCaseLetter(thing.Value) Then Return True
        Next
        Return False
    End Function
    Function returnReachableKeys(map As Dictionary(Of Point, String)) As Dictionary(Of Point, String)
        Dim reachableKeys As New Dictionary(Of Point, String)

        Dim q As New Queue(Of Point)
        Dim discovered As New Dictionary(Of Point, Boolean)

        For Each point In map.Keys
            discovered(point) = False
        Next
        Dim startV = getStartingPoint(map)
        discovered(startV) = True
        q.Enqueue(startV)

        Dim availableKeys = getAvailableKeys(map)
        Console.ForegroundColor = ConsoleColor.Magenta
        While q.Count > 0
            Dim v = q.Dequeue
            print(v)
            If availableKeys.Values.Contains(map(v)) Then
                'if it is a key
                reachableKeys.Add(v, map(v))
            End If
            If isLowerCaseLetter(map(v)) Then Continue While

            For Each w In validNeighbours(v, map)
                If Not discovered(w) Then
                    discovered(w) = True
                    q.Enqueue(w)
                End If
            Next
        End While
        printMap(map)

        Console.ForegroundColor = ConsoleColor.Red
        For Each thing In reachableKeys
            print(thing.Key, thing.Value)
        Next
    End Function
    Sub printMap(map As Dictionary(Of Point, String))
        Console.ForegroundColor = ConsoleColor.White
        For Each pointValue In map
            Console.SetCursorPosition(pointValue.Key.X, pointValue.Key.Y)
            Console.Write(pointValue.Value)
        Next
    End Sub
End Module
