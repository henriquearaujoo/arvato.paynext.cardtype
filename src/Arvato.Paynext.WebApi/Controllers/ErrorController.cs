using Arvato.Paynext.WebApi.Model;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Arvato.Paynext.WebApi.Controllers
{

    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        [Route("error")]
        public ErrorResponse Error()
        {
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            Response.StatusCode = 500;
            //var instance = exceptionFeature.Path;
            //var title = exceptionFeature.Error.Message;
            //var detail = exceptionFeature.Error.StackTrace;

            var errorResponse = new ErrorResponse(exceptionFeature.Error);

            if (exceptionFeature.Error is ValidationException)
            {
                var validationResult = exceptionFeature.Error as ValidationException;
                errorResponse.Details = validationResult.Errors
                    .GroupBy(x => x.PropertyName)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Select(x => x.ErrorMessage).ToArray()
                    );
                Response.StatusCode = 400;
            }
            
            return errorResponse;
        }
    }
}
