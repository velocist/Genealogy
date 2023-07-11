using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace velocist.AccessService {

	/// <summary>
	/// Configure services for database access
	/// </summary>
	public static class AccessServiceExtensions {

		/// <summary>
		/// Adds the database context application.
		/// </summary>
		/// <typeparam name="T">The DbContext type</typeparam>
		/// <param name="services">The services.</param>
		/// <param name="connectionString">The connextion string.</param>
		/// <param name="migrationAssembly">The migration assembly.</param>
		/// <param name="enableSensitiveDataLogging">if set to <c>true</c> [enable sensitive data logging].</param>
		public static void AddServicesDbContextApp<T>(this IServiceCollection services, string connectionString, string migrationAssembly, bool enableSensitiveDataLogging = true) where T : DbContext => services.AddDbContext<T>(options =>
		  options.UseSqlServer(connectionString, x => x.MigrationsAssembly(migrationAssembly))
		  .EnableSensitiveDataLogging(enableSensitiveDataLogging));

		/// <summary>
		/// Adds the service SQL server.
		/// </summary>
		/// <param name="services">The services.</param>
		public static void AddServiceSqlServer(this IServiceCollection services) {
			_ = services.AddScoped(typeof(DataAccess.SqlServer.Interfaces.IUnitOfWork<>), typeof(DataAccess.SqlServer.UnitOfWork<>));
			_ = services.AddScoped(typeof(DataAccess.SqlServer.Interfaces.IGenericRepository<,>), typeof(DataAccess.SqlServer.GenericRepository<,>));
		}

		/// <summary>
		/// Adds the services my SQL.
		/// </summary>
		/// <param name="services">The services.</param>
		/// <param name="connectionString">The connection string.</param>
		public static void AddServicesMySql(this IServiceCollection services, string connectionString) {
			_ = services.AddScoped(typeof(DataAccess.MySql.Interfaces.IUnitOfWork), typeof(DataAccess.MySql.UnitOfWork));
			_ = services.AddSingleton<DataAccess.MySql.Interfaces.IConnector>(new DataAccess.MySql.MySqlConnector(connectionString));
			_ = services.AddScoped(typeof(DataAccess.MySql.Interfaces.IRepository<>), typeof(DataAccess.MySql.Repository<>));
		}
	}
}
