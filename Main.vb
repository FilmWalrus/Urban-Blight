Public Class Main

#Region " Variables "

    '--
    Public MyGUI As MainForm = Nothing

    '--
    Dim WinFlag As Boolean = False

    '--
    Dim SelectedCard As Integer = CardEnum.NoCard
    Dim SelectedCity As CitySquare = Nothing
    Dim SelectedPerson As Integer = -1
    Dim SelectedBuilding As Integer = -1
    Dim SelectedView As Integer = 0

    '--
    Public theYear As Integer = 1

#End Region

#Region " New "

    Sub New()

    End Sub

#End Region

#Region " Sets "

    Public Sub SetCurrentPlayer(ByRef NewPlayer As Player)
        CurrentPlayer = NewPlayer
        '-- Highlight current player
        MyGUI.HighlightCurrentPlayer()
    End Sub

    Public Sub SetSelectedCard(ByVal NewCard As Integer)
        SelectedCard = NewCard

        '-- If the user selected the Building of Choice card without a building there, consider that selecting no card
        If SelectedCard = CardEnum.BuildingSpecialOrder And Cards(CardEnum.BuildingSpecialOrder) Is Nothing Then
            SelectedCard = CardEnum.NoCard
        End If
    End Sub

    Public Sub SetSelectedPerson(ByVal NewPerson As Integer)
        SelectedPerson = NewPerson
        '-- Display the new person information
        MyGUI.DisplaySelectedPerson(SelectedPerson)
    End Sub

    Public Sub SetSelectedBuilding(ByVal NewBuilding As Integer)
        SelectedBuilding = NewBuilding
        '-- Display the new building information
        MyGUI.DisplaySelectedBuilding(SelectedBuilding)
    End Sub

    Public Sub SetSelectedCity(ByRef NewCity As CitySquare)
        SelectedCity = NewCity
        '-- Display the new city information
        MyGUI.UpdateTextBox(TabsEnum.City, SelectedCity.toString())
    End Sub

    Public Sub SetSelectedView(ByVal NewView As Integer)
        SelectedView = NewView
        UpdateView()
    End Sub

    Public Sub SetWinFlag(ByVal WinState As Boolean)
        WinFlag = WinState
    End Sub

#End Region

#Region " Gets "

    Public Function GetSelectedCard() As Integer
        Return SelectedCard
    End Function

    Public Function GetSelectedPerson() As Integer
        Return SelectedPerson
    End Function

    Public Function GetSelectedBuilding() As Integer
        Return SelectedBuilding
    End Function

    Public Function GetSelectedView() As Integer
        Return SelectedView
    End Function

    Public Function GetSelectedCity() As CitySquare
        Return SelectedCity
    End Function



