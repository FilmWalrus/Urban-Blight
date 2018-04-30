Public Class Building

#Region " Variables "
    Public Type As Integer = -1

    Public BaseCost As Integer = 0
    Public MarkdownCost As Integer = 0
    Public PurchasePrice As Integer = 0
    Public MarketPosition As Integer = -1

    Public Jobs As Integer = 0
    Public BusinessSuccess As Integer = 0

    Public Age As Integer = 0
    Public Range As Integer = 0
    Public ExpandRate As Integer = 1

    Public Info As String = ""
    Public SpecialAbility As String = ""
    Public Tags As New List(Of Integer)
    Public EffectText As String = "people affected"

    Public OwnerID As Integer = -1
    Public Location As CitySquare = Nothing
    Public Employees As New List(Of Citizen)
    Public Founder As Citizen = Nothing

    '-- Keep track of who rejected this building for free
    Public RejecterList As New List(Of Player)

    '-- Minimum employee standards
    Public minAge As Integer = Citizen.MinorAge

    '-- Effect Odds and Max Adjustments
    Public StatOdds(StatEnum.EnumEnd - 1) As Integer
    Public StatAdjusts(StatEnum.EnumEnd - 1) As Integer

    '-- Visits, Revenue and Upkeep
    Public CurrentVisitors As Integer = 0
    Public TotalVisitors As Integer = 0
    Public CurrentEffects As Integer = 0
    Public TotalEffects As Integer = 0
    Public CurrentRevenue As Integer = 0
    Public TotalRevenue As Integer = 0
    Public CurrentUpkeep As Integer = 0
    Public TotalUpkeep As Integer = 0

#End Region

#Region " New "

    Sub New()

    End Sub

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer, Optional ByVal bMinAge As Integer = Citizen.MinorAge)
        Type = bType
        BaseCost = bCost
        minAge = bMinAge
        MarkdownCost = BaseCost
        PurchasePrice = BaseCost
        Jobs = bJobs
    End Sub

#End Region

#Region " Sets "
    Public Sub SetStat(ByVal StatType As Integer, ByVal Odds As Integer, ByVal Adj As Integer)
        StatOdds(StatType) = Odds
        StatAdjusts(StatType) = Adj
    End Sub

    Public Sub SetRange(ByVal bRange As Integer)
        Range = bRange
    End Sub

    Public Sub SetInfo(ByVal bInfo As String)
        Info = bInfo + ControlChars.NewLine
    End Sub

    Public Sub SetMinAge(ByVal newMinAge As Integer)
        minAge = newMinAge
    End Sub

    Public Sub SetSpecialAbility(ByVal bSpecial As String)
        SpecialAbility = bSpecial + ControlChars.NewLine
    End Sub

    Public Overridable Sub UpdateStatOdds(ByVal StatType As Integer, ByVal changeValue As Double, ByVal multiplier As Boolean)
        If multiplier Then
            StatOdds(StatType) *= changeValue
        Else
            StatOdds(StatType) += changeValue
        End If
    End Sub

    Public Overridable Sub UpdateStatAdjusts(ByVal StatType As Integer, ByVal changeValue As Double, ByVal multiplier As Boolean)
        If multiplier Then
            StatAdjusts(StatType) *= changeValue
        Else
            StatAdjusts(StatType) += changeValue
        End If
    End Sub

    Public Overridable Sub UpdateAllOdds(ByVal changeValue As Double, ByVal multiplier As Boolean)
        For i As Integer = 0 To StatEnum.EnumEnd - 1
            UpdateStatOdds(i, changeValue, multiplier)
        Next
    End Sub

    Public Overridable Sub UpdateAllAdj(ByVal changeValue As Double, ByVal multiplier As Boolean)
        For i As Integer = 0 To StatEnum.EnumEnd - 1
            UpdateStatAdjusts(i, changeValue, multiplier)
        Next
    End Sub

    Public Sub SetMarkdownPrice(ByVal NewPrice As Integer)
        MarkdownCost = NewPrice
        PurchasePrice = NewPrice
    End Sub


