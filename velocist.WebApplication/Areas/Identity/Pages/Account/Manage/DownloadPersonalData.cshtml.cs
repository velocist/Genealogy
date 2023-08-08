namespace velocist.WebApplication.Areas.Identity.Pages.Account.Manage {
	public class DownloadPersonalDataModel : PageModel {
		private readonly UserManager<User> _userManager;
		private readonly ILogger<DownloadPersonalDataModel> _logger;

		/// <summary>
		/// Initializes a new instance of the <see cref="DownloadPersonalDataModel"/> class.
		/// </summary>
		/// <param name="userManager">The user manager.</param>
		/// <param name="logger">The logger.</param>
		public DownloadPersonalDataModel(
			UserManager<User> userManager,
			ILogger<DownloadPersonalDataModel> logger) {
			_userManager = userManager;
			_logger = logger;
		}

		/// <summary>
		/// Called when [post asynchronous].
		/// </summary>
		/// <returns></returns>
		public async Task<IActionResult> OnPostAsync() {
			var user = await _userManager.GetUserAsync(User);
			if (user == null) {
				return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
			}

			_logger.LogInformation("User with ID '{UserId}' asked for their personal data.", _userManager.GetUserId(User));

			// Only include personal data for download
			var personalData = new Dictionary<string, string>();
			var personalDataProps = typeof(User).GetProperties().Where(
							prop => Attribute.IsDefined(prop, typeof(PersonalDataAttribute)));
			foreach (var p in personalDataProps) {
				personalData.Add(p.Name, p.GetValue(user)?.ToString() ?? "null");
			}

			var logins = await _userManager.GetLoginsAsync(user);
			foreach (var l in logins) {
				personalData.Add($"{l.LoginProvider} external login provider key", l.ProviderKey);
			}

			Response.Headers.Add("Content-Disposition", "attachment; filename=PersonalData.json");
			return new FileContentResult(JsonSerializer.SerializeToUtf8Bytes(personalData), "application/json");
		}
	}
}
