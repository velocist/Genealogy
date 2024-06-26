﻿namespace Genealogy.WebApplication.Areas.Identity.Pages.Account.Manage {
	public class ResetAuthenticatorModel : PageModel {
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;
		private readonly ILogger<ResetAuthenticatorModel> _logger;

		public ResetAuthenticatorModel(
			UserManager<User> userManager,
			SignInManager<User> signInManager,
			ILogger<ResetAuthenticatorModel> logger) {
			_userManager = userManager;
			_signInManager = signInManager;
			_logger = logger;
		}

		[TempData]
		public string StatusMessage { get; set; }

		public async Task<IActionResult> OnGet() {
			var user = await _userManager.GetUserAsync(User);
			if (user == null)
				return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");

			return Page();
		}

		public async Task<IActionResult> OnPostAsync() {
			var user = await _userManager.GetUserAsync(User);
			if (user == null)
				return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");

			_ = await _userManager.SetTwoFactorEnabledAsync(user, false);
			_ = await _userManager.ResetAuthenticatorKeyAsync(user);
			_logger.LogInformation("User with ID '{UserId}' has reset their authentication app key.", user.Id);

			await _signInManager.RefreshSignInAsync(user);
			StatusMessage = "Your authenticator app key has been reset, you will need to configure your authenticator app using the new key.";

			return RedirectToPage("./EnableAuthenticator");
		}
	}
}