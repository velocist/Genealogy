using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using velocist.IdentityService.Entities;

namespace velocist.WebApplication.Areas.Identity.Pages.Account {
    [AllowAnonymous]
    public class ConfirmEmailModel : PageModel {
        private readonly UserManager<User> _userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfirmEmailModel"/> class.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        public ConfirmEmailModel(UserManager<User> userManager) {
            _userManager = userManager;
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
        /// Called when [get asynchronous].
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public async Task<IActionResult> OnGetAsync(string userId, string code) {
            if (userId == null || code == null) {
                return RedirectToPage("/Index");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) {
                return NotFound($"Unable to load user with ID '{userId}'.");
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _userManager.ConfirmEmailAsync(user, code);
            StatusMessage = result.Succeeded ? "Thank you for confirming your email." : "Error confirming your email.";
            return Page();
        }
    }
}
