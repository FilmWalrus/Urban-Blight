Public Class NameGenerator

#Region " Variables "
    Dim FirstSyllable As New ArrayList
    Dim Middle As New ArrayList
    Dim Ending As New ArrayList
    Dim Vowels As New ArrayList
    Dim VowelsPlus As New ArrayList

#End Region

#Region " Functions "
    Public Sub FillLists()
        '--Cleanup
        FirstSyllable.Clear()
        Middle.Clear()
        Ending.Clear()
        Vowels.Clear()
        VowelsPlus.Clear()

        '--Vowels
        Vowels.Add("a")
        Vowels.Add("e")
        Vowels.Add("i")
        Vowels.Add("o")
        Vowels.Add("u")
        VowelsPlus.Add("ai")
        VowelsPlus.Add("ea")
        VowelsPlus.Add("au")
        VowelsPlus.Add("oa")
        VowelsPlus.Add("oi")
        VowelsPlus.Add("ou")
        VowelsPlus.Add("oo")
        VowelsPlus.Add("ee")

        '--FirstSyllable
        FirstSyllable.Add("B")
        FirstSyllable.Add("Br")
        FirstSyllable.Add("Bl")
        FirstSyllable.Add("C")
        FirstSyllable.Add("Cr")
        FirstSyllable.Add("Cl")
        FirstSyllable.Add("Ch")
        FirstSyllable.Add("Chr")
        FirstSyllable.Add("D")
        FirstSyllable.Add("Dr")
        FirstSyllable.Add("F")
        FirstSyllable.Add("Fr")
        FirstSyllable.Add("Fl")
        FirstSyllable.Add("G")
        FirstSyllable.Add("Gr")
        FirstSyllable.Add("Gl")
        FirstSyllable.Add("Gn")
        FirstSyllable.Add("H")
        FirstSyllable.Add("J")
        FirstSyllable.Add("K")
        FirstSyllable.Add("Kl")
        FirstSyllable.Add("Kr")
        FirstSyllable.Add("L")
        FirstSyllable.Add("M")
        FirstSyllable.Add("N")
        FirstSyllable.Add("P")
        FirstSyllable.Add("Pl")
        FirstSyllable.Add("Pr")
        FirstSyllable.Add("Ph")
        FirstSyllable.Add("Qu")
        FirstSyllable.Add("R")
        FirstSyllable.Add("Rh")
        FirstSyllable.Add("S")
        FirstSyllable.Add("St")
        FirstSyllable.Add("Sh")
        FirstSyllable.Add("Sc")
        FirstSyllable.Add("Sk")
        FirstSyllable.Add("Scr")
        FirstSyllable.Add("Shr")
        FirstSyllable.Add("Sn")
        FirstSyllable.Add("Sm")
        FirstSyllable.Add("Sv")
        FirstSyllable.Add("T")
        FirstSyllable.Add("Tr")
        FirstSyllable.Add("Th")
        FirstSyllable.Add("V")
        FirstSyllable.Add("W")
        FirstSyllable.Add("Wr")
        FirstSyllable.Add("Wh")
        FirstSyllable.Add("X")
        FirstSyllable.Add("Y")
        FirstSyllable.Add("Z")

        '--Middle
        Middle.Add("b")
        Middle.Add("bb")
        Middle.Add("c")
        Middle.Add("ck")
        Middle.Add("ch")
        Middle.Add("cr")
        Middle.Add("cc")
        Middle.Add("d")
        Middle.Add("dd")
        Middle.Add("dr")
        Middle.Add("f")
        Middle.Add("ff")
        Middle.Add("fr")
        Middle.Add("g")
        Middle.Add("gr")
        Middle.Add("gg")
        Middle.Add("kk")
        Middle.Add("l")
        Middle.Add("ll")
        Middle.Add("m")
        Middle.Add("mm")
        Middle.Add("n")
        Middle.Add("nn")
        Middle.Add("p")
        Middle.Add("pp")
        Middle.Add("pr")
        Middle.Add("pl")
        Middle.Add("r")
        Middle.Add("rr")
        Middle.Add("s")
        Middle.Add("ss")
        Middle.Add("sh")
        Middle.Add("sc")
        Middle.Add("t")
        Middle.Add("tt")
        Middle.Add("th")
        Middle.Add("tr")
        Middle.Add("v")
        Middle.Add("w")

        '--Endings
        Ending.Add("b")
        Ending.Add("ck")
        Ending.Add("ch")
        Ending.Add("d")
        Ending.Add("f")
        Ending.Add("ff")
        Ending.Add("g")
        Ending.Add("ght")
        Ending.Add("ghton")
        Ending.Add("h")
        Ending.Add("ht")
        Ending.Add("k")
        Ending.Add("l")
        Ending.Add("ll")
        Ending.Add("lm")
        Ending.Add("lt")
        Ending.Add("lp")
        Ending.Add("m")
        Ending.Add("n")
        Ending.Add("mn")
        Ending.Add("p")
        Ending.Add("que")
        Ending.Add("r")
        Ending.Add("rt")
        Ending.Add("rn")
        Ending.Add("rch")
        Ending.Add("s")
        Ending.Add("ss")
        Ending.Add("st")
        Ending.Add("son")
        Ending.Add("sh")
        Ending.Add("t")
        Ending.Add("tt")
        Ending.Add("th")
        Ending.Add("ton")
        Ending.Add("vich")
        Ending.Add("w")
        Ending.Add("x")
        Ending.Add("y")
        Ending.Add("z")
    End Sub

    Public Function GenerateName() As String
        Dim nameStr As String = ""
        Dim i, max As Integer

        '--First Syllable
        max = FirstSyllable.Count - 1
        nameStr += FirstSyllable(GetRandom(0, max))

        '--First Vowel
        If GetRandom(0, 2) <= 1 Then
            max = Vowels.Count - 1
            nameStr += Vowels(GetRandom(0, max))
        Else
            max = VowelsPlus.Count - 1
            nameStr += VowelsPlus(GetRandom(0, max))
        End If

        '--Second Syllable
        If GetRandom(0, 1) = 0 Then
            max = Middle.Count - 1
            nameStr += Middle(GetRandom(0, max))
        Else
            'Last Syllable
            max = Ending.Count - 1
            nameStr += Ending(GetRandom(0, max))
            '--Final Vowel
            If GetRandom(0, 3) = 0 Then
                max = Vowels.Count - 1
                nameStr += Vowels(GetRandom(0, max))
            End If
            Return nameStr
        End If

        '--Second Vowel
        If GetRandom(0, 2) <= 1 Then
            max = Vowels.Count - 1
            nameStr += Vowels(GetRandom(0, max))
        Else
            max = VowelsPlus.Count - 1
            nameStr += VowelsPlus(GetRandom(0, max))
        End If

        '--Third Syllable
        max = Ending.Count - 1
        nameStr += Ending(GetRandom(0, max))
        '--Final Vowel
        If GetRandom(0, 3) = 0 Then
            max = Vowels.Count - 1
            nameStr += Vowels(GetRandom(0, max))
        End If
        Return nameStr
    End Function

#End Region
End Class
