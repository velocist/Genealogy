namespace Genealogy.IdentityService {

	/// <summary>
	/// Configure services for database access
	/// </summary>
	public static class IdentityServiceExtensions {

		/// <summary>
		/// Serviceses the add identity.
		/// </summary>
		/// <typeparam name="TContext">The type of the context.</typeparam>
		/// <param name="services">The services.</param>
		/// <param name="connectionString"></param>
		/// <param name="migrationAssembly"></param>
		/// <param name="enableSensitiveDataLogging"></param>
		/// <param name="requireConfirmedAccount">if set to <c>true</c> [require confirmed account].</param>
		public static void AddServicesIdentityDbContext<TContext>(this IServiceCollection services, string connectionString, string migrationAssembly, bool enableSensitiveDataLogging = true, bool requireConfirmedAccount = true) where TContext : DbContext {

			_ = services.AddDbContext<TContext>(options =>
				options.UseSqlServer(connectionString/*, x => x.MigrationsAssembly(migrationAssembly)*/)
				.EnableSensitiveDataLogging(enableSensitiveDataLogging));

			_ = services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = requireConfirmedAccount)
				.AddEntityFrameworkStores<TContext>()
				.AddDefaultUI()
				 .AddClaimsPrincipalFactory<CustomClaimsPrincipalFactory>()
				 .AddDefaultTokenProviders();
			//services.AddDatabaseDeveloperPageExceptionFilter();

		}
	}
}
