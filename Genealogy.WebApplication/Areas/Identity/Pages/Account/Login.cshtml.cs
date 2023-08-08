namespace Genealogy.WebApplication.Areas.Identity.Pages.Account {
	[AllowAnonymous]
	public class LoginModel : PageModel {
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;
		private readonly ILogger<LoginModel> _logger;

		/// <summary>
		/// Initializes a new instance of the <see cref="LoginModel"/> class.
		/// </summary>
		/// <param name="signInManager">The sign in manager.</param>
		/// <param name="logger">The logger.</param>
		/// <param name="userManager">The user manager.</param>
		[Obsolete]
		public LoginModel(SignInManager<User> signInManager,
			ILogger<LoginModel> logger,
			UserManager<User> userManager) {
			_userManager = userManager;
			_signInManager = signInManager;
			_logger = LogServiceContainer.GetLog<LoginModel>();
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
		/// Gets or sets the external logins.
		/// </summary>
		/// <value>
		/// The external logins.
		/// </value>
		public IList<AuthenticationScheme> ExternalLogins { get; set; }

		/// <summary>
		/// Gets or sets the return URL.
		/// </summary>
		/// <value>
		/// The return URL.
		/// </value>
		public string ReturnUrl { get; set; }

		/// <summary>
		/// Gets or sets the error message.
		/// </summary>
		/// <value>
		/// The error message.
		/// </value>
		[TempData]
		public string ErrorMessage { get; set; }

		public class InputModel {
			[Required]
			[EmailAddress]
			public string Email { get; set; }

			[Required]
			[DataType(DataType.Password)]
			public string Password { get; set; }

			[Display(Name = "Remember me?")]
			public bool RememberMe { get; set; }
		}

		/// <summary>
		/// Called when [get asynchronous].
		/// </summary>
		/// <param name="returnUrl">The return URL.</param>
		public async Task OnGetAsync(string returnUrl = null) {
			if (!string.IsNullOrEmpty(ErrorMessage))
				ModelState.AddModelError(string.Empty, ErrorMessage);

			returnUrl ??= Url.Content("~/");

			// Clear the existing external cookie to ensure a clean login process
			await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

			ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

			ReturnUrl = returnUrl;
		}

		/// <summary>
		/// Called when [post asynchronous].
		/// </summary>
		/// <param name="returnUrl">The return URL.</param>
		/// <returns></returns>
		public async Task<IActionResult> OnPostAsync(string returnUrl = null) {
			returnUrl ??= Url.Content("~/");

			ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

			if (ModelState.IsValid) {
				// This doesn't count login failures towards account lockout
				// To enable password failures to trigger account lockout, set lockoutOnFailure: true
				var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);
				if (result.Succeeded) {
					_logger.LogInformation("User logged in.");
					return LocalRedirect(returnUrl);
				}

				if (result.RequiresTwoFactor)
					return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, Input.RememberMe });

				if (result.IsLockedOut) {
					_logger.LogWarning("User account locked out.");
					return RedirectToPage("./Lockout");
				} else {
					ModelState.AddModelError(string.Empty, "Invalid login attempt.");
					return Page();
				}
			}

			// If we got this far, something failed, redisplay form
			return Page();
		}
	}
}
