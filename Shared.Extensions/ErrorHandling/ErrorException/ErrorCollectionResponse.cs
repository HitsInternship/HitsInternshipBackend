
namespace Shared.Extensions.ErrorHandling.Error
{
    public class ErrorCollectionException : Exception
    {
        public int status { get; set; }
        public Dictionary<string, string> errors { get; set; }
        public ErrorCollectionException(int status, Dictionary<string, string> errors)
        {
            this.status = status;
            this.errors = errors;
        }
        public ErrorCollectionException(ErrorCollectionResponse errorResponse)
        {
            this.status = errorResponse.status;
            this.errors = errorResponse.errors;
        }
    }
}
