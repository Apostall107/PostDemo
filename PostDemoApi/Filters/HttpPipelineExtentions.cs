using Serilog;

namespace PostDemo.Api.Filters
{
    public static class HttpPipelineExtentions
    {
        public static void ConfigureGlobalExceptionHandling(this IApplicationBuilder app, Serilog.ILogger logger)
        {
            app.UseExceptionHandler(options =>
            {
                options.Run(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "application/json";

                    await context.Response.WriteAsJsonAsync(new ErrorModel
                    {
                        SessionID = string.Empty,
                        ErrorReason = "By some reason",
                        IsCritical = true
                    });

                    logger.Fatal("Fatal");
                });
            });
        }
    }
}