#End Region

#Region " Gets "

    Public Overridable Function GetName() As String
        Return BuildingGenerator.GetName(Type)
    End Function

    Public Function GetNameAndAddress() As String
        Return GetName() + " at " + Location.GetName()
    End Function

    Public Overridable Function GetEmploymentStatement() As String
        Return "Employed by the " + GetNameAndAddress()
    End Function

    Public Function GetEmployeeCount() As Integer
        Return Employees.Count
    End Function

    Public Overridable Function GetSpecialAbility() As String
        Return SpecialAbility.Trim
    End Function

    Public Overridable Function GetBaseCost() As Integer
        Return BaseCost
    End Function

    Public Overridable Function GetCost() As Integer
        Return MarkdownCost
    End Function

    Public Overridable Function GetPurchasePrice() As Integer
        Return PurchasePrice
    End Function

    Public Overridable Function GetRange() As Integer
        Return Range
    End Function

    Public Overridable Function GetStatOdds(ByVal StatType As Integer) As Integer
        Return StatOdds(StatType)
    End Function

    Public Overridable Function GetStatAdjust(ByVal StatType As Integer) As Integer
        Return StatAdjusts(StatType)
    End Function

#End Region

#Region " Tags "
    Public Sub AddTag(ByVal newTag As Integer)
        Tags.Add(newTag)
    End Sub

    Public Sub RemoveTag(ByVal newTag As Integer)
        Tags.Remove(newTag)
    End Sub

    Public Function HasTag(ByVal newTag As Integer) As Boolean
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

    Public Overridable Sub AffectStat(ByVal StatType As Integer, ByRef thePerson As Citizen)
        If GetStatOdds(StatType) > 0 Then
            If GetRandom(0, 100) <= GetStatOdds(StatType) Then
                Dim statChange As Integer = GetStatChange(GetStatAdjust(StatType))
                thePerson.OffsetStat(StatType, statChange, "Visited " + GetName())
            End If
        End If
    End Sub

    Public Overridable Sub AffectPerson(ByRef thePerson As Citizen)

        For i As Integer = 0 To StatEnum.EnumEnd - 1
            AffectStat(i, thePerson)
        Next

        AddVisitors(1)
    End Sub

#End Region

