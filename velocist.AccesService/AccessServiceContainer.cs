using System;
using Autofac;

namespace velocist.AccessService {

    /// <summary>
    /// The container for inject dependencies
    /// </summary>
    public static class AccessServiceContainer {

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
        /// Initializes the <see cref="AccessServiceContainer"/> class.
        /// </summary>
        static AccessServiceContainer() {
            try {
                var builder = new ContainerBuilder();

                //Register repositories manage and unit of work for SQL Server EntitiesContext connection 
                builder.RegisterSqlServer<Objects.Entities.AppEntitiesContext>();

                var connectionString = AccessServiceConfiguration.GetConnectionString(AccessServiceSettings.AppContextConnection);
                builder.RegisterDbContext<Objects.Entities.AppEntitiesContext>(connectionString, AccessServiceSettings.AppContextMigration);

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