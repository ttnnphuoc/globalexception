using Newtonsoft.Json;
using System.Net;
using System.Text.Json.Serialization;

namespace HandleGlobalException.Exception1
{
    /*
     * https://mwaseemzakir.substack.com/p/ep-12-how-to-implement-global-exception
     */
    public class GlobalExceptionHandler : IMiddleware
    {
        private ILogger<GlobalExceptionHandler> _logger;
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch(Exception exp)
            {
                string mesage = exp.Message;
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                // Log the Exception Details
                _logger.LogError($"Exception Details: {mesage}");

                var response = new ExceptionDetails
                {
                    Message = mesage,
                    StatusCode = context.Response.StatusCode
                };
                await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
            }
        }
        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        
        {
            _logger = logger;
        }
    }

    public class ExceptionDetails
    {
        public int StatusCode { set; get; }
        public string Message { set; get; }
    }
}
