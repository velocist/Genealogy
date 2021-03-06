using System;
using System.Text;
using System.Windows.Forms;
using Microsoft.Extensions.Hosting;
using velocist.Objects.Entities;
using velocist.AccessService;
using velocist.WinFormsApp.Forms;
using velocist.LogService;
using velocist.IdentityService;
using velocist.IdentityService.Entities;
using velocist.Services;

namespace velocist.WinFormsApp {

    /// <summary>
    /// The main program
    /// </summary>
    internal static class Program {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance); //Para la base de datos Mysql v.6.4.4 and log4net ConsoleColoredAppender

            //var host = CreateDefaultBuilder(Array.Empty<string>()).Build();
            var host = Host.CreateDefaultBuilder(Array.Empty<string>());
            host.ConfigureAppConfiguration((hostingContext, config) => {
                AccessServiceConfiguration.GetConfiguration();
            }).ConfigureLogging(logging => {
                LogServiceConfiguration.GetConfiguration();
            }).ConfigureServices((context, services) => {
                services.AddServicesHttpContextAccessor();
                services.AddServicesDbContextApp<AppEntitiesContext>(AccessServiceConfiguration.GetConnectionString(AccessServiceSettings.AppContextConnection), AccessServiceSettings.AppContextMigrationWinForms);
                services.AddServiceSqlServer();
                /* Identity Auth DbContext */
                var authConnectionString = AccessServiceConfiguration.GetConnectionString(AccessServiceSettings.AuthContextConnection);
                services.AddServicesIdentityDbContext<AuthContext>(authConnectionString, AccessServiceSettings.AuthContextMigration, requireConfirmedAccount: false);
            })
                .Build();
            Application.Run(new MDIParent());
        }

        /// <summary>
        ///  EF Core uses this method at design time to access the DbContext
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) {
            var host = Host.CreateDefaultBuilder(args);
            return host.ConfigureServices((context, services) => {
                services.AddServicesDbContextApp<AppEntitiesContext>(AccessServiceConfiguration.GetConnectionString(AccessServiceSettings.AppContextConnection), AccessServiceSettings.AppContextMigrationWinForms);
            }).ConfigureHostConfiguration(webBuilder => webBuilder.Build()); ;
        }
    }
}