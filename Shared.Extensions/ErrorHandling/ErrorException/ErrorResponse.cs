using Shared.Extensions.ErrorHandling.Error;

namespace Shared.Extensions.ErrorHandling.ErrorException;

public class ErrorException : Exception
{
    public int status { get; set; }
    public string message { get; set; }

    public ErrorException()
    {
    }

    public ErrorException(int status, string message)
    {
        this.status = status;
        this.message = message;
    }

    public ErrorException(ErrorResponse errorResponse)
    {
        status = errorResponse.status;
        message = errorResponse.message;
    }
}