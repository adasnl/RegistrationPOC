using Newtonsoft.Json;
using System.Net;

namespace RegistrationWebAPI.Middleware
{
    public class ResponseExceptionHandlerMiddleware : ExceptionHandlerMiddleware
    {
        public ResponseExceptionHandlerMiddleware(RequestDelegate next, ILogger<ResponseExceptionHandlerMiddleware> logger) : base(next, logger)
        {
        }

        public override (HttpStatusCode code, string message) GetResponse(Exception exception)
        {
            HttpStatusCode code;
            switch (exception)
            {
                case KeyNotFoundException
                    or FileNotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
                case UnauthorizedAccessException:
                    code = HttpStatusCode.Unauthorized;
                    break;
                case ArgumentException
                    or InvalidOperationException:
                    code = HttpStatusCode.BadRequest;
                    break;
                default:
                    code = HttpStatusCode.InternalServerError;
                    break;
            }
            return (code, JsonConvert.SerializeObject(exception.Message));
        }
    }
}
