namespace Mi_primera_api_dotnet.Middleware
{
    public class TimeMiddleware
    {
        private readonly RequestDelegate _next;

        public TimeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public sbyte GetTime()
        {
            return (sbyte)DateTime.Now.Hour;
        }
    }
}
