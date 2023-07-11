﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using velocist.IdentityService.Entities;

namespace velocist.WebApplication.Areas.Identity.Pages.Account {
	[AllowAnonymous]
	public class ResetPasswordModel : PageModel {
		private readonly UserManager<User> _userManager;

		/// <summary>
		/// Initializes a new instance of the <see cref="ResetPasswordModel"/> class.
		/// </summary>
		/// <param name="userManager">The user manager.</param>
		public ResetPasswordModel(UserManager<User> userManager) {
			_userManager = userManager;
		}

		/// <summary>
		/// Gets or sets the input.
		/// </summary>
		/// <value>
		/// The input.
		/// </value>
		[BindProperty]
		public InputModel Input { get; set; }

		public class InputModel {
			[Required]
			[EmailAddress]
			public string Email { get; set; }

			[Required]
			[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
			[DataType(DataType.Password)]
			public string Password { get; set; }

			[DataType(DataType.Password)]
			[Display(Name = "Confirm password")]
			[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
			public string ConfirmPassword { get; set; }

			public string Code { get; set; }
		}

		/// <summary>
		/// Called when [get].
		/// </summary>
		/// <param name="code">The code.</param>
		/// <returns></returns>
		public IActionResult OnGet(string code = null) {
			if (code == null) {
				return BadRequest("A code must be supplied for password reset.");
			} else {
				Input = new InputModel {
					Code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code))
				};
				return Page();
			}
		}

		/// <summary>
		/// Called when [post asynchronous].
		/// </summary>
		/// <returns></returns>
		public async Task<IActionResult> OnPostAsync() {
			if (!ModelState.IsValid) {
				return Page();
			}

			var user = await _userManager.FindByEmailAsync(Input.Email);
			if (user == null) {
				// Don't reveal that the user does not exist
				return RedirectToPage("./ResetPasswordConfirmation");
			}

			var result = await _userManager.ResetPasswordAsync(user, Input.Code, Input.Password);
			if (result.Succeeded) {
				return RedirectToPage("./ResetPasswordConfirmation");
			}

			foreach (var error in result.Errors) {
				ModelState.AddModelError(string.Empty, error.Description);
			}

			return Page();
		}
	}
}
