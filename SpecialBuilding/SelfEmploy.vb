Public Class SelfEmployBuilding
    Inherits Building

    Public SelfEmploymentType As Integer = -1

    Public Enum SelfEmployEnum
        Novelist
        Painter
        Poet
        Sculptor
        Designer
        Photographer
        Jeweler
        Composer
        Street_Musician

        Blogger
        Freelance_Journalist

        Fisherman
        Farmer

        Caterer
        Confectioner
        Microbrewer
        Food_Truck_Operator

        Personal_Trainer
        Yoga_Instructor
        Masseuse
        Private_Tutor
        Event_Planner
        House_Cleaner
        Landscaper
        Nanny
        Hairdresser
        Beautician
        Dog_Walker
        Driver
        Bodyguard

        'Clown
        'Magician

        Plumber
        Electrician
        Carpenter
        Mechanic
        Machinist
        Welder
        Glazier
        Engraver
        Contractor
        Locksmith
        Pest_Exterminator

        Tailor
        Dry_Cleaner
        Traveling_Salesperson
        Watchmaker
        Small_Business_Owner
        Shopkeeper

        Landlord
        Consultant
        Therapist
        Programmer
        Lawyer
        Accountant
        Realtor

        Fortune_Teller
        Gambler

        Petty_Thief
        Drug_Dealer

        EndEnum
    End Enum

    Public Function GetSelfEmployment(ByVal SelfEmployType As Integer) As String
        Dim SelfEmployString As String = CType(SelfEmployType, SelfEmployEnum).ToString()
        SelfEmployString = SelfEmployString.Replace("_", " ")
        Return SelfEmployString
    End Function

    Sub New(ByVal bType As Integer, ByVal bCost As Integer, ByVal bJobs As Integer, Optional ByVal bMinAge As Integer = Citizen.MinorAge)
        MyBase.New(BuildingGen.SelfEmployed, bCost, bJobs, bMinAge)
    End Sub

    Sub ChooseSelfEmployment(ByRef TheCitizen As Citizen)
        If GetRandom(1, 100) < TheCitizen.GetStat(StatEnum.Drunkenness) Then
            SelfEmploymentType = SelfEmployEnum.Drug_Dealer
        ElseIf GetRandom(1, 100) < TheCitizen.GetStat(StatEnum.Criminality) Then
            SelfEmploymentType = SelfEmployEnum.Petty_Thief
        Else
            SelfEmploymentType = GetRandom(0, SelfEmployEnum.EndEnum - 1)
        End If
    End Sub

    Public Overrides Function GetEmploymentStatement() As String
        Return "Self-Employed as a " + GetSelfEmployment(SelfEmploymentType)
    End Function

End Class
