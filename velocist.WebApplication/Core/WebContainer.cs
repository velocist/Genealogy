using System;
using Autofac;
using velocist.IdentityService.Entities;
using velocist.AccessService;
using velocist.Services.Formats;
using velocist.Services.Formats.Interfaces;

namespace velocist.WebApplication.Core {

    /// <summary>
    /// The container for inject dependencies
    /// </summary>
    public static class WebContainer {

        /// <summary>
        /// The container
        /// </summary>
        private static readonly IContainer _container;

        /// <summary>
        /// Gets the container.
        /// </summary>
        /// <value>
        /// The container.
        /// </value>
        public static IContainer Container => _container;

        /// <summary>
        /// Initializes the <see cref="WebContainer"/> class.
        /// </summary>
        static WebContainer() {
            try {
                var builder = new ContainerBuilder();

                //Register DbContext options services for EntitiesContext
                var connectionString = AccessServiceConfiguration.GetConnectionString(AccessServiceSettings.AppContextConnection);
                builder.RegisterDbContext<Objects.Entities.AppEntitiesContext>(connectionString, AccessServiceSettings.AppContextMigration);

                var authConnectionString = AccessServiceConfiguration.GetConnectionString(AccessServiceSettings.AuthContextConnection);
                builder.RegisterDbContext<AuthContext>(connectionString, AccessServiceSettings.AuthContextMigration);

                //Register repositories manage and unit of work for SQL Server EntitiesContext connection 
                builder.RegisterSqlServer<Objects.Entities.AppEntitiesContext>();

                //Register repositories manage and unit of work for SQL Server connection
                builder.RegisterSqlServer<AuthContext>();

                builder.RegisterType<MachineClockDateTime>().As<IDateTime>();

                _container = builder.Build();
            } catch (Exception) {
                throw new Exception();
            }
        }

        /// <summary>
        /// Resolves this instance.
        /// </summary>
        /// <typeparam name="T">The type to resolve</typeparam>
        /// <returns>Return typed resolve</returns>
        public static T Resolve<T>() => _container.Resolve<T>();
    }
}