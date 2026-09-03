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
                    response.ResponseType = businessEx.ResponseType; // 3 (CustomError)
                    response.ResponseCode = businessEx.ResponseCode; // e.g. "INVALID_CREDENTIALS" / "InvalidPhone"
                    response.Message = businessEx.Message;
                    response.Details = businessEx.Errors;
                    statusCode = GetHttpStatusForBusinessError(businessEx.EnumCode);
                    break;

                case SPUnexpectedException spEx:
                    response.ResponseType = 2; // 2 (UnexpectedError)
                    response.ResponseCode = "UnexpectedError";
                    response.Message = spEx.ErrorDescription ?? spEx.Message;
                    response.Details = new { errorTitle = spEx.ErrorTitle, technicalDetails = spEx.TechnicalDetails };
                    statusCode = HttpStatusCode.InternalServerError;
                    break;

                case UnauthorizedAccessException:
                    response.ResponseType = 3;
                    response.ResponseCode = "Unauthorized";
                    response.Message = "Unauthorized access.";
                    statusCode = HttpStatusCode.Unauthorized;
                    break;

                default:
                    response.ResponseType = 2;
                    response.ResponseCode = "UnexpectedError";
                    response.Message = exception.Message ?? "An unexpected error occurred on the server.";
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
                ResponseCode.DuplicateRecord or ResponseCode.UserAlreadyExists or ResponseCode.EmailAlreadyExists => HttpStatusCode.Conflict,
                _ => HttpStatusCode.BadRequest
            };
        }
    }
}
