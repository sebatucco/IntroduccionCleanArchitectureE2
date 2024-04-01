using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE2.NorthWindWebExceptionPresenter
{
    public class ValidationExceptionHandler : ExceptionHandlerBase, IExceptionHandler
    {
        public Task Handle(ExceptionContext exceptionContext)
        {
            var exception = exceptionContext.Exception as ValidationException;
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var failure in exception.Errors)
            {
                stringBuilder.AppendLine(string.Format("propiedad: {0}. error: {1}", failure.PropertyName, failure.ErrorMessage));
            }
            return SetResult(exceptionContext, StatusCodes.Status400BadRequest, "Error datos de entrada", stringBuilder.ToString());
        }
    }
}
