namespace Genealogy.AccessService {

	/// <summary>
	/// The container for inject dependencies
	/// </summary>
	public static class AccessServiceContainer {

		/// <summary>
		/// Gets the container.
		/// </summary>
		/// <value>
		/// The container.
		/// </value>
		public static IContainer Container { get; private set; }

		/// <summary>
		/// Initializes the <see cref="AccessServiceContainer"/> class.
		/// </summary>
		static AccessServiceContainer() {
			try {
				var builder = new ContainerBuilder();

				//Register repositories manage and unit of work for SQL Server EntitiesContext connection 
				builder.RegisterSqlServer<AppEntitiesContext>();

				var connectionString = AccessServiceConfiguration.GetConnectionString(AccessServiceSettings.AppContextConnection);
				builder.RegisterDbContext<AppEntitiesContext>(connectionString, AccessServiceSettings.AppContextMigration);

				Container = builder.Build();
			} catch (Exception) {
				throw new Exception();
			}
		}

		/// <summary>
		/// Resolves this instance.
		/// </summary>
		/// <typeparam name="T">The type to resolve</typeparam>
		/// <returns>Return typed resolve</returns>
		public static T Resolve<T>() => Container.Resolve<T>();
	}
}