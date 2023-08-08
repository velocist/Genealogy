namespace velocist.Objects.Entities {

	/// <summary>
	/// The entities context
	/// </summary>
	/// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
	public class AppEntitiesContext : DbContext {

		/// <summary>
		/// Gets or sets the country.
		/// </summary>
		/// <value>
		/// The country.
		/// </value>
		public virtual DbSet<Country> Country { get; set; }

		/// <summary>
		/// Gets or sets the indice.
		/// </summary>
		/// <value>
		/// The indice.
		/// </value>
		public virtual DbSet<Indices> Indice { get; set; }

		/// <summary>
		/// Gets or sets the investigacion.
		/// </summary>
		/// <value>
		/// The investigacion.
		/// </value>
		public virtual DbSet<Investigacion> Investigacion { get; set; }

		/// <summary>
		/// Gets or sets the recurso.
		/// </summary>
		/// <value>
		/// The recurso.
		/// </value>
		public virtual DbSet<Recurso> Recurso { get; set; }

		/// <summary>
		/// Gets or sets the tipo.
		/// </summary>
		/// <value>
		/// The tipo.
		/// </value>
		public virtual DbSet<Tipo> Tipo { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="AppEntitiesContext"/> class.
		/// </summary>
		/// <param name="options">The options.</param>
		public AppEntitiesContext(DbContextOptions<AppEntitiesContext> options)
			: base(options) {
		}

		/// <summary>
		/// Called when [model creating].
		/// </summary>
		/// <param name="builder">The builder.</param>
		protected override void OnModelCreating(ModelBuilder builder) => base.OnModelCreating(builder);// Customize the ASP.NET Identity model and override the defaults if needed.// For example, you can rename the ASP.NET Identity table names and more.// Add your customizations after calling base.OnModelCreating(builder);
	}
}
