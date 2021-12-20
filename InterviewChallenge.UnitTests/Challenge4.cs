namespace InterviewChallenge.UnitTests;

public class Challenge4
{
    /// <summary>
    /// CHALLENGE 4: Implement ParseRacers it can read from a CSV file with headers.
    /// </summary>
    [Theory]
    [MemberData(nameof(CsvRacerData))]
    public void Racers_can_be_prased_from_csv(string racerData)
    {
        var sut = RacerParser.ParseRacers(racerData);

        Assert.Equal(7, sut.Count);
        Assert.Equal(4, sut.Count(i => i.Result != null));
        Assert.Equal(3, sut.Count(i => i.Errors.Any()));
    }

    private static List<object[]> CsvRacerData()
    {
        return new List<object[]>()
        {
            new object[]{
                @"Name,DateOfBirth,Category,IsVeteran
The Slag Brothers , 198304-28,Open,FALSE
The Slag Brothers , 1983-04-28,Open,1
The Slag Brothers , 1983-04-28,Closed,TRUE
Dick Dastardly,9/9/1979,Masters,TRUE
The Slag Brothers , 1983-04-28,Open,FALSE
The Gruesome Twosome , 2002 06 26,U20,FALSE
Professor Pat Pending, 2012 12 12,U13,TRUE"},

            new object[]{
                @"DateOfBirth,Name,Category,IsVeteran
 198304-28,The Slag Brothers ,Open,FALSE
 1983-04-28,The Slag Brothers ,Open,1
 1983-04-28,The Slag Brothers ,Closed,TRUE
9/9/1979,Dick Dastardly,Masters,TRUE
 1983-04-28,The Slag Brothers ,Open,FALSE
 2002 06 26,The Gruesome Twosome ,U20,FALSE
 2012 12 12,Professor Pat Pending,U13,TRUE"},

            new object[]{
                @"DateOfBirth,Name,Category,,IsVeteran
 198304-28,The Slag Brothers ,Open,,FALSE
 1983-04-28,The Slag Brothers ,Open,,1
 1983-04-28,The Slag Brothers ,Closed,,TRUE
9/9/1979,Dick Dastardly,Masters,,TRUE
 1983-04-28,The Slag Brothers ,Open,,FALSE
 2002 06 26,The Gruesome Twosome ,U20,,FALSE
 2012 12 12,Professor Pat Pending,U13,,TRUE"},
        };
    }
}