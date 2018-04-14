Partial Public Class MainForm

#Region " Views "

    Public Sub FillViewDropdownList()
        For i As Integer = 0 To ViewEnum.EndEnum - 1
            ViewDropdown.Items.Add(GetViewName(i))
        Next
    End Sub

    Private Sub ViewDropdown_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ViewDropdown.SelectedIndexChanged
        CurrentView = ViewDropdown.SelectedIndex
        UpdateView()
    End Sub

    Public Sub UpdateView()
        UpdateTitle()
        UpdateGrid()
    End Sub

    Private Sub ubVForward_Click(sender As Object, e As EventArgs) Handles ubVForward.Click
        CycleThroughViews(True, True)
    End Sub

    Private Sub ubVBack_Click(sender As Object, e As EventArgs) Handles ubVBack.Click
        CycleThroughViews(False, True)
    End Sub

    Public Sub CycleThroughViews(ByVal CycleForward As Boolean, ByVal LoopAround As Boolean)

        '-- Cycle forward or backward
        Dim NewCurrentView As Integer = CurrentView
        If CycleForward Then
            NewCurrentView += 1
        Else
            NewCurrentView -= 1
        End If

        '-- Optionally loop around
        If NewCurrentView < 0 Then
            If LoopAround Then
                NewCurrentView = CurrentView - 1
            Else
                Return
            End If
        ElseIf NewCurrentView >= ViewEnum.EndEnum Then
            If LoopAround Then
                NewCurrentView = 0
            Else
                Return
            End If
        End If

        '-- Display the new person information
        CurrentView = NewCurrentView
        ViewDropdown.SelectedIndex = CurrentView
        'UpdateView()
    End Sub

    Public Function GetViewName(ByVal ViewType As Integer) As String
        Select Case (ViewType)
            Case ViewEnum.Population
                Return "Population"
            Case ViewEnum.Coordinates
                Return "Coordinates"
            Case ViewEnum.Order
                Return "Order Occupied"
            Case ViewEnum.Terrain
                Return "Terrain"
            Case ViewEnum.Buildings
                Return "Buildings"
            Case ViewEnum.Roads
                Return "Roads"
            Case ViewEnum.JobsTotal
                Return "Jobs Total"
            Case ViewEnum.JobsFilled
                Return "Jobs Filled"
            Case ViewEnum.JobsUnfilled
                Return "Jobs Unfilled"
            Case ViewEnum.JobsNeed
                Return "Jobs Needed"
            Case ViewEnum.Minors
                Return "Minors"
            Case ViewEnum.Elderly
                Return "Elders"
            Case ViewEnum.Employees
                Return "Employees"
            Case ViewEnum.UnemployedAdults
                Return "Unemployed Adults"
            Case ViewEnum.UnemployedTotal
                Return "Unemployed Total"
            Case ViewEnum.AgeAvg
                Return "Average Age"
            Case ViewEnum.LifespanAvg
                Return "Average Lifespan"
            Case ViewEnum.MaxAge
                Return "Maximum Age"
            Case ViewEnum.HappinessAvg
                Return "Average Happiness"
            Case ViewEnum.HealthAvg
                Return "Average Health"
            Case ViewEnum.EmploymentAvg
                Return "Average Employment"
            Case ViewEnum.IntelligenceAvg
                Return "Average Intelligence"
            Case ViewEnum.CreativityAvg
                Return "Average Creativity"
            Case ViewEnum.MobilityAvg
                Return "Average Mobility"
            Case ViewEnum.DrunkennessAvg
                Return "Average Drunkenness"
            Case ViewEnum.CriminalityAvg
                Return "Average Criminality"
            Case ViewEnum.HappinessAvgAdults
                Return "Average Adult Happiness"
            Case ViewEnum.HealthAvgAdults
                Return "Average Adult Health"
            Case ViewEnum.EmploymentAvgAdults
                Return "Average Adult Employment"
            Case ViewEnum.IntelligenceAvgAdults
                Return "Average Adult Intelligence"
            Case ViewEnum.CreativityAvgAdults
                Return "Average Adult Creativity"
            Case ViewEnum.MobilityAvgAdults
                Return "Average Adult Mobility"
            Case ViewEnum.DrunkennessAvgAdults
                Return "Average Adult Drunkenness"
            Case ViewEnum.CriminalityAvgAdults
                Return "Average Adult Criminality"
            Case ViewEnum.CurrentRevenue
                Return "Revenue This Turn"
            Case ViewEnum.TotalRevenue
                Return "Revenue Total"
            Case ViewEnum.CurrentUpkeep
                Return "Upkeep This Turn"
            Case ViewEnum.TotalUpkeep
                Return "Upkeep Total"

            Case ViewEnum.CrimeParkingTicket
                Return "Parking Tickets"
            Case ViewEnum.CrimeTrafficTicket
                Return "Traffic Tickets"
            Case ViewEnum.CrimeRobbery
                Return "Robberies"
            Case ViewEnum.CrimeVandalism
                Return "Vandalism"
            Case ViewEnum.CrimeArson
                Return "Arson"
            Case ViewEnum.CrimeMurder
                Return "Murders"

            Case ViewEnum.DeathNaturalCauses
                Return "Deaths by Natural Causes"
            Case ViewEnum.DeathIllness
                Return "Deaths by Illness"
            Case ViewEnum.DeathTrafficAccident
                Return "Deaths by Traffic Accident"
            Case ViewEnum.DeathMurder
                Return "Deaths by Murder"
            Case ViewEnum.DeathResistingArrest
                Return "Deaths by Resisting Arrest"

            Case ViewEnum.BuildingsCurrentPlayer
                Return "Buildings owned by current player"
            Case ViewEnum.BuildingsOtherPlayers
                Return "Buildings owned by other players"
            Case ViewEnum.BuildingsPlayer1
                Return "Buildings owned by player 1"
            Case ViewEnum.BuildingsPlayer2
                Return "Buildings owned by player 2"
            Case ViewEnum.BuildingsPlayer3
                Return "Buildings owned by player 3"
            Case ViewEnum.BuildingsPlayer4
                Return "Buildings owned by player 4"

            Case ViewEnum.Ad
                Return "Advertising Buildings"
            Case ViewEnum.Athletic
                Return "Athletic Buildings"
            Case ViewEnum.Coffee
                Return "Coffee Buildings"
            Case ViewEnum.Commerce
                Return "Commerce Buildings"
            Case ViewEnum.Criminal
                Return "Criminal Buildings"
            Case ViewEnum.Culture
                Return "Culture Buildings"
            Case ViewEnum.Entertainment
                Return "Entertainment Buildings"
            Case ViewEnum.Food
                Return "Food Buildings"
            Case ViewEnum.Franchise
                Return "Franchise Buildings"
            Case ViewEnum.Government
                Return "Government Buildings"
            Case ViewEnum.Manufacturing
                Return "Manufacturing Buildings"
            Case ViewEnum.Medical
                Return "Medical Buildings"
            Case ViewEnum.Monument
                Return "Monument Buildings"
            Case ViewEnum.Nature
                Return "Nature Buildings"
            Case ViewEnum.Power
                Return "Power Buildings"
            Case ViewEnum.Science
                Return "Science Buildings"
            Case ViewEnum.Security
                Return "Security Buildings"
            Case ViewEnum.Transport
                Return "Transport Buildings"
            Case ViewEnum.Travel
                Return "Travel Buildings"

            Case Else
                Return "Statistics"
        End Select
    End Function

#End Region
End Class

