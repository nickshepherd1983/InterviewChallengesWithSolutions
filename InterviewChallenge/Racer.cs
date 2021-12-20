namespace InterviewChallenge;

public record Racer
{
    public string Name { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public RacerCategory Category { get; set; }
    public bool IsVeteran { get; set; }

    public Racer(string name, DateOnly dateOfBirth, RacerCategory category, bool isVeteran)                  
    {
        Name = name;
        DateOfBirth = dateOfBirth;
        Category = category; 
        IsVeteran = isVeteran;
    }
}