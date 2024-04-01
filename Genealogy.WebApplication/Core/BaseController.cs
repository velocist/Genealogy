using Genealogy.Business.Core;
using NuGet.Protocol;

namespace Genealogy.WebApplication.Core {
	public class BaseServiceController<TController, TModel, TEntity> : BaseController<TController, TModel>
		where TController : Controller
		where TModel : class {

		private static IGenealogyServices<TModel, TEntity, AppEntitiesContext> _service { get; set; }

		public BaseServiceController(IStringLocalizer<SharedTranslations> sharedTranslations, IStringLocalizer<ViewsTranslations> viewTranslates, IDateTime date, IViewRender renderView, string controllerName, IGenealogyServices<TModel, TEntity, AppEntitiesContext> service) : base(sharedTranslations, viewTranslates, date, renderView, controllerName) {
			_logger = GetStaticLogger<TController>();
			_service = service;
		}

		public async Task<IActionResult> CreateResponse(ReturnViewTypeId viewType, Exception ex) {
			_logger.LogError(ex.Message);
			return await CreateResponse(viewType, WebStrings.ERROR_SERVER, statusCode: StatusCodes.Status500InternalServerError);
		}

		public async Task<IActionResult> CreateResponse(ReturnViewTypeId viewType, string message, int statusCode) {
			_logger.LogError(message);
			TempData["Error"] = message;
			ModelState.AddModelError(WebStrings.ERROR, message);
			return await ShowRenderView(viewType, ViewData.Model, statusCode);
		}

		public async Task<IActionResult> CreateResponse(ReturnViewTypeId viewType, string message, int statusCode, string url) {
			_logger.LogError(message);
			TempData["Error"] = message;
			ModelState.AddModelError(WebStrings.ERROR, message);
			return await ShowRenderView(viewType, url, statusCode);
		}

		/// <summary>
		/// Indexes this instance.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<IActionResult> Index() {
			GetConfiguration(nameof(Index));
			try {
				if (TempData.TryGetValue("Error", out object error)) {
					ModelState.AddModelError(string.Empty, error.ToString());
					return await ShowRenderView<TModel>(PropertiesView.ViewType, statusCode: StatusCodes.Status400BadRequest);
				}

				return await ShowRenderView<TModel>(PropertiesView.ViewType);
			} catch (Exception ex) {
				_logger.LogError(ex.Message);
				ModelState.AddModelError(string.Empty, WebStrings.ERROR_SERVER);
				return RedirectToAction(nameof(HomeController.Index), "Home");
			}
		}

		/// <summary>
		/// Lists the specified tipo identifier.
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		//[Authorize(Roles = "SuperAdmin")]        
		public async Task<IActionResult> List() {
			try {
				var model = _service.GetAll();
				if (model != null)
					return await ShowRenderView(ReturnViewTypeId.Json, model, statusCode: StatusCodes.Status200OK);

				return await CreateResponse(ReturnViewTypeId.Json, WebStrings.ERROR_GET, StatusCodes.Status400BadRequest);
			} catch (Exception ex) {
				return await CreateResponse(ReturnViewTypeId.Json, ex);
			}
		}

		/// <summary>
		/// Creates this instance.
		/// </summary>
		/// <returns></returns>
		//[Authorize(Roles = "SuperAdmin")]        
		[HttpGet]
		public async Task<IActionResult> Create() {
			GetConfiguration(nameof(Create));
			try {
				return await ShowRenderView(PropertiesView.ViewType, ViewData.Model, statusCode: StatusCodes.Status200OK);
			} catch (Exception ex) {
				return await CreateResponse(PropertiesView.ViewType, ex);
			}
		}

