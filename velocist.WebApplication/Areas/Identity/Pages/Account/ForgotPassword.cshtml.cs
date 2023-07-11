﻿using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using velocist.IdentityService.Entities;

namespace velocist.WebApplication.Areas.Identity.Pages.Account {
	[AllowAnonymous]
	public class ForgotPasswordModel : PageModel {
		private readonly UserManager<User> _userManager;
		private readonly IEmailSender _emailSender;

		/// <summary>
		/// Initializes a new instance of the <see cref="ForgotPasswordModel"/> class.
		/// </summary>
		/// <param name="userManager">The user manager.</param>
		/// <param name="emailSender">The email sender.</param>
		public ForgotPasswordModel(UserManager<User> userManager, IEmailSender emailSender) {
			_userManager = userManager;
			_emailSender = emailSender;
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
		}

		/// <summary>
		/// Called when [post asynchronous].
		/// </summary>
		/// <returns></returns>
		public async Task<IActionResult> OnPostAsync() {
			if (ModelState.IsValid) {
				var user = await _userManager.FindByEmailAsync(Input.Email);
				if (user == null || !(await _userManager.IsEmailConfirmedAsync(user))) {
					// Don't reveal that the user does not exist or is not confirmed
					return RedirectToPage("./ForgotPasswordConfirmation");
				}

				// For more information on how to enable account confirmation and password reset please 
				// visit https://go.microsoft.com/fwlink/?LinkID=532713
				var code = await _userManager.GeneratePasswordResetTokenAsync(user);
				code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
				var callbackUrl = Url.Page(
					"/Account/ResetPassword",
					pageHandler: null,
					values: new { area = "Identity", code },
					protocol: Request.Scheme);

				await _emailSender.SendEmailAsync(
					Input.Email,
					"Reset Password",
					$"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

				return RedirectToPage("./ForgotPasswordConfirmation");
			}

			return Page();
		}
	}
}
