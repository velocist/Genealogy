using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Genealogy.Tests.Technicals.Logger {

    [TestClass()]
    public class StaticLoggerLogLevelTests : BaseStaticLoggerFactoryTest {

        static LogLevel logLevel = LogLevel.Trace;
        static string level = logLevel.ToString();

        string log4netFile = $"Technicals/Logger/Settings/log4netWithAll.config";
        string logsettingsFile = $"Technicals/Logger/LogSettings/LogLevel/logSettingsLogLevel-{level}.json";

        [TestMethod()]
        public void Log4NetTest() {
            var host = Host.CreateDefaultBuilder(Array.Empty<string>());
            _ = host.ConfigureAppConfiguration((hostingContext, config) => new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile(logsettingsFile, optional: false)
               .Build())
                .ConfigureLogging(logging => {
                    logging.ClearProviders();
                    logging.AddLog4Net(log4netFile, true);
                    logging.SetMinimumLevel(logLevel);
                }).ConfigureServices((context, services) => {
                    var builder = services.BuildServiceProvider();
                    InitializeLog(builder.GetRequiredService<ILoggerFactory>());
                }).Build();

            _logger = (ILogger<BaseStaticLoggerFactoryTest>)GetStaticLogger<BaseStaticLoggerFactoryTest>();

            ShowLogs();
        }

        [TestMethod()]
        public void ConsoleTest() {
            var host = Host.CreateDefaultBuilder(Array.Empty<string>());
            _ = host.ConfigureAppConfiguration((hostingContext, config) => new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile(logsettingsFile, optional: false)
               .Build())
                .ConfigureLogging(logging => {
                    logging.ClearProviders();
                    logging.AddConsole();
                    logging.SetMinimumLevel(logLevel);
                }).ConfigureServices((context, services) => {
                    var builder = services.BuildServiceProvider();
                    InitializeLog(builder.GetRequiredService<ILoggerFactory>());
                }).Build();

            _logger = (ILogger<BaseStaticLoggerFactoryTest>)GetStaticLogger<BaseStaticLoggerFactoryTest>();

            ShowLogs();
        }

        [TestMethod()]
        public void DebugTest() {
            var host = Host.CreateDefaultBuilder(Array.Empty<string>());
            _ = host.ConfigureAppConfiguration((hostingContext, config) => new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile(logsettingsFile, optional: false)
               .Build())
                .ConfigureLogging(logging => {
                    logging.ClearProviders();
                    logging.AddDebug();
                    logging.SetMinimumLevel(logLevel);
                }).ConfigureServices((context, services) => {
                    var builder = services.BuildServiceProvider();
                    InitializeLog(builder.GetRequiredService<ILoggerFactory>());
                }).Build();

            _logger = (ILogger<BaseStaticLoggerFactoryTest>)GetStaticLogger<BaseStaticLoggerFactoryTest>();

            ShowLogs();
        }

        [TestMethod()]
        public void Log4NetWithoutMinimumLevelTest() {
            var host = Host.CreateDefaultBuilder(Array.Empty<string>());
            _ = host.ConfigureAppConfiguration((hostingContext, config) => new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile(logsettingsFile, optional: false)
               .Build())
                .ConfigureLogging(logging => {
                    logging.ClearProviders();
                    logging.AddLog4Net(log4netFile, true);
                }).ConfigureServices((context, services) => {
                    var builder = services.BuildServiceProvider();
                    InitializeLog(builder.GetRequiredService<ILoggerFactory>());
                }).Build();

            _logger = (ILogger<BaseStaticLoggerFactoryTest>)GetStaticLogger<BaseStaticLoggerFactoryTest>();

            ShowLogs();
        }

        [TestMethod()]
        public void ConsoleWithoutMinimumLevelTest() {
            var host = Host.CreateDefaultBuilder(Array.Empty<string>());
            _ = host.ConfigureAppConfiguration((hostingContext, config) => new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile(logsettingsFile, optional: false)
               .Build())
                .ConfigureLogging(logging => {
                    logging.ClearProviders();
                    logging.AddConsole();
                }).ConfigureServices((context, services) => {
                    var builder = services.BuildServiceProvider();
                    InitializeLog(builder.GetRequiredService<ILoggerFactory>());
                }).Build();

            _logger = (ILogger<BaseStaticLoggerFactoryTest>)GetStaticLogger<BaseStaticLoggerFactoryTest>();

            ShowLogs();
        }

        [TestMethod()]
        public void DebugWithoutMinimumLevelTest() {
            var host = Host.CreateDefaultBuilder(Array.Empty<string>());
            _ = host.ConfigureAppConfiguration((hostingContext, config) => new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile(logsettingsFile, optional: false)
               .Build())
                .ConfigureLogging(logging => {
                    logging.ClearProviders();
                    logging.AddDebug();
                }).ConfigureServices((context, services) => {
                    var builder = services.BuildServiceProvider();
                    InitializeLog(builder.GetRequiredService<ILoggerFactory>());
                }).Build();

            _logger = (ILogger<BaseStaticLoggerFactoryTest>)GetStaticLogger<BaseStaticLoggerFactoryTest>();

            ShowLogs();
        }

        [TestMethod()]
        public void WithAllTest() {
            var host = Host.CreateDefaultBuilder(Array.Empty<string>());
            _ = host.ConfigureAppConfiguration((hostingContext, config) => new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile(logsettingsFile, optional: false)
               .Build())
                .ConfigureLogging(logging => {
                    logging.ClearProviders();
                    logging.AddLog4Net(log4netFile, true);
                    logging.AddConsole();
                    logging.AddDebug();
                }).ConfigureServices((context, services) => {
                    var builder = services.BuildServiceProvider();
                    InitializeLog(builder.GetRequiredService<ILoggerFactory>());
                }).Build();

            _logger = (ILogger<BaseStaticLoggerFactoryTest>)GetStaticLogger<BaseStaticLoggerFactoryTest>();

            ShowLogs();
        }

        [TestMethod()]
        public void Log4NetWithAllTest() {
            var host = Host.CreateDefaultBuilder(Array.Empty<string>());
            _ = host.ConfigureAppConfiguration((hostingContext, config) => new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile(logsettingsFile, optional: false)
               .Build())
                .ConfigureLogging(logging => {
                    logging.ClearProviders();
                    logging.AddLog4Net(log4netFile, true);
                }).ConfigureServices((context, services) => {
                    var builder = services.BuildServiceProvider();
                    InitializeLog(builder.GetRequiredService<ILoggerFactory>());
                }).Build();

            _logger = (ILogger<BaseStaticLoggerFactoryTest>)GetStaticLogger<BaseStaticLoggerFactoryTest>();

            ShowLogs();
        }

    }
}
