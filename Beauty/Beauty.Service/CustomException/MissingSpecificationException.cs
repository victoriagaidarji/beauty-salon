namespace Beauty.Service.CustomException;

public class MissingSpecificationException: System.Exception
{
    public MissingSpecificationException(string? message) : base(message)
    {
    }
}