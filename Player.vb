Public Class Player

#Region " Variables "
    Public PlayerType As Integer = PlayerTypeEnum.Human
    Public ID As Integer = 0
    Public Score As Integer = 0
    Public Flag As System.Drawing.Color = System.Drawing.Color.Black

    '-- Player Stats
    Public TotalMoney As Integer = 0
    Public TotalPopulation As Integer = 0
    Public TotalJobs As Integer = 0
    Public TotalEmployed As Integer = 0
    Public TotalTerritory As Integer = 0
    Public TotalDevelopment As Integer = 0
    Public TotalScore As Integer = 0

    '--
    Public WipeCost As Integer = WipeCostBase
    Public SpecialOrderCap As Integer = 0

    '-- Special order costs
    Public SpecialOrderOffsets(BuildingGen.BuildingEnum.BuildingCount) As Integer

    '-- Stuff that effects player's choices
    Public BannedBuildings As New List(Of Integer)
    Public BlackMarketList As New List(Of BlackMarketBuilding)
    Public ExurbStations As New List(Of Building)
    Public LandOptionBuildings As New List(Of Building)

    Public CommerceCount As Integer = 0
    Public EmbassyCount As Integer = 0
    Public GovernmentCount As Integer = 0
    Public PollCount As Integer = 0
    Public ThinkTankCount As Integer = 0

    '-- AI stuff
    Public BestMove As CitySquare = Nothing
    Public Personality As AIPersonality = Nothing

#End Region

#Region " New "
    Public Sub New(ByVal myID As Integer)
        ID = myID
        Score = 0
        TotalMoney = 110
        PlayerType = PlayerTypeEnum.Human

        '-- Zero out the special order offsets
        For i As Integer = 0 To SpecialOrderOffsets.Length - 1
            SpecialOrderOffsets(i) = 0
        Next
    End Sub

    Public Sub SetPersonality()
        If PlayerType = PlayerTypeEnum.AI Then
            Personality = New AIPersonality()
        End If
    End Sub

#End Region

