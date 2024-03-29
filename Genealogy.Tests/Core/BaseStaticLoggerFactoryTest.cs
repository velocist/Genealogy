namespace Genealogy.Tests.Core {
    public class BaseStaticLoggerFactoryTest {

        public ILogger<BaseStaticLoggerFactoryTest> _logger { get; set; }

        public void ShowLogs() {

            _logger.LogTrace("Log in TRACE");
            _logger.LogDebug("Log in DEBUG");
            _logger.LogError("Log in ERROR");
            _logger.LogInformation("Log in INFORMATION");
            _logger.LogWarning("Log in WARNING");
            _logger.LogCritical("Log in CRITICAL");

            System.Diagnostics.Debug.WriteLine("Diagnostics in DEBUG");
            System.Diagnostics.Trace.WriteLine("Diagnostics in TRACE");
        }
    }
}
