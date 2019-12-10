Imports System.IO
Imports System.Drawing
Module Monitoring_Station

    Function loadData() As List(Of Point)
        Dim asteriodPoints As New List(Of Point)
        Dim x = 0
        Dim y = 0
        Using reader = New StreamReader("S:\AoC\Advent of Code\Advent of Code\Day 10\test data 4.txt")
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
        Dim value As New asteroidValue(0, New Point(0, 0))
        For Each p1 In asteroids
            Dim count = 0
            For Each p2 In asteroids
                Dim blocked = False
                For Each p3 In From p31 In asteroids Where p1 <> p2 And p2 <> p31 And p31 <> p1
                    If isCollinear(p1, p2, p3) Then
                        If p1.X <> p2.X Then
                            If isBetween(p1.X, p3.X, p2.X) Then blocked = True
                        Else
                            If isBetween(p1.Y, p3.Y, p2.Y) Then blocked = True
                        End If
                    End If
                    If blocked Then Exit For
                Next
                If Not blocked Then count += 1
            Next
            If count > value.asteriodsVisible Then value.update(count - 1, p1)
        Next
        Return value.returnFinalValue()
    End Function

    Function part2()
        Dim asteroids = loadData()

        Dim stationLocation As New Point(11, 13)

        asteroids.Remove(stationLocation)

        Dim pointWithStuff As New List(Of distAnglePoint)

        For Each asteroid In asteroids
            Dim distance = getDistance(stationLocation, asteroid)
            Dim angle As Double = getAngle(stationLocation, asteroid)
            pointWithStuff.Add(New distAnglePoint(distance, angle, asteroid))
        Next
        'not 2517



        Console.WriteLine(pointWithStuff(0).angle)

        pointWithStuff = insertionSortByAngle(pointWithStuff)


        'get distAnglePoint where the angle is the same

        Dim newList As New List(Of List(Of distAnglePoint))

        Dim prevAngle As Double = 0
        newList.Add(New List(Of distAnglePoint) From {pointWithStuff(0)})
        For Each thing In pointWithStuff

            Dim currentAngle = Math.Round(thing.angle * 1000) / 1000
            Dim prevAngleRounded = Math.Round(prevAngle * 1000) / 1000
            If currentAngle = prevAngleRounded Then
                newList(newList.Count - 1).Add(thing)
            Else
                newList.Add(New List(Of distAnglePoint) From {thing})
            End If

            prevAngle = thing.angle

        Next

        pointWithStuff.Clear()

        For Each subList In newList

            If subList.Count > 2 Then
                Dim sortedList = insertionSortByDistance(subList)
                For Each thing In sortedList
                    pointWithStuff.Add(thing)
                Next
            Else
                pointWithStuff.Add(subList(0))
            End If

        Next




        Dim index = pointWithStuff.Count - 1

        Dim previousAngle As Double = -1

        Dim count = 0

        pointWithStuff.Reverse()

        Do

            Dim angle = pointWithStuff(index).angle

            If Math.Round(angle * 1000) / 1000 <> Math.Round(previousAngle * 1000) / 1000 Or pointWithStuff.Count <= 1 Then

                Dim returnPoint = pointWithStuff(index).point
                pointWithStuff.RemoveAt(index)
                count += 1
                If count = 200 Then
                    Return returnPoint.X * 100 + returnPoint.Y
                End If

            End If
            previousAngle = angle
            index -= 1
            If index < 0 Then index = pointWithStuff.Count - 1
        Loop

        Return "bad"
    End Function
    Function insertionSortByAngle(inputArr As List(Of distAnglePoint))
        Dim a = inputArr
        Dim i = 1
        While i < a.Count
            Dim j = i
            While j > 0 AndAlso a(j - 1).angle > a(j).angle
                Dim temp = a(j - 1)
                a(j - 1) = a(j)
                a(j) = temp
                j -= 1
            End While
            i += 1
        End While
        Return a
    End Function
    Function insertionSortByDistance(inputArr As List(Of distAnglePoint))
        Dim a = inputArr
        Dim i = 1
        While i < a.Count
            Dim j = i
            While j > 0 AndAlso a(j - 1).distance > a(j).distance
                Dim temp = a(j - 1)
                a(j - 1) = a(j)
                a(j) = temp
                j -= 1
            End While
            i += 1
        End While
        Return a
    End Function
    Function getDistance(p1 As Point, p2 As Point) As Integer
        Return (p1.X - p2.X) ^ 2 + (p1.Y - p2.Y) ^ 2
    End Function

    Function getAngle(p1 As Point, p2 As Point) As Double
        Dim vect As New Point(p1.X - p2.X, p1.Y - p2.Y)
        Dim toadd
        If p1.X < p2.X Then
            toadd = Math.PI
        Else
            toadd = 0
        End If
        Return toadd + Math.Acos(-vect.Y / Math.Sqrt(vect.X ^ 2 + vect.Y ^ 2))
    End Function

    Function isBetween(p1 As Integer, p2 As Integer, p3 As Integer)
        Return p1 <= p3 And p3 <= p2 Or p2 <= p3 And p3 <= p1
    End Function

    Function isCollinear(p1 As Point, p2 As Point, p3 As Point)
        Return 0 = (p1.X * (p2.Y - p3.Y) +
                    p2.X * (p3.Y - p1.Y) +
                    p3.X * (p1.Y - p2.Y))
    End Function

End Module
Class distAnglePoint
    Public distance As Integer
    Public angle As Double
    Public point As Point

    Public Sub New(newDist As Integer, newAngle As Double, newPoint As Point)
        distance = newDist
        angle = newAngle
        point = newPoint
    End Sub


End Class
Class asteroidValue
    Public asteriodsVisible As Integer
    Public coord As Point

    Public Sub New(inputVal As Integer, inputPoint As Point)
        asteriodsVisible = inputVal
        coord = inputPoint
    End Sub

    Public Function getValue()
        Return Me.asteriodsVisible
    End Function
    Public Sub update(newasteroidsVisible As Integer, newCoord As Point)
        asteriodsVisible = newasteroidsVisible
        coord = newCoord
    End Sub

    Public Function returnFinalValue()
        Return $"Asteriods visible: {asteriodsVisible}   Point: [{coord.X}, {coord.Y}]"
    End Function


End Class