namespace Genealogy.WebApplication.Core {

    /// <summary>
    /// The factory Entities context
    /// </summary>
    /// <seealso cref="IDesignTimeDbContextFactory{TContext}" />
    public class AuthContextFactory : IDesignTimeDbContextFactory<AuthContext> {

        /// <summary>
        /// Creates a new instance of a derived context.
        /// </summary>
        /// <param name="args">Arguments provided by the design-time service.</param>
        /// <returns>
        /// An instance of <typeparamref name="TContext" />.
        /// </returns>
        public AuthContext CreateDbContext(string[] args) {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(Common.AccessServiceConfiguration.AppSettingsFile, optional: false)
                .Build();

            var builder = new DbContextOptionsBuilder<AuthContext>();
            var connectionString = configuration.GetConnectionString(Common.AccessServiceConfiguration.GetAuthConnectionName());

            _ = builder.UseSqlServer(connectionString, x => x.MigrationsAssembly(Common.AccessServiceConfiguration.GetAuthContextMigration()))
                .EnableSensitiveDataLogging();
            return new AuthContext(builder.Options);
        }
    }
}
