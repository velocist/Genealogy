namespace Genealogy.WebApplication.Areas.Identity.Pages {
	[AllowAnonymous]
	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public class ErrorModel : PageModel {

		/// <summary>
		/// Gets or sets the request identifier.
		/// </summary>
		/// <value>
		/// The request identifier.
		/// </value>
		public string RequestId { get; set; }

		/// <summary>
		/// Gets a value indicating whether [show request identifier].
		/// </summary>
		/// <value>
		///   <c>true</c> if [show request identifier]; otherwise, <c>false</c>.
		/// </value>
		public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

		/// <summary>
		/// Called when [get].
		/// </summary>
		public void OnGet() => RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
	}
}
