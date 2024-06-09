namespace Genealogy.Controllers {
	public class FileViewerController : BaseController<FileViewerController, FileViewerModel> {

		/// <summary>
		/// Initializes a new instance of the <see cref="FileViewerController"/> class.
		/// </summary>
		/// <param name="sharedTranslations">The shared translations.</param>
		/// <param name="viewTranslates">The view translates.</param>
		/// <param name="date">The date.</param>
		/// <param name="renderView">The render view.</param>
		/// <param name="baseService">The base service.</param>
		public FileViewerController(IStringLocalizer<SharedTranslations> sharedTranslations, IStringLocalizer<ViewsTranslations> viewTranslates, IDateTime date, IViewRender renderView, FSCatalogService baseService)
			: base(sharedTranslations, viewTranslates, date, renderView, "FileViewer") {
			var json = System.IO.File.ReadAllText("./Views/FileViewer/_Configure.json");
			Views = velocist.Services.Json.JsonAppHelper<ViewModel>.ConvertJsonToObject(json, false);
		}

		[HttpGet]
		public async Task<IActionResult> Index() {
			try {
				PropertiesView = Views.CustomViewModels.Find(x => x.ViewType == ReturnViewTypeId.View && x.ActionName == nameof(Index) && x.ControllerName == ControllerName);
				return await ShowRenderView<FileViewerModel>(ReturnViewTypeId.View);
			} catch (Exception ex) {
				_logger.LogError(ex.Message);
				ModelState.AddModelError(string.Empty, WebStrings.ERROR_SERVER);
				return await Task.FromResult(View(nameof(HomeController.Index)));
			}
		}

		//[Authorize(Roles = "User")]
		//[Authorize(Roles = "Moderator")]
		//[Authorize(Roles = "SuperAdmin")]
		[HttpPost]
		public async Task<IActionResult> Index(IFormFile file, int row) {
			PropertiesView = Views.CustomViewModels.Find(x => x.ViewType == ReturnViewTypeId.PartialView && x.ActionName == nameof(Index) && x.ControllerName == ControllerName);
			var model = new List<FileViewerModel>();
			//var model = new FileViewerModel();
			try {
				if (file != null) {
					//Check format file
					if (!file.FileName.EndsWith(".csv") && !file.FileName.EndsWith(".xsl") && !file.FileName.EndsWith(".xlsx")) {
						ModelState.AddModelError(string.Empty, _sharedTranslations["Selecciona un archivo .csv, .xls o .xlsx"]);
						return await ShowRenderView<FileViewerModel>(ReturnViewTypeId.PartialView, statusCode: StatusCodes.Status400BadRequest);
					}

					var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot", "files", file.FileName);
					if (System.IO.File.Exists(path)) {
						System.IO.File.Delete(path);
					}

					//Copy file to import
					var pathCopy = FilesHelper.CopyFile(file, path);

					model.Add(new FileViewerModel());
					if (pathCopy != null && pathCopy.Length > 0) {
						model = ExportExcel<FileViewerModel>.ImportList(pathCopy, row);
						if (model != null) {
							ViewData.Model = model;
							return await ShowRenderView<FileViewerModel>(ReturnViewTypeId.PartialView, statusCode: StatusCodes.Status200OK);
						} else {
							ModelState.AddModelError(string.Empty, "Error al importar el archivo.");
							return await ShowRenderView<FileViewerModel>(ReturnViewTypeId.PartialView, statusCode: StatusCodes.Status400BadRequest);
						}
					} else {
						ModelState.AddModelError(string.Empty, WebStrings.ERROR_BAD_REQUEST);
						return await ShowRenderView<FileViewerModel>(ReturnViewTypeId.PartialView, statusCode: StatusCodes.Status400BadRequest);
					}
				} else {
					ModelState.AddModelError(string.Empty, WebStrings.ERROR_BAD_REQUEST);
					return await ShowRenderView<FileViewerModel>(ReturnViewTypeId.PartialView, statusCode: StatusCodes.Status400BadRequest);
				}
			} catch (Exception ex) {
				_logger.LogError(ex.Message);
				ModelState.AddModelError(string.Empty, WebStrings.ERROR_SERVER);
				return await ShowRenderView<FileViewerModel>(ReturnViewTypeId.PartialView, statusCode: StatusCodes.Status400BadRequest);
			}
		}

		/// <summary>
		/// Download tamplate
		/// </summary>
		/// <returns>ActionResult</returns>
		[HttpGet]
		public async Task<ActionResult> DownloadTemplate(string plantilla) {
			PropertiesView = Views.CustomViewModels.Find(x => x.ViewType == ReturnViewTypeId.View && x.ActionName == nameof(Index) && x.ControllerName == ControllerName);
			try {
				if (plantilla == null || plantilla.Equals(string.Empty)) {
					TempData["Message"] = WebStrings.ERROR_SERVER;//ModelState.AddModelError(string.Empty, Strings.ERROR_SERVER);
					return await Task.FromResult(RedirectToAction(nameof(HomeController.Index)));
				}

				var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot", "files", $"Plantilla{plantilla}.xltx");//PlantillaPadron
				var fileName = Path.GetFileName(filePath);

				if (!System.IO.File.Exists(filePath)) {
					TempData["Message"] = WebStrings.ERROR_SERVER;//ModelState.AddModelError(string.Empty, Strings.ERROR_SERVER);
					return await Task.FromResult(RedirectToAction(nameof(HomeController.Index)));
				}

				var fileBytes = System.IO.File.ReadAllBytes(filePath);
				FileResult archivo = File(fileBytes, "multipart/form-data", fileName); //application/force-download
				if (archivo != null) {
					return archivo;
				} else {
					TempData["Message"] = WebStrings.ERROR_SERVER;//ModelState.AddModelError(string.Empty, Strings.ERROR_SERVER);
					return await Task.FromResult(RedirectToAction(nameof(HomeController.Index)));
				}
			} catch (Exception ex) {
				_logger.LogError(ex.Message);
				TempData["Message"] = WebStrings.ERROR_SERVER;// ModelState.AddModelError(string.Empty, Strings.ERROR_SERVER);
				return await Task.FromResult(RedirectToAction(nameof(HomeController.Index)));
			}
		}


	}
}
