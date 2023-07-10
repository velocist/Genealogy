using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using velocist.Business.Models;

namespace velocist.WebApplication.Controllers {

    /// <summary>
    /// The home controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class HomeController : Controller {

        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        public HomeController() {
            _logger = LogService.LogServiceContainer.GetLog<HomeController>();
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