Public Class Building

#Region " Variables "
    Public Type As Integer = -1

    Public Cost As Integer = 0
    Public Jobs As Integer = 0
    Public Success As Integer = 0
    Public Age As Integer = 0

    Public Info As String = ""
    Public SpecialAbility As String = ""
    Public Tags As New ArrayList

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

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        Type = bType
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

    Public Sub SetSpecialAbility(ByVal bSpecial As String)
        SpecialAbility = bSpecial
    End Sub

#End Region

#Region " Gets "

    Public Function GetName() As String
        Return BuildingGenerator.GetName(Type)
    End Function

    Public Function GetNameAndAddress() As String
        Return GetName() + " at " + Location.GetName()
    End Function

    Public Function GetEmployeeCount() As Integer
        Return Employees.Count
    End Function

    Public Overridable Function GetCost() As Integer
        Return Cost
    End Function

    Public Overridable Function GetHappinessOdds() As Integer
        Return Happiness_odds
    End Function
    Public Overridable Function GetHappinessAdj() As Integer
        Return Happiness_adj
    End Function

    Public Overridable Function GetHealthOdds() As Integer
        Return Health_odds
    End Function
    Public Overridable Function GetHealthAdj() As Integer
        Return Health_adj
    End Function

    Public Overridable Function GetIntelligenceOdds() As Integer
        Return Intelligence_odds
    End Function
    Public Overridable Function GetIntelligenceAdj() As Integer
        Return Intelligence_adj
    End Function

    Public Overridable Function GetCreativityOdds() As Integer
        Return Creativity_odds
    End Function
    Public Overridable Function GetCreativityAdj() As Integer
        Return Creativity_adj
    End Function

    Public Overridable Function GetMobilityOdds() As Integer
        Return Mobility_odds
    End Function
    Public Overridable Function GetMobilityAdj() As Integer
        Return Mobility_adj
    End Function

    Public Overridable Function GetDrunkennessOdds() As Integer
        Return Drunkenness_odds
    End Function
    Public Overridable Function GetDrunkennessAdj() As Integer
        Return Drunkenness_adj
    End Function

    Public Overridable Function GetCriminalityOdds() As Integer
        Return Criminality_odds
    End Function
    Public Overridable Function GetCriminalityAdj() As Integer
        Return Criminality_adj
    End Function

#End Region

#Region " Tags "
    Public Sub AddTag(ByVal newTag As String)
        Tags.Add(newTag)
    End Sub

    Public Function HasTag(ByVal newTag As String) As Boolean
        Return Tags.Contains(newTag)
    End Function
#End Region

#Region " Affect Person "

    Public Function GetStatChange(ByVal adj As Integer) As Integer
        If adj < 0 Then
            Return GetRandom(adj, -1)
        Else
            Return GetRandom(1, adj)
        End If
    End Function

    Public Overridable Sub AffectHappiness(ByRef thePerson As Person)
        If GetHappinessOdds() > 0 Then
            If GetRandom(0, 100) <= GetHappinessOdds() Then
                Dim statChange As Integer = GetStatChange(GetHappinessAdj())
                thePerson.Happiness += statChange
                thePerson.AddEvent("happiness from visiting " + GetName(), statChange)
            End If
        End If
    End Sub

    Public Overridable Sub AffectHealth(ByRef thePerson As Person)
        If GetHealthOdds() > 0 Then
            If GetRandom(0, 100) <= GetHealthOdds() Then
                Dim statChange As Integer = GetStatChange(GetHealthAdj())
                thePerson.Health += statChange
                thePerson.AddEvent("health from visiting " + GetName(), statChange)
            End If
        End If
    End Sub

    Public Overridable Sub AffectIntelligence(ByRef thePerson As Person)
        If GetIntelligenceOdds() > 0 Then
            If GetRandom(0, 100) <= GetIntelligenceOdds() Then
                Dim statChange As Integer = GetStatChange(GetIntelligenceAdj())
                thePerson.Intelligence += statChange
                thePerson.AddEvent("intelligence from visiting " + GetName(), statChange)
            End If
        End If
    End Sub

    Public Overridable Sub AffectCreativity(ByRef thePerson As Person)
        If GetCreativityOdds() > 0 Then
            If GetRandom(0, 100) <= GetCreativityOdds() Then
                Dim statChange As Integer = GetStatChange(GetCreativityAdj())
                thePerson.Creativity += statChange
                thePerson.AddEvent("creativity from visiting " + GetName(), statChange)
            End If
        End If
    End Sub

    Public Overridable Sub AffectMobility(ByRef thePerson As Person)
        If GetMobilityOdds() > 0 Then
            If GetRandom(0, 100) <= GetMobilityOdds() Then
                Dim statChange As Integer = GetStatChange(GetMobilityAdj())
                thePerson.Mobility += statChange
                thePerson.AddEvent("mobility from visiting " + GetName(), statChange)
            End If
        End If
    End Sub

    Public Overridable Sub AffectDrunkenness(ByRef thePerson As Person)
        If GetDrunkennessOdds() > 0 Then
            If GetRandom(0, 100) <= GetDrunkennessOdds() Then
                Dim statChange As Integer = GetStatChange(GetDrunkennessAdj())
                thePerson.Drunkenness += statChange
                thePerson.AddEvent("drunkenness from visiting " + GetName(), statChange)
            End If
        End If
    End Sub

    Public Overridable Sub AffectCriminality(ByRef thePerson As Person)
        If GetCriminalityOdds() > 0 Then
            If GetRandom(0, 100) <= GetCriminalityOdds() Then
                Dim statChange As Integer = GetStatChange(GetCriminalityAdj())
                thePerson.Criminality += statChange
                thePerson.AddEvent("criminality from visiting " + GetName(), statChange)
            End If
        End If
    End Sub

    Public Overridable Sub AffectPerson(ByRef thePerson As Person)
        AffectHappiness(thePerson)
        AffectHealth(thePerson)
        AffectIntelligence(thePerson)
        AffectCreativity(thePerson)
        AffectMobility(thePerson)
        AffectDrunkenness(thePerson)
        AffectCriminality(thePerson)
    End Sub

#End Region

#Region " Job Functions "

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

    Public Overridable Sub ConstructionEffects()
        '-- Base building type has no construction effects
    End Sub

    Public Overridable Sub ExpandBuilding()
        Jobs += 1
    End Sub

    Public Overridable Function CheckSuccess() As Boolean

        '-- Building must be at max employment
        If GetEmployeeCount() = Jobs Then

            '-- Odds of expanding = half the average employment score of employees
            Dim odds As Double = 0.0
            odds += SafeDivide(Success, GetEmployeeCount() * 2.0)

            '-- Odds of expanding go down as you get larger
            Dim oddsRange As Integer = 100 + (10 * Jobs)

            If GetRandom(0, oddsRange) <= odds Then '-- Remove equal sign to prevent 0 job businesses from expanding?
                '--Buildings expand
                ExpandBuilding()
                Return True
            Else
                Return False
            End If
        End If

    End Function

    Public Overridable Function UpdateInternal() As Boolean
        Age = Age + TimeIncrement
        Return True
    End Function

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

        BuildingString += "Name: " + GetName() + ControlChars.NewLine

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
        If DebugMode Then
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

        '-- Show special ability text
        If SpecialAbility.Length > 0 Then
            BuildingString += ControlChars.NewLine + ControlChars.NewLine

            BuildingString += SpecialAbility
        End If

        Return BuildingString
    End Function

End Class
