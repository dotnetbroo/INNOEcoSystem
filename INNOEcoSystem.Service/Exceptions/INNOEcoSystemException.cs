namespace INNOEcoSystem.Service.Exceptions;

public class INNOEcoSystemException : Exception
{
    public int StatusCode { get; set; }

    public INNOEcoSystemException(int code, string message) : base(message)
    {
        StatusCode = code;
    }
}
