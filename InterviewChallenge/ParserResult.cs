namespace InterviewChallenge;

public class ParserResult<T> where T : class
{
    public ParserResult()
    {
        Errors = new List<string>();
    }

    public T? Result { get; set; }
    public ICollection<string> Errors { get; }
}
