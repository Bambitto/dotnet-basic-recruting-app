namespace MatchDataManager.Api.Exceptions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public ExceptionMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                if (ex is NotFoundException)
                {
                    context.Response.StatusCode = 404;
                    await context.Response.WriteAsJsonAsync(ex.Message);
                }

                if (ex is BadRequestException)
                {
                    context.Response.StatusCode = 400;
                    await context.Response.WriteAsJsonAsync(ex.Message);
                }
            }
        }
    }
}
