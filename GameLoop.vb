Partial Public Class MainForm

#Region " Game Loop "
    Sub NextPlayer()
        '-- Cleanup
        ResetForNewTurn()

        '--Advance to next player (If last player in round and end condition is met, show Game Over screen)
        AdvanceToNextPlayer()

        '-- Handle events: births, deaths, movement, employment, crime, taxation, and business expansion
        EventsHappen()

        '-- Update grid, players, and cards
        UpdateAll()

        '-- Take turn automatically if AI
        RunAI()

        '-- Display event messages
        UpdateTextBox(txt_event, Diary.toString())
        Infotab.SelectedTab = Infotab.TabPages(EventTab)
        UpdateTabs()

    End Sub

    Sub RunAI()

        '-- Toggle the buttons so humans can't play for the computer
        UpdateButtonEnables()

        '-- If not an AI bail at this point
        If CurrentPlayer.PlayerType <> PlayerAI Then
            Return
        End If

        Dim AIActionEvents As String = ""
        Dim AIActionCount As Integer = 0

        '-- Loop until the AI does not have enough money for the action they want to take.
        Dim ActionSuccess As Boolean = False
        Do
            '-- Get the AIs decision (the action they chose and where they chose to make it)
            Dim AIDecision As Integer = CurrentPlayer.ChooseNextAction(Cards)

            If AIDecision = AIPass Then
                ActionSuccess = False
            Else
                SelectedCard = AIDecision
                ClickCity = CurrentPlayer.BestMove
                ActionSuccess = Build()
            End If

            If ActionSuccess Then
                AIActionCount += 1
                If AIDecision >= 0 And AIDecision < CardCount Then
                    Dim newBuilding As Building = ClickCity.Buildings(ClickCity.Buildings.Count - 1) '-- Get latest building
                    Diary.AIBuildEvents.AddEvent(CurrentPlayer.GetPlayerName() + " bought a " + newBuilding.GetNameAndAddress())
                ElseIf AIDecision = RoadCard Then
                    Diary.AIRoadEvents.AddEvent(CurrentPlayer.GetPlayerName() + " upgraded the road at " + ClickCity.GetName())
                ElseIf AIDecision = LandCard Then
                    Diary.AILandEvents.AddEvent(CurrentPlayer.GetPlayerName() + " founded " + ClickCity.GetName() + " at " + ClickCity.GetLocationText())
                End If
            ElseIf AIActionCount = 0 Then
                Diary.AILandEvents.AddEvent(CurrentPlayer.GetPlayerName() + " passed on their turn")
            End If

        Loop While ActionSuccess


    End Sub

    Sub AdvanceToNextPlayer()
        '-- Move to next human or AI player. 
        Do
            CurrentPlayerIndex += 1
            If CurrentPlayerIndex = Players.Count Then
                CurrentPlayerIndex = 0

                '-- If this was the end of the round, advance the clock
                theYear += TimeIncrement
                UpdateTitle()

                '-- Check for a winner
                If (GameType = YearGame And theYear >= GoalNumber) Or WinFlag = True Then
                    GameOver()
                End If
            End If
            CurrentPlayer = Players(CurrentPlayerIndex)
        Loop While CurrentPlayer.PlayerType = PlayerNone

        '-- Highlight current player
        HighlightCurrentPlayer()

        '-- Update player info
        CurrentPlayer.GetPlayerScore()
    End Sub

    Sub EventsHappen()
        Dim TurnEvents As New Turn(CurrentPlayer, theYear)
        TurnEvents.UpdatePeople()
    End Sub

#End Region

End Class
