using Newtonsoft.Json;

namespace Genealogy.WebApplication.Controllers {

	/// <summary>
	/// The home controller
	/// </summary>
	/// <seealso cref="Controller" />
	public class HomeController : BaseController<HomeController, HomeViewModel> {

		/// <summary>
		/// Initializes a new instance of the <see cref="HomeController"/> class.
		/// </summary>
		/// <param name="sharedTranslations">The shared translations.</param>
		/// <param name="viewTranslates">The view translates.</param>
		/// <param name="date">The date.</param>
		/// <param name="renderView">The render view.</param>
		public HomeController(IStringLocalizer<SharedTranslations> sharedTranslations, IStringLocalizer<ViewsTranslations> viewTranslates, IDateTime date, IViewRender renderView)
			: base(sharedTranslations, viewTranslates, date, renderView, "Home") {
		}

		/// <summary>
		/// Indexes this instance.
		/// </summary>
		/// <returns></returns>
		public async Task<IActionResult> Index() {
			_logger.LogDebug("Index");

			var json = System.IO.File.ReadAllText("./Views/Home/IndexConfigure.json");
			PropertiesView = JsonConvert.DeserializeObject<CustomViewModel>(json);

			ViewData.Model = new HomeViewModel() {
				ListaGrupos = {
					new Grupos() { Id = 1, Title = "Grupo1" }
				},
				ListaBuscadores = {
					new Buscadores() { Id = 1, Title = "Buscador1" }
				},
			};

			return await ShowRenderView(ReturnViewTypeId.View, ViewData.Model, PropertiesView);
		}

		//public async Task<IActionResult> Listar() {
		//	_logger.LogDebug("Listar");

		//	var json = System.IO.File.ReadAllText("./Controllers/jsonConfigure.json");
		//	PropertiesView = JsonConvert.DeserializeObject<CustomViewModel>(json);

		//	ViewData.Model = new HomeViewModel() {
		//		ListaGrupos = {
		//			new Grupos() { Id = 1, Title = "Grupo1" },
		//			new Grupos() { Id = 2, Title = "Grupo2" }
		//		},
		//		ListaBuscadores = {
		//			new Buscadores() { Id = 1, Title = "Buscador1" },
		//			new Buscadores() { Id = 2, Title = "Buscador2" }
		//		},
		//	};

		//	return await ShowRenderView<HomeViewModel>(ReturnViewTypeId.View, PropertiesView);
		//}

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