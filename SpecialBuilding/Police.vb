'-- This file contains classes for Police Stations and other Security-type buildings

Public Class CrimePreventionBuilding
    Inherits Building

    Public DefaultOdds As New List(Of Double)
    Public ChanceFatal As Double = 0

    Enum PreventionType
        Fail
        SuccessPeaceful
        SuccessFatal
    End Enum

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
        SetRange(1)
        EffectText = "crimes prevented"
    End Sub

    Public Overridable Function IsSpecialty(ByRef thePerson As Citizen, ByVal crimeType As Integer) As Boolean
        Return True '-- Default crime preventer doesn't have a specialty
    End Function

    Public Overridable Function GetChanceFatal(ByRef thePerson As Citizen, ByVal crimeType As Integer) As Double
        Dim OddsFatal As Double = ChanceFatal
        OddsFatal += SafeDivide(thePerson.Criminality, 8.0) '-- Hardened criminals are more likely to die
        OddsFatal += SafeDivide(thePerson.Drunkenness, 8.0) '-- Criminals are more likely to die if they are drunk
        Return OddsFatal
    End Function

    Public Overridable Function CheckIfFatal(ByRef thePerson As Citizen, ByVal crimeType As Integer) As Integer
        If GetRandom(1, 100) <= GetChanceFatal(thePerson, crimeType) Then
            Return PreventionType.SuccessFatal
        Else
            '-- If the criminal was caught and not killed, they get fired from any job they had
            thePerson.Fired()
            Return PreventionType.SuccessPeaceful
        End If
    End Function

    Public Overridable Function GetPreventionOdds(ByVal Distance As Integer) As Integer
        '-- Get the odds of preventing a crime at this range
        If Distance > Range Then
            Return 0
        ElseIf Range > DefaultOdds.Count Then
            '-- If range increases expand the odds outward
            Distance -= (Range - DefaultOdds.Count)
        End If
        Dim Odds As Double = DefaultOdds(Distance)
        Return Odds
    End Function

    Public Overrides Function PreventCrime(ByRef thePerson As Citizen, ByVal crimeType As Integer) As Integer

        '-- Check if the crime preventer specializes in this type of thing
        If Not IsSpecialty(thePerson, crimeType) Then
            Return PreventionType.Fail
        End If

        '-- Check if crime preventer is in range
        Dim Distance As Integer = Location.GetDistance(thePerson.Residence)
        If Distance > Range Then
            Return PreventionType.Fail
        End If

        '-- Get the odds of preventing a crime at this range
        Dim PreventOdds As Integer = GetPreventionOdds(Distance)

        '-- Attempt to prevent this crime!
        If GetRandom(1, 100) <= PreventOdds Then
            AddEffects(1)

            '-- Check if the criminal was killed in the incident
            Return CheckIfFatal(thePerson, crimeType)
        Else
            Return PreventionType.Fail
        End If
    End Function

End Class

Public Class DetectiveBuilding
    Inherits CrimePreventionBuilding

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
        DefaultOdds.Add(50.0)
        DefaultOdds.Add(25.0)
        DefaultOdds.Add(5.0)
        SetRange(2)
        ChanceFatal = 2
        EffectText = "cases solved"
    End Sub

End Class

Public Class FireStationBuilding
    Inherits CrimePreventionBuilding

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
        DefaultOdds.Add(90.0)
        DefaultOdds.Add(75.0)
        ChanceFatal = 0
        EffectText = "fires extinguished"
    End Sub

    Public Overrides Function IsSpecialty(ByRef thePerson As Citizen, ByVal crimeType As Integer) As Boolean
        Return crimeType = Turn.CrimeType.Arson '-- Fire departments only prevent arson
    End Function

End Class

Public Class MilitaryBaseBuilding
    Inherits CrimePreventionBuilding

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
        DefaultOdds.Add(30.0)
        DefaultOdds.Add(20.0)
        ChanceFatal = 50
    End Sub

    Public Overrides Function IsSpecialty(ByRef thePerson As Citizen, ByVal crimeType As Integer) As Boolean
        Return True '-- Armies prevent most crimes
    End Function

End Class

Public Class PoliceBuilding
    Inherits CrimePreventionBuilding

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
        DefaultOdds.Add(80.0)
        DefaultOdds.Add(40.0)
        DefaultOdds.Add(10.0)
        ChanceFatal = 10
        SetRange(2)
    End Sub

End Class

Public Class PrivateSecurityBuilding
    Inherits CrimePreventionBuilding

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
        DefaultOdds.Add(95.0)
        DefaultOdds.Add(65.0)
        ChanceFatal = 0
        EffectText = "threats neutralized"
    End Sub

    Public Overrides Function GetChanceFatal(ByRef thePerson As Citizen, ByVal crimeType As Integer) As Double
        Dim odds As Double = MyBase.GetChanceFatal(thePerson, crimeType)

        Select Case crimeType
            Case Turn.CrimeType.Murder
                odds += 100
            Case Turn.CrimeType.Arson
                odds += 80.0
            Case Else
                odds += 40.0
        End Select

        Return odds
    End Function

    Public Overrides Function IsSpecialty(ByRef thePerson As Citizen, ByVal crimeType As Integer) As Boolean
        If crimeType = Turn.CrimeType.Murder Then '-- Private security specializes in bodyguarding
            Return True
        Else
            Return GetRandom(1, 100) < 50
        End If
    End Function

End Class
