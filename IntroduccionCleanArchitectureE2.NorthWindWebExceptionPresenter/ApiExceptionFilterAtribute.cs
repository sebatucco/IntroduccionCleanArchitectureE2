using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroduccionCleanArchitectureE2.NorthWindWebExceptionPresenter
{
    public class ApiExceptionFilterAtribute : ExceptionFilterAttribute
    {
        readonly IDictionary<Type, IExceptionHandler> _exceptionHandlers;

        public ApiExceptionFilterAtribute(IDictionary<Type, IExceptionHandler> exceptionHandlers)
        {
            _exceptionHandlers = exceptionHandlers;
        }

        public override void OnException(ExceptionContext context)
        {
            Type exceptionType = context.Exception.GetType();
            if (_exceptionHandlers.ContainsKey(exceptionType))
            {
                _exceptionHandlers[exceptionType].Handle(context);
            }
            else
            {
                new ExceptionHandlerBase().SetResult(context, StatusCodes.Status500InternalServerError, "error al procesar la respuesta", "");
            }
            base.OnException(context);
        }
    }
}
