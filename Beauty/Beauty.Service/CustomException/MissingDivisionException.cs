namespace Beauty.Service.CustomException;

public class MissingDivisionException: System.Exception
{
    public MissingDivisionException(string? message) : base(message)
    {
    }
}