		/// <summary>
		/// Creates the specified model.
		/// </summary>
		/// <param name="model">The model.</param>
		/// <returns></returns>
		//[Authorize(Roles = "SuperAdmin")]        
		[HttpPost]
		public async Task<IActionResult> Create(TModel model) {
			GetConfiguration(nameof(Create), model);
			try {
				if (!ModelState.IsValid)
					return await ShowRenderView(PropertiesView.ViewType, ViewData.Model, statusCode: StatusCodes.Status400BadRequest);

				if (_service.Add(model) != null)
					return await ShowRenderView(PropertiesView.ViewType, ViewData.Model, statusCode: StatusCodes.Status200OK);

				return await CreateResponse(PropertiesView.ViewType, WebStrings.ERROR_MODIFY, StatusCodes.Status400BadRequest);
			} catch (Exception ex) {
				return await CreateResponse(PropertiesView.ViewType, ex);
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
			GetConfiguration(nameof(Edit));
			try {

				if (string.IsNullOrEmpty(id))
					return await CreateResponse(ReturnViewTypeId.Json, WebStrings.ERROR_DATA, statusCode: StatusCodes.Status400BadRequest, Url.ActionLink(nameof(Index)));

				var model = _service.GetById(int.Parse(id));
				if (model != null) {
					ViewData.Model = model;
					return await ShowRenderView(PropertiesView.ViewType, ViewData.Model, statusCode: StatusCodes.Status200OK);
				}

				return await CreateResponse(ReturnViewTypeId.Json, WebStrings.ERROR_GET, statusCode: StatusCodes.Status400BadRequest, Url.ActionLink(nameof(Index)));
			} catch (Exception ex) {
				return await CreateResponse(ReturnViewTypeId.Json, ex);
			}
		}

		/// <summary>
		/// Edits the specified model.
		/// </summary>
		/// <param name="model">The model.</param>
		/// <returns></returns>
		//[Authorize(Roles = "SuperAdmin")]        
		[HttpPost]
		public async Task<IActionResult> Edit(TModel model) {
			GetConfiguration(nameof(Edit), model);
			try {
				if (!ModelState.IsValid)
					return await CreateResponse(PropertiesView.ViewType, WebStrings.ERROR_DATA, statusCode: StatusCodes.Status400BadRequest, Url.ActionLink(nameof(Index)));

				if (_service.Edit(model))
					return await Task.FromResult(new JsonResult(StatusCodes.Status200OK));

				return await CreateResponse(PropertiesView.ViewType, WebStrings.ERROR_MODIFY, statusCode: StatusCodes.Status400BadRequest);
			} catch (Exception ex) {
				return await CreateResponse(PropertiesView.ViewType, ex);
			}
		}

		[HttpGet]
		public async Task<IActionResult> Details(string id) {
			GetConfiguration(nameof(Details));
			try {

				if (string.IsNullOrEmpty(id))
					return await CreateResponse(ReturnViewTypeId.Json, WebStrings.ERROR_DATA, statusCode: StatusCodes.Status400BadRequest, Url.ActionLink(nameof(Index)));

				var model = _service.GetById(int.Parse(id));
				if (model != null) 
					return await ShowRenderView(PropertiesView.ViewType, model, statusCode: StatusCodes.Status200OK);

				return await CreateResponse(ReturnViewTypeId.Json, WebStrings.ERROR_GET, statusCode: StatusCodes.Status400BadRequest, Url.ActionLink(nameof(Index)));
			} catch (Exception ex) {
				return await CreateResponse(ReturnViewTypeId.Json, ex);
			}
		}
	}

