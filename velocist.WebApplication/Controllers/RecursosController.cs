namespace velocist.WebApplication.Controllers {

	/// <summary>
	/// Resources controller
	/// </summary>
	/// <seealso cref="Controller" />
	public class RecursosController : Controller {

		#region DEPENDENCE INJECTIONS
		private static ILogger<RecursosController> _logger;
		private readonly IStringLocalizer<SharedTranslations> _sharedTranslations;
		private readonly IStringLocalizer<ViewsTranslations> _viewTranslates;
		private readonly IDateTime _date;
		private readonly IViewRender _renderView;
		#endregion

		/// <summary>
		/// Gets the modal configuration.
		/// </summary>
		/// <value>
		/// The modal configuration.
		/// </value>
		[Obsolete]
		private ModalConfiguration<RecursosViewModel> ModalConfiguration { get; }

		/// <summary>
		/// Constructor of the controller
		/// </summary>
		/// <param name="unitOfWork">Unit of work</param>
		/// <param name="sharedTranslations">Shared Translations</param>
		/// <param name="viewTranslates">View translations</param>
		/// <param name="date">Datetime</param>
		/// <param name="renderView">Render view</param>
		[Obsolete]
		public RecursosController(IStringLocalizer<SharedTranslations> sharedTranslations, IStringLocalizer<ViewsTranslations> viewTranslates, IDateTime date, IViewRender renderView) {
			_logger = LogService.LogServiceContainer.GetLog<RecursosController>();
			_sharedTranslations = sharedTranslations;
			_viewTranslates = viewTranslates;
			_date = date;
			_renderView = renderView;
			ModalConfiguration = new ModalConfiguration<RecursosViewModel>("Recursos") {
				Title = "Recursos",
				TableAjaxAction = "/Recursos/" + Constants.ListAction,
				IndexPath = "~/Views/Recursos/Index.cshtml"
			};
		}

		/// <summary>
		/// Initializes the view.
		/// </summary>
		/// <param name="action">The action.</param>
		/// <param name="isModal">if set to <c>true</c> [is modal].</param>
		[Obsolete]
		private void InitView(Constants.Action action, bool isModal = true) {
			ViewBag.BreadcumbTitle = _sharedTranslations[ModalConfiguration.Title];
			ViewBag.BreadcumbController = _sharedTranslations[ModalConfiguration.Title];
			ViewBag.ControllerName = ModalConfiguration.ControllerName;

			if (action.Equals(Constants.Action.CREATE)) {
				ViewBag.TitleModal = _sharedTranslations[ModalConfiguration.TitleCreate];
				ViewBag.PartialName = ModalConfiguration.PartialNameEdit;
				if (isModal)
					ViewBag.Action = Constants.CreateAction;
			} else if (action.Equals(Constants.Action.EDIT)) {
				ViewBag.TitleModal = _sharedTranslations[ModalConfiguration.TitleEdit];
				ViewBag.PartialName = ModalConfiguration.PartialNameEdit;
				if (isModal)
					ViewBag.Action = Constants.EditAction;
			} else if (action.Equals(Constants.Action.DETAILS)) {
				ViewBag.TitleModal = _sharedTranslations[ModalConfiguration.TitleDetails];
				ViewBag.PartialName = ModalConfiguration.PartialNameDetails;
				if (isModal)
					ViewBag.Action = Constants.DetailsAction;
			} else if (action.Equals(Constants.Action.DELETE)) {
				ViewBag.TitleModal = _sharedTranslations[ModalConfiguration.TitleDelete];
				ViewBag.PartialName = ModalConfiguration.PartialNameDelete;
				if (isModal)
					ViewBag.Action = Constants.DeleteAction;
			} else if (action.Equals(Constants.Action.LIST)) {
				ViewBag.Title = _sharedTranslations[ModalConfiguration.Title];
				ViewBag.PartialName = ModalConfiguration.PartialNameList;
				ViewBag.PartialNameScript = ModalConfiguration.PartialNameScript;
				ViewBag.TableAjaxAction = ModalConfiguration.TableAjaxAction;
				if (User.IsInRole(Constants.Roles.SuperAdmin.ToString()))
					ModalConfiguration.UploadFile = true;
				else
					ModalConfiguration.UploadFile = false;

				ViewBag.UploadFile = ModalConfiguration.UploadFile;
			}
		}

		/// <summary>
		/// Indexes this instance.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[Obsolete]
		public async Task<IActionResult> Index() {
			try {
				InitView(Constants.Action.LIST);
				//ViewBag.Tipos = new TipoModel().List();
				return await Task.FromResult(View(ModalConfiguration.IndexPath));
			} catch (Exception ex) {
				_logger.LogError(ex.Message);
				ModelState.AddModelError(string.Empty, WebStrings.ERROR_SERVER);
				return await Task.FromResult(View(nameof(HomeController.Index)));
			}
		}

		/// <summary>
		/// Creates this instance.
		/// </summary>
		/// <returns></returns>
		//[Authorize(Roles = "SuperAdmin")]        
		[HttpGet]
		[Obsolete]
		public async Task<IActionResult> Create() {
			try {
				InitView(Constants.Action.CREATE);
				return await Task.FromResult(View(ModalConfiguration.ModalPath, new RecursosViewModel()));
			} catch (Exception ex) {
				_logger.LogError(ex.Message);
				ModelState.AddModelError(string.Empty, WebStrings.ERROR_SERVER);
				return await Task.FromResult(View(nameof(Index)));
			}
		}

		/// <summary>
		/// Creates the specified model.
		/// </summary>
		/// <param name="model">The model.</param>
		/// <returns></returns>
		//[Authorize(Roles = "SuperAdmin")]        
		[HttpPost]
		[Obsolete]
		public async Task<IActionResult> Create(RecursosViewModel model) {
			string strRenderView;
			try {
				InitView(Constants.Action.CREATE);
				if (ModelState.IsValid)
					if (model.Save())
						return await Task.FromResult(new JsonResult(StatusCodes.Status200OK));
					else {
						ModelState.AddModelError(string.Empty, WebStrings.ERROR_MODIFY);
						strRenderView = await _renderView.RenderAsync(ModalConfiguration.ModalPath, model, new ViewDataDictionary(ViewData));
						return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status400BadRequest });
					}

				ModelState.AddModelError(string.Empty, WebStrings.ERROR_BAD_REQUEST);
				strRenderView = await _renderView.RenderAsync(ModalConfiguration.ModalPath, model, new ViewDataDictionary(ViewData));
				return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status400BadRequest });
			} catch (Exception ex) {
				_logger.LogError(ex.Message);
				ModelState.AddModelError(string.Empty, WebStrings.ERROR_SERVER);
				strRenderView = await _renderView.RenderAsync(ModalConfiguration.ModalPath, model, new ViewDataDictionary(ViewData));
				return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status500InternalServerError });
			}
		}

		/// <summary>
		/// Edits the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		//[Authorize(Roles = "SuperAdmin")]        
		[HttpGet]
		[Obsolete]
		public async Task<IActionResult> Edit(string id) {
			string strRenderView;
			try {
				InitView(Constants.Action.EDIT);
				if (id != null && id.Length > 0) {
					var model = new RecursosViewModel(int.Parse(id)).Get();
					if (model != null) {
						strRenderView = await _renderView.RenderAsync(ModalConfiguration.ModalPath, model, new ViewDataDictionary(ViewData));
						return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status200OK });
					} else {
						ModelState.AddModelError(string.Empty, WebStrings.ERROR_GET);
						strRenderView = await _renderView.RenderAsync(ModalConfiguration.ModalPath, model, new ViewDataDictionary(ViewData));
						return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status400BadRequest });
					}
				}

				ModelState.AddModelError(string.Empty, WebStrings.ERROR_BAD_REQUEST);
				strRenderView = await _renderView.RenderAsync(ModalConfiguration.IndexPath, new RecursosViewModel(), new ViewDataDictionary(ViewData));
				return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status400BadRequest });
			} catch (Exception ex) {
				_logger.LogError(ex.Message);
				ModelState.AddModelError(string.Empty, WebStrings.ERROR_SERVER);
				strRenderView = await _renderView.RenderAsync(ModalConfiguration.IndexPath, new RecursosViewModel(), new ViewDataDictionary(ViewData));
				return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status500InternalServerError });
			}
		}

		/// <summary>
		/// Edits the specified model.
		/// </summary>
		/// <param name="model">The model.</param>
		/// <returns></returns>
		//[Authorize(Roles = "SuperAdmin")]        
		[HttpPost]
		[Obsolete]
		public async Task<IActionResult> Edit(RecursosViewModel model) {
			string strRenderView;
			try {
				InitView(Constants.Action.EDIT);
				if (ModelState.IsValid)
					if (model.Update())
						return await Task.FromResult(new JsonResult(StatusCodes.Status200OK));
					else {
						ModelState.AddModelError(string.Empty, WebStrings.ERROR_MODIFY);
						strRenderView = await _renderView.RenderAsync(ModalConfiguration.ModalPath, model, new ViewDataDictionary(ViewData));
						return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status400BadRequest });
					}

				ModelState.AddModelError(string.Empty, WebStrings.ERROR_BAD_REQUEST);
				strRenderView = await _renderView.RenderAsync(ModalConfiguration.ModalPath, model, new ViewDataDictionary(ViewData));
				return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status400BadRequest });
			} catch (Exception ex) {
				_logger.LogError(ex.Message);
				ModelState.AddModelError(string.Empty, WebStrings.ERROR_SERVER);
				strRenderView = await _renderView.RenderAsync(ModalConfiguration.ModalPath, model, new ViewDataDictionary(ViewData));
				return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status500InternalServerError });
			}
		}

		/// <summary>
		/// Lists the specified tipo identifier.
		/// </summary>
		/// <param name="tipo_id">The tipo identifier.</param>
		/// <returns></returns>
		[HttpPost]
		[Obsolete]
		//[Authorize(Roles = "SuperAdmin")]        
		public async Task<IActionResult> List(int tipo_id) {
			try {
				var model = new RecursosViewModel().List(/*tipo_id*/);
				return await Task.FromResult(new JsonResult(model) { StatusCode = StatusCodes.Status200OK });
			} catch (Exception ex) {
				_logger.LogError(ex.Message);
				return await Task.FromResult(new JsonResult(WebStrings.ERROR_SERVER) { StatusCode = StatusCodes.Status500InternalServerError });
			}
		}

		//[Authorize(Roles = "SuperAdmin")]
		//[HttpPost]
		//public async Task<JsonResult> Import(IFormFile file) {
		//    string strRenderView;
		//    try {
		//        if (file != null) {
		//            RecursosViewModel model = new();
		//            //Check format file
		//            if (!file.FileName.EndsWith(".csv")) {
		//                ModelState.AddModelError(string.Empty, _sharedTranslations["Selecciona un archivo csv"]);
		//                strRenderView = await _renderView.RenderAsync(ModalConfiguration.IndexPath, new RecursosViewModel(), new ViewDataDictionary(ViewData));
		//                return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status400BadRequest });
		//            }

		//            //Copy file to import
		//            string pathCopy = FilesHelper.CopyFile(file, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot", file.FileName));

		//            if (pathCopy != null && pathCopy.Length > 0) {
		//                model.FileName = Path.GetFileName(file.FileName);
		//                //Do import
		//                if (model.Import(pathCopy, 0)) {
		//                    return await Task.FromResult(new JsonResult(StatusCodes.Status200OK));
		//                } else {
		//                    ModelState.AddModelError(string.Empty, Strings.ERROR_IMPORT);
		//                    strRenderView = await _renderView.RenderAsync(ModalConfiguration.IndexPath, new RecursoModel(), new ViewDataDictionary(ViewData));
		//                    return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status400BadRequest });
		//                }
		//            }
		//        }
		//        ModelState.AddModelError(string.Empty, Strings.ERROR_BAD_REQUEST);
		//        strRenderView = await _renderView.RenderAsync(ModalConfiguration.IndexPath, new RecursoModel(), new ViewDataDictionary(ViewData));
		//        return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status400BadRequest });
		//    } catch (Exception ex) {
		//        _logger.LogError(ex.Message);
		//        ModelState.AddModelError(string.Empty, Strings.ERROR_SERVER);
		//        strRenderView = await _renderView.RenderAsync(ModalConfiguration.IndexPath, new List<RecursoModel>(), new ViewDataDictionary(ViewData));
		//        return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status500InternalServerError });
		//    }
		//}

	}
}
