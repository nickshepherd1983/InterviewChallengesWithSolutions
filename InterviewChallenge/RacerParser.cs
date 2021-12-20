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

    public static ParserResult<Racer> ParseRacerWithPotentialErrors(string racerData)
    {
        var parserResult = new ParserResult<Racer>();

        try
        {
            parserResult.Result = ParseRacer(racerData);
        }
        catch (Exception ex)
        {
            parserResult.Errors.Add(ex.Message);
        }

        return parserResult;
    }

    private static RacerCategory RacerCategoryFromString(string racerCategory)
    {
        return racerCategory switch
        {
            "Masters" => RacerCategory.Masters,
            "Open" => RacerCategory.Open,
            "U20" => RacerCategory.U20,
            "U13" => RacerCategory.U13,
            _ => throw new InvalidDataException("Racer category is not valid"),
        };
    }

    public static List<ParserResult<Racer>> ParseRacers(IEnumerable<string> racersData)
    {
        var racers = new List<ParserResult<Racer>>();

        foreach (var racerData in racersData)
            racers.Add(ParseRacerWithPotentialErrors(racerData));

        return racers;
    }

    public static List<ParserResult<Racer>> ParseRacers(string racersCsvData)
    {
        var racers = new List<ParserResult<Racer>>();
        int[]? columnIndexs = null;

        foreach (var racerData in racersCsvData.Split(Environment.NewLine))
        {
            if (columnIndexs == null)
                columnIndexs = ParseHeaderRow(racerData);
            else
                ParseDataRow(racers, columnIndexs, racerData);
        }

        return racers;
    }

    private static int[] ParseHeaderRow(string racerData)
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

    private static void ParseDataRow(List<ParserResult<Racer>> racers, int[] columnIndexs, string racerData)
    {
        var columnData = racerData.Split(',');

        racers.Add(ParseRacerWithPotentialErrors(
            string.Format("{0},{1},{2},{3}",
            columnData[columnIndexs[0]],
            columnData[columnIndexs[1]],
            columnData[columnIndexs[2]],
            columnData[columnIndexs[3]])
            )
        );
    }
}