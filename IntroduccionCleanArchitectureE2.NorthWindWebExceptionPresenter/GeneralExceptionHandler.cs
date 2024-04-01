using IntroduccionCleanArchitectureE2.NorthWindEntities.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE2.NorthWindWebExceptionPresenter
{
    public class GeneralExceptionHandler : ExceptionHandlerBase, IExceptionHandler
    {
        public Task Handle(ExceptionContext exceptionContext)
        {
           var exception = exceptionContext.Exception as GeneralExceptions;

            return SetResult(exceptionContext, StatusCodes.Status500InternalServerError, exception.Message, exception.Detail);
        }
    }
}
