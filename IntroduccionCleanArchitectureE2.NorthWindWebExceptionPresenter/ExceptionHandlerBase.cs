using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE2.NorthWindWebExceptionPresenter
{
    public class ExceptionHandlerBase
    {
        readonly Dictionary<int, string> RFC7231Types = new Dictionary<int, string>
        {
            { StatusCodes.Status500InternalServerError,"https://datatracker.ietf.org/doc/rfc7231#section-6.6.1"},
             { StatusCodes.Status400BadRequest,"https://datatracker.ietf.org/doc/rfc7231#section-6.5.4"}
        };

        public Task SetResult(ExceptionContext exceptionContext, int? status, string title, string detail)
        {
            ProblemDetails problemDetails = new ProblemDetails
            {
                Status = status,
                Title = title,
                Type = RFC7231Types.ContainsKey(status.Value) ?
                RFC7231Types[status.Value] :"",
                Detail = detail
            };
            exceptionContext.Result = new ObjectResult(problemDetails)
            {
                StatusCode = status,
            };
            exceptionContext.ExceptionHandled = true;
            return Task.CompletedTask;
        }
    }
}
