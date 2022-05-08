using System.IO;
using Microsoft.Extensions.Configuration;

namespace velocist.AccessService {

    /// <summary>
    /// Class to supports configuaration log
    /// </summary>
    public class AccessServiceConfiguration {

        private static readonly IConfiguration _configuration;

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public static IConfiguration Configuration => _configuration;

        /// <summary>
        /// Initializes the <see cref="AccessServiceConfiguration"/> class.
        /// </summary>
        static AccessServiceConfiguration() {
            _configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile(AccessServiceSettings.AppSettingsFile, optional: false)
               .Build();
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <returns>Return configuration.</returns>
        public static IConfiguration GetConfiguration() => Configuration;

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <param name="connectionName">Name of the connection.</param>
        /// <returns>Return string connection.</returns>
        public static string GetConnectionString(string connectionName) => Configuration.GetConnectionString(connectionName);
    }
}
