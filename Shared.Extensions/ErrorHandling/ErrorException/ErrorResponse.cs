namespace Shared.Extensions.ErrorHandling.Error
{
    public class ErrorException : Exception
    {
        public int status { get; set; }
        public string message { get; set; }

        public ErrorException() { }

        public ErrorException(int status, string message)
        {
            this.status = status;
            this.message = message;
        }

        public ErrorException(ErrorResponse errorResponse)
        {
            this.status = errorResponse.status;
            this.message = errorResponse.message;
        }
    }
}
