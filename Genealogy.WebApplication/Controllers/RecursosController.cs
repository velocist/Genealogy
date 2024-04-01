using Genealogy.Business.Services.Interfaces;

namespace Genealogy.WebApplication.Controllers {

	/// <summary>
	/// Resources controller
	/// </summary>
	/// <seealso cref="Controller" />
	public class RecursosController : BaseServiceController<RecursosController, RecursoModel, Recurso> {

		/// <summary>
		/// Constructor of the controller
		/// </summary>
		/// <param name="sharedTranslations">Shared Translations</param>
		/// <param name="viewTranslates">View translations</param>
		/// <param name="date">Datetime</param>
		/// <param name="renderView">Render view</param>
		/// <param name="baseService"></param>
		public RecursosController(IStringLocalizer<SharedTranslations> sharedTranslations, IStringLocalizer<ViewsTranslations> viewTranslates, IDateTime date, IViewRender renderView, RecursoService baseService)
			: base(sharedTranslations, viewTranslates, date, renderView, "Recursos", baseService) {
			var json = System.IO.File.ReadAllText("./Views/Recursos/_Configure.json");
			Views = velocist.Services.Json.JsonAppHelper<ViewModel>.ConvertJsonToObject(json, false);
		}

	}
}
