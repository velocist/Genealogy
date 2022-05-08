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

        public static void AddServiceSqlServer(this IServiceCollection services) {
            services.AddScoped(typeof(DataAccess.SqlServer.Interfaces.IUnitOfWork<>), typeof(DataAccess.SqlServer.UnitOfWork<>));
            services.AddScoped(typeof(DataAccess.SqlServer.Interfaces.IGenericRepository<,>), typeof(DataAccess.SqlServer.GenericRepository<,>));
        }

        public static void AddServicesMySql(this IServiceCollection services, string connectionString) {
            services.AddScoped(typeof(DataAccess.MySql.Interfaces.IUnitOfWork), typeof(DataAccess.MySql.UnitOfWork));
            services.AddSingleton<DataAccess.MySql.Interfaces.IConnector>(new DataAccess.MySql.MySqlConnector(connectionString));
            services.AddScoped(typeof(DataAccess.MySql.Interfaces.IRepository<>), typeof(DataAccess.MySql.Repository<>));
        }
    }
}
