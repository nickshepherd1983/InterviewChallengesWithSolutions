using Xunit;

namespace InterviewChallenge.UnitTests;

public class RacerParserTests
{
    /// <summary>
    /// CHALLENGE 1: Write a parser that satisfies the following theory  
    /// </summary>
    [Theory]
    [MemberData(nameof(ValidRacerData))]
    public void Valid_data_can_be_parsed(
        string racerData,
        string name,
        DateOnly dateOfBirth,
        RacerCategory category,
        bool isVetran)
    {
        var sut = RacerParser.ParseRacer(racerData);

        Assert.Equal(name, sut.Name);
        Assert.Equal(dateOfBirth, sut.DateOfBirth);
        Assert.Equal(category, sut.Category);
        Assert.Equal(isVetran, sut.IsVeteran);
    }

    private static List<object[]> ValidRacerData()
    {
        return new List<object[]> {

            new object[]{
                "Dick Dastardly,09/09/1979,Masters,true",
                "Dick Dastardly",
                new DateOnly(1979,09,09),
                RacerCategory.Masters,
                true  },

            new object[]{
                "The Slag Brothers , 1983-04-28,Open,false",
                "The Slag Brothers",
                new DateOnly(1983,04,28),
                RacerCategory.Open,
                false },

            new object[]{
                " The Gruesome Twosome , 2002 06 26,U20,false",
                "The Gruesome Twosome",
                new DateOnly(2002,06,26),
                RacerCategory.U20,
                false },

            new object[]{
                "Professor Pat Pending, 2012 12 12,U13,TRUE",
                "Professor Pat Pending",
                new DateOnly(2012,12,12),
                RacerCategory.U13,
                true }
        };
    }

    /// <summary>
    /// CHALLENGE 2: Implement ParseRacerWithPotentialErrors so that it handles the following error messages. 
    /// </summary>
    [Theory]
    [MemberData(nameof(InvalidRacerData))]
    public void Invalid_data_can_be_parsed(
        string racerData, 
        string errorMessage)
    {
        var sut = RacerParser.ParseRacerWithPotentialErrors(racerData);

        Assert.Null(sut.Item1);
        Assert.Contains(errorMessage, sut.Item2);
    }

    private static List<object[]> InvalidRacerData()
    {
        return new List<object[]>()
        {
            new object[]{
                "", 
                "The racer data contains the incorrect number of elements"},

            new object[]{
                "The Slag Brothers , 198304-28,Open,false",
                "Date of birth is not valid"},

            new object[]{
                "The Slag Brothers , 1983-04-28,Open,1",
                "Is veteran is not valid"},

            new object[]{
                "The Slag Brothers , 1983-04-28,Closed,true",
                "Racer category is not valid"},
        };
    }

    /// <summary>
    /// CHALLENGE 3: Implement ParseRacers such that it takes a collection of strings.
    /// </summary>
    [Fact]
    public void Racers_can_be_prased_from_collection()
    {
        var racerDataString = @"
The Slag Brothers , 198304-28,Open,false
The Slag Brothers , 1983-04-28,Open,1
The Slag Brothers , 1983-04-28,Closed,true
Dick Dastardly,09/09/1979,Masters,true
The Slag Brothers , 1983-04-28,Open,false
The Gruesome Twosome , 2002 06 26,U20,false
Professor Pat Pending, 2012 12 12,U13,TRUE";
        var racerData = racerDataString.Split(Environment.NewLine);

        var sut = RacerParser.ParseRacers(racerData);

        Assert.Equal(8, sut.Count);
        Assert.Equal(4, sut.Count(i => i.Item1 != null));
        Assert.Equal(4, sut.Count(i => i.Item2 != null));
    }
}