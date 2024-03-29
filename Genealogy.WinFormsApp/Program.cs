using Genealogy.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Genealogy.WinFormsApp {

    /// <summary>
    /// The main program
    /// </summary>
    public static class Program {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main() {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance); //Para la base de datos Mysql v.6.4.4 and log4net ConsoleColoredAppender

            var host = Host.CreateDefaultBuilder(Array.Empty<string>());

            _ = host.ConfigureAppConfiguration((hostingContext, config) => AccessServiceConfiguration.GetConfiguration())
                .ConfigureLogging(logging => {
                    //LogServiceContainer.GetConfiguration();
                    logging.ClearProviders();
                    logging.AddLog4Net(AccessServiceConfiguration.LogSettingsFile, true);
#if DEBUG
                    logging.SetMinimumLevel(LogLevel.Trace);
#else
                    logging.SetMinimumLevel(LogLevel.Error);
#endif
                })
                .ConfigureServices((context, services) => {
                    _ = services.ConfigureAppDatabaseServices();
                    _ = services.ConfigureAppUnitOfWork();
                    _ = services.ConfigureAppServices();


                    var builder = services.BuildServiceProvider();
                    InitializeLog(builder.GetRequiredService<ILoggerFactory>());

                }).Build();

            Application.Run(new MDIParent());
        }

        /// <summary>
        ///  EF Core uses this method at design time to access the DbContext
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) {
            var host = Host.CreateDefaultBuilder(args);
            return host.ConfigureServices((context, services) => services.AddServicesDbContextApp<AppEntitiesContext>(AccessServiceConfiguration.GetConnectionString(AccessServiceConfiguration.GetAppConnectionName()), AccessServiceConfiguration.GetAppContextMigration())).ConfigureHostConfiguration(webBuilder => webBuilder.Build());
            ;
        }
    }
}