	public class BaseController<TController, TModel> : Controller
		where TController : Controller
		where TModel : class {

		public static ILogger _logger { get; set; }

		public readonly IStringLocalizer<SharedTranslations> _sharedTranslations;
		public readonly IStringLocalizer<ViewsTranslations> _viewTranslates;
		public readonly IDateTime _date;
		public readonly IViewRender _renderView;
		public readonly string _controllerName;

		public ViewModel Views { get; set; }

		[ViewData]
		public CustomViewModel PropertiesView { get; set; }

		public BaseController(IStringLocalizer<SharedTranslations> sharedTranslations, IStringLocalizer<ViewsTranslations> viewTranslates, IDateTime date, IViewRender renderView, string controllerName) {
			_logger = GetStaticLogger<TController>();
			_sharedTranslations = sharedTranslations;
			_viewTranslates = viewTranslates;
			_date = date;
			_renderView = renderView;
			_controllerName = controllerName;
		}

		//public void ConfigureModal() {
		//	Modal = new CustomModalModel() {
		//		ControllerName = _controllerName,
		//		//TableAjaxAction = Constants.ListAction,
		//		UploadFile = false,
		//		ViewName = "",
		//		PartialViewName = "",
		//		Title = "",
		//	};

		//	ModalConfiguration = new ModalConfiguration<TModel>("Recursos") {
		//		Title = "Recursos",
		//		TableAjaxAction = "/Recursos/" + Constants.ListAction,
		//		//IndexPath = "~/Views/Recursos/Index.cshtml"
		//		IndexPath = Constants.CommonIndexViewName
		//	};
		//	ModalConfiguration.ControllerName = $"{_controllerName}";

		//	ModalConfiguration.IndexPath = Constants.CommonIndexViewName;

		//	ModalConfiguration.PartialNameScript = $"~/Views/{_controllerName}/_{_controllerName}ScriptsPartial.cshtml";

		//	ModalConfiguration.PartialNameList = $"~/Views/{_controllerName}/_List.cshtml";
		//	ModalConfiguration.PartialNameCreate = $"~/Views/{_controllerName}/_Edit.cshtml";
		//	ModalConfiguration.PartialNameEdit = $"~/Views/{_controllerName}/_Edit.cshtml";
		//	ModalConfiguration.PartialNameDetails = $"~/Views/{_controllerName}/_Edit.cshtml";
		//	ModalConfiguration.PartialNameDelete = $"~/Views/{_controllerName}/_Delete.cshtml";

		//	ModalConfiguration.ModalPath = Constants._CommonModal;
		//	ModalConfiguration.ModalError = Constants._ModalError;
		//	ModalConfiguration.ModalDelete = Constants._ModalDelete;

		//	ModalConfiguration.TitleCreate = Constants.ModalTitleCreate;
		//	ModalConfiguration.TitleEdit = Constants.ModalTitleEdit;
		//	ModalConfiguration.TitleDetails = Constants.ModalTitleDetails;
		//	ModalConfiguration.TitleDelete = Constants.ModalTitleDelete;

		//	ModalConfiguration.TableAjaxAction = Constants.ListAction;
		//	ModalConfiguration.UploadFile = false;
		//}

		///// <summary>
		///// Initializes the view.
		///// </summary>
		///// <param name="action">The action.</param>
		///// <param name="isModal">if set to <c>true</c> [is modal].</param>
		//public void InitView(Constants.Action action, bool isModal = true) {
		//    ViewBag.BreadcumbTitle = _sharedTranslations[ModalConfiguration.Title];
		//    ViewBag.BreadcumbController = _sharedTranslations[ModalConfiguration.Title];
		//    ViewBag.ControllerName = ModalConfiguration.ControllerName;

		//    if (action.Equals(Constants.Action.CREATE)) {
		//        ViewBag.TitleModal = _sharedTranslations[ModalConfiguration.TitleCreate];
		//        ViewBag.PartialName = ModalConfiguration.PartialNameEdit;
		//        if (isModal)
		//            ViewBag.Action = Constants.CreateAction;
		//    } else if (action.Equals(Constants.Action.EDIT)) {
		//        ViewBag.TitleModal = _sharedTranslations[ModalConfiguration.TitleEdit];
		//        ViewBag.PartialName = ModalConfiguration.PartialNameEdit;
		//        if (isModal)
		//            ViewBag.Action = Constants.EditAction;
		//    } else if (action.Equals(Constants.Action.DETAILS)) {
		//        ViewBag.TitleModal = _sharedTranslations[ModalConfiguration.TitleDetails];
		//        ViewBag.PartialName = ModalConfiguration.PartialNameDetails;
		//        if (isModal)
		//            ViewBag.Action = Constants.DetailsAction;
		//    } else if (action.Equals(Constants.Action.DELETE)) {
		//        ViewBag.TitleModal = _sharedTranslations[ModalConfiguration.TitleDelete];
		//        ViewBag.PartialName = ModalConfiguration.PartialNameDelete;
		//        if (isModal)
		//            ViewBag.Action = Constants.DeleteAction;
		//    } else if (action.Equals(Constants.Action.LIST)) {
		//        ViewBag.Title = _sharedTranslations[ModalConfiguration.Title];
		//        ViewBag.PartialName = ModalConfiguration.PartialNameList;
		//        ViewBag.PartialNameScript = ModalConfiguration.PartialNameScript;
		//        ViewBag.TableAjaxAction = ModalConfiguration.TableAjaxAction;
		//        if (User.IsInRole(Constants.Roles.SuperAdmin.ToString()))
		//            ModalConfiguration.UploadFile = true;
		//        else
		//            ModalConfiguration.UploadFile = false;

		//        ViewBag.UploadFile = ModalConfiguration.UploadFile;
		//    }
		//}

		public void GetConfiguration(string action) {
			PropertiesView = Views.CustomViewModels.Find(x => x.ActionName == action && x.ControllerName == _controllerName);
			ViewData.Add("PropertiesView", PropertiesView);
		}

		public void GetConfiguration<TModel>(string action, TModel model) {
			PropertiesView = Views.CustomViewModels.Find(x => x.ActionName == action && x.ControllerName == _controllerName);
			ViewData.Add("PropertiesView", PropertiesView);
			ViewData.Model = model;
		}

		/// <summary>
		/// Renderiza el html del tipo de vista y los argumentos para una respuesta Javascript/JQuery/Ajax.
		/// </summary>
		/// <typeparam name="TView">Modelo de la vista.</typeparam>
		/// <typeparam name="TModel">Modelo de la vista.</typeparam>
		/// <param name="viewType"><see cref="ReturnViewTypeId"/>Tipo de modal/vista que queremos renderizar.</param>
		/// <param name="view"></param>
		/// <param name="model">Modelo de la vista para renderizar. En caso de que el modal/vista contenga un modelo.</param>
		/// <param name="viewName">Nombre de la vista.</param>
		/// <param name="args">Argumentos para devolver en el resultado.</param>
		/// <returns></returns>
		public async Task<ActionResult> ShowRenderView<TModel>(ReturnViewTypeId viewType, /*IBasePropertiesView view,*/ TModel model = default,/* ViewDataDictionary viewData = null,*/ object args = null, int statusCode = 200) where TModel : class {
			try {
				if (ViewData.Model == null)
					ViewData.Model = model;

				switch (viewType) {
					case ReturnViewTypeId.InformationModal:
					case ReturnViewTypeId.SucessModal:
					case ReturnViewTypeId.WarningModal:
					case ReturnViewTypeId.ErrorModal:
						var simpleModalString = await _renderView.RenderAsync(PropertiesView.ViewName, ViewData.Model, new ViewDataDictionary(ViewData));
						if (statusCode != 0) {
							return await Task.FromResult(new JsonResult(simpleModalString) { StatusCode = statusCode });
						} else {
							return await Task.FromResult(Json(new { modal = simpleModalString, args }));
						}

					case ReturnViewTypeId.CustomModal:
						var customModalString = await _renderView.RenderAsync(PropertiesView.ViewPath, ViewData.Model, new ViewDataDictionary(ViewData));
						if (statusCode != 0) {
							return await Task.FromResult(new JsonResult(customModalString) { StatusCode = statusCode });
						} else {
							return await Task.FromResult(Json(new { modal = customModalString }));
						}

					case ReturnViewTypeId.StringView:
						var viewString = await _renderView.RenderAsync(PropertiesView.ViewPath, ViewData.Model, new ViewDataDictionary(ViewData));
						if (statusCode != 0) {
							return await Task.FromResult(new JsonResult(viewString) { StatusCode = statusCode });
						} else {
							return await Task.FromResult(Json(new { view = viewString, args }));
						}

					case ReturnViewTypeId.StringPartialView:
						var partialViewString = string.Empty;
						partialViewString = await _renderView.RenderAsync(PropertiesView.PartialViewPath, ViewData.Model, new ViewDataDictionary(ViewData));
						return await Task.FromResult(new JsonResult(partialViewString) { StatusCode = statusCode });

					case ReturnViewTypeId.View:
						ViewResult view = null;
						if (ViewData.Model != null)
							view = View(PropertiesView.ViewPath, ViewData.Model);
						else
							view = View(PropertiesView.ViewPath);

						view.ViewData = ViewData;
						view.TempData = TempData;
						return await Task.FromResult(view);

					case ReturnViewTypeId.PartialView:
						PartialViewResult partial = null;
						if (ViewData.Model != null)
							partial = PartialView(PropertiesView.PartialViewPath, ViewData.Model);
						else
							partial = PartialView(PropertiesView.PartialViewPath);

						partial.ViewData = ViewData;
						partial.TempData = TempData;
						return await Task.FromResult(partial);

					case ReturnViewTypeId.Alert:
						return await Task.FromResult(PartialView("~/Views/Shared/_AlertError.cshtml", ViewData.Model));

					case ReturnViewTypeId.Json:
						//if (ViewData.Model != null)
						return await Task.FromResult(new JsonResult(ViewData.Model) { StatusCode = statusCode });
					//else
					//	return await Task.FromResult(new JsonResult() { StatusCode = statusCode });
					default:
						_logger.LogError("ReturnViewType sin definir.");
						return null;
				}
			} catch (Exception ex) {
				//Logger<TModel>.Write(ex);
				throw new Exception(ex.Message, ex);
			}
		}

	}

	public enum ReturnViewTypeId {
		None = 0,
		InformationModal = 1,
		SucessModal = 2,
		WarningModal = 3,
		ErrorModal = 4,
		CustomModal = 5,
		StringView = 6,
		StringPartialView = 7,
		View = 8,
		PartialView = 9,
		Alert = 10,
		Json = 11,
	}
}
