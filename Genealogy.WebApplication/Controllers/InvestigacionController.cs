using Genealogy.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Genealogy.WebApplication.Controllers {
	public class InvestigacionController : BaseServiceController<InvestigacionController, InvestigacionModel, Investigacion> {

		/// <summary>
		/// Constructor of the controller
		/// </summary>
		/// <param name="sharedTranslations">Shared Translations</param>
		/// <param name="viewTranslates">View translations</param>
		/// <param name="date">Datetime</param>
		/// <param name="renderView">Render view</param>
		/// <param name="baseService"></param>
		public InvestigacionController(IStringLocalizer<SharedTranslations> sharedTranslations, IStringLocalizer<ViewsTranslations> viewTranslates, IDateTime date, IViewRender renderView, InvestigacionService baseService)
			: base(sharedTranslations, viewTranslates, date, renderView, "Investigacion", baseService) {
			var json = System.IO.File.ReadAllText("./Views/Investigacion/_Configure.json");
			Views = velocist.Services.Json.JsonAppHelper<ViewModel>.ConvertJsonToObject(json, false);
		}

	}
}
