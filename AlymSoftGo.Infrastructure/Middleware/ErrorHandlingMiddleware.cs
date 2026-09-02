using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using AlymSoftGo.Domain.Common;
using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.Exceptions;

namespace AlymSoftGo.Infrastructure.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Middleware caught exception: {Message}", ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var response = new ErrorDto();
            var statusCode = HttpStatusCode.InternalServerError;

            switch (exception)
            {
                case SPBusinessException businessEx:
                    response.Code = businessEx.ResponseCode;
                    response.Message = businessEx.Message;
                    response.Details = businessEx.Errors;
                    statusCode = GetHttpStatusForBusinessError(businessEx.ResponseCode);
                    break;

                case SPUnexpectedException spEx:
                    response.Code = ResponseCode.UnexpectedError;
                    response.Message = spEx.ErrorDescription;
                    response.Details = new { errorTitle = spEx.ErrorTitle, technicalDetails = spEx.TechnicalDetails };
                    statusCode = HttpStatusCode.InternalServerError;
                    break;

                case UnauthorizedAccessException:
                    response.Code = ResponseCode.Unauthorized;
                    response.Message = "Unauthorized access.";
                    statusCode = HttpStatusCode.Unauthorized;
                    break;

                default:
                    response.Code = ResponseCode.UnexpectedError;
                    response.Message = "An unexpected error occurred on the server.";
                    statusCode = HttpStatusCode.InternalServerError;
                    break;
            }

            context.Response.StatusCode = (int)statusCode;
            var jsonOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var jsonResponse = JsonSerializer.Serialize(response, jsonOptions);

            await context.Response.WriteAsync(jsonResponse);
        }

        private static HttpStatusCode GetHttpStatusForBusinessError(ResponseCode code)
        {
            return code switch
            {
                ResponseCode.NotFound or 
                ResponseCode.ProductNotFound or 
                ResponseCode.CategoryNotFound or 
                ResponseCode.CompanyNotFound or 
                ResponseCode.BranchNotFound or 
                ResponseCode.OrderNotFound => HttpStatusCode.NotFound,

                ResponseCode.Unauthorized or ResponseCode.InvalidCredentials => HttpStatusCode.Unauthorized,
                ResponseCode.Forbidden => HttpStatusCode.Forbidden,
                ResponseCode.DuplicateRecord or ResponseCode.UserAlreadyExists => HttpStatusCode.Conflict,
                _ => HttpStatusCode.BadRequest
            };
        }
    }
}
