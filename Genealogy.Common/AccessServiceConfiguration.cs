using System.Reflection.Metadata;
using Microsoft.Extensions.Configuration;

namespace Genealogy.Common {

    /// <summary>
    /// Class to supports configuaration log
    /// </summary>
    public class AccessServiceConfiguration {

        /// <summary>
        /// The application settings file
        /// </summary>
        public const string AppSettingsFile = "Settings/appsettings.json";
        private const string AccessServiceSettingsName = "AccessServiceSettings";

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public static IConfiguration Configuration { get; private set; }

        /// <summary>
        /// Initializes the <see cref="AccessServiceConfiguration"/> class.
        /// </summary>
        static AccessServiceConfiguration() {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile(AppSettingsFile, optional: false)
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

        /// <summary>
        /// Gets the access service setting.
        /// </summary>
        /// <param name="setting">The setting.</param>
        /// <returns></returns>
        public static string GetAccessServiceSetting(string setting) => Configuration.GetSection(AccessServiceSettingsName + setting).Value;

        public static string GetAppConnectionName() => Configuration.GetSection(AccessServiceSettingsName + ":" + "AppContextConnection").Value;
        public static string GetAppContextMigration() => Configuration.GetSection(AccessServiceSettingsName + ":" + "AppContextMigration").Value;
        public static string GetAuthContextMigration() => Configuration.GetSection(AccessServiceSettingsName + ":" + "AuthContextMigration").Value;
        public static string GetAuthConnectionName() => Configuration.GetSection(AccessServiceSettingsName + ":" + "AuthContextConnection").Value;
    }
}
