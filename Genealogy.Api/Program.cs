using Microsoft.AspNetCore.HttpLogging;

namespace Genealogy.Api {

	public class Program {
		/// <summary>
		/// Constructor of the startup class
		/// </summary>
		/// <param name="configuration"></param>
		public Program(IConfiguration configuration) {
			Configuration = configuration;
		}

		/// <summary>
		/// Configuration
		/// </summary>
		public static IConfiguration Configuration { get; set; }

		public static void Main(string[] args) {

			//var applicationOptions = new WebApplicationOptions() {
			//	ApplicationName = "Genealogy Api",

			//};
			var builder = WebApplication.CreateBuilder();

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddAuthentication("Bearer").AddJwtBearer();
			builder.Services.AddHttpLogging(option => new HttpLoggingOptions() {

			});

			var configuration = Configuration.ConfigureApp();

			_ = builder.WebHost.ConfigureAppConfiguration((hostingContext, config) => new ConfigurationBuilder()
			   .SetBasePath(Directory.GetCurrentDirectory())
			   .AddJsonFile(Common.AccessServiceConfiguration.AppSettingsFile, optional: false)
			   .Build())
				.ConfigureLogging(logging => {
					logging.ClearProviders();
					logging.AddLog4Net("Settings/log4net.config", true);
				}).ConfigureServices((context, services) => {
					var builder = services.BuildServiceProvider();
					InitializeLog(builder.GetRequiredService<ILoggerFactory>());
				});

			builder.Services.ConfigureAppDatabaseServices();
			builder.Services.ConfigureAppUnitOfWork();
			builder.Services.ConfigureAppServices();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment()) {
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();



			app.Run();
		}
	}
}
