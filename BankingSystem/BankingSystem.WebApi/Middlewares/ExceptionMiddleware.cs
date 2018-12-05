using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingSystem.Common;
using BankingSystem.Common.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BankingSystem.WebApi.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {

            try
            {
                return _next(httpContext);
            }
            catch (Exception ex)
            {
                HandleError(httpContext, ex);
            }

            return Task.CompletedTask;
        }

        private void HandleManagedError(HttpContext httpContext, BankingException managedException)
        {
            string accountNumber = ExtractAccountNumber(httpContext);
            managedException.ErrorDetails.AccountNumber = accountNumber;

            httpContext.Response.WriteAsync(managedException.ErrorDetails.ToString());
        }

        private void HandleError(HttpContext httpContext, Exception exception)
        {
            string accountNumber = ExtractAccountNumber(httpContext);
            ErrorDetails errorDetails = new ErrorDetails(exception.Message) { AccountNumber = accountNumber };

            httpContext.Response.WriteAsync(errorDetails.ToString());
        }

        private string ExtractAccountNumber(HttpContext httpContext)
        {
            string code = "accountnumber";
            //from queries
            foreach (var item in httpContext.Request.Query)
            {
                if (item.Key.ToLower() == code)
                {
                    return item.Value;
                }
            }

            foreach (var item in httpContext.Request.Form)
            {
                if (item.Key.ToLower() == code)
                {
                    return item.Value;
                }
            }

            return null;
        }
    }
}
