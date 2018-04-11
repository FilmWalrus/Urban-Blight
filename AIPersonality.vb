Public Class AIPersonality

#Region " Variables "
    Public DifficultyLevel As Integer = 0

    Public PreferenceList As New List(Of AIDifficulty)

    Public Enum AIDifficulty
        AI_Easy
        AI_Medium
        AI_Hard
        AI_Cheater
    End Enum

    '-- AI Personalities
    Public Enum AIType
        AI_ProBuilding
        AI_ProLand
        AI_ProRoad
        AI_ProJob
        AI_AntiBuilding
        AI_AntiLand
        AI_AntiRoad
        AI_AntiJob
        AI_ProPlain
        AI_ProDirt
        AI_ProForest
        AI_ProDesert
        AI_ProMountain
        AI_ProSwamp
        AI_ProTownship
        AI_ProCoast
        AI_AntiPlain
        AI_AntiDirt
        AI_AntiForest
        AI_AntiDesert
        AI_AntiMountain
        AI_AntiSwamp
        AI_AntiTownship
        AI_AntiCoast
        AI_ProHappiness
        AI_ProHealth
        AI_ProIntelligence
        AI_ProCreativity
        AI_ProMobility
        AI_AntiCrime
        AI_AntiDrunk
        AI_AntiHappiness
        AI_AntiHealth
        AI_AntiIntelligence
        AI_AntiCreativity
        AI_AntiMobility
        AI_ProCrime
        AI_ProDrunk
        AI_Erratic
        AI_Miser
        AI_Spendthrift
        AI_Compulsive
        AI_Error
    End Enum
    '-- Confrontational - Seek out other players
    '-- Shy - Avoid other players
    '-- Schizophrenic - 33% chance of changing personalities each round
    '-- Compulsive - Can not resist likes/dislikes
    '-- ??? - Expansion not based on adj populations

#End Region


#Region " New "
    Public Sub New()
        GeneratePersonality()
    End Sub

    Public Sub GeneratePersonality()
        DifficultyLevel = GetRandom(0, AIDifficulty.AI_Cheater)

        For i As Integer = 0 To 2
            Dim newPreference As Integer = GetRandom(-5, AIType.AI_Error - 1)
            If (Not PreferenceList.Contains(newPreference)) And newPreference >= 0 Then
                PreferenceList.Add(newPreference)
            End If
        Next
    End Sub

