Imports System.IO
Module Universal_Orbit_Map

    Function part1()
        Dim orbit As New Dictionary(Of String, List(Of String))
        Dim planets As New List(Of String)
        Using reader = New StreamReader("S:\AoC\Advent of Code\Advent of Code\Day 6\data.txt")
            Do Until reader.EndOfStream
                Dim line = reader.ReadLine

                Dim parent = "" 'line.Substring(0, 3)
                Dim child = "" ' line.Substring(4, 3)
                Dim doneWithParent As Boolean = False
                For i = 0 To line.Count - 1
                    If line(i) = ")" Then doneWithParent = True
                    If Not doneWithParent Then
                        parent += line(i)
                    ElseIf line(i) <> ")" Then
                        child += line(i)
                    End If
                Next
                planets.Add(child)
                If orbit.ContainsKey(parent) Then
                    orbit(parent).Add(child)
                Else
                    Dim tempList As New List(Of String) From {child}
                    orbit.Add(parent, tempList)
                End If
            Loop
        End Using
        Dim count = 0
        For Each target In planets
            Dim q As New Queue(Of String)
            Dim start_v = "COM"
            Dim discovered As New Dictionary(Of String, Boolean)
            For Each planet In planets
                discovered(planet) = False
            Next
            Dim camefrom As New Dictionary(Of String, String)
            discovered(start_v) = True
            q.Enqueue(start_v)
            While q.Count > 0
                Dim v = q.Dequeue
                count += 1
                If v = target Then
                    Exit While
                End If
                If orbit.ContainsKey(v) Then
                    For Each adjacentPlanet In orbit(v)
                        If Not discovered(adjacentPlanet) Then
                            discovered(adjacentPlanet) = True
                            q.Enqueue(adjacentPlanet)
                            camefrom(adjacentPlanet) = v
                        End If
                    Next
                End If

            End While
            Dim tempV As String = target
            Dim tempC As Integer
            While 1
                tempV = camefrom(tempV)
                tempC += 1
                If tempV = "COM" Then Exit While
            End While
            count = tempC
        Next
        Return count
    End Function
    Function part2()
        Dim orbit As New Dictionary(Of String, List(Of String))
        Dim planets As New List(Of String)
        Using reader = New StreamReader("S:\AoC\Advent of Code\Advent of Code\Day 6\data.txt")
            Do Until reader.EndOfStream
                Dim line = reader.ReadLine
                Dim parent = "" 'line.Substring(0, 3)
                Dim child = "" ' line.Substring(4, 3)
                Dim doneWithParent As Boolean = False
                For i = 0 To line.Count - 1
                    If line(i) = ")" Then doneWithParent = True
                    If Not doneWithParent Then
                        parent += line(i)
                    ElseIf line(i) <> ")" Then
                        child += line(i)
                    End If
                Next
                planets.Add(child)
                If orbit.ContainsKey(parent) Then
                    orbit(parent).Add(child)
                Else
                    Dim tempList As New List(Of String) From {child}
                    orbit.Add(parent, tempList)
                End If
                If Not planets.Contains(parent) Then planets.Add(parent)
                If orbit.ContainsKey(child) Then
                    orbit(child).Add(parent)
                Else
                    Dim tempList As New List(Of String) From {parent}
                    orbit.Add(child, tempList)
                End If

            Loop
        End Using
        Dim cameFrom As New Dictionary(Of String, String)
        Dim discovered As New Dictionary(Of String, Boolean)
        Dim Q As New Queue(Of String)
        Dim start_v = "YOU"
        Dim targetPlanet = "SAN"
        For Each planet In planets
            discovered(planet) = False
        Next
        Q.Enqueue(start_v)
        discovered(start_v) = True
        While Q.Count > 0
            Dim currentPlanet = Q.Dequeue()
            If currentPlanet = targetPlanet Then Exit While
            For Each adjacentPlanet In From adjacentPlanet1 In orbit(currentPlanet) Where Not discovered(adjacentPlanet1)
                discovered(adjacentPlanet) = True
                cameFrom(adjacentPlanet) = currentPlanet
                Q.Enqueue(adjacentPlanet)
            Next
        End While
        Dim count = 0
        Dim backtrackPlanet = "SAN"
        Do
            count += 1
            backtrackPlanet = cameFrom(backtrackPlanet)
        Loop Until backtrackPlanet = "YOU"
        Return count - 2
    End Function

End Module
