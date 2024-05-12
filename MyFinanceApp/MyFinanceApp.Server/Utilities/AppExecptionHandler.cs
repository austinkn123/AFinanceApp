using Microsoft.AspNetCore.Diagnostics;

namespace AppLibrary.Utilities
{

    public class AppExecptionHandler : IExceptionHandler
    {
        private readonly ILogger<AppExecptionHandler> logger;
        public AppExecptionHandler(ILogger<AppExecptionHandler> logger)
        {
            this.logger = logger;
        }
        public ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            var exceptionMessage = exception.Message;
            logger.LogError(
                "ERROR MESSAGE: {exceptionMessage}, Time of occurrence {time}",
                exceptionMessage, DateTime.UtcNow);
            // Return false to continue with the default behavior
            // - or - return true to signal that this exception is handled
            return ValueTask.FromResult(false);
        }
    }
}
