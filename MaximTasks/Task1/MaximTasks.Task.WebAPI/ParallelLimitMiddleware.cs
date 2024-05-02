namespace MaximTasks.Task1.WebAPI
{
    /// <summary>
    /// Middleware для работы с текущим количеством запросов.
    /// </summary>
    public class ParallelLimitMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly int _maxCountRequest;

        private static int _countRequest;

        public ParallelLimitMiddleware(RequestDelegate next, IConfiguration appConfig)
        {
            _next = next;
            _maxCountRequest = int.Parse(appConfig["Settings:ParallelLimit"]);
        }

        public async Task InvokeAsync(HttpContext context, IConfiguration appConfig)
        {
            _countRequest++;

            if (_countRequest > _maxCountRequest)
            {
                context.Response.StatusCode = 503;
            }
            else
            {
                try
                {
                    await _next.Invoke(context);
                }
                finally
                {
                    _countRequest--;
                }
            }
        }
    }
}
