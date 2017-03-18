using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleware.Foundation.Exceptions;

namespace Teleware.Foundation.AspNetCore.MVC.Filters
{
    public class ApiExceptionFilter : IExceptionFilter
    {
        private readonly IHostingEnvironment _env;

        public ApiExceptionFilter(IHostingEnvironment env)
        {
            _env = env;
        }

        public void OnException(ExceptionContext context)
        {
            if (_env.IsDevelopment())
            {
                HandleDevelopmentException(context);
            }
            else
            {
                HandleProductionException(context);
            }
        }

        private static void HandleDevelopmentException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case HttpClientNoticeableException httpClientException:
                    context.Result = new ObjectResult(new
                    {
                        message = httpClientException.Message,
                        stackTrace = httpClientException.StackTrace
                    })
                    {
                        StatusCode = httpClientException.StatusCode
                    };
                    context.ExceptionHandled = true;
                    break;

                case ClientNoticeableException clientException:
                    context.Result = new ObjectResult(new
                    {
                        message = clientException.Message,
                        stackTrace = clientException.StackTrace
                    })
                    {
                        StatusCode = 400
                    };
                    context.ExceptionHandled = true;
                    break;

                default:
                    context.Result = new ObjectResult(new
                    {
                        message = "服务端发生异常，请联系管理员",
                        stackTrace = context.Exception.StackTrace
                    })
                    {
                        StatusCode = 500
                    };
                    context.ExceptionHandled = true;
                    break;
            }
        }

        private static void HandleProductionException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case HttpClientNoticeableException httpClientException:
                    context.Result = new ObjectResult(new { message = httpClientException.Message })
                    {
                        StatusCode = httpClientException.StatusCode
                    };
                    context.ExceptionHandled = true;
                    break;

                case ClientNoticeableException clientException:
                    context.Result = new ObjectResult(new { message = clientException.Message })
                    {
                        StatusCode = 400
                    };
                    context.ExceptionHandled = true;
                    break;

                default:
                    context.Result = new ObjectResult(new
                    {
                        message = "服务端发生异常，请联系管理员"
                    })
                    {
                        StatusCode = 500
                    };
                    context.ExceptionHandled = true;
                    break;
            }
        }
    }
}