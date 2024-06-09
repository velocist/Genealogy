namespace Genealogy.WebApplication.Controllers {

	/// <summary>
	/// Resources controller
	/// </summary>
	/// <seealso cref="Controller" />
	public class FSRecordController : BaseServiceController<FSRecordController, FSRecordModel, FSRecord> {

		/// <summary>
		/// Initializes a new instance of the <see cref="FSRecordController"/> class.
		/// </summary>
		/// <param name="sharedTranslations">The shared translations.</param>
		/// <param name="viewTranslates">The view translates.</param>
		/// <param name="date">The date.</param>
		/// <param name="renderView">The render view.</param>
		/// <param name="baseService">The base service.</param>
		public FSRecordController(IStringLocalizer<SharedTranslations> sharedTranslations, IStringLocalizer<ViewsTranslations> viewTranslates, IDateTime date, IViewRender renderView, FSRecordService baseService)
			: base(sharedTranslations, viewTranslates, date, renderView, "FSRecord") {
			var json = System.IO.File.ReadAllText("./Views/FSRecord/_Configure.json");
			Views = velocist.Services.Json.JsonAppHelper<ViewModel>.ConvertJsonToObject(json, false);
		}

	}
}
