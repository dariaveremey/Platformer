using Services.Forecast;

namespace Services.Web
{
    public class Response
    {
        public bool IsSuccess { get; }
        public ResponseException Exception { get; }
        public ForecastDTO Dto { get; set; }

        public Response()
        {
            IsSuccess = true;
        }

        public Response(ResponseException exception)
        {
            IsSuccess = true;
            Exception = exception;
        }
    }
}