namespace Genealogy.WebApplication.Controllers {

	/// <summary>
	/// Resources controller
	/// </summary>
	public class RecursosController : BaseServiceController<RecursosController, RecursoModel, Recurso> {

		/// <summary>
		/// Initializes a new instance of the <see cref="RecursosController"/> class.
		/// </summary>
		/// <param name="sharedTranslations">The shared translations.</param>
		/// <param name="viewTranslates">The view translates.</param>
		/// <param name="date">The date.</param>
		/// <param name="renderView">The render view.</param>
		/// <param name="baseService">The base service.</param>
		public RecursosController(IStringLocalizer<SharedTranslations> sharedTranslations, IStringLocalizer<ViewsTranslations> viewTranslates, IDateTime date, IViewRender renderView, RecursoService baseService)
			: base(sharedTranslations, viewTranslates, date, renderView, "Recursos") {
			var json = System.IO.File.ReadAllText("./Views/Recursos/_Configure.json");
			Views = velocist.Services.Json.JsonAppHelper<ViewModel>.ConvertJsonToObject(json, false);
		}

	}
}
