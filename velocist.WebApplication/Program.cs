using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace velocist.WebApplication {

	/// <summary>
	/// Program class
	/// </summary>
	public class Program {

		/// <summary>
		/// Main method
		/// </summary>
		/// <param name="args">Arguments to the Main method</param>
		public static void Main(string[] args) {
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance); //Para la base de datos Mysql v.6.4.4 and log4net ConsoleColoredAppender
			CreateHostBuilder(args).Build().Run();
		}

		/// <summary>
		/// CreateHostBuilder method
		/// </summary>
		/// <param name="args">Arguments to the host builder</param>
		/// <returns>Return static IHostBuilder</returns>
		public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
.ConfigureAppConfiguration((hostingContext, config) => AccessService.AccessServiceConfiguration.GetConfiguration()).ConfigureLogging(logging => LogService.LogServiceContainer.GetConfiguration()).ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
	}
}