#Region " Functions "

    Function GetPlayerName() As String
        Dim playerName As String = "Player " + (ID + 1).ToString()
        If PlayerType = PlayerTypeEnum.Human Then
            'playerName += ", Human"
        ElseIf PlayerType = PlayerTypeEnum.AI Then
            playerName += ", AI"
        Else
            playerName += ", ?"
        End If

        Return playerName
    End Function

    Function GetPlayerPopulation() As List(Of Citizen)
        Dim populationArray As New List(Of Citizen)
        For i As Integer = 0 To GridWidth
            For j As Integer = 0 To GridHeight
                Dim thisLocation As CitySquare = GridArray(i, j)
                If thisLocation.IsOwned(ID) Then
                    populationArray.AddRange(thisLocation.People)
                End If
            Next
        Next
        Return populationArray
    End Function

    Function GetPlayerPopulationCount() As Integer
        Dim sum As Integer = 0
        For i As Integer = 0 To GridWidth
            For j As Integer = 0 To GridHeight
                If GridArray(i, j).IsOwned(ID) Then
                    sum = sum + GridArray(i, j).getPopulation()
                End If
            Next
        Next
        TotalPopulation = sum
        Return sum
    End Function

    Function GetPlayerTerritory() As List(Of CitySquare)
        Dim territoryArray As New List(Of CitySquare)
        For i As Integer = 0 To GridWidth
            For j As Integer = 0 To GridHeight
                If GridArray(i, j).IsOwned(ID) Then
                    territoryArray.Add(GridArray(i, j))
                End If
            Next
        Next
        Return territoryArray
    End Function

    Function GetPlayerTerritoryCount() As Integer
        Dim sum As Integer = 0
        For i As Integer = 0 To GridWidth
            For j As Integer = 0 To GridHeight
                If GridArray(i, j).IsOwned(ID) Then
                    sum = sum + 1
                End If
            Next
        Next
        TotalTerritory = sum
        Return sum
    End Function

    Function GetPlayerAdjacentTerritory() As List(Of CitySquare)
        Dim territoryArray As New List(Of CitySquare)
        For i As Integer = 0 To GridWidth
            For j As Integer = 0 To GridHeight
                Dim thisLocation As CitySquare = GridArray(i, j)

                '-- No one can already owns this location and it can't be a lake
                If Not thisLocation.IsOwned() And thisLocation.Terrain <> TerrainEnum.Lake Then

                    '-- The current player must own an adjacent location
                    Dim adjacentList As List(Of CitySquare) = thisLocation.GetAdjacents()
                    For k As Integer = 0 To adjacentList.Count - 1
                        Dim neighborLocation As CitySquare = adjacentList(k)
                        If neighborLocation.IsOwned(ID) Then
                            territoryArray.Add(thisLocation)
                            Exit For
                        End If
                    Next

                End If
            Next
        Next
        Return territoryArray
    End Function

    Function GetPlayerDevelopment() As Integer
        Dim sum As Integer = 0
        For i As Integer = 0 To GridWidth
            For j As Integer = 0 To GridHeight
                If GridArray(i, j).IsOwned(ID) Then
                    sum = sum + GridArray(i, j).getDevelopment()
                End If
            Next
        Next
        TotalDevelopment = sum
        Return sum
    End Function

    Function GetPlayerScore() As Integer
        '-- Set Census values to 0
        TotalTerritory = 0
        TotalPopulation = 0
        TotalDevelopment = 0
        TotalEmployed = 0
        TotalJobs = 0
        TotalScore = 0

        For Each CurrentLocation As CitySquare In GridArray
            If CurrentLocation.IsOwned(ID) Then

                '-- Update player territory, population, development, employees, and jobs
                TotalTerritory += 1
                TotalPopulation += CurrentLocation.getPopulation()
                TotalDevelopment += CurrentLocation.getDevelopment()
                TotalEmployed += CurrentLocation.getJobsFilled()
                TotalJobs += CurrentLocation.getJobsTotal()

                '-- Update player score for their citizens
                For Each CurrentCitizen As Citizen In CurrentLocation.People
                    TotalScore += CurrentCitizen.GetCitizenValue()
                Next
            End If
        Next

        '-- Update player score for their territory and development
        TotalScore += (TotalDevelopment * 4.0)
        TotalScore += (TotalTerritory * 12.0)

        '-- Update player score for their employment ratio (Up to 20% bonus)
        TotalScore += (SafeDivide(TotalEmployed, TotalPopulation) * TotalScore * 0.2)

        Return TotalScore
    End Function

    Function GetPlayerLandCost() As Integer
        Dim landCost As Integer = 50
        For i As Integer = 0 To GridWidth
            For j As Integer = 0 To GridHeight
                Dim theLocation As CitySquare = GridArray(i, j)
                If theLocation.IsOwned(ID) Then
                    If theLocation.Terrain <> TerrainEnum.Swamp Then
                        landCost += 20
                    End If
                End If
            Next
        Next
        Return landCost
    End Function

    Function GetPlayerWipeCost() As Integer
        Return WipeCost
    End Function

    Function GetSpecialOrderCap() As Integer
        Return SpecialOrderCap
    End Function

    Public Sub UpdateSpecialOrderCap()
        SpecialOrderCap += (10 + CommerceCount)
    End Sub

    Function IsValidLandExpansion(ByVal theLocation As CitySquare) As Boolean

        '-- You can not expand onto occupied land or water
        If theLocation.IsOwned() Or theLocation.Terrain = TerrainEnum.Lake Then
            Return False
        End If

        '-- Check if a special building this player owns allows them to build at this location
        For i As Integer = 0 To LandOptionBuildings.Count - 1
            If LandOptionBuildings(i).IsLandExpansionOption(theLocation) Then
                Return True
            End If
        Next

        '-- Check if this player owns a neighboring location
        Dim adjacentList As List(Of CitySquare) = theLocation.GetAdjacents()
        For i As Integer = 0 To adjacentList.Count - 1
            Dim neighborLocation As CitySquare = adjacentList(i)
            If neighborLocation.IsOwned(ID) Then
                Return True
            End If
        Next
        Return False
    End Function

    Function IsValidBuild(ByVal theLocation As CitySquare, ByRef theCost As Integer) As Boolean

        '-- Location must be owned by someone
        If Not theLocation.IsOwned() Then
            Return False
        End If

        '-- Someone else owns this location!
        If Not theLocation.IsOwned(ID) Then
            '-- You need to own at least one embassy to build in an opponent's territory
            If EmbassyCount <= 0 Then
                Return False
            Else
                '-- Building in enemy territory costs 120% minus 10% for each additional embassy
                Dim EmbassyCostModifier As Double = 1.3 - (EmbassyCount * 0.1)
                theCost *= EmbassyCostModifier
            End If
        End If

        '-- Conservation areas make it more expensive to build here
        If theLocation.CountBuildingsByType(BuildingGen.BuildingEnum.Conservation_Area) > 0 Then
            Dim ConservationCostModifier As Double = 1.4
            theCost *= ConservationCostModifier
        End If

        Return True
    End Function

    Public Function GetPollingOptions() As Integer
        Dim PollingOptions As Integer = 1
        For i As Integer = 0 To PollCount - 1
            If GetRandom(0, 1) = 0 Then
                PollingOptions += 1
            End If
        Next
        Return PollingOptions
    End Function

    Public Overrides Function toString() As String
        Dim textString As String = ""
        textString += GetPlayerName().ToString() + ControlChars.NewLine
        textString += "$" + TotalMoney.ToString() + ControlChars.NewLine
        textString += "Pop: " + TotalPopulation.ToString() + ControlChars.NewLine
        textString += "Jobs: " + TotalEmployed.ToString() + "/" + TotalJobs.ToString() + ControlChars.NewLine
        textString += "Territory: " + TotalTerritory.ToString() + ControlChars.NewLine
        textString += "Buildings: " + TotalDevelopment.ToString() + ControlChars.NewLine
        textString += "Score: " + TotalScore.ToString() + ControlChars.NewLine
        textString += "Cap: $" + SpecialOrderCap.ToString()

        Return textString
    End Function
