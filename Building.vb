Public Class Building

#Region " Variables "
    Public Name As String = ""
    Public Type As Integer = -1
    Public Cost As Integer = 0
    Public Jobs As Integer = 0
    Public Success As Integer = 0
    Public Info As String = ""
    Public Location As CitySquare = Nothing
    Public Employees As New ArrayList

    '-- Keep track of how many times no one bought this for free
    Public RejectionCount As Integer = 0

    '-- Minimum employee standards
    Public minAge As Integer = 16

    '-- Effect Change
    Public Happiness_adj As Integer = 0
    Public Health_adj As Integer = 0
    Public Employment_adj As Integer = 0
    Public Intelligence_adj As Integer = 0
    Public Creativity_adj As Integer = 0
    Public Mobility_adj As Integer = 0
    Public Drunkenness_adj As Integer = 0
    Public Criminality_adj As Integer = 0

    '-- Effect Odds
    Public Happiness_odds As Integer = 0
    Public Health_odds As Integer = 0
    Public Employment_odds As Integer = 0
    Public Intelligence_odds As Integer = 0
    Public Creativity_odds As Integer = 0
    Public Mobility_odds As Integer = 0
    Public Drunkenness_odds As Integer = 0
    Public Criminality_odds As Integer = 0

#End Region

#Region " New "

    Sub New()

    End Sub

    Sub New(ByVal bType As Integer, ByVal bName As String, ByVal bCost As Integer, ByVal bJobs As Integer)
        Type = bType
        Name = bName
        Cost = bCost
        Jobs = bJobs
    End Sub

#End Region

#Region " Sets "
    Public Sub SetHappiness(ByVal odds As Integer, ByVal adj As Integer)
        Happiness_adj = adj
        Happiness_odds = odds
    End Sub

    Public Sub SetHealth(ByVal odds As Integer, ByVal adj As Integer)
        Health_adj = adj
        Health_odds = odds
    End Sub

    Public Sub SetIntelligence(ByVal odds As Integer, ByVal adj As Integer)
        Intelligence_adj = adj
        Intelligence_odds = odds
    End Sub

    Public Sub SetCreativity(ByVal odds As Integer, ByVal adj As Integer)
        Creativity_adj = adj
        Creativity_odds = odds
    End Sub

    Public Sub SetMobility(ByVal odds As Integer, ByVal adj As Integer)
        Mobility_adj = adj
        Mobility_odds = odds
    End Sub

    Public Sub SetDrunkenness(ByVal odds As Integer, ByVal adj As Integer)
        Drunkenness_adj = adj
        Drunkenness_odds = odds
    End Sub

    Public Sub SetCriminality(ByVal odds As Integer, ByVal adj As Integer)
        Criminality_adj = adj
        Criminality_odds = odds
    End Sub

    Public Sub SetInfo(ByVal bInfo As String)
        Info = bInfo
    End Sub
#End Region

#Region " Gets "

    Public Function GetName() As String
        Return Name.ToString()
    End Function

    Public Function GetNameAndAddress() As String
        Return GetName() + " at " + Location.GetName()
    End Function

    Public Function GetEmployeeCount() As Integer
        Return Employees.Count
    End Function

    Public Overridable Function GetCostt() As Integer
        Return Cost
    End Function

#End Region

