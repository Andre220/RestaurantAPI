using Microsoft.Extensions.Logging;

namespace RestaurantWeb.Helpers
{
    public static class Log 
    {
        private static ILogger? _logger;

        public static void Configure(ILogger logger)
        {
            _logger = logger;
        }

        public static void LogInfo(string message) => _logger?.LogInformation(message);
        public static void LogWarning(string message) => _logger?.LogWarning(message);
        public static void LogError(string message) => _logger?.LogError(message);
    }
}
