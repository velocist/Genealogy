namespace Genealogy.WebApplication.Controllers {

	/// <summary>
	/// Resources controller
	/// </summary>
	/// <seealso cref="Controller" />
	public class FSImageController : BaseServiceController<FSImageController, FSImageModel, FSImage> {

		/// <summary>
		/// Initializes a new instance of the <see cref="FSImageController"/> class.
		/// </summary>
		/// <param name="sharedTranslations">The shared translations.</param>
		/// <param name="viewTranslates">The view translates.</param>
		/// <param name="date">The date.</param>
		/// <param name="renderView">The render view.</param>
		/// <param name="baseService">The base service.</param>
		public FSImageController(IStringLocalizer<SharedTranslations> sharedTranslations, IStringLocalizer<ViewsTranslations> viewTranslates, IDateTime date, IViewRender renderView, FSImageService baseService)
			: base(sharedTranslations, viewTranslates, date, renderView, "FSImage") {
			var json = System.IO.File.ReadAllText("./Views/FSImage/_Configure.json");
			Views = velocist.Services.Json.JsonHelper<ViewModel>.DeserializeToObject(json, false);
		}

	}
}