#Region " Affect Person "

    Public Overridable Sub AffectHappiness(ByRef thePerson As Person)
        If Happiness_odds > 0 Then
            If GetRandom(0, 100) <= Happiness_odds Then
                If Happiness_adj < 0 Then
                    thePerson.Happiness -= GetRandom(Happiness_adj, -1)
                Else
                    thePerson.Happiness += GetRandom(1, Happiness_adj)
                End If
            End If
        End If
    End Sub

    Public Overridable Sub AffectHealth(ByRef thePerson As Person)
        If Health_odds > 0 Then
            If GetRandom(0, 100) <= Health_odds Then
                If Health_adj < 0 Then
                    thePerson.Health += GetRandom(Health_adj, -1)
                Else
                    thePerson.Health += GetRandom(1, Health_adj)
                End If
            End If
        End If
    End Sub

    Public Overridable Sub AffectIntelligence(ByRef thePerson As Person)
        If Intelligence_odds > 0 Then
            If GetRandom(0, 100) <= Intelligence_odds Then
                If Intelligence_adj < 0 Then
                    thePerson.Intelligence += GetRandom(Intelligence_adj, -1)
                Else
                    thePerson.Intelligence += GetRandom(1, Intelligence_adj)
                End If
            End If
        End If
    End Sub

    Public Overridable Sub AffectCreativity(ByRef thePerson As Person)
        If Creativity_odds > 0 Then
            If GetRandom(0, 100) <= Creativity_odds Then
                If Creativity_adj < 0 Then
                    thePerson.Creativity += GetRandom(Creativity_adj, -1)
                Else
                    thePerson.Creativity += GetRandom(1, Creativity_adj)
                End If
            End If
        End If
    End Sub

    Public Overridable Sub AffectMobility(ByRef thePerson As Person)
        If Mobility_odds > 0 Then
            If GetRandom(0, 100) <= Mobility_odds Then
                If Mobility_adj < 0 Then
                    thePerson.Creativity += GetRandom(Mobility_adj, -1)
                Else
                    thePerson.Creativity += GetRandom(1, Mobility_adj)
                End If
            End If
        End If
    End Sub

    Public Overridable Sub AffectDrunkenness(ByRef thePerson As Person)
        If Drunkenness_odds > 0 Then
            If GetRandom(0, 100) <= Drunkenness_odds Then
                If Drunkenness_adj < 0 Then
                    thePerson.Drunkenness += GetRandom(Drunkenness_adj, -1)
                Else
                    thePerson.Drunkenness += GetRandom(1, Drunkenness_adj)
                End If
            End If
        End If
    End Sub

    Public Overridable Sub AffectCriminality(ByRef thePerson As Person)
        If Criminality_odds > 0 Then
            If GetRandom(0, 100) <= Criminality_odds Then
                If Criminality_adj < 0 Then
                    thePerson.Criminality += GetRandom(Criminality_adj, -1)
                Else
                    thePerson.Criminality += GetRandom(1, Criminality_adj)
                End If
            End If
        End If
    End Sub

    Public Sub AffectPerson(ByRef thePerson As Person)
        AffectHappiness(thePerson)
        AffectHealth(thePerson)
        AffectIntelligence(thePerson)
        AffectCreativity(thePerson)
        AffectMobility(thePerson)
        AffectDrunkenness(thePerson)
        AffectCriminality(thePerson)
    End Sub


#End Region

#Region " Hiring "

    Public Overridable Function WillHire(ByRef Candidate As Person) As Boolean

        '-- Confirm there is an open position
        If GetEmployeeCount() >= Jobs Then
            Return False
        End If

        '-- Make sure the candidate meets the minimum age requirement
        If Candidate.Age < minAge Then
            Return False
        End If

        Return True
    End Function

    Public Sub HireEmployee(ByRef Employee As Person)
        '-- Quit any previous job
        If Employee.JobBuilding IsNot Nothing Then
            Employee.JobBuilding.Employees.Remove(Employee)
        End If

        '-- Start at your new job
        Employees.Add(Employee)
        Employee.JobBuilding = Me
        Employee.Employment += 1
    End Sub

#End Region

#Region " Destruction "

    Public Sub Destroy()
        '-- All the employees are back on the street
        For i As Integer = 0 To Employees.Count - 1
            Dim theEmployee As Person = Employees(i)
            theEmployee.JobBuilding = Nothing
        Next

        '-- Remove the building from this location
        Location.Buildings.Remove(Me)
    End Sub
#End Region

