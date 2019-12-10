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

        Dim value As New asteroidValue(0, New Point(0, 0))

        resetGrid(asteroids)



        For Each point1 In asteroids
            'current point
            Console.ForegroundColor = ConsoleColor.Cyan
            Console.SetCursorPosition(point1.X, point1.Y)
            Console.Write("X")
            Dim currentStationValue As New asteroidValue(0, point1)
            For Each point2 In asteroids
                Console.ForegroundColor = ConsoleColor.Red
                Console.SetCursorPosition(point1.X, point1.Y)
                Console.Write("X")
                'need to check if this point is in front of the point3
                For Each point3 In asteroids

                    Console.ForegroundColor = ConsoleColor.Green
                    Console.SetCursorPosition(point1.X, point1.Y)
                    Console.Write("X")
                    Console.ReadKey()
                    'need to check if this point is on the same line as point1 and 
                    If isCollinear(point1, point2, point3) Then
                        'the 3 points are on a straight line
                        'need to check if point2 is in the middle of p1 and p3
                        If point1.X <> point3.X Then
                            If isBetween(point1.X, point2.X, point3.X) Then
                                'not a valid point as point2 is in front of point3 
                                Exit For
                            Else
                                'is on a line with point2 & 3 but point 2 isnt in front of 3
                                currentStationValue.asteriodsVisible += 1
                            End If
                        Else
                            If isBetween(point1.Y, point2.Y, point3.Y) Then
                                'not a valid point as point2 is in front of point3 
                                Exit For
                            Else
                                'is on a line with point2 & 3 but point 2 isnt in front of 3
                                currentStationValue.asteriodsVisible += 1
                            End If
                        End If
                    Else
                        'not collinear
                        Exit For
                    End If
                Next
            Next
        Next


        Return Nothing
    End Function
    Sub resetGrid(asteroids As List(Of Point))
        Console.Clear()
        Console.ResetColor()

        For Each point In asteroids
            Console.SetCursorPosition(point.X, point.Y)
            Console.Write("X")
        Next
    End Sub

    Function isBetween(p1 As Integer, p2 As Integer, p3 As Integer)
        Return p1 <= p2 <= p3 Or p3 <= p2 <= p1
    End Function

    Function isCollinear(p1 As Point, p2 As Point, p3 As Point)
        Return 0 = (p1.X * (p2.Y - p3.Y) +
                    p2.X * (p3.Y - p1.Y) +
                    p3.X * (p1.Y - p2.Y))
    End Function

End Module
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