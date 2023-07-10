using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using velocist.IdentityService.Entities;

namespace velocist.WebApplication.Areas.Identity.Pages.Account {
    [AllowAnonymous]
    public class LoginWithRecoveryCodeModel : PageModel {
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<LoginWithRecoveryCodeModel> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginWithRecoveryCodeModel"/> class.
        /// </summary>
        /// <param name="signInManager">The sign in manager.</param>
        /// <param name="logger">The logger.</param>
        public LoginWithRecoveryCodeModel(SignInManager<User> signInManager, ILogger<LoginWithRecoveryCodeModel> logger) {
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
        /// Gets or sets the return URL.
        /// </summary>
        /// <value>
        /// The return URL.
        /// </value>
        public string ReturnUrl { get; set; }

        public class InputModel {
            [BindProperty]
            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Recovery Code")]
            public string RecoveryCode { get; set; }
        }

        /// <summary>
        /// Called when [get asynchronous].
        /// </summary>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException">Unable to load two-factor authentication user.</exception>
        public async Task<IActionResult> OnGetAsync(string returnUrl = null) {
			// Ensure the user has gone through the username & password screen first
			var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
			if (user != null) {
				ReturnUrl = returnUrl;

				return Page();
			}

			throw new InvalidOperationException($"Unable to load two-factor authentication user.");
		}

		/// <summary>
		/// Called when [post asynchronous].
		/// </summary>
		/// <param name="returnUrl">The return URL.</param>
		/// <returns></returns>
		/// <exception cref="System.InvalidOperationException">Unable to load two-factor authentication user.</exception>
		public async Task<IActionResult> OnPostAsync(string returnUrl = null) {
			if (!ModelState.IsValid) {
				return Page();
			}

			var user = await _signInManager.GetTwoFactorAuthenticationUserAsync();
			if (user != null) {
				var recoveryCode = Input.RecoveryCode.Replace(" ", string.Empty);

				var result = await _signInManager.TwoFactorRecoveryCodeSignInAsync(recoveryCode);

				if (result.Succeeded) {
					_logger.LogInformation("User with ID '{UserId}' logged in with a recovery code.", user.Id);
					return LocalRedirect(returnUrl ?? Url.Content("~/"));
				}
				if (result.IsLockedOut) {
					_logger.LogWarning("User with ID '{UserId}' account locked out.", user.Id);
					return RedirectToPage("./Lockout");
				} else {
					_logger.LogWarning("Invalid recovery code entered for user with ID '{UserId}' ", user.Id);
					ModelState.AddModelError(string.Empty, "Invalid recovery code entered.");
					return Page();
				}
			}

			throw new InvalidOperationException($"Unable to load two-factor authentication user.");
		}
	}
}
