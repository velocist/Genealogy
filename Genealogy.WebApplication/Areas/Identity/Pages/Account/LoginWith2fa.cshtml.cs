﻿namespace Genealogy.WebApplication.Areas.Identity.Pages.Account {
	[AllowAnonymous]
	public class LoginWith2faModel : PageModel {
		private readonly SignInManager<User> _signInManager;
		private readonly ILogger<LoginWith2faModel> _logger;

		/// <summary>
		/// Initializes a new instance of the <see cref="LoginWith2faModel"/> class.
		/// </summary>
		/// <param name="signInManager">The sign in manager.</param>
		/// <param name="logger">The logger.</param>
		public LoginWith2faModel(SignInManager<User> signInManager, ILogger<LoginWith2faModel> logger) {
			_signInManager = signInManager;
			_logger = logger;
		}

		/// <summary>
		/// Gets or sets the input.
		/// </summary>
		/// <value>
		/// The input.
		/// </value>
		[BindProperty]
		public InputModel Input { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether [remember me].
		/// </summary>
		/// <value>
		///   <c>true</c> if [remember me]; otherwise, <c>false</c>.
		/// </value>
		public bool RememberMe { get; set; }

		/// <summary>
		/// Gets or sets the return URL.
		/// </summary>
		/// <value>
		/// The return URL.
		/// </value>
		public string ReturnUrl { get; set; }

		public class InputModel {
			[Required]
			[StringLength(7, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
			[DataType(DataType.Text)]
			[Display(Name = "Authenticator code")]
			public string TwoFactorCode { get; set; }

			[Display(Name = "Remember this machine")]
			public bool RememberMachine { get; set; }
		}

		/// <summary>
		/// Called when [get asynchronous].
		/// </summary>
		/// <param name="rememberMe">if set to <c>true</c> [remember me].</param>
		/// <param name="returnUrl">The return URL.</param>
		/// <returns></returns>
		/// <exception cref="InvalidOperationException">Unable to load two-factor authentication user.</exception>
		public async Task<IActionResult> OnGetAsync(bool rememberMe, string returnUrl = null) {
			// Ensure the user has gone through the username & password screen first
			var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();

			if (user != null) {
				ReturnUrl = returnUrl;
				RememberMe = rememberMe;

				return Page();
			}

			throw new InvalidOperationException($"Unable to load two-factor authentication user.");
		}

		/// <summary>
		/// Called when [post asynchronous].
		/// </summary>
		/// <param name="rememberMe">if set to <c>true</c> [remember me].</param>
		/// <param name="returnUrl">The return URL.</param>
		/// <returns></returns>
		/// <exception cref="InvalidOperationException">Unable to load two-factor authentication user.</exception>
		public async Task<IActionResult> OnPostAsync(bool rememberMe, string returnUrl = null) {
			if (!ModelState.IsValid)
				return Page();

			returnUrl ??= Url.Content("~/");

			var user = await _signInManager.GetTwoFactorAuthenticationUserAsync() ?? throw new InvalidOperationException($"Unable to load two-factor authentication user.");
			var authenticatorCode = Input.TwoFactorCode.Replace(" ", string.Empty).Replace("-", string.Empty);

			var result = await _signInManager.TwoFactorAuthenticatorSignInAsync(authenticatorCode, rememberMe, Input.RememberMachine);

			if (result.Succeeded) {
				_logger.LogInformation("User with ID '{UserId}' logged in with 2fa.", user.Id);
				return LocalRedirect(returnUrl);
			} else if (result.IsLockedOut) {
				_logger.LogWarning("User with ID '{UserId}' account locked out.", user.Id);
				return RedirectToPage("./Lockout");
			} else {
				_logger.LogWarning("Invalid authenticator code entered for user with ID '{UserId}'.", user.Id);
				ModelState.AddModelError(string.Empty, "Invalid authenticator code.");
				return Page();
			}
		}
	}
}