#End Region

#Region " AI "

    Public Function ChooseNextAction(ByRef Cards() As Building) As Integer

        '-- Misers often just hoard their money
        If Personality.BeMiserly() Then
            Return CardEnum.NoCard
        End If

        Dim roadNeed As Double = 0.0
        Dim buildingNeed As Double = 0.0
        Dim landNeed As Double = 0.0

        Dim citizenList As List(Of Citizen) = GetPlayerPopulation()
        Dim territoryList As List(Of CitySquare) = GetPlayerTerritory()

        '-- Collect some basic info on employment and transport levels
        Dim citizensEmployed As Integer = 0
        Dim citizensUnemployed As Integer = 0
        Dim roadLevelTotal As Integer = 0
        For i As Integer = 0 To citizenList.Count - 1

            '-- Add up how many citizens employed and unemployed
            Dim currentCitizen As Citizen = citizenList(i)
            If currentCitizen.JobBuilding Is Nothing Then
                citizensUnemployed += 1
            Else
                citizensEmployed += 1
            End If

            '-- Add up road level per citizen
            Dim currentResidence As CitySquare = currentCitizen.Residence
            roadLevelTotal += currentResidence.Transportation
        Next

        '-- Calculate the need for more jobs (on a 0 to 100 scale)
        buildingNeed = 100 * SafeDivide(citizensUnemployed, citizenList.Count) * Personality.GetBuildingAdjustment()

        '-- Calculate the need for more roads (on a 0 to 100 scale)
        Dim averageRoadLevel As Double = SafeDivide(roadLevelTotal, citizenList.Count)
        roadNeed = 100 * SafeDivide(CDbl(RoadEnum.Highway) - averageRoadLevel, RoadEnum.Highway) * Personality.GetRoadAdjustment()

        '-- Calculate the need for more land (on a 0 to 100+ scale with 100)
        ' 100 being an average population of 20 per square
        Dim averagePopulation As Double = SafeDivide(citizenList.Count, territoryList.Count)
        landNeed = 100 * SafeDivide(averagePopulation, 20.0) * Personality.GetLandAdjustment()

        '-- Determine best locations for buildings and roads
        Dim bestBuildingLocation As CitySquare = Nothing
        Dim maxBuildingUtility As Double = -1
        Dim bestRoadLocation As CitySquare = Nothing
        Dim maxRoadUtility As Double = -1
        For i As Integer = 0 To territoryList.Count - 1
            Dim thisLocation As CitySquare = territoryList(i)

            '-- Check if this is the location in most need of jobs
            Dim thisBuildingUtility As Double = (thisLocation.getUnemploymentValue() - thisLocation.getJobsEmpty())
            thisBuildingUtility *= Personality.GetDecisionAdjustment()
            If thisBuildingUtility > maxBuildingUtility Then
                maxBuildingUtility = thisBuildingUtility
                bestBuildingLocation = thisLocation
            End If

            '-- Check if this is the location in most need of roads
            Dim thisRoadUtility As Double = ((RoadEnum.Highway - thisLocation.Transportation) / RoadEnum.Highway * thisLocation.getPopulation())
            thisRoadUtility *= Personality.GetDecisionAdjustment()
            If thisRoadUtility > maxRoadUtility Then
                maxRoadUtility = thisRoadUtility
                bestRoadLocation = thisLocation
            End If
        Next


        '-- Find the weight of the decision in favor of buying each building
        '-- Equal to the need for jobs * value of the building / cost of the building
        Dim cardDecisionWeights(Cards.Length - 1) As Double
        Dim cardWeightSum As Double = 0
        For i As Integer = 0 To Cards.Length - 1
            Dim theBuilding As Building = Cards(i)

            '-- Skip empty cards
            If theBuilding Is Nothing Then
                cardDecisionWeights(i) = -2.0
                Continue For
            End If

            '-- Skip buildings banned for this player
            If BannedBuildings.Contains(theBuilding.Type) Then
                cardDecisionWeights(i) = -2.0 '-- AI can't build banned buildings
            Else
                cardDecisionWeights(i) = buildingNeed * theBuilding.GetValueForAI(Personality)
            End If

            cardWeightSum += cardDecisionWeights(i)
        Next
        Dim cardWeightAvg As Double = SafeDivide(cardWeightSum, Cards.Length)

        '-- Find the weight of the decision in favor of buying road
        '-- Equal to the need for roads * value of the road / cost of road
        Dim roadDecisionWeight As Double = roadNeed * maxRoadUtility / RoadCostBase



        '-- Determine best location for land expansion
        Dim adjLandList As List(Of CitySquare) = GetPlayerAdjacentTerritory()
        Dim landCostBase As Integer = GetPlayerLandCost()
        Dim bestLandCost As Integer = landCostBase
        Dim bestLandLocation As CitySquare = Nothing
        Dim maxLandUtility As Double = -1.0
        For i As Integer = 0 To adjLandList.Count - 1
            Dim thisLocation As CitySquare = adjLandList(i)

            Dim neighboringPopulation As Integer = 0
            Dim adjacentList As List(Of CitySquare) = thisLocation.GetAdjacents()
            For k As Integer = 0 To adjacentList.Count - 1
                Dim ownedLocation As CitySquare = adjacentList(k)
                If ownedLocation.IsOwned(ID) Then
                    neighboringPopulation += ownedLocation.getPopulation()
                End If
            Next

            Dim landUtility As Double = neighboringPopulation / 2.0

            Dim terrainBonus As Double = 0.0
            Dim landCostAdj As Double = landCostBase
            Select Case (thisLocation.Terrain)
                Case TerrainEnum.Dirt
                    landCostAdj -= RoadCostBase '-- Free road
                    landUtility *= 0.95 '-- Lower creativity
                Case TerrainEnum.Forest
                    landUtility *= 1.25 '-- People are happier
                Case TerrainEnum.Mountain
                    terrainBonus = cardWeightAvg '-- Card decision weight of average building available
                    landUtility *= 0.85 '-- Lower mobility
                Case TerrainEnum.Swamp
                    landCostAdj = 10 '-- Cost is actually 0
                    landUtility *= 0.5 '-- Unhappy, unhealthy, high upkeep
                Case TerrainEnum.Township
                    landUtility *= 0.8 '-- Tax loss
                    terrainBonus += 2 '-- Free population
                Case TerrainEnum.Desert
                    landCostAdj *= 0.5 '-- 50% rebate
                    landUtility *= 0.75 '-- Less chance of drawing population
            End Select

            If thisLocation.Coastal Then
                landUtility *= 1.05 '-- People are happier
            End If

            '-- Get the overall utility of this land
            Dim thisLandUtility As Double = (buildingNeed * landUtility / landCostAdj) + terrainBonus

            '-- Adjust the desirability of this terrain based on the AI's personality
            thisLandUtility *= Personality.GetTerrainAdjustment(thisLocation.Terrain)
            If thisLocation.Coastal Then
                thisLandUtility *= Personality.GetTerrainAdjustment(TerrainEnum.Lake)
            End If
            thisLandUtility *= Personality.GetDecisionAdjustment()

            '-- Check if this is the location that would be the best land purchase
            If thisLandUtility > maxLandUtility Then
                maxLandUtility = thisLandUtility
                bestLandLocation = thisLocation
                If thisLocation.Terrain = TerrainEnum.Swamp Then
                    bestLandCost = 0
                Else
                    bestLandCost = landCostAdj
                End If
            End If
        Next

        '-- Find the weight of the decision in favor of buying land
        '-- Equal to the need for land * value of the land / cost of land (pre-calculated above)
        Dim landDecisionWeight As Double = maxLandUtility


        Dim decisionWeights As New List(Of Double)
        decisionWeights.AddRange(cardDecisionWeights)
        decisionWeights.Add(roadDecisionWeight)
        decisionWeights.Add(landDecisionWeight)

        '-- Determine the best action to take by comparing all previous choices
        Dim bestDecisionWeight As Double = -1.0
        Dim finalDecision As Integer = CardEnum.NoCard
        For i As Integer = 0 To decisionWeights.Count - 1

            '-- Spendthrifts won't consciously choose an action that will result in a pass
            If Personality.PreferenceList.Contains(AIPersonality.AIType.AI_Spendthrift) Then
                Dim ChoiceCost As Integer = 0
                If i <= CardEnum.BuildingSpecialOrder Then
                    If Cards(i) IsNot Nothing Then
                        ChoiceCost = Cards(i).GetPurchasePrice()
                    End If
                ElseIf i = CardEnum.Road Then
                    ChoiceCost = RoadCostBase
                ElseIf i = CardEnum.Land Then
                    ChoiceCost = bestLandCost
                End If

                If TotalMoney < ChoiceCost Then
                    Continue For
                End If
            End If

            '-- Check if this is the best decision
            If decisionWeights(i) > bestDecisionWeight Then
                bestDecisionWeight = decisionWeights(i)
                finalDecision = i
            End If
        Next

        '-- Save the location of the best move
        If finalDecision = CardEnum.NoCard Then
            BestMove = Nothing
        ElseIf finalDecision <= CardEnum.BuildingSpecialOrder Then
            BestMove = bestBuildingLocation
        ElseIf finalDecision = CardEnum.Road Then
            BestMove = bestRoadLocation
        ElseIf finalDecision = CardEnum.Land Then
            BestMove = bestLandLocation
        Else
            BestMove = Nothing
        End If

        '-- If for any reason no best move was selected, make sure the action is set to Pass
        If BestMove Is Nothing Then
            finalDecision = CardEnum.NoCard
        End If

        Return finalDecision

    End Function

    Public Function GetReproduceAdjustment() As Double
        If PlayerType = PlayerTypeEnum.AI Then
            Return Personality.GetReproduceAdjustment()
        Else
            Return 1.0
        End If
    End Function

    Public Function GetTaxAdjustment() As Double
        If PlayerType = PlayerTypeEnum.AI Then
            Return Personality.GetTaxAdjustment()
        Else
            Return 1.0
        End If
    End Function

#End Region

End Class
