Public Class GroceryBuilding
    Inherits Building

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
    End Sub

    Public Overrides Function GetStatAdjust(ByVal StatType As Integer) As Integer
        If StatType = StatEnum.Health Then
            Dim PopulationBonus As Integer = 0
            If Location IsNot Nothing Then
                PopulationBonus = Math.Floor(SafeDivide(Location.getPopulation(), 6.0))
            End If

            Return MyBase.GetStatAdjust(StatType) + PopulationBonus
        Else
            Return MyBase.GetStatAdjust(StatType)
        End If

    End Function
End Class

Public Class RestaurantBuilding
    Inherits Building

    Public PreviousPopulation As Integer = 0

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
    End Sub

    Public Overrides Function UpdateInternal() As Boolean
        MyBase.UpdateInternal()

        Dim CurrentPopulation As Integer = Location.getPopulation()

        Dim PopulationDrop As Integer = PreviousPopulation - CurrentPopulation
        '-- Save current population for next turn
        PreviousPopulation = CurrentPopulation

        '-- Only consider moving if there was a population drop
        If PopulationDrop <= 0 Then
            Return True
        End If

        If GetRandom(1, 6) <= PopulationDrop Then
            '-- Close down this restaurant and move to an adjacent location
            Dim AdjLocation As List(Of CitySquare) = Location.GetAdjacents()
            Dim BestAdj As CitySquare = Nothing
            Dim HighestPopulation As Integer = 0
            For i As Integer = 0 To AdjLocation.Count - 1
                Dim thisPopulation As Integer = AdjLocation(i).getPopulation()
                If thisPopulation > HighestPopulation Then
                    HighestPopulation = thisPopulation
                    BestAdj = AdjLocation(i)
                End If
            Next

            '-- If a decent alternative location is nearby, close shop and move there
            If BestAdj IsNot Nothing And HighestPopulation > 0 Then
                Dim newBuilding As Building = BuildingGenerator.CreateBuilding(BuildingGen.BuildingEnum.Restaurant)
                BestAdj.AddBuilding(newBuilding, BestAdj.OwnerID)
                Diary.SpecialBuildingEvents.AddEventNoLimit(GetName() + " closed shop and moved to " + BestAdj.GetName())
                PreviousPopulation = HighestPopulation
                Return False
            End If
        End If

        Return True
    End Function

End Class