#End Region

    Function Build() As Boolean
        Dim UpdateNeeded As Boolean = False
        Dim SpendingMoney As Integer = CurrentPlayer.TotalMoney

        '-- What is the cost of this card?
        Dim CardCost As Integer = 0
        If SelectedCard = CardEnum.Road Or SelectedCard = CardEnum.RoadMax Then
            CardCost = RoadCostBase
        ElseIf SelectedCard = CardEnum.Land Then
            If SelectedCity.Terrain = TerrainEnum.Swamp Then
                CardCost = 0 '-- Swamps are free!
            Else
                CardCost = CurrentPlayer.GetPlayerLandCost()
            End If
        ElseIf SelectedCard = CardEnum.WipeBuildings Then
            CardCost = CurrentPlayer.GetPlayerWipeCost()
        ElseIf SelectedCard >= 0 And SelectedCard < Cards.Length Then
            If Cards(SelectedCard) Is Nothing Then
                Return False
            End If
            CardCost = Cards(SelectedCard).GetPurchasePrice()
        Else
            Return False
        End If

        '-- Was the selected CitySquare valid?
        If SelectedCard = CardEnum.Land Then
            '-- For Land cards they must be unowned, adjacent to land the player already owns, and not a lake
            If Not CurrentPlayer.IsValidLandExpansion(SelectedCity) Then
                Return False
            End If
        ElseIf SelectedCard >= 0 And SelectedCard < Cards.Length Then
            '-- For road cards the location must be owned by the player or, with an embassy, another player
            If Not CurrentPlayer.IsValidBuild(SelectedCity, CardCost) Then
                Return False
            End If
        ElseIf SelectedCard = CardEnum.Road Or SelectedCard = CardEnum.RoadMax Then
            '-- For Roads the player must already own the land and highway can't already be present
            If (Not SelectedCity.IsOwned(CurrentPlayer.ID)) Or SelectedCity.Transportation = RoadEnum.Highway Then
                Return False
            End If
        End If

        '-- Can the player afford it?
        If CardCost > SpendingMoney Then
            Return False
        ElseIf SelectedCard = CardEnum.BuildingSpecialOrder Then
            '-- If you bought a building of your choice, reduce your choice money by the cost
            CurrentPlayer.SpecialOrderCap -= CardCost
            '-- Also increase the special order price of this building type for this player
            CurrentPlayer.SpecialOrderOffsets(Cards(SelectedCard).Type) += 50
        End If

        '-- Pay for construction
        CurrentPlayer.TotalMoney -= CardCost
        UpdateNeeded = True

        '-- Do construction
        If SelectedCard = CardEnum.Road Or SelectedCard = CardEnum.RoadMax Then
            '-- Upgrade Road
            SelectedCity.AddRoad()
        ElseIf SelectedCard = CardEnum.Land Then
            '-- Expand Territory
            SelectedCity.Occupy(CurrentPlayer.ID)

            '-- Handle special terrain bonuses
            If SelectedCity.Terrain = TerrainEnum.Desert Then
                '-- Desert effect: rebate
                CurrentPlayer.TotalMoney += SafeDivide(CardCost, 2)
            ElseIf SelectedCity.Terrain = TerrainEnum.Dirt Then
                '-- Dirt effect: free road
                SelectedCity.Transportation = RoadEnum.Dirt
            ElseIf SelectedCity.Terrain = TerrainEnum.Mountain Then
                '-- Rock effect: free building
                Dim randNum As Integer = GetRandom(0, CardEnum.BuildingSpecialOrder - 1)
                Dim newBuilding As Building = Cards(randNum)
                newBuilding.PurchasePrice = 0
                newBuilding.Location = SelectedCity
                SelectedCity.AddBuilding(newBuilding, CurrentPlayer.ID)
                SetSelectedBuilding(SelectedCity.Buildings.Count - 1)
                Cards(randNum) = Nothing
            ElseIf SelectedCity.Terrain = TerrainEnum.Township Then
                '-- Township effect: free population
                Dim maxFreePopulation As Integer = Math.Min(10, Math.Floor(SafeDivide(CurrentPlayer.GetPlayerPopulationCount(), 15.0)) + 2)
                Dim randNum As Integer = GetRandom(2, maxFreePopulation)
                For i As Integer = 0 To randNum - 1
                    Dim founder As New Citizen(True)
                    SelectedCity.AddPerson(founder)
                Next
            End If
        ElseIf SelectedCard >= 0 And SelectedCard < Cards.Length Then
            '-- Create Building
            Cards(SelectedCard).PurchasePrice = CardCost
            SelectedCity.AddBuilding(Cards(SelectedCard), CurrentPlayer.ID)
            SetSelectedBuilding(SelectedCity.Buildings.Count - 1)
            Cards(SelectedCard) = Nothing
        ElseIf SelectedCard = CardEnum.WipeBuildings Then
            For i As Integer = 0 To Cards.Length - 1
                Cards(i) = Nothing
            Next
            CurrentPlayer.WipeCost = WipeCostBase + 5
        End If

        '-- Update grid, cards, and players
        If UpdateNeeded Then

            If SelectedCard = CardEnum.RoadMax Then
                '-- If road max was selected keep building more road
                Build()
            ElseIf SelectedCard = CardEnum.WipeBuildings Then
                '-- Check for extra redraws
                CheckForExtraRedraws()
            End If

            UpdateAll()
        End If

        Return True
    End Function

