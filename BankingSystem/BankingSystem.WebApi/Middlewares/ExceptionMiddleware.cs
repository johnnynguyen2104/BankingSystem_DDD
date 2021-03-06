﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BankingSystem.Common;
using BankingSystem.Common.Exceptions;
using BankingSystem.Persistence.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BankingSystem.WebApi.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next
            , ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                HandleError(httpContext, ex);
            }
        }

        private void HandleError(HttpContext httpContext, Exception exception)
        {
            string accountNumber = ExtractAccountNumber(httpContext);
            ErrorDetails errorDetails = new ErrorDetails(exception.Message) { AccountNumber = accountNumber };
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            httpContext.Response.ContentType = "application/json";

            _logger.LogError(errorDetails.Message);

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

            if (httpContext.Request.HasFormContentType)
            {
                foreach (var item in httpContext.Request.Form)
                {
                    if (item.Key.ToLower() == code)
                    {
                        return item.Value;
                    }
                }
            }
         

            return null;
        }
    }
}
