Imports System.IO
Imports System.Linq
Imports System.Net.Http.Headers

Module Universal_Orbit_Map

    Function part1()
        Dim orbit As New Dictionary(Of String, List(Of String))
        Dim planets As New List(Of String)
        Using reader = New StreamReader("S:\AoC\Advent of Code\Advent of Code\Day 6\data.txt")
            Do Until reader.EndOfStream
                Dim line = reader.ReadLine
                planets.Add(line.Split(")")(1))
                If orbit.ContainsKey(line.Split(")")(0)) Then
                    orbit(line.Split(")")(0)).Add(line.Split(")")(1))
                Else
                    orbit.Add(line.Split(")")(0), New List(Of String) From {line.Split(")")(1)})
                End If
            Loop
        End Using
        Dim count = 0
        For Each target In planets
            If target = "COM" Then Continue For
            Dim camefrom As Dictionary(Of String, String) = dfsPathLength(orbit, planets, "COM", target, True)
            Dim tempV As String = target
            Do
                tempV = camefrom(tempV)
                count += 1
            Loop Until tempV = "COM"
        Next
        Return count
    End Function
    Function part2()
        Dim orbit As New Dictionary(Of String, List(Of String))
        Dim planets As New List(Of String)
        Using reader = New StreamReader("S:\AoC\Advent of Code\Advent of Code\Day 6\data.txt")
            Do Until reader.EndOfStream
                Dim line = reader.ReadLine
                planets.Add(line.Split(")")(0))
                planets.Add(line.Split(")")(1))
                Dim tempList As New List(Of String) From {line.Split(")")(1), line.Split(")")(0)}
                For Each obj In tempList
                    For Each obj1 In tempList
                        If orbit.ContainsKey(obj) Then
                            orbit(obj).Add(obj1)
                        Else
                            orbit.Add(obj, New List(Of String) From {obj1})
                        End If
                    Next
                Next
            Loop
        End Using
        Return dfsPathLength(orbit, planets, "YOU", "SAN", False) - 2
    End Function
    Function dfsPathLength(orbit As Dictionary(Of String, List(Of String)), planets As List(Of String), startingPlanet As String, targetPlanet As String, returnCameFrom As Boolean)
        Dim cameFrom As New Dictionary(Of String, String)
        Dim discovered As New Dictionary(Of String, Boolean)
        Dim Q As New Queue(Of String)
        For Each planet In planets
            discovered(planet) = False
        Next
        Q.Enqueue(startingPlanet)
        discovered(startingPlanet) = True
        While Q.Count > 0
            Dim currentPlanet = Q.Dequeue()
            If currentPlanet = targetPlanet Then Exit While
            If Not orbit.ContainsKey(currentPlanet) Then Continue While
            For Each adjacentPlanet In From adjacentPlanet1 In orbit(currentPlanet) Where Not discovered(adjacentPlanet1)
                discovered(adjacentPlanet) = True
                cameFrom(adjacentPlanet) = currentPlanet
                Q.Enqueue(adjacentPlanet)
            Next
        End While
        If returnCameFrom Then Return cameFrom
        Dim count = 0
        Dim backtrackPlanet = targetPlanet
        Do
            count += 1
            backtrackPlanet = cameFrom(backtrackPlanet)
        Loop Until backtrackPlanet = startingPlanet
        Return count
    End Function
End Module
