namespace Beauty.Service.CustomException;

public class ExistIsEntityException: System.Exception
{
    public ExistIsEntityException(string? message) : base(message)
    {
    }
}