#Region " Evaluation Functions "

    Public Function GetValueForCitizen() As Double
        Dim buildingValue As Double = 0

        '-- Get the value of the building adjusted by the AI's personality
        buildingValue += (Happiness_odds * Happiness_adj)
        buildingValue += (Health_odds * Health_adj)
        buildingValue += (Intelligence_odds * Intelligence_adj)
        buildingValue += (Creativity_odds * Creativity_adj)
        buildingValue += (Mobility_odds * Mobility_adj)
        buildingValue -= (Drunkenness_odds * Drunkenness_adj)
        buildingValue -= (Criminality_odds * Criminality_adj)

        Return buildingValue

    End Function

    Public Function GetValueForAI(ByRef aiBrain As AIPersonality) As Double
        Dim buildingValue As Double = 0

        '-- Get the value of the building adjusted by the AI's personality
        buildingValue += (Happiness_odds * Happiness_adj / 200.0 * aiBrain.GetStatAdjustment(StatHappiness))
        buildingValue += (Health_odds * Health_adj / 200.0 * aiBrain.GetStatAdjustment(StatHealth))
        buildingValue += (Intelligence_odds * Intelligence_adj / 200.0 * aiBrain.GetStatAdjustment(StatIntelligence))
        buildingValue += (Creativity_odds * Creativity_adj / 200.0 * aiBrain.GetStatAdjustment(StatCreativity))
        buildingValue += (Mobility_odds * Mobility_adj / 200.0 * aiBrain.GetStatAdjustment(StatMobility))
        buildingValue -= (Drunkenness_odds * Drunkenness_adj / 200.0 * aiBrain.GetStatAdjustment(StatDrunkenness))
        buildingValue -= (Criminality_odds * Criminality_adj / 200.0 * aiBrain.GetStatAdjustment(StatCriminality))

        buildingValue += (Jobs * aiBrain.GetStatAdjustment(StatEmployment))

        If Cost <= 0 Then
            Return 9999999.9
        Else
            Return SafeDivide(buildingValue, Cost)
        End If

    End Function
#End Region

    Public Overrides Function toString() As String
        Dim BuildingString As String = ""

        BuildingString += "Name: " + Name + ControlChars.NewLine

        If Location IsNot Nothing Then
            BuildingString += "Location: " + Location.GetName() + ControlChars.NewLine
        End If

        '-- Show job info
        BuildingString += "Jobs: " + GetEmployeeCount.ToString + "/" + Jobs.ToString + ControlChars.NewLine
        If Employees.Count > 0 Then
            BuildingString += "Employees: "
            For i As Integer = 0 To Employees.Count - 1
                Dim Employee As Person = Employees(i)
                BuildingString += Employee.Name

                If i <> Employees.Count - 1 Then
                    BuildingString += ", "
                Else
                    BuildingString += ControlChars.NewLine
                End If
            Next
        End If
        BuildingString += ControlChars.NewLine

        '-- Show stat info
        Dim ShowStats As Boolean = True
        If ShowStats Then
            If Happiness_odds > 0 Then
                BuildingString += "Happiness: " + Happiness_odds.ToString + "% chance boosts up to " + Happiness_adj.ToString + ControlChars.NewLine
            End If
            If Health_odds > 0 Then
                BuildingString += "Health: " + Health_odds.ToString + "% chance boosts up to " + Health_adj.ToString + ControlChars.NewLine
            End If
            If Intelligence_odds > 0 Then
                BuildingString += "Intelligence: " + Intelligence_odds.ToString + "% chance boosts up to " + Intelligence_adj.ToString + ControlChars.NewLine
            End If
            If Creativity_odds > 0 Then
                BuildingString += "Creativity: " + Creativity_odds.ToString + "% chance boosts up to " + Creativity_adj.ToString + ControlChars.NewLine
            End If
            If Mobility_odds > 0 Then
                BuildingString += "Mobility: " + Mobility_odds.ToString + "% chance boosts up to " + Mobility_adj.ToString + ControlChars.NewLine
            End If
            If Drunkenness_odds > 0 Then
                BuildingString += "Drunkenness: " + Drunkenness_odds.ToString + "% chance boosts up to " + Drunkenness_adj.ToString + ControlChars.NewLine
            End If
            If Criminality_odds > 0 Then
                BuildingString += "Criminality: " + Criminality_odds.ToString + "% chance boosts up to " + Criminality_adj.ToString + ControlChars.NewLine
            End If
        End If

        '-- Show flavor text
        BuildingString += ControlChars.NewLine

        BuildingString += Info

        Return BuildingString
    End Function

End Class
