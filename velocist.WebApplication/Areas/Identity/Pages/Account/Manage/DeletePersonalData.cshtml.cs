using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using velocist.IdentityService.Entities;

namespace velocist.WebApplication.Areas.Identity.Pages.Account.Manage {

    /// <summary>
    /// Page model for delete personal data
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.RazorPages.PageModel" />
    public class DeletePersonalDataModel : PageModel {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<DeletePersonalDataModel> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeletePersonalDataModel"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <param name="signInManager">The sign in manager.</param>
        /// <param name="logger">The logger.</param>
        public DeletePersonalDataModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ILogger<DeletePersonalDataModel> logger) {
            _userManager = userManager;
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
        /// Input model
        /// </summary>
        public class InputModel {

            /// <summary>
            /// Gets or sets the password.
            /// </summary>
            /// <value>
            /// The password.
            /// </value>
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [require password].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [require password]; otherwise, <c>false</c>.
        /// </value>
        public bool RequirePassword { get; set; }

        /// <summary>
        /// Called when [get].
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnGet() {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            RequirePassword = await _userManager.HasPasswordAsync(user);
            return Page();
        }

        /// <summary>
        /// Called when [post asynchronous].
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException">Unexpected error occurred deleting user with ID '{userId}'.</exception>
        public async Task<IActionResult> OnPostAsync() {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            RequirePassword = await _userManager.HasPasswordAsync(user);
            if (RequirePassword) {
                if (!await _userManager.CheckPasswordAsync(user, Input.Password)) {
                    ModelState.AddModelError(string.Empty, "Incorrect password.");
                    return Page();
                }
            }

            var result = await _userManager.DeleteAsync(user);
            var userId = await _userManager.GetUserIdAsync(user);
            if (!result.Succeeded) {
                throw new InvalidOperationException($"Unexpected error occurred deleting user with ID '{userId}'.");
            }

            await _signInManager.SignOutAsync();

            _logger.LogInformation("User with ID '{UserId}' deleted themselves.", userId);

            return Redirect("~/");
        }
    }
}
