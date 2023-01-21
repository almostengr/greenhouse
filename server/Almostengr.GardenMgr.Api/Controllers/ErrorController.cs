using System;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Almostengr.GardenMgr.Api.Controllers
{
    public class ErrorController : BaseApiController
    {
        private readonly ILogger<BaseApiController> _logger;

        public ErrorController(ILogger<BaseApiController> logger)
        {
            _logger = logger;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("/error")]
        public IActionResult HandleError()
        {
            var contextException = HttpContext.Features.Get<IExceptionHandlerFeature>();

            HttpStatusCode responseStatusCode;
            
            switch (contextException.Error.GetType().Name)
            {
                case nameof(NullReferenceException):
                case nameof(ArgumentNullException):
                    responseStatusCode = HttpStatusCode.BadRequest;
                    break;
                
                default:
                    responseStatusCode = HttpStatusCode.InternalServerError;
                    break;
            }

            _logger.LogError(contextException.Error, contextException.Error.Message);

            return Problem(detail: contextException.Error.Message, statusCode: (int)responseStatusCode);
        }

    }
}