#Region " Job Functions "

    Public Overridable Function WillHire(ByRef Candidate As Citizen) As Boolean

        '-- Confirm there is an open position
        If GetEmployeeCount() >= Jobs Then
            Return False
        End If

        '-- Make sure the candidate meets the minimum age requirement
        If Candidate.Age < minAge Then
            Return False
        End If

        '-- Check whether candidate will apply (they may be happy with their current job)
        If Not Candidate.WillApply(Me) Then
            Return False
        End If

        If Candidate.GetStat(StatEnum.Intelligence) < 5 Then
            Return False
        End If

        '-- Check the candidate's qualifications
        Dim Odds As Double = 20
        Odds = Odds + (15 - Math.Abs(Age - 35.0)) / 5.0
        Odds = Odds + (Candidate.GetStat(StatEnum.Health) / 9.0)
        Odds = Odds + (Candidate.GetStat(StatEnum.Happiness) / 15.0)
        Odds = Odds - (Candidate.GetStat(StatEnum.Drunkenness) / 6.0)
        Odds = Odds - (Candidate.GetStat(StatEnum.Criminality) / 5.0)
        Odds = Odds + (Candidate.GetStat(StatEnum.Intelligence) / 4.5)
        Odds = Odds + (Candidate.GetStat(StatEnum.Creativity) / 5.5)
        Odds = Odds + (Candidate.GetStat(StatEnum.Mobility) / 15.0)
        If GetRandom(0, 100) <= Odds Then
            HireEmployee(Candidate)
            Return True
        Else
            RejectEmployee(Candidate)
            Return False
        End If

        Return True
    End Function

    Public Sub HireEmployee(ByRef Employee As Citizen, Optional ByVal PostEvent As Boolean = True)
        If GetEmployeeCount() >= Jobs Then
            Return
        End If

        '-- Post the event
        If PostEvent Then
            If Type = BuildingGen.SelfEmployed Then
                Diary.HireEvents.AddEvent(Employee.GetNameAndAddress() + GetEmploymentStatement())
            Else
                Diary.HireEvents.AddEvent(Employee.GetNameAndAddress() + " took a job at the " + GetNameAndAddress())
            End If
        End If

        '-- Quit any previous job
        If Employee.JobBuilding IsNot Nothing Then
            Employee.JobBuilding.Employees.Remove(Employee)
        End If

        '-- Start at your new job
        Employees.Add(Employee)
        Employee.JobBuilding = Me
        Employee.ApplicationAccepted()
    End Sub

    Public Sub RejectEmployee(ByRef Candidate As Citizen)
        Candidate.ApplicationRejected()
    End Sub

    Public Sub TransferEmployees(ByRef SourceBuilding As Building)
        '-- Move employees from another building into this one
        Dim OriginalStaff As New List(Of Citizen)
        For i As Integer = 0 To SourceBuilding.Employees.Count - 1
            OriginalStaff.Add(SourceBuilding.Employees(i))
        Next
        For i As Integer = 0 To OriginalStaff.Count - 1
            HireEmployee(OriginalStaff(i), False)
        Next
    End Sub

    Public Sub MassacreEmployees(ByVal CauseOfDeath As Integer)
        '-- Kill all employees
        Dim OriginalStaff As New List(Of Citizen)
        For i As Integer = 0 To Employees.Count - 1
            OriginalStaff.Add(Employees(i))
        Next
        For i As Integer = 0 To OriginalStaff.Count - 1
            OriginalStaff(i).Die(CauseOfDeath)
        Next
    End Sub

    Public Overridable Sub ExpandBuilding(ByVal NewJobs As Integer)
        Jobs += NewJobs
    End Sub

    Public Overridable Sub CutBack(ByVal JobReduction As Integer)
        Jobs -= JobReduction
        While Employees.Count > Jobs
            Employees(0).Fired()
        End While
    End Sub

    Public Overridable Sub ExpandIfSuccessful()

        '-- Building must be at max employment
        If GetEmployeeCount() = Jobs Then

            '-- Odds of expanding are half the business sucess
            Dim odds As Double = 0.0
            odds += SafeDivide(BusinessSuccess, 2.0)

            '-- Odds of expanding go down as you get larger
            Dim oddsRange As Integer = 100 + (10 * Jobs)

            If GetRandom(0, oddsRange) <= odds Then '-- Remove equal sign to prevent 0 job businesses from expanding?
                '--Buildings expand
                ExpandBuilding(ExpandRate)
                Diary.ExpansionEvents.AddEvent(GetNameAndAddress() + " expanded to capacity " + Jobs.ToString)
            End If
        End If

    End Sub

    Public Overridable Function UpdateInternal() As Boolean
        Age = Age + TimeIncrement

        '-- Decommission old buildings
        Dim DecomissionOdds As Integer = SafeDivide(Age - 50, TimeIncrement)
        If GetRandom(1, 100) < DecomissionOdds Then
            Location.ClosedHistory += 1
            Diary.SpecialBuildingEvents.AddEventNoLimit(GetNameAndAddress() + " closed after " + Age.ToString() + " years")
            Return False
        End If

        '-- Business Success is sum of the employee's employment scores (calculated earlier) divided by the # of jobs
        '-- Plus 1 for every 10 visitors this turn
        BusinessSuccess = SafeDivide(BusinessSuccess, Jobs) + SafeDivide(CurrentVisitors, 10.0)

        Return True
    End Function

    Public Sub UpdateNeighbors(ByVal AddThis As Boolean)

        '-- Update the city squares within range with a refernce to this building
        Dim LocationsInRange As New List(Of CitySquare)
        Location.GetLocationsInRange(GetRange(), LocationsInRange)
        For i As Integer = 0 To LocationsInRange.Count - 1
            If AddThis Then
                Location.NeighborBuildings.Add(Me)
            Else
                Location.NeighborBuildings.Remove(Me)
            End If
        Next

    End Sub

