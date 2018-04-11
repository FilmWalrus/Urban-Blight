Partial Public Class MainForm

#Region " Initialization "
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '-- Urban Blight begins HERE
        SetDebugMode(True)

        StartGame()
    End Sub

    Sub StartGame()
        '-- Get player count and game type
        Dim Introduction As New Intro
        If Introduction.ShowDialog() <> DialogResult.OK Then
            Me.DialogResult = DialogResult.No
            Me.Close()
        End If

        '-- Run setup on the NameGenerator and HintGenerator
        Namer.FillLists()
        Hinter.FillLists()

        '-- Fill button list and view dropdown
        FillButtonList()
        FillViewDropdownList()

        '-- Display title, year, game goal, and current view
        UpdateTitle()

        '-- Create players
        CreatePlayers()

        '-- Create the map
        CreateMapGrid()
        CreateOpeningCities()

        '-- Display initial player info
        UpdatePlayers()
        CurrentPlayerIndex = -1

        '-- Finish initialization
        init = True

        '-- First player's turn
        NextPlayer()
    End Sub

    Sub StartNewGame()
        Me.DialogResult = DialogResult.Yes
        Me.Close()
    End Sub

    Sub CreatePlayers()

        '-- Display Player Info GUIs for active players
        For i As Integer = 0 To Players.Count - 1
            Dim thisPlayer As Player = Players(i)

            '-- Display player Info GUIs for active players
            Dim PlayerVisibility As Boolean = False
            If thisPlayer.PlayerType <> PlayerNone Then
                PlayerVisibility = True
            End If

            If i = 0 Then
                Players(i).Flag = Flag1
                gbP1.Visible = PlayerVisibility
                gbP1.BackColor = thisPlayer.Flag
                If thisPlayer.PlayerType = PlayerHuman Then
                    p1_details.Visible = False
                End If
            ElseIf i = 1 Then
                Players(i).Flag = Flag2
                gbP2.Visible = PlayerVisibility
                gbP2.BackColor = thisPlayer.Flag
                If thisPlayer.PlayerType = PlayerHuman Then
                    p2_details.Visible = False
                End If
            ElseIf i = 2 Then
                Players(i).Flag = Flag3
                gbP3.Visible = PlayerVisibility
                gbP3.BackColor = thisPlayer.Flag
                If thisPlayer.PlayerType = PlayerHuman Then
                    p3_details.Visible = False
                End If
            ElseIf i = 3 Then
                Players(i).Flag = Flag4
                gbP4.Visible = PlayerVisibility
                gbP4.BackColor = thisPlayer.Flag
                If thisPlayer.PlayerType = PlayerHuman Then
                    p4_details.Visible = False
                End If
            End If
        Next

    End Sub

    Sub CreateMapGrid()

        Dim path As String = My.Application.Info.DirectoryPath

        '-- Location Variables
        Dim LeftStart As Integer = 16
        Dim LeftIncrement As Integer = 60
        Dim TopStart As Integer = 16
        Dim TopIncrement As Integer = 60

        '-- Create grid of colored labels
        Dim CurrentX As Integer = LeftStart
        Dim CurrentY As Integer = TopStart
        For i As Integer = 0 To GridWidth
            For j As Integer = 0 To GridHeight

                Dim newLocation As New CitySquare(i, j)
                GridArray(i, j) = newLocation

                '-- Set position and size of grid squares
                Dim gridSquare As LabelWithTextBorder = newLocation.GridSquare 'Label
                gridSquare.Location = New System.Drawing.Point(CurrentX, CurrentY)
                gridSquare.Size = New System.Drawing.Size(LeftIncrement, TopIncrement)

                '-- Add handlers
                'AddHandler ClickBox.Click, AddressOf LabelClick
                'AddHandler ClickBox.MouseEnter, AddressOf LabelMouseOver
                AddHandler gridSquare.MouseUp, AddressOf MapMouseUp

                '-- Add this grid square to the main GUI
                Me.Controls.Add(gridSquare)

                CurrentX += LeftIncrement
            Next
            CurrentX = LeftStart
            CurrentY += TopIncrement
        Next
    End Sub

    Sub CreateOpeningCities()
        Dim wallBuffer As Integer = 2
        For i As Integer = 0 To Players.Count - 1

            '-- Make sure this player exists
            Dim thisPlayer As Player = Players(i)
            If thisPlayer.PlayerType = PlayerNone Then
                Continue For
            End If

            '-- Found opening cities
            While (True)
                Dim startX As Integer = GetRandom(wallBuffer, GridWidth - wallBuffer)
                Dim startY As Integer = GetRandom(wallBuffer, GridWidth - wallBuffer)
                Dim theLocation As CitySquare = GridArray(startX, startY)

                '-- Starting cities can't be on or adjacent to another city
                If (Not theLocation.IsOwned() And Not GridArray(startX + 1, startY).IsOwned() And Not GridArray(startX - 1, startY).IsOwned() And Not GridArray(startX, startY - 1).IsOwned() And Not GridArray(startX, startY + 1).IsOwned()) Then
                    theLocation.Occupy(i)

                    '-- Starting cities are always on Plain terrain and start out with free dirt roads
                    theLocation.SetTerrain(TerrainPlain)
                    theLocation.AddRoad()

                    ' Create starting population
                    Dim j As Integer
                    For j = 0 To StartPop - 1
                        Dim founder As New Citizen(True)
                        GridArray(startX, startY).AddPerson(founder)
                    Next

                    GridArray(startX, startY).GridSquare.BackColor = thisPlayer.Flag
                    Exit While
                End If
            End While

        Next

        '-- Mark terrain by water (has to be after opening cities are founded in case they were on a lake)
        UpdateCoastline()

        '-- Redraw the grid
        UpdateGrid()
    End Sub

#End Region

End Class
