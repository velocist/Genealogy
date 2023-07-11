using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace velocist.WebApplication.Areas.Identity.Pages.Account {
	[AllowAnonymous]
	public class ResetPasswordConfirmationModel : PageModel {

		/// <summary>
		/// Called when [get].
		/// </summary>
		public void OnGet() {

		}
	}
}
