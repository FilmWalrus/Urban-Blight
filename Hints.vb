Public Class HintGenerator

#Region " Variables "
    Dim HintList As New List(Of String)

    Dim BuildList As New List(Of BuildMan)
#End Region

#Region " Functions "

    Public Sub FillLists()
        '-- Citizens
        HintList.Add("Many traits are partially hereditary, like intelligence and creativity. Predispositions towards crime and alcohal can also be passed on.")
        HintList.Add("Each turn your citizens go through six phases: (1) Aging, internal changes and possibly death, (2) Reproduction, (3) Travel, (4) Leisure, visiting building and applying for jobs, (5) Crime and accidents, (6) Taxation.")
        HintList.Add("The numbers for all eight citizen trait range from 0 to 100.")
        '-- Population
        HintList.Add("Dense, crowded cities can be unhygenic and depressing, lowering health and happiness.")
        HintList.Add("Crowded cities encourage crime, in addition to having other detrimental effects. However, kids who grow up in densily populated cities gain extra street smarts.")
        '-- Health
        HintList.Add("Umemployed citizens with low health will often take the starving artist path and call up creative reserves to survive.")
        HintList.Add("Health is the single most important factor in whether your citizen will reproduce, but many other factors are involved.")
        HintList.Add("Your citizens will die if their health becomes low or their age becomes very high. They can also die for other reasons.")
        '-- Intelligence and Creativity
        HintList.Add("All citizens attend primary school, but must apply to get higher education. To be accepted, students must have increase their intelligence rapidly while still fairly young. Entrance standards are higher in larger cities. Keep in mind that higher education does not require college buildings.")
        '-- Employment
        HintList.Add("Your citizens must apply for jobs based on their traits. Once employed, their 'employment' trait will go to 1 and then will gradually increase.")
        HintList.Add("Once employed, citizens will succeed in their jobs based on their intelligence and creativity. If a business is fully staffed and highly successful, it may expand to hire more employees.")
        HintList.Add("Unemployed citizens that are not minors will get ever more depressed and will gradually turn to crime.")
        HintList.Add("Citizens who are very successful at their employment are happier and more fulfilled.")
        HintList.Add("Citizens normally pay $5 in tax (even dependents) but must pay an extra $2 after getting employed.")
        '-- Mobility and Transportation
        HintList.Add("Babies are born with almost no mobility, but it increases rapidly as they learn to walk, run and bike. At the age of 16 citizens learn to drive and if they already have a job, they'll buy a hotrod and get an extra mobility boost.")
        HintList.Add("Citizens move around within your kingdom for three reasons: (1) To escape urban crowds and crime, (2) To find jobs if unemployed, (3) To seek out culture and fun in highly developed areas.")
        HintList.Add("Citizens with high mobility are more likely to get into car crashes. However, better roads reduce the risk.")
        HintList.Add("The mobility of your citizens increases based on the quality of the roads where they are living.")
        HintList.Add("Better roads allow far ranging movement for your citizens. With highways and highly mobile citizens, movement can be virtually unlimited.")
        HintList.Add("Roads are best improved in centrally located areas, to maximize their use.")
        HintList.Add("The road quality of a destination city does not affect the journey to it, only the journey beyond it.")
        '-- Emigration & Rivalry
        HintList.Add("Citizens can emigrate between rival kingdoms or visit foreign buildings that are within physical contact.")
        HintList.Add("Happy citizens are more patriotic and are less inclined to emigrate to rival cities. However, nothing stop them from benefitting from a rival's buildings if these are within their mobility range.")
        HintList.Add("Place buildings with negative qualities (like crime rings, bars and factories) just outside the borders of rival players to make sure they share the detrimental effects.")
        HintList.Add("Create job opportunities and highly-developed cultural centers on the borders to rival cities to seduce their citizens into emigrating.")
        HintList.Add("If you are far behind in population, try connecting your kingdom to a crowded rival to nab immigrants.")
        '-- Drunkenness
        HintList.Add("Drunkenness makes your citizens happier and more sexual free, but it does have negative side-effects. It can make it harder for your citizens to get hired for jobs and increases the chance of car accidents and crimes of passion.")
        HintList.Add("Bars, Stadiums and Colleges increase drunkenness. Police stations, churches, hospitals and coffee shops decrease it.")
        HintList.Add("After drunkenness reaches a certain point, it becomes addictive for a citizen. High amounts of alcohal can be unhealthy for them and lead to depressions. If the addiction becomes life threatening rare citizens have the will power to go cold turkey.")
        '-- Criminality
        HintList.Add("Citizens steal from the national treasury and commit murder as their criminality increases.")
        HintList.Add("Some murderers develop a taste for crime and become more likely to strike after every kill, especially if the victim was rich and well-employed.")
        HintList.Add("When citizens steal, they always take an amount equal to their current criminality stat.")
        '-- Buildings
        HintList.Add("Citizens regularly visit buildings in nearby cities and experience their effects if their mobility allows.")
        HintList.Add("Buildings only affect the character traits of your population. They have no special abilities.")
        HintList.Add("All buildings drop in price by $5 after every purchase and at the end of turns. Making all your land and road purchases at the beginning of your turn will save you money on buildings.")
        HintList.Add("If a building reaches a cost of $0 and is still not purchased, it will eventually be replaced.")
        '-- Score
        HintList.Add("Your score is determined by a combination of population (based on their traits), building development, territory and employment ratio.")
        HintList.Add("Each citizen contributes to your overall score, but not all citizens are counted equally. Increasing the right traits for your citizens will result in better-than-linear improvement.")
        HintList.Add("The happiness of your citizens is the most important aspect of determining their worth for your total score.")
        HintList.Add("A winner is not determined until all players have taken the same number of turns, so don't think that going first has any special advantage.")
        '-- Terrain
        HintList.Add("Buying rock terrain provides a free building on the plot selected at random from the buildings currently available. Time your expansion wisely to take maximum advantage of this bonus by buying only when expensive, beneficial buildings are available.")
        HintList.Add("Buying dirt terrain is best near the very beginning when roads are highly needed and late in the game when land is very expensive.")
        HintList.Add("Savvy expansion can cut your rivals off from beneficial terrain and room for expansion. Use the lake terrain to your advantage when blocking rivals.")
        HintList.Add("You can not buy land already owned, on lakes or not adjacent to your own territory.")
        HintList.Add("Buildings in cities against edges or lakes are unlikely to be used as often as buildings located in central regions.")
        HintList.Add("You must pay $10 per city in upkeep once you have a territory of four or more. This does not apply if the upkeep would consume more than half your income.")
        '-- General
        HintList.Add("Use the buttons on the 'View' tab to get a general ideas of your current status and needs.")
        HintList.Add("Right-click on cities or open terrain to see more details in the 'City' tab.")
        HintList.Add("You can give your cities personalized names if you click on them twice and then press the 'Name' button.")
        HintList.Add("Right-click on a city and then go to the 'Person' tab to view the traits for each of the local citizens.")
        HintList.Add("Left-click on a button on the right side of the screen to see more details in the 'Card' tab.")
    End Sub

    Public Function GenerateHint() As String
        'Dim hintString As String = ""
        'hintString += HintList(GetRandom(0, HintList.Count - 1))
        'Return hintString

        Dim hintString As String = ""

        Dim aMan1 As New AirportMan()
        Dim bMan1 As New BuildMan()
        Dim hMan1 As New HotelMan()

        BuildList.Add(aMan1)
        BuildList.Add(bMan1)
        BuildList.Add(hMan1)

        For i As Integer = 0 To BuildList.Count - 1
            Dim xMan As BuildMan = BuildList(i)
            hintString += xMan.GetName()
        Next

        Return hintString

    End Function


#End Region

End Class

Public Class BuildMan

    Public Function GetName() As String
        Return "My name is " + GetAirportName()
    End Function

    Public Overridable Function GetAirportName() As String
        Return "Base"
    End Function
End Class

Public Class AirportMan
    Inherits BuildMan

    Public Overrides Function GetAirportName() As String
        Return "Airport" + GetFlightNumber()
    End Function

    Public Function GetFlightNumber() As String
        Return "Flight707"
    End Function

End Class

Public Class HotelMan
    Inherits BuildMan

    Public Overrides Function GetAirportName() As String
        Return "Hotel"
    End Function
End Class
