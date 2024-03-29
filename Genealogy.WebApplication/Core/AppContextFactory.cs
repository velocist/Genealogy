namespace Genealogy.WebApplication.Core {

    /// <summary>
    /// The factory Entities context
    /// </summary>
    /// <seealso cref="IDesignTimeDbContextFactory{TContext}" />
    public class AppContextFactory : IDesignTimeDbContextFactory<AppEntitiesContext> {

        /// <summary>
        /// Creates a new instance of a derived context.
        /// </summary>
        /// <param name="args">Arguments provided by the design-time service.</param>
        /// <returns>
        /// </returns>
        public AppEntitiesContext CreateDbContext(string[] args) {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(Common.AccessServiceConfiguration.AppSettingsFile, optional: false)
                .Build();

            var builder = new DbContextOptionsBuilder<AppEntitiesContext>();
            var connectionString = configuration.GetConnectionString(Common.AccessServiceConfiguration.GetAppConnectionName());

            _ = builder.UseSqlServer(connectionString, x => x.MigrationsAssembly(Common.AccessServiceConfiguration.GetAppContextMigration()))
                .EnableSensitiveDataLogging();
            return new AppEntitiesContext(builder.Options);
        }
    }
}