#Region " Update Info "
    Sub UpdateAll()
        UpdateGrid()
        UpdateCards(True)
        SelectedCard = CardEnum.NoCard
        MyGUI.UpdateButtonSelection()
        MyGUI.DisplayPlayerText()
        If SelectedCity IsNot Nothing Then
            MyGUI.UpdateTextBox(TabsEnum.City, SelectedCity.toString())
        End If
    End Sub

    Sub UpdateGrid()
        For Each CurrentLocation As CitySquare In GridArray
            CurrentLocation.UpdateGridSquare(SelectedView)
        Next
    End Sub

    Sub UpdateCards(ByVal DropPrices As Boolean)

        '-- Adjust cost of redraw and building of your choice
        If DropPrices Then
            '-- Reduce cost for this player to wipe the buildings cards by 5 (no lower limit)
            CurrentPlayer.WipeCost -= DropCostBase

            '-- Increase the Special Order cap for this player
            CurrentPlayer.UpdateSpecialOrderCap()

            '-- Fill the dropdown with the buildings this player can choose
            MyGUI.FillBuildingDropdown()
        End If

        '-- Adjust costs of building market and refill if any are missing
        For i As Integer = 0 To Cards.Length - 1
            Dim CardBuilding As Building = Cards(i)

            If CardBuilding Is Nothing Then
                If i <> CardEnum.BuildingSpecialOrder Then
                    '-- Refill the building market to full
                    Dim NewBulidingType As Integer = -1

                    '-- If the player has polling stations, let them determine the next building for the market
                    Dim PollingOptions As Integer = CurrentPlayer.GetPollingOptions()
                    If PollingOptions > 1 And SelectedCard <> CardEnum.WipeBuildings And CurrentPlayer.PlayerType = PlayerTypeEnum.Human Then
                        Dim PollScreen As New PollingScreen(PollingOptions)
                        PollScreen.ShowDialog()
                        NewBulidingType = PollScreen.BuildingChoice
                    End If

                    CardBuilding = BuildingGenerator.CreateBuilding(NewBulidingType)
                    Cards(i) = CardBuilding
                End If
            Else
                '-- If no player bought this building even for free, replace it
                If CardBuilding.IsBuildingUnwanted(CurrentPlayer) Then
                    Dim newBuilding As Building = BuildingGenerator.CreateBuilding(-1)
                    Cards(i) = newBuilding
                End If

                If DropPrices Then
                    '-- Reduce cost of available buildings
                    CardBuilding.DropPrice()
                End If
            End If

            Dim cardText As String = ""

            If CardBuilding Is Nothing Then
                '-- Display the player's Choice cost
                cardText += "Special Order" + ControlChars.NewLine
                cardText += "$" + CurrentPlayer.GetSpecialOrderCap().ToString() + " - Cap"
            Else
                '-- Adjust the purchase price for this player
                CardBuilding.AdjPurchasePrice(CurrentPlayer, i)

                '--Update building card text
                cardText += CardBuilding.GetName() + ControlChars.NewLine
                cardText += "$" + CardBuilding.GetPurchasePrice().ToString() + " - "
                cardText += CardBuilding.Jobs.ToString() + " Jobs"
            End If

            MyGUI.UpdateButtonText(i, cardText)
        Next

        '-- Update wipe card text
        Dim WipeCost As Integer = CurrentPlayer.GetPlayerWipeCost()
        MyGUI.UpdateButtonText(CardEnum.WipeBuildings, "$" + WipeCost.ToString() + " - Redraw Above")

        '-- Update road card text
        Dim RoadCost As Integer = RoadCostBase
        MyGUI.UpdateButtonText(CardEnum.Road, "$" + RoadCost.ToString() + " - Road")

        '-- Update land card text
        Dim LandCost As Integer = CurrentPlayer.GetPlayerLandCost()
        MyGUI.UpdateButtonText(CardEnum.Land, "$" + LandCost.ToString() + " - Land")

        '-- Set whether the building buttons are enabled for this player
        MyGUI.UpdateButtonEnables()

    End Sub

    Public Sub ChangePlayerMoney(ByVal PlayerId As Integer, ByVal MoneyChange As Integer)
        Players(PlayerId).TotalMoney += MoneyChange
        MyGUI.DisplayPlayerText()
    End Sub

    Sub CheckForExtraRedraws()
        If CurrentPlayer.PlayerType <> PlayerTypeEnum.Human Then
            Return
        End If

        For i As Integer = 0 To CurrentPlayer.ThinkTankCount - 1
            UpdateCards(False)
            Dim msgRslt As MsgBoxResult = MsgBox("Redraw a new set of buildings for free?", MsgBoxStyle.YesNo)
            If msgRslt = MsgBoxResult.Yes Then
                For j As Integer = 0 To Cards.Length - 1
                    Cards(j) = Nothing
                Next
            ElseIf msgRslt = MsgBoxResult.No Then
                Exit For
            End If
        Next
    End Sub

    Public Sub RenameCurrentCity()
        Dim CName As New RenameCity
        CName.ShowDialog()
        SelectedCity.CityName = LastCityName
        MyGUI.UpdateTextBox(TabsEnum.Building, SelectedCity.toString())
    End Sub

    Public Sub CloseCurrentBuilding()
        '-- Prompt the player to see if they want to close this building
        Dim theBuilding As Building = SelectedCity.Buildings(SelectedBuilding)
        Dim ClosurePrice As Integer = Math.Max(20, theBuilding.GetPurchasePrice() - theBuilding.Age)
        Dim ClosureQuery As String = "Close " + theBuilding.GetNameAndAddress() + " for $" + ClosurePrice.ToString() + "?"

        Dim result As Integer = MessageBox.Show(ClosureQuery, "Close Building", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            '-- Make sure the player can afford it
            If CurrentPlayer.TotalMoney < ClosurePrice Then
                Return
            Else
                ChangePlayerMoney(CurrentPlayer.ID, -ClosurePrice)
            End If

            '-- Close the building
            theBuilding.Location.ClosedHistory += 1
            theBuilding.Destroy()

            '-- Set to the next building if this one was closed
            CycleThroughBuildings(False, True)
            CycleThroughBuildings(True, True)
        End If
    End Sub

#End Region

    Sub ResetForNewTurn()
        If SelectedCity IsNot Nothing Then
            SelectedCity.GridSquare.BorderStyle = BorderStyle.FixedSingle
        End If

        SelectedCard = CardEnum.NoCard
        Cards(CardEnum.BuildingSpecialOrder) = Nothing

        MyGUI.UpdateButtonSelection()
        MyGUI.ClearTexts()
        Diary.ClearEvents()

        SetSelectedBuilding(0)
        SetSelectedPerson(0)
        SetSelectedView(ViewEnum.Population)
    End Sub

    Public Sub CycleThroughPersons(ByVal CycleForward As Boolean, ByVal LoopAround As Boolean)
        If SelectedCity Is Nothing Then
            Return
        End If

        Dim CityPopulation As Integer = SelectedCity.getPopulation()
        If CityPopulation = 0 Then
            Return
        End If

        '-- Cycle forward or backward
        Dim NewSelectedPerson As Integer = SelectedPerson
        If CycleForward Then
            NewSelectedPerson += 1
        Else
            NewSelectedPerson -= 1
        End If

        '-- Optionally loop around
        If NewSelectedPerson < 0 Then
            If LoopAround Then
                NewSelectedPerson = CityPopulation - 1
            Else
                Return
            End If
        ElseIf NewSelectedPerson >= CityPopulation Then
            If LoopAround Then
                NewSelectedPerson = 0
            Else
                Return
            End If
        End If

        '-- Display the new person information
        SetSelectedPerson(NewSelectedPerson)
    End Sub

    Public Sub CycleThroughBuildings(ByVal CycleForward As Boolean, ByVal LoopAround As Boolean)
        If SelectedCity Is Nothing Then
            Return
        End If

        Dim CityBuildings As Integer = SelectedCity.getDevelopment()
        If CityBuildings = 0 Then
            SetSelectedBuilding(0)
            Return
        End If

        '-- Cycle forward or backward
        Dim NewSelectedBuilding As Integer = SelectedBuilding
        If CycleForward Then
            NewSelectedBuilding += 1
        Else
            NewSelectedBuilding -= 1
        End If

        '-- Optionally loop around
        If NewSelectedBuilding < 0 Then
            If LoopAround Then
                NewSelectedBuilding = CityBuildings - 1
            Else
                Return
            End If
        ElseIf NewSelectedBuilding >= CityBuildings Then
            If LoopAround Then
                NewSelectedBuilding = 0
            Else
                Return
            End If
        End If

        '-- Display the new person information
        SetSelectedBuilding(NewSelectedBuilding)
    End Sub

#Region " Views "

    Public Sub CycleThroughViews(ByVal CycleForward As Boolean, ByVal LoopAround As Boolean)

        '-- Cycle forward or backward
        Dim NewSelectedView As Integer = SelectedView
        If CycleForward Then
            NewSelectedView += 1
        Else
            NewSelectedView -= 1
        End If

        '-- Optionally loop around
        If NewSelectedView < 0 Then
            If LoopAround Then
                NewSelectedView = SelectedView - 1
            Else
                Return
            End If
        ElseIf NewSelectedView >= ViewEnum.EndEnum Then
            If LoopAround Then
                NewSelectedView = 0
            Else
                Return
            End If
        End If

        '-- Display the new view information
        SetSelectedView(NewSelectedView)
    End Sub

    Public Sub UpdateView()
        MyGUI.ViewDropdown.SelectedIndex = SelectedView
        MyGUI.UpdateTitle()
        UpdateGrid()
    End Sub

    Public Sub ResetView()
        If Not (GetSelectedView() = ViewEnum.Roads And GetSelectedCard() = CardEnum.Road) Then
            SetSelectedView(ViewEnum.Population)
        End If
    End Sub

#End Region

    Public Function GetSelectedCardText() As String
        Dim cardText As String = ""
        If (SelectedCard > CardEnum.NoCard And SelectedCard <= CardEnum.Building4) Then
            cardText += Cards(SelectedCard).toString()
        ElseIf SelectedCard = CardEnum.BuildingSpecialOrder Then
            If Cards(SelectedCard) Is Nothing Then
                cardText += "You can special order a building of your choice from the dropdown so long as its special order price is within your cap." + ControlChars.NewLine + ControlChars.NewLine
                cardText += "Your cap increases by $10 after every action you take. If you build a special order your cap drops by the purchase price. "
                cardText += "Each additional special order of the same building type costs $50 more than the previous."
            Else
                cardText += Cards(SelectedCard).toString()
            End If
        ElseIf SelectedCard = CardEnum.RoadMax Then
            cardText += "Increase road on a square to the maximum level you can afford."
        ElseIf SelectedCard = CardEnum.Road Then
            cardText += "Roads help increase the mobility of you population and allows them to reach nearby squares within your kingdom. Roads always cost " + RoadCostBase.ToString()
        ElseIf SelectedCard = CardEnum.Land Then
            cardText += "Land can only be bought adjacent to land you already own. The cost increases by 20 after every time you buy."
        ElseIf SelectedCard = CardEnum.WipeBuildings Then
            cardText += "Redraw discards the currently available buildings and draws new ones, for the base price of $100. Click anywhere on the map to confirm." + ControlChars.NewLine + ControlChars.NewLine
            cardText += "Like with buildings, the cost drops $5 after every action you take." + ControlChars.NewLine + ControlChars.NewLine
            cardText += "Unlike buildings, the cost is unique to each player and can go below $0."
        End If
        Return cardText
    End Function

#Region " Game Over "
    Public Sub GameOver()
        Dim GameTypeText As String = ""
        Dim WinningString As String = ""
        Dim maxValue As Integer = 0
        Dim currentValue As Integer = 0
        Dim winningPlayer As Integer = -1
        For i As Integer = 0 To Players.Count - 1
            Dim currentPlayer As Player = Players(i)

            Select Case GameType
                Case GameEnum.Score
                    GameTypeText = "Score"
                    currentValue = currentPlayer.GetPlayerScore()
                Case GameEnum.Territory
                    GameTypeText = "Territory"
                    currentValue = currentPlayer.GetPlayerTerritoryCount()
                Case GameEnum.Population
                    GameTypeText = "Population"
                    currentValue = currentPlayer.GetPlayerPopulationCount()
                Case GameEnum.Development
                    GameTypeText = "Development"
                    currentValue = currentPlayer.GetPlayerDevelopment()
                Case GameEnum.Year
                    GameTypeText = "Score"
                    currentValue = currentPlayer.GetPlayerScore()
            End Select

            WinningString += "Player " + (i + 1).ToString + " " + GameTypeText + ": " + currentValue.ToString + ControlChars.NewLine
            If currentValue > maxValue Then
                maxValue = currentValue
                winningPlayer = i + 1
            End If
        Next
        WinningString += ControlChars.NewLine + "The winner is: Player " + winningPlayer.ToString + ControlChars.NewLine


        Dim EndingScreen As New GameOver(WinningString)
        If EndingScreen.ShowDialog = DialogResult.Yes Then
            MyGUI.StartNewGame()
        ElseIf EndingScreen.DialogResult = DialogResult.No Then
            MyGUI.DialogResult = DialogResult.No
            MyGUI.Close()
        Else
            WinFlag = False
            GameType = GameEnum.Infinite
        End If
    End Sub
#End Region

End Class
