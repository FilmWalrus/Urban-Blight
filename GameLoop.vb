Partial Public Class Main

#Region " Game Loop "
    Sub StartTurn()

        '-- Cleanup
        ResetForNewTurn()

        '-- Handle events: births, deaths, movement, employment, crime, taxation, and business expansion
        EventsHappen()

        '-- Update grid, players, and cards
        UpdateAll()

        '-- Take turn automatically if AI
        RunAI()

        '-- Display event messages
        MyGUI.UpdateTextBox(TabsEnum.Events, Diary.toString())
        MyGUI.SetTab(TabsEnum.Events)

    End Sub

    Sub EndTurn()
        '-- Advance to next player (If last player in round and end condition is met, show Game Over screen)
        AdvanceToNextPlayer()

        '-- Start the next turn
        StartTurn()
    End Sub

    Sub RunAI()
        '-- Toggle the buttons so humans can't play for the computer
        MyGUI.UpdateButtonEnables()

        '-- If not an AI bail at this point
        If CurrentPlayer.PlayerType <> PlayerTypeEnum.AI Then
            Return
        End If

        Dim AIActionEvents As String = ""
        Dim AIActionCount As Integer = 0

        '-- Loop until the AI does not have enough money for the action they want to take.
        Dim ActionSuccess As Boolean = False
        Do
            '-- Get the AIs decision (the action they chose and where they chose to make it)
            Dim AIDecision As Integer = CurrentPlayer.ChooseNextAction(Cards)

            If AIDecision = CardEnum.NoCard Then
                ActionSuccess = False
            Else
                SelectedCard = AIDecision
                SetSelectedCity(CurrentPlayer.BestMove)
                ActionSuccess = Build()
            End If

            If ActionSuccess Then
                AIActionCount += 1
                If AIDecision >= 0 And AIDecision <= CardEnum.BuildingSpecialOrder Then
                    Dim newBuilding As Building = SelectedCity.Buildings(SelectedCity.Buildings.Count - 1) '-- Get latest building
                    Diary.AIBuildEvents.AddEvent(CurrentPlayer.GetPlayerName() + " bought a " + newBuilding.GetNameAndAddress())
                ElseIf AIDecision = CardEnum.Road Then
                    Diary.AIRoadEvents.AddEvent(CurrentPlayer.GetPlayerName() + " upgraded the road at " + SelectedCity.GetName())
                ElseIf AIDecision = CardEnum.Land Then
                    Diary.AILandEvents.AddEvent(CurrentPlayer.GetPlayerName() + " founded " + SelectedCity.GetName() + " at " + SelectedCity.GetLocationText())
                End If
            ElseIf AIActionCount = 0 Then
                Diary.AILandEvents.AddEvent(CurrentPlayer.GetPlayerName() + " passed on their turn")
            End If

        Loop While ActionSuccess


    End Sub

    Sub AdvanceToNextPlayer()
        '-- Move to next human or AI player. 
        Do
            Dim NextPlayerID As Integer = CurrentPlayer.ID + 1
            If NextPlayerID = Players.Count Then
                NextPlayerID = 0

                '-- If this was the end of the round, advance the clock
                theYear += TimeIncrement
                MyGUI.UpdateTitle()

                '-- Check for a winner
                If (GameType = GameEnum.Year And theYear >= GoalNumber) Or WinFlag = True Then
                    GameOver()
                End If
            End If
            UrbanBlight.SetCurrentPlayer(Players(NextPlayerID))
        Loop While CurrentPlayer.PlayerType = PlayerTypeEnum.None

        '-- Update player info
        CurrentPlayer.GetPlayerScore()
    End Sub

    Sub EventsHappen()
        Dim TurnEvents As New Turn(theYear)
        TurnEvents.UpdatePeople()
    End Sub

#End Region

End Class
