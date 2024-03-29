using Genealogy.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Genealogy.WebApplication.Controllers {

    /// <summary>
    /// Resources controller
    /// </summary>
    /// <seealso cref="Controller" />
    public class RecursosController : BaseController<RecursosController, RecursoModel> {

        private static IRecursoService<RecursoModel, Recurso, AppEntitiesContext> _service;

        /// <summary>
        /// Constructor of the controller
        /// </summary>
        /// <param name="sharedTranslations">Shared Translations</param>
        /// <param name="viewTranslates">View translations</param>
        /// <param name="date">Datetime</param>
        /// <param name="renderView">Render view</param>
        /// <param name="baseService"></param>
        public RecursosController(IStringLocalizer<SharedTranslations> sharedTranslations, IStringLocalizer<ViewsTranslations> viewTranslates, IDateTime date, IViewRender renderView, RecursoService baseService)
            : base(sharedTranslations, viewTranslates, date, renderView, "Recursos") {
            _service = baseService;
            var json = System.IO.File.ReadAllText("./Views/Recursos/_ListConfigure.json");
            Views = velocist.Services.Json.JsonAppHelper<ViewModel>.ConvertJsonToObject(json, false);
        }

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index() {
            try {
                ViewData.Model = _service.GetAll(x => x.Tipo == 1).ToList();
                PropertiesView = Views.CustomViewModels.Find(x => x.ViewType == ReturnViewTypeId.View && x.ActionName == nameof(Index) && x.ControllerName == _controllerName);
                return await ShowRenderView(ReturnViewTypeId.View, PropertiesView, ViewData.Model);
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                ModelState.AddModelError(string.Empty, WebStrings.ERROR_SERVER);
                return await Task.FromResult(View(nameof(HomeController.Index)));
            }
        }

		/// <summary>
		/// Lists the specified tipo identifier.
		/// </summary>
		/// <param name="tipo_id">The tipo identifier.</param>
		/// <returns></returns>
		[HttpPost]
		//[Authorize(Roles = "SuperAdmin")]        
		public async Task<IActionResult> List(int tipo_id) {
			try {
				var model = _service.GetAll(x => x.Tipo == tipo_id);
				return await Task.FromResult(new JsonResult(model) { StatusCode = StatusCodes.Status200OK });
			} catch (Exception ex) {
				_logger.LogError(ex.Message);
				return await Task.FromResult(new JsonResult(WebStrings.ERROR_SERVER) { StatusCode = StatusCodes.Status500InternalServerError });
			}
		}

		/// <summary>
		/// Creates this instance.
		/// </summary>
		/// <returns></returns>
		//[Authorize(Roles = "SuperAdmin")]        
		[HttpGet]
        public async Task<IActionResult> Create() {
            try {
                ViewData.Model = new RecursoModel();
                PropertiesView = Views.CustomViewModels.Find(x => x.ViewType == ReturnViewTypeId.CustomModal && x.ActionName == nameof(Create) && x.ControllerName == _controllerName);
                return await ShowRenderView(ReturnViewTypeId.View, PropertiesView, ViewData.Model);
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
        public async Task<IActionResult> Create(RecursoModel model) {
            ViewData.Model = model;
            PropertiesView = Views.CustomViewModels.Find(x => x.ViewType == ReturnViewTypeId.CustomModal && x.ActionName == nameof(Create) && x.ControllerName == _controllerName);
            try {
                if (ModelState.IsValid)
                    if (_service.Add(model) != null)
                        return await Task.FromResult(new JsonResult(StatusCodes.Status200OK));
                    else {
                        ModelState.AddModelError(string.Empty, WebStrings.ERROR_MODIFY);
                        return await ShowRenderView(ReturnViewTypeId.View, PropertiesView, model, new ViewDataDictionary(ViewData), statusCode: StatusCodes.Status400BadRequest);
                    }

                ModelState.AddModelError(string.Empty, WebStrings.ERROR_BAD_REQUEST);
                return await ShowRenderView(ReturnViewTypeId.View, PropertiesView, model, new ViewDataDictionary(ViewData), statusCode: StatusCodes.Status400BadRequest);
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                ModelState.AddModelError(string.Empty, WebStrings.ERROR_SERVER);
                return await ShowRenderView(ReturnViewTypeId.View, PropertiesView, model, new ViewDataDictionary(ViewData), statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        //[Authorize(Roles = "SuperAdmin")]        
        [HttpGet]
        public async Task<IActionResult> Edit(string id) {
            PropertiesView = Views.CustomViewModels.Find(x => x.ViewType == ReturnViewTypeId.CustomModal && x.ActionName == nameof(Edit) && x.ControllerName == _controllerName);
            try {

                if (id == null || id.Length > 0) {
                    ModelState.AddModelError(string.Empty, WebStrings.ERROR_BAD_REQUEST);
                    return await ShowRenderView(ReturnViewTypeId.View, PropertiesView, new RecursoModel(), new ViewDataDictionary(ViewData), statusCode: StatusCodes.Status400BadRequest);
                }

                var model = _service.GetById(int.Parse(id));
                if (model == null) {
                    ModelState.AddModelError(string.Empty, WebStrings.ERROR_GET);
                    return await ShowRenderView(ReturnViewTypeId.View, PropertiesView, new RecursoModel(), new ViewDataDictionary(ViewData), statusCode: StatusCodes.Status400BadRequest);
                }

                ViewData.Model = model;
                return await ShowRenderView(ReturnViewTypeId.View, PropertiesView, model, new ViewDataDictionary(ViewData), statusCode: StatusCodes.Status200OK);
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                ModelState.AddModelError(string.Empty, WebStrings.ERROR_SERVER);
                return await ShowRenderView(ReturnViewTypeId.View, PropertiesView, new RecursoModel(), new ViewDataDictionary(ViewData), statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Edits the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        //[Authorize(Roles = "SuperAdmin")]        
        [HttpPost]
        public async Task<IActionResult> Edit(RecursoModel model) {
            string strRenderView;
            ViewData.Model = model;
            PropertiesView = Views.CustomViewModels.Find(x => x.ViewType == ReturnViewTypeId.CustomModal && x.ActionName == nameof(Edit) && x.ControllerName == _controllerName);
            try {
                if (ModelState.IsValid)
                    if (_service.Edit(model))
                        return await Task.FromResult(new JsonResult(StatusCodes.Status200OK));
                    else {
                        ModelState.AddModelError(string.Empty, WebStrings.ERROR_MODIFY);
                        return await ShowRenderView(ReturnViewTypeId.View, PropertiesView, new RecursoModel(), new ViewDataDictionary(ViewData), statusCode: StatusCodes.Status400BadRequest);
                    }

                ModelState.AddModelError(string.Empty, WebStrings.ERROR_BAD_REQUEST);
                return await ShowRenderView(ReturnViewTypeId.View, PropertiesView, model, new ViewDataDictionary(ViewData), statusCode: StatusCodes.Status400BadRequest);
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                ModelState.AddModelError(string.Empty, WebStrings.ERROR_SERVER);
                return await ShowRenderView(ReturnViewTypeId.View, PropertiesView, model, new ViewDataDictionary(ViewData), statusCode: StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id) {
            ViewData.Model = new RecursoModel();
            PropertiesView = Views.CustomViewModels.Find(x => x.ViewType == ReturnViewTypeId.CustomModal && x.ActionName == nameof(Details) && x.ControllerName == _controllerName);
            try {

                if (id == null || id.Length < 0) {
                    ModelState.AddModelError(string.Empty, WebStrings.ERROR_BAD_REQUEST);
                    return await ShowRenderView(ReturnViewTypeId.View, PropertiesView, ViewData.Model, new ViewDataDictionary(ViewData), statusCode: StatusCodes.Status400BadRequest);
                }

                var model = _service.GetById(int.Parse(id));
                if (model == null) {
                    ModelState.AddModelError(string.Empty, WebStrings.ERROR_GET);
                    return await ShowRenderView(ReturnViewTypeId.View, PropertiesView, ViewData.Model, new ViewDataDictionary(ViewData), statusCode: StatusCodes.Status400BadRequest);
                }

                return await ShowRenderView(ReturnViewTypeId.View, PropertiesView, model, new ViewDataDictionary(ViewData), statusCode: StatusCodes.Status200OK);
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                ModelState.AddModelError(string.Empty, WebStrings.ERROR_SERVER);
                return await ShowRenderView(ReturnViewTypeId.View, PropertiesView, ViewData.Model, new ViewDataDictionary(ViewData), statusCode: StatusCodes.Status500InternalServerError);
            }
        }

       


        //public async Task<ActionResult> EjemploModales(int tipo) {
        //    try {
        //        var model = new RecursoModel() {
        //            Id = 1,
        //            LastChange = DateTime.Now,
        //        };
        //        var modal = new CustomModalModel() {
        //            Title = "Home",
        //            SubTitle = "Panel de control",
        //            ControllerName = "Home",
        //            ActionName = "Index",
        //            //Model = model,
        //            ViewName = "Index",
        //            ViewPath = "~/View/Shared/Common/Index.cshtml",
        //            PartialViewName = "_Dashboard",
        //            PartialViewPath = "~/Views/Home/_Dashboard.cshtml",
        //            IsTableView = true,
        //            UploadFile = true,
        //            TableView = new PropertiesTableView() {
        //                TableAjaxAction = "_RecursosScriptsPartial.cshtml",
        //                HasOrdering = true,
        //                HasPagination = true,
        //                HasSearch = true,
        //            }
        //        };

        //        switch (tipo) {
        //            //case (int)ReturnViewTypeId.ConfirmModal: //Devuelve un modal de información renderizado.
        //            //var config = new ConfirmModalConfiguration() {
        //            //    //Setear parametros para los botones de Accion
        //            //    AccionBotonOK = $"URL?con=parametros",
        //            //    AccionBotonKO = $"URL?con=parametros"
        //            //};
        //            //return await ShowRenderView(ReturnViewTypeId.ConfirmModal, new GenericModalModel("modalConfirmacion", message: "Esto es un modal de confirmación.", viewType: ReturnViewTypeId.ConfirmModal, config));

        //            case (int)ReturnViewTypeId.InformationModal: //Devuelve un modal de información renderizado.
        //            return await ShowRenderView(ReturnViewTypeId.InformationModal, modal/*, model, new CustomModal<BaseModel>("modalInformacion", message: "Esto es un modal de información.", viewType: ReturnViewTypeId.InformationModal)*/);

        //            case (int)ReturnViewTypeId.SucessModal: //Devuelve un modal de éxito renderizado.
        //            return await ShowRenderView(ReturnViewTypeId.SucessModal, modal/*, model, new CustomModal<BaseModel>("modalSuccess", message: "Esto es un modal de éxito.", viewType: ReturnViewTypeId.SucessModal)*/);

        //            case (int)ReturnViewTypeId.WarningModal: //Devuelve un modal de advertencia renderizado.
        //            return await ShowRenderView(ReturnViewTypeId.WarningModal, modal/*, model, new CustomModal<BaseModel>("modalWarning", message: "Esto es un modal de advertencia.", viewType: ReturnViewTypeId.WarningModal)*/);

        //            case (int)ReturnViewTypeId.ErrorModal: //Devuelve un modal de error renderizado.
        //            return await ShowRenderView(ReturnViewTypeId.ErrorModal, modal/*, model, new CustomModal<BaseModel>("modalError", message: "Esto es un modal de error.", viewType: ReturnViewTypeId.ErrorModal)*/);

        //            case (int)ReturnViewTypeId.CustomModal: //Devuelve un modal personalizado renderizado.
        //            return await ShowRenderView(ReturnViewTypeId.CustomModal, modal, /*model, */"modalPersonalizado");

        //            case (int)ReturnViewTypeId.StringView: //Devuelve una vista renderizada
        //            return await ShowRenderView(ReturnViewTypeId.StringView, modal, /*model,*/ "Vista");

        //            case (int)ReturnViewTypeId.StringPartialView:
        //            return await ShowRenderView(ReturnViewTypeId.StringPartialView, modal, /*model,*/ "_VistaParcial");

        //            case (int)ReturnViewTypeId.View:
        //            return await ShowRenderView(ReturnViewTypeId.View, modal, /*model,*/ "_VistaParcial");

        //            default:
        //            return await Task.FromResult(Json(new { reload = true }));
        //        };
        //    } catch (Exception ex) {
        //        return null;
        //        //return await ShowRenderView(ReturnViewTypeId.ErrorModal, new CustomModal("modalError", message: "Error de servidor", viewType: ReturnViewTypeId.ErrorModal));
        //    }
        //}

        //[Authorize(Roles = "SuperAdmin")]
        //[HttpPost]
        //public async Task<JsonResult> Export(IFormFile file) {
        //    string strRenderView;
        //    try {
        //        if (file != null) {
        //            RecursoService model = new();
        //            //Check format file
        //            if (!file.FileName.EndsWith(".csv")) {
        //                ModelState.AddModelError(string.Empty, _sharedTranslations["Selecciona un archivo csv"]);
        //                strRenderView = await _renderView.RenderAsync(ModalConfiguration.IndexPath, new RecursoService(), new ViewDataDictionary(ViewData));
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
        //                    strRenderView = await _renderView.RenderAsync(ModalConfiguration.IndexPath, new Model(), new ViewDataDictionary(ViewData));
        //                    return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status400BadRequest });
        //                }
        //            }
        //        }
        //        ModelState.AddModelError(string.Empty, Strings.ERROR_BAD_REQUEST);
        //        strRenderView = await _renderView.RenderAsync(ModalConfiguration.IndexPath, new Model(), new ViewDataDictionary(ViewData));
        //        return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status400BadRequest });
        //    } catch (Exception ex) {
        //        _logger.LogError(ex.Message);
        //        ModelState.AddModelError(string.Empty, Strings.ERROR_SERVER);
        //        strRenderView = await _renderView.RenderAsync(ModalConfiguration.IndexPath, new GetAll<Model>(), new ViewDataDictionary(ViewData));
        //        return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status500InternalServerError });
        //    }
        //}

    }
}
