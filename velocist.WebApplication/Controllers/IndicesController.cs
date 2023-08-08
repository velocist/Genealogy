namespace velocist.WebApplication.Controllers {

	/// <summary>
	/// The Indices controller
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
	public class IndicesController : Controller {

		#region DEPENDENCE INJECTIONS
		private readonly ILogger<IndicesController> _logger;
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
		private ModalConfiguration<IndicesViewModel> ModalConfiguration { get; }

		/// <summary>
		/// Initializes a new instance of the <see cref="IndicesController"/> class.
		/// </summary>
		/// <param name="sharedTranslations">The shared translations.</param>
		/// <param name="viewTranslates">The view translates.</param>
		/// <param name="date">The date.</param>
		/// <param name="renderView">The render view.</param>
		[Obsolete]
		public IndicesController(IStringLocalizer<SharedTranslations> sharedTranslations, IStringLocalizer<ViewsTranslations> viewTranslates, IDateTime date, IViewRender renderView) {
			_logger = LogService.LogServiceContainer.GetLog<IndicesController>();
			_sharedTranslations = sharedTranslations;
			_viewTranslates = viewTranslates;
			_date = date;
			_renderView = renderView;
			ModalConfiguration = new ModalConfiguration<IndicesViewModel>("Indices") {
				Title = "Indices FS",
				TableAjaxAction = "/Indices/" + Constants.ListAction
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
				if (isModal) {
					ViewBag.Action = Constants.CreateAction;
				}
			} else if (action.Equals(Constants.Action.EDIT)) {
				ViewBag.TitleModal = _sharedTranslations[ModalConfiguration.TitleEdit];
				ViewBag.PartialName = ModalConfiguration.PartialNameEdit;
				if (isModal) {
					ViewBag.Action = Constants.EditAction;
				}
			} else if (action.Equals(Constants.Action.DETAILS)) {
				ViewBag.TitleModal = _sharedTranslations[ModalConfiguration.TitleDetails];
				ViewBag.PartialName = ModalConfiguration.PartialNameDetails;
				if (isModal) {
					ViewBag.Action = Constants.DetailsAction;
				}
			} else if (action.Equals(Constants.Action.DELETE)) {
				ViewBag.TitleModal = _sharedTranslations[ModalConfiguration.TitleDelete];
				ViewBag.PartialName = ModalConfiguration.PartialNameDelete;
				if (isModal) {
					ViewBag.Action = Constants.DeleteAction;
				}
			} else if (action.Equals(Constants.Action.LIST)) {
				ViewBag.Title = _sharedTranslations[ModalConfiguration.Title];
				ViewBag.PartialName = ModalConfiguration.PartialNameList;
				ViewBag.PartialNameScript = ModalConfiguration.PartialNameScript;
				ViewBag.TableAjaxAction = ModalConfiguration.TableAjaxAction;
				if (User.IsInRole(Constants.Roles.SuperAdmin.ToString())) {
					ModalConfiguration.UploadFile = true;
				} else {
					ModalConfiguration.UploadFile = false;
				}

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
				InitView(Constants.Action.LIST, false);
				return await Task.FromResult(View(ModalConfiguration.IndexPath));
			} catch (Exception ex) {
				_logger.LogError(ex, ex.Message);
				ModelState.AddModelError(string.Empty, Core.WebStrings.ERROR_SERVER);
				return await Task.FromResult(View(nameof(HomeController.Index)));
			}
		}

		/// <summary>
		/// Creates this instance.
		/// </summary>
		/// <returns></returns>
		[Authorize(Roles = "SuperAdmin")]
		[HttpGet]
		[Obsolete]
		public async Task<IActionResult> Create() {
			if (!User.Identity.IsAuthenticated) {
				//string strRenderView = await _renderView.RenderAsync("AccessDenied.cshtml", model, new ViewDataDictionary(ViewData));
				// return await Task.FromResult(Unauthorized());
				return RedirectToAction("Error", "Home");
			}

			try {
				InitView(Constants.Action.CREATE);
				return await Task.FromResult(View(ModalConfiguration.ModalPath, new IndiceModel()));
			} catch (Exception ex) {
				_logger.LogError(ex, ex.Message);
				ModelState.AddModelError(string.Empty, Core.WebStrings.ERROR_SERVER);
				return await Task.FromResult(View(nameof(Index)));
			}
		}

		/// <summary>
		/// Creates the specified model.
		/// </summary>
		/// <param name="model">The model.</param>
		/// <returns></returns>
		[Authorize(Roles = "SuperAdmin")]
		[HttpPost]
		[Obsolete]
		public async Task<IActionResult> Create(IndicesViewModel model) {
			string strRenderView;
			if (!User.Identity.IsAuthenticated) {
				//strRenderView = await _renderView.RenderAsync("Error.cshtml", model, new ViewDataDictionary(ViewData));
				return await Task.FromResult(Unauthorized());
			}

			try {
				InitView(Constants.Action.CREATE);
				if (ModelState.IsValid) {
					if (model.Save()) {
						return await Task.FromResult(new JsonResult(StatusCodes.Status200OK));
					} else {
						ModelState.AddModelError(string.Empty, Core.WebStrings.ERROR_MODIFY);
						strRenderView = await _renderView.RenderAsync(ModalConfiguration.ModalPath, model, new ViewDataDictionary(ViewData));
						return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status400BadRequest });
					}
				}

				ModelState.AddModelError(string.Empty, Core.WebStrings.ERROR_BAD_REQUEST);
				strRenderView = await _renderView.RenderAsync(ModalConfiguration.ModalPath, model, new ViewDataDictionary(ViewData));
				return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status400BadRequest });
			} catch (Exception ex) {
				_logger.LogError(ex, ex.Message);
				ModelState.AddModelError(string.Empty, Core.WebStrings.ERROR_SERVER);
				strRenderView = await _renderView.RenderAsync(ModalConfiguration.ModalPath, model, new ViewDataDictionary(ViewData));
				return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status500InternalServerError });
			}
		}

		/// <summary>
		/// Edits the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		[Authorize(Roles = "SuperAdmin")]
		[HttpGet]
		[Obsolete]
		public async Task<IActionResult> Edit(int id) {
			string strRenderView;
			try {
				InitView(Constants.Action.EDIT);
				if (id > 0) {
					var model = new IndicesViewModel(id).Get();
					if (model != null) {
						strRenderView = await _renderView.RenderAsync(ModalConfiguration.ModalPath, model, new ViewDataDictionary(ViewData));
						return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status200OK });
					} else {
						ModelState.AddModelError(string.Empty, Core.WebStrings.ERROR_GET);
						strRenderView = await _renderView.RenderAsync(ModalConfiguration.ModalPath, model, new ViewDataDictionary(ViewData));
						return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status400BadRequest });
					}
				}

				ModelState.AddModelError(string.Empty, Core.WebStrings.ERROR_BAD_REQUEST);
				strRenderView = await _renderView.RenderAsync(ModalConfiguration.IndexPath, new IndiceModel(), new ViewDataDictionary(ViewData));
				return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status400BadRequest });
			} catch (Exception ex) {
				_logger.LogError(ex, ex.Message);
				ModelState.AddModelError(string.Empty, Core.WebStrings.ERROR_SERVER);
				strRenderView = await _renderView.RenderAsync(ModalConfiguration.IndexPath, new IndiceModel(), new ViewDataDictionary(ViewData));
				return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status500InternalServerError });
			}
		}

		/// <summary>
		/// Edits the specified model.
		/// </summary>
		/// <param name="model">The model.</param>
		/// <returns></returns>
		[Authorize(Roles = "SuperAdmin")]
		[HttpPost]
		[Obsolete]
		public async Task<IActionResult> Edit(IndicesViewModel model) {
			string strRenderView;
			InitView(Constants.Action.EDIT);
			try {
				if (ModelState.IsValid) {
					if (model.Update()) {
						return await Task.FromResult(new JsonResult(StatusCodes.Status200OK));
					} else {
						ModelState.AddModelError(string.Empty, Core.WebStrings.ERROR_MODIFY);
						strRenderView = await _renderView.RenderAsync(ModalConfiguration.ModalPath, model, new ViewDataDictionary(ViewData));
						return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status400BadRequest });
					}
				}

				ModelState.AddModelError(string.Empty, Core.WebStrings.ERROR_BAD_REQUEST);
				strRenderView = await _renderView.RenderAsync(ModalConfiguration.ModalPath, model, new ViewDataDictionary(ViewData));
				return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status400BadRequest });
			} catch (Exception ex) {
				_logger.LogError(ex, ex.Message);
				ModelState.AddModelError(string.Empty, Core.WebStrings.ERROR_SERVER);
				strRenderView = await _renderView.RenderAsync(ModalConfiguration.ModalPath, model, new ViewDataDictionary(ViewData));
				return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status500InternalServerError });
			}
		}

		//[HttpGet]
		//public async Task<IActionResult> Delete(int id) {
		//    string strRenderView;
		//    ViewBag.TitleModal = _sharedTranslations[Strings.ModalTitleDelete];
		//    ViewBag.Action = Strings._DeleteAction;
		//    ViewBag.Controller = _Controller;
		//    ViewBag.PartialNameEdit = Strings.ModalConfiguration.PartialNameEdit;
		//    try {
		//        if (id > 0) {
		//            IndicesModel model = new IndicesModel(_unitOfWork, id).Get();
		//            if (model != null) {
		//                ViewBag.Id = model.Id;
		//                strRenderView = await _renderView.RenderAsync(ModalConfiguration.ModalPathDelete, model, new ViewDataDictionary(ViewData));
		//                return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status200OK });
		//            } else {
		//                ModelState.AddModelError(string.Empty, Strings.ERROR_GET);
		//                strRenderView = await _renderView.RenderAsync(ModalConfiguration.ModalPathError, model, new ViewDataDictionary(ViewData));
		//                return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status400BadRequest });
		//            }
		//        }
		//        ModelState.AddModelError(string.Empty, Strings.ERROR_BAD_REQUEST);
		//        strRenderView = await _renderView.RenderAsync(ModalConfiguration.ModalPathError, new IndicesModel(), new ViewDataDictionary(ViewData));
		//        return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status400BadRequest });
		//    } catch (Exception ex) {
		//        _logger.LogError(ex.Message);
		//        ModelState.AddModelError(string.Empty, Strings.ERROR_SERVER);
		//        strRenderView = await _renderView.RenderAsync(ModalConfiguration.ModalPathError, new IndicesModel(), new ViewDataDictionary(ViewData));
		//        return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status500InternalServerError });
		//    }
		//}

		//[Authorize(Roles = "SuperAdmin")]
		//[HttpPost]
		//public async Task<IActionResult> Delete(IndicesModel model) {
		//    try {
		//        if (model != null) {
		//            if (!new IndicesModel(_unitOfWork, model.Id).Delete()) {
		//                ModelState.AddModelError(string.Empty, "Error al eliminar");
		//            }
		//        } else {
		//            ModelState.AddModelError(string.Empty, _sharedTranslations[Strings.ERROR_BAD_REQUEST]);
		//        }
		//    } catch (Exception ex) {
		//        _logger.LogError(ex.Message);
		//        ModelState.AddModelError(string.Empty, _sharedTranslations[Strings.ERROR_SERVER]);
		//    }
		//    return await Task.FromResult(RedirectToAction(nameof(Index)));
		//}

		/// <summary>
		/// Lists this instance.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[Obsolete]
		public async Task<JsonResult> List() {
			try {
				var model = new IndicesViewModel().List();
				return await Task.FromResult(new JsonResult(model) { StatusCode = StatusCodes.Status200OK });
			} catch (Exception ex) {
				_logger.LogError(ex, ex.Message);
				return await Task.FromResult(new JsonResult(Core.WebStrings.ERROR_SERVER) { StatusCode = StatusCodes.Status500InternalServerError });
			}
		}

		//[Authorize(Roles = "SuperAdmin")]
		//[HttpPost]
		//public async Task<JsonResult> Import(IFormFile file) {
		//    string strRenderView;
		//    try {
		//        if (file != null) {
		//            //Check format file
		//            if (!file.FileName.EndsWith(".csv")) {
		//                ModelState.AddModelError(string.Empty, _sharedTranslations["Selecciona un archivo csv"]);
		//                strRenderView = await _renderView.RenderAsync(ModalConfiguration.IndexPath, new IndicesModel(), new ViewDataDictionary(ViewData));
		//                return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status400BadRequest });
		//            }

		//            //Copy file to import
		//            string pathCopy = FilesHelper.CopyFile(file, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot", file.FileName));

		//            if (pathCopy != null && pathCopy.Length > 0) {
		//                IndicesModel model = new(_unitOfWork);
		//                if (model.Import(pathCopy, 0)) {
		//                    return await Task.FromResult(new JsonResult(StatusCodes.Status200OK));
		//                } else {
		//                    ModelState.AddModelError(string.Empty, Strings.ERROR_IMPORT);
		//                    strRenderView = await _renderView.RenderAsync(ModalConfiguration.IndexPath, new IndicesModel(), new ViewDataDictionary(ViewData));
		//                    return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status400BadRequest });
		//                }
		//            }
		//        }
		//        ModelState.AddModelError(string.Empty, Strings.ERROR_BAD_REQUEST);
		//        strRenderView = await _renderView.RenderAsync(ModalConfiguration.IndexPath, new IndicesModel(), new ViewDataDictionary(ViewData));
		//        return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status400BadRequest });
		//    } catch (Exception ex) {
		//        _logger.LogError(ex.Message);
		//        ModelState.AddModelError(string.Empty, Strings.ERROR_SERVER);
		//        strRenderView = await _renderView.RenderAsync(ModalConfiguration.IndexPath, new List<IndicesModel>(), new ViewDataDictionary(ViewData));
		//        return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status500InternalServerError });
		//    }
		//}

	}
}