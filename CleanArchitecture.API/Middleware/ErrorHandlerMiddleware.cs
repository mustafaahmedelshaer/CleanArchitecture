using CleanArchitecture.Application.Communications;
using System.Globalization;
using System.Net;
using System.Text.Json;

namespace CleanArchitecture.API.Middleware
{
    public class ErrorHandlerMiddleware
    {

        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                //var test = EResponseStatus.Exception;
                switch (error)
                {
                    //case AppException e:
                    //    // custom application error
                    //    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    //    //test = EResponseStatus.badRequest;
                    //    break;
                    case KeyNotFoundException e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        //test = EResponseStatus.NotFound;
                        break;
                    case AggregateException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        //test = EResponseStatus.Exception;
                        break;
                }
                ;
                //var result;
                var StatusCode = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), response.StatusCode.ToString(CultureInfo.InvariantCulture));
                if (response.StatusCode == (int)HttpStatusCode.InternalServerError)
                {
                    await response.WriteAsync(JsonSerializer.Serialize(new GeneralResponse<string>("An unexpected server error occurred.", StatusCode)));
                }
                else
                {

                await response.WriteAsync(JsonSerializer.Serialize(new GeneralResponse<string>(error?.Message, StatusCode)));
                }

            }
        }
    }
}
