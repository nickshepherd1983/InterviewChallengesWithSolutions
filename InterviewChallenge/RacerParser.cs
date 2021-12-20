namespace InterviewChallenge;

public static class RacerParser
{
    public static Racer ParseRacer(string racerData)
    {
        var racerDataParts = racerData.Split(new string[] { "," }, StringSplitOptions.TrimEntries);

        if (racerDataParts.Length != 4)
            throw new InvalidDataException("The racer data contains the incorrect number of elements");

        var name = racerDataParts[0];

        if (!DateOnly.TryParse(racerDataParts[1], out var dateofBirth))
            throw new InvalidDataException("Date of birth is not valid");

        var category = RacerCategoryFromString(racerDataParts[2]);

        if (!bool.TryParse(racerDataParts[3], out bool isVeteran))
            throw new InvalidDataException("Is veteran is not valid");

        return new Racer(name, dateofBirth, category, isVeteran);
    }

    public static (Racer?, List<string>?) ParseRacerWithPotentialErrors(string racerData)
    {
        try
        {
            return (ParseRacer(racerData), null);
        }
        catch (Exception ex)
        {
            return (null, new List<string> { ex.Message });
        }
    }

    private static RacerCategory RacerCategoryFromString(string racerCategory)
    {
        switch (racerCategory)
        {
            case "Masters":
                return RacerCategory.Masters;
            case "Open":
                return RacerCategory.Open;
            case "U20":
                return RacerCategory.U20;
            case "U13":
                return RacerCategory.U13;
            default:
                throw new InvalidDataException("Racer category is not valid");
        }
    }

    public static List<(Racer?, List<string>?)> ParseRacers(IEnumerable<string> racersData)
    {
        var racers = new List<(Racer?, List<string>?)>();

        foreach (var racerData in racersData)
            racers.Add(ParseRacerWithPotentialErrors(racerData));

        return racers;
    }

    public static List<(Racer?, List<string>?)> ParseRacers(string racersCsvData)
    {
        var racers = new List<(Racer?, List<string>?)>();
        int[]? columnIndexs = null;

        foreach (var racerData in racersCsvData.Split(Environment.NewLine))
        {
            if (columnIndexs == null)
                columnIndexs = ParseColumnIndexs(racerData);
            else
            {
                var columnData = racerData.Split(',');
                racers.Add(ParseRacerWithPotentialErrors(
                    $"{columnData[columnIndexs[0]]}," +
                    $"{columnData[columnIndexs[1]]}," +
                    $"{columnData[columnIndexs[2]]}," +
                    $"{columnData[columnIndexs[3]]}"));
            }
        }

        return racers;
    }

    private static int[] ParseColumnIndexs(string racerData)
    {
        int[]? columnIndexs = new int[4];
        int i = 0;

        foreach (var headerColumn in racerData.Split(','))
        {
            switch (headerColumn)
            {
                case "Name":
                    columnIndexs[0] = i;
                    break;
                case "DateOfBirth":
                    columnIndexs[1] = i;
                    break;
                case "Category":
                    columnIndexs[2] = i;
                    break;
                case "IsVeteran":
                    columnIndexs[3] = i;
                    break;
            }

            i++;
        }

        return columnIndexs;
    }
}