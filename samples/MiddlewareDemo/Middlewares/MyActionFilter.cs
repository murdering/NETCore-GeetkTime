using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;

namespace MiddlewareDemo.Middlewares
{
    public class MyActionFilter : IActionFilter
    {
        ILogger _logger;

        public MyActionFilter(ILogger<MyActionFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("action已经执行完毕");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation("action正在执行");
        }
    }
}
