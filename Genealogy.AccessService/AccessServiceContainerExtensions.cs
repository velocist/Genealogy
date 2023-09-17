namespace Genealogy.AccessService {

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
					_ = sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
					_ = sqlOptions.MigrationsAssembly(migrationAssembly);
					_ = sqlOptions.CommandTimeout(300);
				}).EnableSensitiveDataLogging();

			_ = builder.Register(c => {
				var options = dbContextOptionsBuilder;
				return options.Options;
			}).InstancePerLifetimeScope();

			_ = builder.RegisterType<TContext>()
				  .AsSelf()
				  .InstancePerLifetimeScope();
		}

		/// <summary>
		/// Registers the SQL server.
		/// </summary>
		/// <typeparam name="TContext">The type of the context.</typeparam>
		/// <param name="builder">The builder.</param>
		public static void RegisterSqlServer<TContext>(this ContainerBuilder builder) where TContext : DbContext {
			_ = builder.RegisterType<velocist.DataAccess.SqlServer.UnitOfWork<TContext>>().As<IUnitOfWork<TContext>>().InstancePerLifetimeScope();
			_ = builder.RegisterType<velocist.DataAccess.SqlServer.GenericRepository<IEntity, TContext>>().As<IGenericRepository<IEntity, TContext>>().InstancePerLifetimeScope();
		}

		/// <summary>
		/// Registers my SQL server.
		/// </summary>
		/// <param name="builder">The builder.</param>
		/// <param name="nameConnection"></param>
		public static void RegisterMySqlServer(this ContainerBuilder builder, string nameConnection) {
			var connectionString = AccessServiceConfiguration.GetConnectionString(nameConnection);
			_ = builder.RegisterType<velocist.DataAccess.MySql.MySqlConnector>().As<velocist.Services.DataAccess.MySql.Interfaces.IConnector>().WithParameter("connectionString", connectionString).InstancePerLifetimeScope();
			_ = builder.RegisterType<velocist.DataAccess.MySql.UnitOfWork>().As<velocist.Services.DataAccess.MySql.Interfaces.IUnitOfWork>().InstancePerLifetimeScope();
			//builder.RegisterType<Repository<IEntity>>().As<IRepository<IEntity>>().InstancePerLifetimeScope();
		}
	}
}