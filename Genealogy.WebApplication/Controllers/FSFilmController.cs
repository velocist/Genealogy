namespace Genealogy.WebApplication.Controllers {

	/// <summary>
	/// Resources controller
	/// </summary>
	/// <seealso cref="Controller" />
	public class FSFilmController : BaseServiceController<FSFilmController, FSFilmModel, FSFilm> {

		/// <summary>
		/// Initializes a new instance of the <see cref="FSFilmController"/> class.
		/// </summary>
		/// <param name="sharedTranslations">The shared translations.</param>
		/// <param name="viewTranslates">The view translates.</param>
		/// <param name="date">The date.</param>
		/// <param name="renderView">The render view.</param>
		///// <param name="baseService">The base service.</param>
		public FSFilmController(IStringLocalizer<SharedTranslations> sharedTranslations, IStringLocalizer<ViewsTranslations> viewTranslates, IDateTime date, IViewRender renderView/*, FSFilmService baseService*/)
			: base(sharedTranslations, viewTranslates, date, renderView, "FSFilm"/*, baseService*/) {
			var json = System.IO.File.ReadAllText("./Views/FSFilm/_Configure.json");
			Views = velocist.Services.Json.JsonAppHelper<ViewModel>.ConvertJsonToObject(json, false);
		}

	}
}