#End Region

#Region " Building Effects "

    Public Overridable Sub ConstructionEffects()
        Age = GetRandom(0, TimeIncrement - 1)

        If Location Is Nothing Then
            Return
        End If

        '-- Commerce Tag: Update the player's CommerceBuilding count.
        If HasTag(BuildingGen.TagEnum.Commerce) Then
            Players(OwnerID).CommerceCount += 1
        End If

        '-- Criminal Tag: Slaughter all other criminals at this location and destroy their buildings
        If HasTag(BuildingGen.TagEnum.Criminal) Then
            Dim CriminalList As List(Of Building) = Location.GetBuildingsByTag(BuildingGen.TagEnum.Criminal)
            For Each CriminalOrg As Building In CriminalList
                If Not CriminalOrg.Equals(Me) Then
                    Diary.SpecialBuildingEvents.AddEventNoLimit(GetNameAndAddress() + " wiped out " + CriminalOrg.GetName() + " and their " + CriminalOrg.Employees.Count.ToString() + " members")
                    CriminalOrg.MassacreEmployees(DeathEnum.Murder)
                    CriminalOrg.Destroy()
                End If
            Next
        End If

        '-- Food Tag: +1 Health for Farm or Ranch
        If HasTag(BuildingGen.TagEnum.Food) Then
            Location.FoodCount += 1
            If Location.CountBuildingsByType(BuildingGen.BuildingEnum.Farm) > 0 Then
                UpdateStatAdjusts(StatEnum.Health, 1, False)
            End If
            If Location.CountBuildingsByType(BuildingGen.BuildingEnum.Ranch) > 0 Then
                UpdateStatAdjusts(StatEnum.Health, 1, False)
            End If
        End If

        '-- Government Tag: Update the player's GovernmentBuilding count.
        If HasTag(BuildingGen.TagEnum.Government) Then
            Players(OwnerID).GovernmentCount += 1
        End If

        '-- Monument Tag: Gets twice the visitor odds if a monument is present
        If HasTag(BuildingGen.TagEnum.Monument) Then
            If Location.CountBuildingsByType(BuildingGen.BuildingEnum.Monument) > 0 Then
                UpdateAllOdds(2.0, True)
            End If
        End If

        '-- Nature Tag: Update the location's nature count
        If HasTag(BuildingGen.TagEnum.Nature) Then
            Location.NatureCount += 1
        End If

        '-- Science Tag: Update the player's science count
        If HasTag(BuildingGen.TagEnum.Science) Then
            Players(OwnerID).ScienceCount += 1
        End If

        '-- Check all buildings at this location
        For Each theBuilding As Building In Location.Buildings
            If theBuilding.Equals(Me) Then
                Continue For
            Else
                theBuilding.UpdateBuildingEffects()
            End If

            If theBuilding.Type = BuildingGen.BuildingEnum.Temp_Agency Then
                '-- If temp agencies are here, add a job to this building for each
                Jobs += 1
                theBuilding.AddEffects(1)
            ElseIf theBuilding.Type = BuildingGen.BuildingEnum.Mine Then
                Dim theMine As MineBuilding = theBuilding
                theMine.ApplyMineRebate(Me)
            End If
        Next

        '-- Check all adjacent locations and their buildings
        Dim AdjLocations As List(Of CitySquare) = Location.GetTrueAdjacents()
        For Each theLocation As CitySquare In AdjLocations
            For Each theBuilding As Building In theLocation.Buildings
                If theBuilding.Type = BuildingGen.BuildingEnum.Warehouse Then
                    '-- For each adjacent warehouse, up the expansion rate
                    ExpandRate += 1
                    theBuilding.AddEffects(1)
                ElseIf theBuilding.Type = BuildingGen.BuildingEnum.Mine Then
                    Dim theMine As MineBuilding = theBuilding
                    theMine.ApplyMineRebate(Me)
                End If
            Next
        Next
    End Sub

    Public Overridable Sub UpdateBuildingEffects()
        '-- Base class does nothing
    End Sub

    Public Overridable Function SavePatient(ByRef thePerson As Citizen, ByVal causeOfDeath As Integer) As Boolean
        '-- Most buildings can not save patients
        Return False
    End Function

    Public Overridable Function PreventCrime(ByRef thePerson As Citizen, ByVal crimeType As Integer) As Integer
        '-- Most buildings can not prevent crimes
        Return CrimePreventionBuilding.PreventionType.Fail
    End Function

    Public Overridable Function GetBirthrateAdjust(ByRef thePerson As Citizen) As Double
        '-- Most buildings do not affect the birthrate
        Return 1.0
    End Function

    Public Function DoesAnotherBuildingOfTheSameTypeExistHere() As Boolean
        Return (Location.CountBuildingsByType(Type) > 1)
    End Function

    Public Overridable Function GetAdjacentLocations() As List(Of CitySquare)
        Dim AdjacentLocations As New List(Of CitySquare)
        Return AdjacentLocations
    End Function

    Public Overridable Sub UpdateEndurance(ByRef Mobility As Integer, ByRef thePerson As Citizen)
        '-- Base class does nothing
    End Sub

    Public Overridable Sub SetupBuilding()
        '-- Reset current revenue and upkeep
        CurrentVisitors = 0
        CurrentEffects = 0
        CurrentRevenue = 0
        CurrentUpkeep = 0
        BusinessSuccess = 0
    End Sub

    Public Overridable Sub CleanupBuilding()
        '-- Base class does nothing
    End Sub

    Public Overridable Function IsLandExpansionOption(ByRef testLocation As CitySquare) As Boolean
        Return False
    End Function



