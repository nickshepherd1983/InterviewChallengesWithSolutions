namespace InterviewChallenge.UnitTests;

public class Challenge3
{
    /// <summary>
    /// CHALLENGE 3: Implement ParseRacers such that it takes a collection of strings.
    /// </summary>
    [Fact]
    public void Racers_can_be_prased_from_collection()
    {
        var racersCsvData = @"
The Slag Brothers , 198304-28,Open,false
The Slag Brothers , 1983-04-28,Open,1
The Slag Brothers , 1983-04-28,Closed,true
Dick Dastardly,09/09/1979,Masters,true
The Slag Brothers , 1983-04-28,Open,false
The Gruesome Twosome , 2002 06 26,U20,false
Professor Pat Pending, 2012 12 12,U13,TRUE";
        var racerData = racersCsvData.Split(Environment.NewLine);

        var sut = RacerParserX.ParseRacers(racerData);

        Assert.Equal(8, sut.Count);
        Assert.Equal(4, sut.Count(i => i.Item1 != null));
        Assert.Equal(4, sut.Count(i => i.Item2 != null));
    }
}