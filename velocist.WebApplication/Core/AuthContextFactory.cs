using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using velocist.IdentityService.Entities;

namespace velocist.WebApplication.Core {

    /// <summary>
    /// The factory Entities context
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.Design.IDesignTimeDbContextFactory&lt;velocist.IdentityService.Entities.AuthContext&gt;" />
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
                .AddJsonFile(AccessService.AccessServiceSettings.AppSettingsFile, optional: false)
                .Build();

            var builder = new DbContextOptionsBuilder<AuthContext>();
            var connectionString = configuration.GetConnectionString(AccessService.AccessServiceSettings.AuthContextConnection);

            builder.UseSqlServer(connectionString, x => x.MigrationsAssembly(AccessService.AccessServiceSettings.AuthContextMigration))
                .EnableSensitiveDataLogging();
            return new AuthContext(builder.Options);
        }
    }
}