#End Region

#Region " Visits, Effects, Revenue, and Upkeep "
    Public Sub AddVisitors(ByVal NewVisitors As Integer)
        CurrentVisitors += NewVisitors
        TotalVisitors += NewVisitors
    End Sub

    Public Sub AddEffects(ByVal NewEffect As Integer)
        CurrentEffects += NewEffect
        TotalEffects += NewEffect
    End Sub

    Public Sub AddRevenue(ByVal NewRevenue As Integer)
        CurrentRevenue += NewRevenue
        TotalRevenue += NewRevenue
    End Sub

    Public Sub AddUpkeep(ByVal NewUpkeep As Integer)
        CurrentUpkeep += NewUpkeep
        TotalUpkeep += NewUpkeep
    End Sub

    Public Overridable Function CollectRevenue() As Integer
        AddRevenue(SafeDivide(CurrentVisitors, 5.0)) '-- Building revenue increases with visitors
        Return CurrentRevenue
    End Function

    Public Function CollectUpkeep() As Integer
        AddUpkeep(SafeDivide(Age, 10.0)) '-- Building upkeep increases with age
        Return CurrentUpkeep
    End Function
#End Region

#Region " Cost of Building "

    Public Sub DropPrice()
        MarkdownCost = Math.Max(MarkdownCost - DropCostBase, 0)
        PurchasePrice = MarkdownCost
    End Sub

    Public Sub AdjPurchasePrice(ByRef thisPlayer As Player, ByVal CardPosition As Integer)
        '-- Government buildings get 5% more expensive for each one you already have
        If HasTag(BuildingGen.TagEnum.Government) Then
            Dim PriceAdjust As Double = 1.0 + (thisPlayer.GovernmentCount * 0.05)
            PurchasePrice *= PriceAdjust
        End If

        '-- Black markets reduce the price of buildings in certain market locations
        For Each BlackMarket As BlackMarketBuilding In thisPlayer.BlackMarketList
            If BlackMarket.CardPosition = CardPosition Then
                PurchasePrice *= SafeDivide(100.0 - BlackMarket.DiscountPercentage, 100.0)
            End If
        Next
    End Sub

    Public Function IsBuildingUnwanted(ByRef thisPlayer As Player) As Boolean
        '-- Check to see if every player has rejected this building even for free
        If GetCost() <= 0 Then
            If Not RejecterList.Contains(thisPlayer) Then
                RejecterList.Add(thisPlayer)

                '-- Count the number of active players
                Dim ActivePlayers As Integer = 0
                For i As Integer = 0 To Players.Count - 1
                    If Players(i).PlayerType <> PlayerTypeEnum.None Then
                        ActivePlayers += 1
                    End If
                Next

                '-- If all active players have rejected this building, replace it
                If RejecterList.Count = ActivePlayers Then
                    Return True
                End If
            End If
        End If
        Return False
    End Function
