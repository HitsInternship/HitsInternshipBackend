using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Extensions.ErrorHandling.Error;

namespace Shared.Extensions.ErrorHandling.Validation
{
    public static class FailedAnnotationValidationResponse
    {
        public static IActionResult MakeValidationResponse(ActionContext context)
        {
            var validationProblemDetails = new ValidationProblemDetails(context.ModelState)
            {
                Status = StatusCodes.Status400BadRequest,
            };

            var problemDetails = new ErrorCollectionResponse((int)validationProblemDetails.Status);

            foreach (var error in validationProblemDetails.Errors)
            {
                problemDetails.AddError(error.Key, error.Value.First());
            }

            var result = new BadRequestObjectResult(problemDetails);

            result.ContentTypes.Add("application/problem+json");

            return result;
        }
    }
}
