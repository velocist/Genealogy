namespace Genealogy.Tests.Technicals.Logger {
    [TestClass()]
    public class LoggerTest {

        ILogger<LoggerTest> _logger { get; set; }

        public LoggerTest() {
            _logger = LogServiceContainer.GetLog<LoggerTest>();
        }

        [TestMethod()]
        public void LogTraceTest() => _logger.LogTrace("Log in TRACE");

        [TestMethod()]
        public void LogDebugTest() => _logger.LogDebug("Log in DEBUG");

        [TestMethod()]
        public void LogErrorTest() => _logger.LogError("Log in ERROR");

        [TestMethod()]
        public void LogInformationTest() => _logger.LogInformation("Log in INFORMATION");

        [TestMethod()]
        public void LogWarningTest() => _logger.LogWarning("Log in WARNING");

        [TestMethod()]
        public void LogCriticalTest() => _logger.LogCritical("Log in CRITICAL");
    }
}
