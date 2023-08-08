namespace Genealogy.WebApplication.Controllers {

	/// <summary>
	/// The home controller
	/// </summary>
	/// <seealso cref="Controller" />
	public class HomeController : Controller {

		private readonly ILogger<HomeController> _logger;

		/// <summary>
		/// Initializes a new instance of the <see cref="HomeController"/> class.
		/// </summary>
		[Obsolete]
		public HomeController() {
			_logger = LogServiceContainer.GetLog<HomeController>();
		}

		/// <summary>
		/// Indexes this instance.
		/// </summary>
		/// <returns></returns>
		public IActionResult Index() {
			_logger.LogDebug("Index");
			return View();
		}

		/// <summary>
		/// Privacies this instance.
		/// </summary>
		/// <returns></returns>
		public IActionResult Privacy() => View();

		/// <summary>
		/// Errors this instance.
		/// </summary>
		/// <returns></returns>
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

		/// <summary>
		/// Errors the specified XHR.
		/// </summary>
		/// <param name="xhr">The XHR.</param>
		/// <returns></returns>
		public IActionResult Error(object xhr) => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
}