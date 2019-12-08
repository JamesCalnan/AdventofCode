Imports System.Linq
Imports System.Drawing
Module Space_Image_Format
    Function part1()
        Dim input = My.Computer.FileSystem.ReadAllText("S:\AoC\Advent of Code\Advent of Code\Day 8\data.txt")

        Dim layers As New Dictionary(Of Integer, List(Of String))

        Dim width = 25
        Dim height = 6

        Dim layerNumber = 1

        Dim w = 0
        Dim h = 0

        For Each number In input

            If Not layers.ContainsKey(layerNumber) Then
                layers.Add(layerNumber, New List(Of String) From {number})
            Else
                layers(layerNumber).Add(number)
            End If
            w += 1
            If w = width And h = height - 1 Then
                layerNumber += 1
                w = 0
                h = 0
            End If
            If w = width Then
                w = 0
                h += 1
            End If
        Next

        Dim zeroValues As List(Of Integer) = (From item In layers.Keys Select layers(item).FindAll(Function(val) val = "0").Count).ToList()
        Return layers(zeroValues.IndexOf(zeroValues.Min()) + 1).FindAll(Function(val) val = "1").Count * layers(zeroValues.IndexOf(zeroValues.Min()) + 1).FindAll(Function(val) val = "2").Count

    End Function

    Function part2()
        Dim input = My.Computer.FileSystem.ReadAllText("S:\AoC\Advent of Code\Advent of Code\Day 8\data.txt")

        Dim layers As New Dictionary(Of Integer, List(Of String))

        Dim width = 25
        Dim height = 6

        Dim layerNumber = 1

        Dim w = 0
        Dim h = 0



        For Each number In input

            If Not layers.ContainsKey(layerNumber) Then
                layers.Add(layerNumber, New List(Of String) From {number})
            Else
                layers(layerNumber).Add(number)
            End If
            w += 1
            If w = width And h = height - 1 Then
                layerNumber += 1
                w = 0
                h = 0
            End If
            If w = width Then
                w = 0
                h += 1
            End If
        Next

        'loop through each layer
        'look at the data at specific position
        'store the image data preserving the layer order
        'decide what to be outputted at specific pixel



        Dim x As Integer = 0
        Dim y As Integer = 0


        Dim imageData As New Dictionary(Of Point, List(Of String))

        For Each item In layers
            For Each listItem In item.Value
                If x = width Then
                    x = 0
                    y += 1
                End If
                If Not imageData.ContainsKey(New Point(x, y)) Then
                    imageData.Add(New Point(x, y), New List(Of String) From {listItem})
                Else
                    imageData(New Point(x, y)).Add(listItem)
                End If
                x += 1
            Next
            y = 0
            x = 0
        Next

        For Each item In imageData
            Console.SetCursorPosition(item.Key.X, item.Key.Y)
            Console.BackgroundColor = returnColour(item.Value)
            Console.ForegroundColor = returnColour(item.Value)
            Console.Write("X")
        Next


    End Function
    Function returnColour(colours As List(Of String)) As ConsoleColor
        For Each colour In colours
            If colour = "0" Then
                Return ConsoleColor.Black
            ElseIf colour = "1" Then
                Return ConsoleColor.White
            ElseIf colour = "2" Then
                Continue For
            End If
        Next
        Return Nothing
    End Function
End Module
