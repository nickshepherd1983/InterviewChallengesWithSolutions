namespace InterviewChallenge.UnitTests;

public class Challenge2
{
    /// <summary>
    /// CHALLENGE 2: Implement ParseRacerWithPotentialErrors so that it handles the following error messages. 
    /// </summary>
    [Theory]
    [MemberData(nameof(InvalidRacerData))]
    public void Invalid_data_can_be_parsed(
        string racerData,
        string errorMessage)
    {
        var sut = RacerParserX.ParseRacerWithPotentialErrors(racerData);

        Assert.Null(sut.Result);
        Assert.Contains(errorMessage, sut.Errors);
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
}