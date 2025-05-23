﻿namespace Genealogy.IdentityService.Entities {

	/// <summary>
	/// Identity database context
	/// </summary>
	/// <seealso cref="IdentityDbContext{TUser}" />
	public class AuthContext : IdentityDbContext<User> {


		/// <summary>
		/// Initializes a new instance of the <see cref="AuthContext"/> class.
		/// </summary>
		/// <param name="options">The options.</param>
		public AuthContext(DbContextOptions<AuthContext> options)
			: base(options) {
		}

		/// <summary>
		/// Configures the schema needed for the identity framework.
		/// </summary>
		/// <param name="builder">The builder being used to construct the model for this context.</param>
		protected override void OnModelCreating(ModelBuilder builder) => base.OnModelCreating(builder);// Customize the ASP.NET Identity model and override the defaults if needed.// For example, you can rename the ASP.NET Identity table names and more.// Add your customizations after calling base.OnModelCreating(builder);

		/// <summary>
		/// Gets or sets the tickets request.
		/// </summary>
		/// <value>
		/// The tickets request.
		/// </value>
		public virtual DbSet<TicketsRequest> TicketsRequest { get; set; }

		/// <summary>
		/// Gets or sets the tickets response.
		/// </summary>
		/// <value>
		/// The tickets response.
		/// </value>
		public virtual DbSet<TicketsResponse> TicketsResponse { get; set; }

	}
}
