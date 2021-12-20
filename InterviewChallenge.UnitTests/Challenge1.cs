namespace InterviewChallenge.UnitTests;

public class Challenge1
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
}