#End Region

    Public Function GetReproduceAdjustment() As Double
        Select Case DifficultyLevel
            Case AIDifficulty.AI_Easy
                Return 0.8
            Case AIDifficulty.AI_Medium
                Return 0.9
            Case AIDifficulty.AI_Hard
                Return 1.0
            Case AIDifficulty.AI_Cheater
                Return 1.1
        End Select
    End Function

    Public Function GetTaxAdjustment() As Double

        Select Case DifficultyLevel
            Case AIDifficulty.AI_Easy
                Return 0.8
            Case AIDifficulty.AI_Medium
                Return 0.9
            Case AIDifficulty.AI_Hard
                Return 1.0
            Case AIDifficulty.AI_Cheater
                Return 1.1
        End Select
    End Function

    Public Function BeMiserly() As Boolean
        If PreferenceList.Contains(AIType.AI_Miser) Then
            If GetRandom(0, 1) = 0 Then
                Return True
            End If
        End If
        Return False
    End Function

    Public Function GetDecisionAdjustment() As Double

        '-- Difficulty level
        Dim WobbleMax As Double = 0.0
        Select Case DifficultyLevel
            Case AIDifficulty.AI_Easy
                WobbleMax = 0.4
            Case AIDifficulty.AI_Medium
                WobbleMax = 0.2
            Case AIDifficulty.AI_Hard
                WobbleMax = 0.1
            Case AIDifficulty.AI_Cheater
                WobbleMax = 0.0
        End Select

        If PreferenceList.Contains(AIType.AI_Erratic) Then
            WobbleMax += 0.5
        End If
        Dim DoubleWobble As Double = WobbleMax * 2.0

        '-- Get a random adjustment modifer (as a %) of +/- WobbleMax
        Dim adj As Double = 1.0 + (WobbleMax - (Rnd() * DoubleWobble))

        Return adj

    End Function

    Public Function GetStatAdjustment(ByVal StatType As Integer) As Double

        Dim StatLiked As Double = 5.0
        Dim StatDisliked As Double = -3.0

        If PreferenceList.Contains(AIType.AI_Compulsive) Then
            '-- Compulsive AIs can not overcome their preferences
            StatLiked = 999999999.9
            StatDisliked = -999999999.9
        End If

        Select Case StatType
            Case StatEnum.Happiness
                If PreferenceList.Contains(AIType.AI_ProHappiness) Then
                    Return StatLiked
                ElseIf PreferenceList.Contains(AIType.AI_AntiHappiness) Then
                    Return StatDisliked
                Else
                    Return 1.0
                End If
            Case StatEnum.Health
                If PreferenceList.Contains(AIType.AI_ProHealth) Then
                    Return StatLiked
                ElseIf PreferenceList.Contains(AIType.AI_AntiHealth) Then
                    Return StatDisliked
                Else
                    Return 1.0
                End If
            Case StatEnum.Employment
                If PreferenceList.Contains(AIType.AI_ProJob) Then
                    Return 2.0
                ElseIf PreferenceList.Contains(AIType.AI_AntiJob) Then
                    Return 0.5
                Else
                    Return 1.0
                End If
            Case StatEnum.Intelligence
                If PreferenceList.Contains(AIType.AI_ProIntelligence) Then
                    Return StatLiked
                ElseIf PreferenceList.Contains(AIType.AI_AntiIntelligence) Then
                    Return StatDisliked
                Else
                    Return 1.0
                End If
            Case StatEnum.Creativity
                If PreferenceList.Contains(AIType.AI_ProCreativity) Then
                    Return StatLiked
                ElseIf PreferenceList.Contains(AIType.AI_AntiCreativity) Then
                    Return StatDisliked
                Else
                    Return 1.0
                End If
            Case StatEnum.Mobility
                If PreferenceList.Contains(AIType.AI_ProMobility) Then
                    Return StatLiked
                ElseIf PreferenceList.Contains(AIType.AI_AntiMobility) Then
                    Return StatDisliked
                Else
                    Return 1.0
                End If
            Case StatEnum.Criminality
                If PreferenceList.Contains(AIType.AI_ProCrime) Then
                    Return StatLiked
                ElseIf PreferenceList.Contains(AIType.AI_AntiCrime) Then
                    Return StatDisliked
                Else
                    Return 1.0
                End If
            Case StatEnum.Drunkenness
                If PreferenceList.Contains(AIType.AI_ProDrunk) Then
                    Return StatLiked
                ElseIf PreferenceList.Contains(AIType.AI_AntiDrunk) Then
                    Return StatDisliked
                Else
                    Return 1.0
                End If
        End Select
        Return 1.0
    End Function

    Public Function GetTerrainAdjustment(ByVal TerrainType As Integer) As Double

        Dim TerrainLiked As Double = 2.0
        Dim TerrainDisliked As Double = 0.5
        Dim TerrainStrongDisliked As Double = 0.2

        If PreferenceList.Contains(AIType.AI_Compulsive) Then
            '-- Compulsive AIs can not overcome their preferences
            TerrainLiked = 999999999.9
            TerrainDisliked = -999999999.9
            TerrainStrongDisliked = -999999999.9
        End If

        Select Case TerrainType
            Case TerrainPlain
                If PreferenceList.Contains(AIType.AI_ProPlain) Then
                    Return TerrainLiked
                ElseIf PreferenceList.Contains(AIType.AI_AntiPlain) Then
                    Return TerrainDisliked
                Else
                    Return 1.0
                End If
            Case TerrainDirt
                If PreferenceList.Contains(AIType.AI_ProDirt) Then
                    Return TerrainLiked
                ElseIf PreferenceList.Contains(AIType.AI_AntiDirt) Then
                    Return TerrainDisliked
                Else
                    Return 1.0
                End If
            Case TerrainForest
                If PreferenceList.Contains(AIType.AI_ProForest) Then
                    Return TerrainLiked
                ElseIf PreferenceList.Contains(AIType.AI_AntiForest) Then
                    Return TerrainDisliked
                Else
                    Return 1.0
                End If
            Case TerrainMountain
                If PreferenceList.Contains(AIType.AI_ProMountain) Then
                    Return TerrainLiked
                ElseIf PreferenceList.Contains(AIType.AI_AntiMountain) Then
                    Return TerrainStrongDisliked
                Else
                    Return 1.0
                End If
            Case TerrainLake
                If PreferenceList.Contains(AIType.AI_ProCoast) Then
                    Return TerrainLiked
                ElseIf PreferenceList.Contains(AIType.AI_AntiCoast) Then
                    Return TerrainDisliked
                Else
                    Return 1.0
                End If
            Case TerrainSwamp
                If PreferenceList.Contains(AIType.AI_ProSwamp) Then
                    Return TerrainLiked
                ElseIf PreferenceList.Contains(AIType.AI_AntiSwamp) Then
                    Return TerrainStrongDisliked
                Else
                    Return 1.0
                End If
            Case TerrainDesert
                If PreferenceList.Contains(AIType.AI_ProDesert) Then
                    Return TerrainLiked
                ElseIf PreferenceList.Contains(AIType.AI_AntiDesert) Then
                    Return TerrainDisliked
                Else
                    Return 1.0
                End If
            Case TerrainTownship
                If PreferenceList.Contains(AIType.AI_ProTownship) Then
                    Return TerrainLiked
                ElseIf PreferenceList.Contains(AIType.AI_AntiTownship) Then
                    Return TerrainDisliked
                Else
                    Return 1.0
                End If
        End Select
        Return 1.0
    End Function

    Public Function GetProAdjustment() As Double
        If PreferenceList.Contains(AIType.AI_Compulsive) Then
            '-- Compulsive AIs can not overcome their preferences
            Return 999999999.9
        Else
            Return 1.5
        End If
    End Function

    Public Function GetAntiAdjustment() As Double
        If PreferenceList.Contains(AIType.AI_Compulsive) Then
            '-- Compulsive AIs can not overcome their preferences
            Return -1.0
        Else
            Return 0.5
        End If
    End Function

    Public Function GetRoadAdjustment() As Double
        If PreferenceList.Contains(AIType.AI_ProRoad) Then
            Return GetProAdjustment()
        ElseIf PreferenceList.Contains(AIType.AI_AntiRoad) Then
            Return GetAntiAdjustment()
        Else
            Return 1.0
        End If
    End Function

    Public Function GetBuildingAdjustment() As Double
        If PreferenceList.Contains(AIType.AI_ProBuilding) Then
            Return GetProAdjustment()
        ElseIf PreferenceList.Contains(AIType.AI_AntiBuilding) Then
            Return GetAntiAdjustment()
        Else
            Return 1.0
        End If
    End Function

    Public Function GetLandAdjustment() As Double
        If PreferenceList.Contains(AIType.AI_ProLand) Then
            Return GetProAdjustment()
        ElseIf PreferenceList.Contains(AIType.AI_AntiLand) Then
            Return GetAntiAdjustment()
        Else
            Return 1.0
        End If
    End Function

    Public Overrides Function toString() As String

        Dim personalityText As String = ""

        '-- Difficulty level
        Select Case DifficultyLevel
            Case AIDifficulty.AI_Easy
                personalityText += "Rookie"
            Case AIDifficulty.AI_Medium
                personalityText += "Amateur"
            Case AIDifficulty.AI_Hard
                personalityText += "Pro" '-- Expert
            Case AIDifficulty.AI_Cheater
                personalityText += "Cheater"
        End Select

        If PreferenceList.Count > 0 Then
            personalityText += ", "
        End If

        '-- Personality type
        For i As Integer = 0 To PreferenceList.Count - 1
            Dim currentPref As Integer = PreferenceList(i)
            Select Case currentPref
                Case AIType.AI_ProBuilding
                    personalityText += "Builder"
                Case AIType.AI_ProLand
                    personalityText += "Expansionist"
                Case AIType.AI_ProRoad
                    personalityText += "Driver"
                Case AIType.AI_ProJob
                    personalityText += "Employer"
                Case AIType.AI_AntiBuilding
                    personalityText += "Hippy"
                Case AIType.AI_AntiLand
                    personalityText += "Recluse"
                Case AIType.AI_AntiRoad
                    personalityText += "Pedestrian"
                Case AIType.AI_AntiJob
                    personalityText += "Hobo" 'Bum
                Case AIType.AI_ProPlain
                    personalityText += "Rancher"
                Case AIType.AI_ProDirt
                    personalityText += "Farmer"
                Case AIType.AI_ProForest
                    personalityText += "Nature Lover"
                Case AIType.AI_ProDesert
                    personalityText += "Sun Bather"
                Case AIType.AI_ProMountain
                    personalityText += "Mountaineer"
                Case AIType.AI_ProSwamp
                    personalityText += "Snake Charmer"
                Case AIType.AI_ProTownship
                    personalityText += "Socialite" 'Extrovert
                Case AIType.AI_ProCoast
                    personalityText += "Swimmer"
                Case AIType.AI_AntiPlain
                    personalityText += "Agoraphobe"
                Case AIType.AI_AntiDirt
                    personalityText += "Misophobe"
                Case AIType.AI_AntiForest
                    personalityText += "Hylophobe" 'Hylophobe
                Case AIType.AI_AntiDesert
                    personalityText += "Xerophobe"
                Case AIType.AI_AntiMountain
                    personalityText += "Acrophobe"
                Case AIType.AI_AntiSwamp
                    personalityText += "Herpetophobe" 'Ophidiophobia
                Case AIType.AI_AntiTownship
                    personalityText += "Misanthrope" 'Anthropophobe Introvert
                Case AIType.AI_AntiCoast
                    personalityText += "Aquaphobe"
                Case AIType.AI_ProHealth
                    personalityText += "Health Nut" 'Jock
                Case AIType.AI_ProHappiness
                    personalityText += "Fun Lover" 'Party Animal, Optimist
                Case AIType.AI_ProIntelligence
                    personalityText += "Nerd"
                Case AIType.AI_ProCreativity
                    personalityText += "Artist"
                Case AIType.AI_ProMobility
                    personalityText += "Traveler"
                Case AIType.AI_AntiCrime
                    personalityText += "Crime Fighter"
                Case AIType.AI_AntiDrunk
                    personalityText += "Teetotaler" 'Prohibitionist
                Case AIType.AI_AntiHealth
                    personalityText += "Slob"
                Case AIType.AI_AntiHappiness
                    personalityText += "Sad Sack" 'Pessimist
                Case AIType.AI_AntiIntelligence
                    personalityText += "Anti-Intellectual"
                Case AIType.AI_AntiCreativity
                    personalityText += "Dullard"
                Case AIType.AI_AntiMobility
                    personalityText += "Couch Potato"
                Case AIType.AI_ProCrime
                    personalityText += "Crook"
                Case AIType.AI_ProDrunk
                    personalityText += "Drunk"
                Case AIType.AI_Erratic
                    personalityText += "Eccentric"
                Case AIType.AI_Miser
                    personalityText += "Miser"
                Case AIType.AI_Spendthrift
                    personalityText += "Spendthrift"
                Case AIType.AI_Compulsive
                    personalityText += "Compulsive"
                Case AIType.AI_Error
                    personalityText += "Error"
            End Select

            If i <> PreferenceList.Count - 1 Then
                personalityText += ", "
            End If
        Next

        Return personalityText
    End Function

End Class
