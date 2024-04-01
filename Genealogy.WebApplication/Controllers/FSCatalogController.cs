using Genealogy.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Genealogy.WebApplication.Controllers {

	/// <summary>
	/// Resources controller
	/// </summary>
	/// <seealso cref="Controller" />
	public class FSCatalogController : BaseServiceController<FSCatalogController, FSCatalogModel, FSCatalog> {

		/// <summary>
		/// Constructor of the controller
		/// </summary>
		/// <param name="sharedTranslations">Shared Translations</param>
		/// <param name="viewTranslates">View translations</param>
		/// <param name="date">Datetime</param>
		/// <param name="renderView">Render view</param>
		/// <param name="baseService"></param>
		public FSCatalogController(IStringLocalizer<SharedTranslations> sharedTranslations, IStringLocalizer<ViewsTranslations> viewTranslates, IDateTime date, IViewRender renderView, FSCatalogService baseService)
			: base(sharedTranslations, viewTranslates, date, renderView, "FSCatalog", baseService) {
			var json = System.IO.File.ReadAllText("./Views/FSCatalog/_Configure.json");
			Views = velocist.Services.Json.JsonAppHelper<ViewModel>.ConvertJsonToObject(json, false);
		}

	}
}
