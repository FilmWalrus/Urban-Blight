'-- This file contains classes for Hospital and other Medical-type buildings

Public Class HospitalBuilding
    Inherits Building

    Public HospitalCampus As New List(Of Integer)

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
        SetRange(1) '-- Hospitals have a base range of 1
        EffectText = "lives saved"
    End Sub

    Public Sub UpdateHospitalCampus(ByVal medType As Integer)
        If Not HospitalCampus.Contains(medType) Then
            HospitalCampus.Add(medType)
        End If
    End Sub

    Public Overrides Sub ConstructionEffects()
        MyBase.ConstructionEffects()

        '-- Increase the range of hospitals on this square if an ambulance service is present
        If Location.CountBuildingsByType(BuildingGen.BuildingEnum.Ambulance_Service) > 0 Then
            Range += 1
        End If

        UpdateHospitalCampus(Type)

        '-- Update all medical buildings on this location to alert them that the hospital campus has changed
        Dim MedicalBuildings As List(Of Building) = Location.GetBuildingsByTag(BuildingGen.TagEnum.Medical)
        For i As Integer = 0 To MedicalBuildings.Count - 1
            Dim thisMedicalBuilding As Building = MedicalBuildings(i)
            thisMedicalBuilding.UpdateBuildingEffects()
        Next
    End Sub

    Public Overrides Sub UpdateBuildingEffects()
        '-- Add all local medical buildings to the hospital campus
        Dim MedicalBuildings As List(Of Building) = Location.GetBuildingsByTag(BuildingGen.TagEnum.Medical)
        For i As Integer = 0 To MedicalBuildings.Count - 1
            Dim thisMedicalBuilding As Building = MedicalBuildings(i)
            UpdateHospitalCampus(thisMedicalBuilding.Type)
        Next
    End Sub

    Public Overridable Function IsSpecialty(ByRef thePerson As Citizen, ByVal causeOfDeath As Integer) As Boolean
        Return False '-- Default hospital doesn't have a specialty
    End Function

    Public Function GetHealthBonus() As Integer
        '-- Medical buildings are more effective when part of a large hospital campus
        Dim HealthBonus As Integer = (HospitalCampus.Count - 1) * 3.0
        Return HealthBonus
    End Function

    Public Overrides Function SavePatient(ByRef thePerson As Citizen, ByVal causeOfDeath As Integer) As Boolean

        '-- Check if the hospital specializes in this type of thing
        If Not IsSpecialty(thePerson, causeOfDeath) Then
            Return False
        End If

        '-- Check if hospital is in range
        Dim Distance As Integer = Location.GetDistance(thePerson.Residence)
        If Distance > Range Then
            Return False
        End If

        '-- Get the odds of saving a patient at this range
        Dim SaveOdds As Integer = 12
        If Distance < Range Then
            SaveOdds = 25
        End If
        SaveOdds += GetHealthBonus()

        '-- Attempt to save!
        If GetRandom(1, 100) <= SaveOdds Then
            AddEffects(1)
            Return True
        Else
            Return False
        End If
    End Function

    Public Overrides Function GetStatOdds(ByVal StatType As Integer) As Integer
        If StatType = StatEnum.Health Then
            Return MyBase.GetStatOdds(StatType) + GetHealthBonus()
        End If
        Return MyBase.GetStatOdds(StatType)
    End Function

    Public Overrides Sub Destroy()
        '-- Make sure there isn't another of this building on this square
        If DoesAnotherBuildingOfTheSameTypeExistHere() Then
            Return
        End If

        '-- Update all medical buildings on this location to alert them that the hospital campus has changed
        Dim MedicalBuildings As List(Of Building) = Location.GetBuildingsByTag(BuildingGen.TagEnum.Medical)
        For i As Integer = 0 To MedicalBuildings.Count - 1
            Dim thisMedicalBuilding As Building = MedicalBuildings(i)
            thisMedicalBuilding.UpdateBuildingEffects()
        Next

        MyBase.Destroy()
    End Sub
End Class

Public Class HospitalCancerBuilding
    Inherits HospitalBuilding

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
    End Sub

    Public Overrides Function IsSpecialty(ByRef thePerson As Citizen, ByVal causeOfDeath As Integer) As Boolean
        Return (causeOfDeath = DeathEnum.Illness)
    End Function
End Class

Public Class HospitalEmergencyBuilding
    Inherits HospitalBuilding

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
    End Sub

    Public Overrides Function IsSpecialty(ByRef thePerson As Citizen, ByVal causeOfDeath As Integer) As Boolean
        Return (causeOfDeath = DeathEnum.TrafficAccident)
    End Function
End Class

Public Class HospitalPediatricBuilding
    Inherits HospitalBuilding

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
    End Sub

    Public Overrides Function IsSpecialty(ByRef thePerson As Citizen, ByVal causeOfDeath As Integer) As Boolean
        Return thePerson.IsMinor()
    End Function
End Class

Public Class HospitalGeriatricBuilding
    Inherits HospitalBuilding

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
    End Sub

    Public Overrides Function IsSpecialty(ByRef thePerson As Citizen, ByVal causeOfDeath As Integer) As Boolean
        Return thePerson.IsElderly()
    End Function
End Class

Public Class HospitalMaternityBuilding
    Inherits HospitalBuilding

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
    End Sub

    Public Overrides Function GetBirthrateAdjust(ByRef thePerson As Citizen) As Double

        '-- Check if hospital is in range
        Dim Distance As Integer = Location.GetDistance(thePerson.Residence)
        If Distance > Range Then
            Return 1.0
        End If

        '-- Get the odds of saving a patient at this range
        Dim BirthrateAdjust As Double = 1.1
        If Distance < Range Then
            BirthrateAdjust = 1.2
        End If

        Return BirthrateAdjust
    End Function
End Class

Public Class AmbulanceBuilding
    Inherits Building

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer)
        MyBase.New(bType, bCost, bJobs)
    End Sub

    Public Overrides Sub ConstructionEffects()
        MyBase.ConstructionEffects()

        '-- Make sure there isn't already a building of this type here
        If Location.CountBuildingsByType(BuildingGen.BuildingEnum.Ambulance_Service) > 0 Then
            Return
        End If

        '-- Increase the range of medical buildings on this square
        Dim BuildingList As List(Of Building) = Location.GetBuildingsByTag(BuildingGen.TagEnum.Medical)
        For i As Integer = 0 To BuildingList.Count - 1
            Dim thisBuilding As Building = BuildingList(i)
            thisBuilding.Range += 1
        Next
    End Sub

    Public Overrides Sub Destroy()
        '-- Make sure there isn't another of this building on this square
        If Location.CountBuildingsByType(BuildingGen.BuildingEnum.Ambulance_Service) > 1 Then
            Return
        End If

        '-- Decrease the range of medical buildings on this square
        Dim BuildingList As List(Of Building) = Location.GetBuildingsByTag(BuildingGen.TagEnum.Medical)
        For i As Integer = 0 To BuildingList.Count - 1
            Dim thisBuilding As Building = BuildingList(i)
            thisBuilding.Range -= 1
        Next

        MyBase.Destroy()
    End Sub
End Class
