namespace Genealogy.WebApplication.Controllers {

	public class InvestigacionController : BaseServiceController<InvestigacionController, InvestigacionModel, Investigacion> {

		/// <summary>
		/// Initializes a new instance of the <see cref="InvestigacionController"/> class.
		/// </summary>
		/// <param name="sharedTranslations">The shared translations.</param>
		/// <param name="viewTranslates">The view translates.</param>
		/// <param name="date">The date.</param>
		/// <param name="renderView">The render view.</param>
		/// <param name="baseService">The base service.</param>
		public InvestigacionController(IStringLocalizer<SharedTranslations> sharedTranslations, IStringLocalizer<ViewsTranslations> viewTranslates, IDateTime date, IViewRender renderView, InvestigacionService baseService)
			: base(sharedTranslations, viewTranslates, date, renderView, "Investigacion") {
			var json = System.IO.File.ReadAllText("./Views/Investigacion/_Configure.json");
			Views = velocist.Services.Json.JsonHelper<ViewModel>.DeserializeToObject(json, false);
		}

	}
}
