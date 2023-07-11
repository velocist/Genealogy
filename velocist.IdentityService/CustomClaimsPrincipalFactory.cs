using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using velocist.IdentityService.Entities;

namespace velocist.IdentityService {

	/// <summary>
	/// The custom claims factory for identity login
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Identity.UserClaimsPrincipalFactory{TUser, TRole}" />
	public class CustomClaimsPrincipalFactory : UserClaimsPrincipalFactory<User, IdentityRole> {

		/// <summary>
		/// Initializes a new instance of the <see cref="CustomClaimsPrincipalFactory"/> class.
		/// </summary>
		/// <param name="userManager">The user manager.</param>
		/// <param name="roleManager">The role manager.</param>
		/// <param name="optionsAccessor">The options accessor.</param>
		public CustomClaimsPrincipalFactory(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, roleManager, optionsAccessor) {
		}

		/// <summary>
		/// Generate the claims for a user.
		/// </summary>
		/// <param name="user">The user to create a <see cref="T:System.Security.Claims.ClaimsIdentity" /> from.</param>
		/// <returns>
		/// The <see cref="T:System.Threading.Tasks.Task" /> that represents the asynchronous creation operation, containing the created <see cref="T:System.Security.Claims.ClaimsIdentity" />.
		/// </returns>
		protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user) {
			var identity = await base.GenerateClaimsAsync(user);
			identity.AddClaim(new Claim("Name", user.Name ?? ""));
			identity.AddClaim(new Claim("Surname", user.Surname1 ?? ""));
			identity.AddClaim(new Claim("Surname1", user.Surname2 ?? ""));
			identity.AddClaim(new Claim("AppConfigured", user.AppConfigured.ToString()));
			identity.AddClaim(new Claim("DbConnection", user.DbConnection ?? ""));
			identity.AddClaim(new Claim("TourConfirmed", user.TourConfirmed.ToString()));
			return identity;
		}
	}

	//public class ICustomClaimsPrincipalFactory : IUserClaimsPrincipalFactory<User> { }
}
