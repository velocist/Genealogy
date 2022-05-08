using System;
using Autofac;
using Microsoft.EntityFrameworkCore;
using velocist.Objects;

namespace velocist.AccessService {

    /// <summary>
    /// Class that extends ContainerBuilder 
    /// </summary>
    public static class AccessServiceContainerExtensions {

        /// <summary>
        /// Registers the database context.
        /// </summary>
        /// <typeparam name="TContext">The type of the context.</typeparam>
        /// <param name="builder">The builder.</param>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="migrationAssembly">The migration assembly.</param>
        public static void RegisterDbContext<TContext>(this ContainerBuilder builder, string connectionString, string migrationAssembly) where TContext : DbContext {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<TContext>()
                .UseSqlServer(connectionString, sqlOptions => {
                    sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                    sqlOptions.MigrationsAssembly(migrationAssembly);
                    sqlOptions.CommandTimeout(300);
                }).EnableSensitiveDataLogging();

            builder.Register(c => {
                var options = dbContextOptionsBuilder;
                return options.Options;
            }).InstancePerLifetimeScope();

            builder.RegisterType<TContext>()
                  .AsSelf()
                  .InstancePerLifetimeScope();
        }

        /// <summary>
        /// Registers the SQL server.
        /// </summary>
        /// <typeparam name="TContext">The type of the context.</typeparam>
        /// <param name="builder">The builder.</param>
        public static void RegisterSqlServer<TContext>(this ContainerBuilder builder) where TContext : DbContext {
            builder.RegisterType<DataAccess.SqlServer.UnitOfWork<TContext>>().As<DataAccess.SqlServer.Interfaces.IUnitOfWork<TContext>>().InstancePerLifetimeScope();
            builder.RegisterType<DataAccess.SqlServer.GenericRepository<IEntity, TContext>>().As<DataAccess.SqlServer.Interfaces.IGenericRepository<IEntity, TContext>>().InstancePerLifetimeScope();
        }

        /// <summary>
        /// Registers my SQL server.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="nameConnection"></param>
        public static void RegisterMySqlServer(this ContainerBuilder builder, string nameConnection) {
            var connectionString = AccessServiceConfiguration.GetConnectionString(nameConnection);
            builder.RegisterType<DataAccess.MySql.MySqlConnector>().As<DataAccess.MySql.Interfaces.IConnector>().WithParameter("connectionString", connectionString).InstancePerLifetimeScope();
            builder.RegisterType<DataAccess.MySql.UnitOfWork>().As<DataAccess.MySql.Interfaces.IUnitOfWork>().InstancePerLifetimeScope();
            //builder.RegisterType<Repository<IEntity>>().As<IRepository<IEntity>>().InstancePerLifetimeScope();
        }

    }
}