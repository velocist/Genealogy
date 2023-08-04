namespace Genealogy.WinFormsApp {

	/// <summary>
	/// The container for inject dependencies
	/// </summary>
	internal static class WinFormsContainer {

		/// <summary>
		/// Gets the container.
		/// </summary>
		/// <value>
		/// The container.
		/// </value>
		public static IContainer Container { get; private set; }

		/// <summary>
		/// Initializes the <see cref="WinFormsContainer"/> class.
		/// </summary>
		static WinFormsContainer() {
			try {
				var builder = new ContainerBuilder();

				////Register Unit of work for MySql connection
				//builder.RegisterMySqlServer(AccessService.SettingsConfiguration.AppContextConnection);

				//Register DbContext options services for EntitiesContext
				var connectionString = AccessServiceConfiguration.GetConnectionString(AccessServiceSettings.AppContextConnection);
				builder.RegisterDbContext<AppEntitiesContext>(connectionString, AccessServiceSettings.AppContextMigration);

				var authConnectionString = AccessServiceConfiguration.GetConnectionString(AccessServiceSettings.AuthContextConnection);
				builder.RegisterDbContext<AuthContext>(connectionString, AccessServiceSettings.AuthContextMigration);

				//Register repositories manage and unit of work for SQL Server EntitiesContext connection 
				builder.RegisterSqlServer<AppEntitiesContext>();

				//Register repositories manage and unit of work for SQL Server connection
				builder.RegisterSqlServer<AuthContext>();

				_ = builder.RegisterType<MachineClockDateTime>().As<IDateTime>();

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