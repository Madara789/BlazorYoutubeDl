using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorYoutubeDl.Domain.Exeptions;
using BlazorYoutubeDl.Utils;

namespace BlazorYoutubeDl.API.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public ErrorController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [Route("error")]
        public ErrorResponse Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error;
            var code = StatusCodes.Status500InternalServerError;

            if (exception is HttpStatusException statusException)
                code = statusException.Status;

            Response.StatusCode = code;

            return new ErrorResponse(exception, code, _env.IsDevelopment() ? exception.StackTrace : "");
        }
    }
}
