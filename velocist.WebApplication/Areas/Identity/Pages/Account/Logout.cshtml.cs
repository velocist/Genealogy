using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using velocist.IdentityService.Entities;

namespace velocist.WebApplication.Areas.Identity.Pages.Account {
	[AllowAnonymous]
	public class LogoutModel : PageModel {
		private readonly SignInManager<User> _signInManager;
		private readonly ILogger<LogoutModel> _logger;

		/// <summary>
		/// Initializes a new instance of the <see cref="LogoutModel"/> class.
		/// </summary>
		/// <param name="signInManager">The sign in manager.</param>
		/// <param name="logger">The logger.</param>
		public LogoutModel(SignInManager<User> signInManager, ILogger<LogoutModel> logger) {
			_signInManager = signInManager;
			_logger = logger;
		}

		/// <summary>
		/// Called when [get].
		/// </summary>
		public void OnGet() {
		}

		/// <summary>
		/// Called when [post].
		/// </summary>
		/// <param name="returnUrl">The return URL.</param>
		/// <returns></returns>
		public async Task<IActionResult> OnPost(string returnUrl = null) {
			await _signInManager.SignOutAsync();
			_logger.LogInformation("User logged out.");
			if (returnUrl != null) {
				return LocalRedirect(returnUrl);
			} else {
				return RedirectToPage();
			}
		}
	}
}
