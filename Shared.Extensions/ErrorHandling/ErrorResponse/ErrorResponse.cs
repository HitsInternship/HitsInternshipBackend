namespace Shared.Extensions.ErrorHandling.Error
{
    public class ErrorResponse
    {
        public int status { get; set; }
        public string message { get; set; }

        public ErrorResponse() { }

        public ErrorResponse(int status, string message)
        {
            this.status = status;
            this.message = message;
        }
    }
}
