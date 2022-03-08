'Fallon Smith
'RCET0265
'Spring 2022
'Shuffle the Deck
'https://github.com/SmitFall/ShuffleTheDeck

Option Strict On
Option Explicit On

Module ShuffleTheDeck

    Sub Main()
        Dim DeltHand(3, 12) As Boolean
        Dim Suit As Integer
        Dim Card As Integer
        Dim trys As Integer

        For i = 0 To 75

            'test to see if the card has already been drawn
            'Yes: Do not display card again and redraw
            'No: Mark the card true in the table and display it

            Do
                trys += 1
                Suit = RandomNumberInRange(3)
                Card = RandomNumberInRange(12)
            Loop While DeltHand(Suit, Card)

            DeltHand(Suit, Card) = True

            Console.Clear()
            DisplayDeltHand(DeltHand)
            trys = 0
            Console.ReadLine()

        Next

        DisplayDeltHand(DeltHand)
        Console.Read()
        'press enter to draw a card
    End Sub

    Sub DisplayDeltHand(ByRef DeltHand(,) As Boolean)
        Dim header() As String = {"Hearts", "Spades", "Clubs", "Diamonds"}
        Dim columnWidth As Integer = 8
        Dim columnData As String

        For row = 0 To DeltHand.GetLength(1)
            For column = 0 To DeltHand.GetLength(0) - 1
                Select Case row
                    Case 0 'first row is column headers
                        columnData = header(column).PadLeft(columnWidth)
                    Case Else
                        If Not DeltHand(column, row - 1) Then 'mark if ball has been drawn
                            columnData = "  "
                        Else 'show number if ball hasn't been drawn
                            columnData = CStr(row)
                            If row = 1 Then
                                columnData = ("Ace")
                            ElseIf row = 11 Then
                                columnData = ("Jack")
                            ElseIf row = 12 Then
                                columnData = ("Queen")
                            ElseIf row = 13 Then
                                columnData = ("King")
                            End If

                        End If
                End Select
                Console.Write(columnData.PadLeft(columnWidth) & " |")
            Next
            Console.WriteLine()


        Next

    End Sub


    ''' <summary>
    ''' The default range is 0 - 10.
    ''' The maximum number must be greater than minimum number.
    ''' </summary>
    ''' <param name="max%"></param>
    ''' <param name="min%"></param>
    ''' <returns>Returns a random integer within a range defined by the max and min arguments.</returns>
    ''' <exception cref="System.ArgumentException">Thrown when <c>max > min</c></exception>
    Function RandomNumberInRange(Optional max% = 10%, Optional min% = 0%) As Integer
        Dim _max% = max - min
        If _max < 0 Then
            Throw New System.ArgumentException("Maximum number must be greater than minimum number")
        End If
        Randomize(DateTime.Now.Millisecond)
        Return CInt(System.Math.Floor(Rnd() * (_max + 1))) + min
    End Function

End Module