#End Region

#Region " Destruction "

    Public Overridable Sub Destroy()
        '-- All the employees are back on the street
        For i As Integer = 0 To Employees.Count - 1
            Dim theEmployee As Citizen = Employees(i)
            theEmployee.JobBuilding = Nothing
        Next

        '-- The founder loses the building
        If Founder IsNot Nothing Then
            Founder.BuildingsFounded.Remove(Me)
        End If

        '-- Commerce Tag:  Lower the player's CommerceCount
        If HasTag(BuildingGen.TagEnum.Commerce) Then
            Players(OwnerID).CommerceCount -= 1
        End If

        '-- Food Tag: +1 Health for Farm or Ranch
        If HasTag(BuildingGen.TagEnum.Food) Then
            Location.FoodCount -= 1
        End If

        '-- If this was a government building, lower the player's government count
        If HasTag(BuildingGen.TagEnum.Government) Then
            Players(OwnerID).GovernmentCount -= 1
        End If

        '-- Science Tag: Update the player's ScienceCount
        If HasTag(BuildingGen.TagEnum.Science) Then
            Players(OwnerID).ScienceCount -= 1
        End If

        '-- Remove the building from this location
        Location.Buildings.Remove(Me)
    End Sub
#End Region

#Region " Evaluation Functions "

    Public Function GetValueForCitizen() As Double
        Dim buildingValue As Double = 0

        '-- Get the value of the building based on its stats
        For i As Integer = 0 To StatEnum.EnumEnd - 1
            buildingValue += (StatOdds(i) * StatAdjusts(i))
        Next

        Return buildingValue

    End Function

    Public Function GetValueForAI(ByRef aiBrain As AIPersonality) As Double
        Dim buildingValue As Double = 0

        '-- Get the value of the building adjusted by the AI's personality
        For i As Integer = 0 To StatEnum.EnumEnd - 1
            buildingValue += (StatOdds(i) * StatAdjusts(i) / 200.0 * aiBrain.GetStatAdjustment(i))
        Next

        buildingValue += (Jobs * aiBrain.GetStatAdjustment(StatEnum.Employment))

        If PurchasePrice <= 0 Then
            Return 9999999.9
        Else
            Return SafeDivide(buildingValue, PurchasePrice)
        End If

    End Function
