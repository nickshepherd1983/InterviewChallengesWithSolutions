namespace InterviewChallenge;

public static class RacerParser
{
    public static Racer ParseRacer(string racerData)
    {
        var racerDataParts = racerData.Split( new string[] { "," }, StringSplitOptions.TrimEntries);

        if (racerDataParts.Length != 4)
            throw new InvalidDataException("The racer data contains the incorrect number of elements");
        
        var name = racerDataParts[0];

        if(!DateOnly.TryParse(racerDataParts[1], out var dateofBirth))
            throw new InvalidDataException("Date of birth is not valid");

        var category = RacerCategoryFromString(racerDataParts[2]);

        if (!bool.TryParse(racerDataParts[3], out bool isVeteran))
            throw new InvalidDataException("Is veteran is not valid");

        return new Racer(name, dateofBirth, category, isVeteran);
    }

    private static RacerCategory RacerCategoryFromString(string racerCategory)
    {
        switch (racerCategory)
        {
            case "Masters":
                return RacerCategory.Masters;
            default:
                throw new InvalidDataException("Racer category is not valid");
        }
    }
}