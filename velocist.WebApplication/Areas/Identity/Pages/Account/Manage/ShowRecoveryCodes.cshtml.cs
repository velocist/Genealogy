namespace velocist.WebApplication.Areas.Identity.Pages.Account.Manage {
	public class ShowRecoveryCodesModel : PageModel {

		/// <summary>
		/// Gets or sets the recovery codes.
		/// </summary>
		/// <value>
		/// The recovery codes.
		/// </value>
		[TempData]
		public string[] RecoveryCodes { get; set; }

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
		public IActionResult OnGet() {
			if (RecoveryCodes == null || RecoveryCodes.Length == 0) {
				return RedirectToPage("./TwoFactorAuthentication");
			}

			return Page();
		}
	}
}
