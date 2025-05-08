
namespace Shared.Extensions.ErrorHandling.Error
{
    public class ErrorCollectionResponse
    {
        public int status { get; set; }
        public Dictionary<string, string> errors { get; set; }

        public ErrorCollectionResponse(int status)
        {
            this.status = status;
            this.errors = new Dictionary<string, string>();
        }
        public ErrorCollectionResponse(int status, Dictionary<string, string> errors)
        {
            this.status = status;
            this.errors = errors;
        }

        public void AddError(string key, string error)
        {
            errors.Add(key, error);
        }
    }
}
