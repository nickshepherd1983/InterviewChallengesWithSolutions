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
        var racer = RacerParser.ParseRacer(racerData);

        Assert.Equal(name, racer.Name);
        Assert.Equal(dateOfBirth, racer.DateOfBirth);
        Assert.Equal(category, racer.Category);
        Assert.Equal(isVetran, racer.IsVeteran);
    }

    public static List<object[]> ValidRacerData()
    {
        return new List<object[]> {

            new object[]{ 
                "Dick Dastardly,09/09/1979,Masters,true", 
                "Dick Dastardly", 
                new DateOnly(1979,09,09), 
                RacerCategory.Masters, 
                true  }
        };
    }
}