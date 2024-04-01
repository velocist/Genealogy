using Genealogy.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Genealogy.WebApplication.Controllers {

	/// <summary>
	/// Resources controller
	/// </summary>
	/// <seealso cref="Controller" />
	public class FSRecordController : BaseServiceController<FSRecordController, FSRecordModel, FSRecord> {

		/// <summary>
		/// Constructor of the controller
		/// </summary>
		/// <param name="sharedTranslations">Shared Translations</param>
		/// <param name="viewTranslates">View translations</param>
		/// <param name="date">Datetime</param>
		/// <param name="renderView">Render view</param>
		/// <param name="baseService"></param>
		public FSRecordController(IStringLocalizer<SharedTranslations> sharedTranslations, IStringLocalizer<ViewsTranslations> viewTranslates, IDateTime date, IViewRender renderView, FSRecordService baseService)
			: base(sharedTranslations, viewTranslates, date, renderView, "FSRecord", baseService) {
			var json = System.IO.File.ReadAllText("./Views/FSRecord/_Configure.json");
			Views = velocist.Services.Json.JsonAppHelper<ViewModel>.ConvertJsonToObject(json, false);
		}

		//[Authorize(Roles = "SuperAdmin")]
		//[HttpPost]
		//public async Task<JsonResult> Export(IFormFile file) {
		//    string strRenderView;
		//    try {
		//        if (file != null) {
		//            FSRecordService model = new();
		//            //Check format file
		//            if (!file.FileName.EndsWith(".csv")) {
		//                ModelState.AddModelError(string.Empty, _sharedTranslations["Selecciona un archivo csv"]);
		//                strRenderView = await _renderView.RenderAsync(ModalConfiguration.IndexPath, new FSRecordService(), ViewData);
		//                return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status400BadRequest });
		//            }

		//            //Copy file to import
		//            string pathCopy = FilesHelper.CopyFile(file, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot", file.FileName));

		//            if (pathCopy != null && pathCopy.Length > 0) {
		//                model.FileName = Path.GetFileName(file.FileName);
		//                //Do import
		//                if (model.Export(pathCopy, 0)) {
		//                    return await Task.FromResult(new JsonResult(StatusCodes.Status200OK));
		//                } else {
		//                    ModelState.AddModelError(string.Empty, Strings.ERROR_IMPORT);
		//                    strRenderView = await _renderView.RenderAsync(ModalConfiguration.IndexPath, new Model(), ViewData);
		//                    return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status400BadRequest });
		//                }
		//            }
		//        }
		//        ModelState.AddModelError(string.Empty, Strings.ERROR_BAD_REQUEST);
		//        strRenderView = await _renderView.RenderAsync(ModalConfiguration.IndexPath, new Model(), ViewData);
		//        return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status400BadRequest });
		//    } catch (Exception ex) {
		//        _logger.LogError(ex.Message);
		//        ModelState.AddModelError(string.Empty, Strings.ERROR_SERVER);
		//        strRenderView = await _renderView.RenderAsync(ModalConfiguration.IndexPath, new GetAll<Model>(), ViewData);
		//        return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status500InternalServerError });
		//    }
		//}

	}
}
