using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using velocist.IdentityService.Entities;

namespace velocist.WebApplication.Areas.Identity.Pages.Account.Manage {
	public class Disable2faModel : PageModel {
		private readonly UserManager<User> _userManager;
		private readonly ILogger<Disable2faModel> _logger;

		/// <summary>
		/// Initializes a new instance of the <see cref="Disable2faModel"/> class.
		/// </summary>
		/// <param name="userManager">The user manager.</param>
		/// <param name="logger">The logger.</param>
		public Disable2faModel(
			UserManager<User> userManager,
			ILogger<Disable2faModel> logger) {
			_userManager = userManager;
			_logger = logger;
		}

		/// <summary>
		/// Gets or sets the status message.
		/// </summary>
		/// <value>
		/// The status message.
		/// </value>
		[TempData]
		public string StatusMessage { get; set; }

		/// <summary>
		/// Called when [get].
		/// </summary>
		/// <returns></returns>
		/// <exception cref="System.InvalidOperationException">Cannot disable 2FA for user with ID '{_userManager.GetUserId(User)}' as it's not currently enabled.</exception>
		public async Task<IActionResult> OnGet() {
			var user = await _userManager.GetUserAsync(User);
			if (user == null) {
				return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
			}

			if (!await _userManager.GetTwoFactorEnabledAsync(user)) {
				throw new InvalidOperationException($"Cannot disable 2FA for user with ID '{_userManager.GetUserId(User)}' as it's not currently enabled.");
			}

			return Page();
		}

		/// <summary>
		/// Called when [post asynchronous].
		/// </summary>
		/// <returns></returns>
		/// <exception cref="System.InvalidOperationException">Unexpected error occurred disabling 2FA for user with ID '{_userManager.GetUserId(User)}'.</exception>
		public async Task<IActionResult> OnPostAsync() {
			var user = await _userManager.GetUserAsync(User);
			if (user == null) {
				return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
			}

			var disable2faResult = await _userManager.SetTwoFactorEnabledAsync(user, false);
			if (!disable2faResult.Succeeded) {
				throw new InvalidOperationException($"Unexpected error occurred disabling 2FA for user with ID '{_userManager.GetUserId(User)}'.");
			}

			_logger.LogInformation("User with ID '{UserId}' has disabled 2fa.", _userManager.GetUserId(User));
			StatusMessage = "2fa has been disabled. You can reenable 2fa when you setup an authenticator app";
			return RedirectToPage("./TwoFactorAuthentication");
		}
	}
}