#End Region

    Public Function PrintStat(ByVal StatType As Integer) As String
        If GetStatOdds(StatType) > 0 Then
            Return GetStatOdds(StatType).ToString() + "% chance to boost " + GetStatName(StatType).ToString() + " up to " + GetStatAdjust(StatType).ToString() + ControlChars.NewLine
        End If
        Return ""
    End Function

    Public Overrides Function toString() As String
        Dim BuildingString As String = ""

        BuildingString += GetName() + ControlChars.NewLine '"Name: " + 

        If OwnerID > 0 Then
            BuildingString += "Player: " + (OwnerID + 1).ToString() + ControlChars.NewLine
            If Founder IsNot Nothing Then
                BuildingString += "Founder: " + Founder.Name + ControlChars.NewLine
            End If
        End If

        If Location IsNot Nothing Then
            BuildingString += "Location: " + Location.GetName() + ControlChars.NewLine
            BuildingString += "Age: " + Age.ToString + ControlChars.NewLine
        End If

        BuildingString += "Cost: $" + GetPurchasePrice().ToString + "   (Base Value $" + GetBaseCost().ToString + ")" + ControlChars.NewLine

        If Range > 0 Then
            BuildingString += "Range: " + GetRange().ToString() + ControlChars.NewLine
        End If
        If ExpandRate > 1 Then
            BuildingString += "Expansion Rate: " + ExpandRate.ToString() + ControlChars.NewLine
        End If

        '-- Show job info
        BuildingString += "Hiring Age: " + minAge.ToString + ControlChars.NewLine
        BuildingString += "Jobs: " + GetEmployeeCount.ToString + "/" + Jobs.ToString + "   Success: " + BusinessSuccess.ToString() + ControlChars.NewLine
        If Employees.Count > 0 Then
            BuildingString += "Employees: "
            For i As Integer = 0 To Employees.Count - 1
                Dim Employee As Citizen = Employees(i)
                BuildingString += Employee.Name

                If i <> Employees.Count - 1 Then
                    BuildingString += ", "
                Else
                    BuildingString += ControlChars.NewLine
                End If
            Next
        End If
        BuildingString += ControlChars.NewLine

        '-- Show visitors, effects, revenue and upkeep
        If TotalVisitors > 0 Or TotalEffects > 0 Or TotalRevenue > 0 Or TotalUpkeep > 0 Then
            If TotalVisitors > 0 Then
                BuildingString += CurrentVisitors.ToString + " visitors this turn." + ControlChars.NewLine
                BuildingString += TotalVisitors.ToString + " visitors total." + ControlChars.NewLine
            End If
            If TotalEffects > 0 Then
                BuildingString += CurrentEffects.ToString + " " + EffectText + " this turn." + ControlChars.NewLine
                BuildingString += TotalEffects.ToString + " " + EffectText + " total." + ControlChars.NewLine
            End If
            If TotalRevenue > 0 Then
                BuildingString += "Revenue this turn: $" + CurrentRevenue.ToString + ControlChars.NewLine
                BuildingString += "Revenue total: $" + TotalRevenue.ToString + ControlChars.NewLine
            End If
            If TotalUpkeep > 0 Then
                BuildingString += "Upkeep this turn: $" + CurrentUpkeep.ToString + ControlChars.NewLine
                BuildingString += "Upkeep total: $" + TotalUpkeep.ToString + ControlChars.NewLine
            End If
            BuildingString += ControlChars.NewLine
        End If

        '-- Show flavor text
        If Info.TrimEnd.Length > 0 Then
            BuildingString += Info + ControlChars.NewLine
        End If

        '-- Show special ability text
        If GetSpecialAbility().Length > 0 Then
            BuildingString += GetSpecialAbility() + ControlChars.NewLine + ControlChars.NewLine
        End If

        '-- Show tags
        If Tags.Count > 0 Then
            BuildingString += "Tags: "
            For i As Integer = 0 To Tags.Count - 1
                BuildingString += BuildingGenerator.GetTagName(Tags(i))

                If i <> Tags.Count - 1 Then
                    BuildingString += ", "
                Else
                    BuildingString += ControlChars.NewLine
                End If
            Next
            BuildingString += ControlChars.NewLine
        End If

        '-- Show stat info
        If DebugMode Then
            For i As Integer = 0 To StatEnum.EnumEnd - 1
                BuildingString += PrintStat(i)
            Next
            BuildingString += ControlChars.NewLine
        End If

        Return BuildingString
    End Function

End Class
