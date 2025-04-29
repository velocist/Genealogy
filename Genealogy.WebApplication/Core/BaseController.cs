using System.Net.Http;
using System.Net.Http.Json;
using Genealogy.Business.Core;

namespace Genealogy.WebApplication.Core {
	public class BaseServiceController<TController, TModel, TEntity> : BaseController<TController, TModel>
		where TController : Controller
		where TModel : GenealogyBaseModel, new() {

		protected HttpClient GenealogyApiClient = new() {
			BaseAddress = new Uri("https://localhost:7040/api/"),
		};

		public string GenealogyApiEndpoint { get; set; }

		public BaseServiceController(IStringLocalizer<SharedTranslations> sharedTranslations, IStringLocalizer<ViewsTranslations> viewTranslates, IDateTime date, IViewRender renderView, string controllerName/*, IGenealogyServices<TModel, TEntity, AppEntitiesContext> service*/) : base(sharedTranslations, viewTranslates, date, renderView, controllerName) {
			_logger = GetStaticLogger<TController>();
			//_service = service;
			GenealogyApiEndpoint = GenealogyApiClient.BaseAddress + ControllerName;
		}

		protected async Task<IActionResult> CreateResponse(ReturnViewTypeId viewType, Exception ex) {
			_logger.LogError(ex.Message);
			return await CreateResponse(viewType, WebStrings.ERROR_SERVER, statusCode: StatusCodes.Status500InternalServerError);
		}

		protected async Task<IActionResult> CreateResponse(ReturnViewTypeId viewType, string message, int statusCode) {
			_logger.LogError(message);
			TempData["Error"] = message;
			ModelState.AddModelError(WebStrings.ERROR, message);
			return await ShowRenderView(viewType, ViewData.Model, statusCode);
		}

		protected async Task<IActionResult> CreateResponse(ReturnViewTypeId viewType, string message, int statusCode, string url) {
			_logger.LogError(message);
			TempData["Error"] = message;
			ModelState.AddModelError(WebStrings.ERROR, message);
			return await ShowRenderView(viewType, url, statusCode);
		}

		protected async Task<IActionResult> CreateResponse(ReturnViewTypeId viewType, HttpResponseMessage message) {
			LogResponse(message);
			TempData["Error"] = message.ReasonPhrase;
			ModelState.AddModelError(WebStrings.ERROR, message.ReasonPhrase);
			return await ShowRenderView(viewType, ViewData.Model, message.StatusCode);
		}

		protected void LogResponse(HttpResponseMessage messageResponse) {
			_logger.LogDebug($"IsSuccessStatusCode: {messageResponse.IsSuccessStatusCode} " +
				$"StatusCode: {messageResponse.StatusCode} " +
				$"ReasonPhrase: {messageResponse.ReasonPhrase} " +
				$"RequestMessage: {messageResponse.RequestMessage}");
		}

		protected IAsyncEnumerable<TModel> GetListResult(HttpResponseMessage messageResponse) {
			LogResponse(messageResponse);
			var model = messageResponse.Content.ReadFromJsonAsAsyncEnumerable<TModel>();
			return model;
		}

		protected Task<TResponse> GetObjectResult<TResponse>(HttpResponseMessage messageResponse) {
			LogResponse(messageResponse);
			var model = messageResponse.Content.ReadFromJsonAsync<TResponse>();
			return model;
		}

		/// <summary>
		/// Indexes this instance.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<IActionResult> Index() {
			//Configuracmos la vista
			GetConfiguration(nameof(Index));
			try {
				//Devolvemos la vista de error si lo hay
				if (TempData.TryGetValue("Error", out var error)) {
					ModelState.AddModelError(string.Empty, error.ToString());
					return await ShowRenderView<TModel>(PropertiesView.ViewType, statusCode: StatusCodes.Status400BadRequest);
				}

				//Devolvemos la vista
				return await ShowRenderView<TModel>(PropertiesView.ViewType);
			} catch (Exception ex) {
				Trace.WriteLine(ex);
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
				//Hecemos la llamada a la api
				var result = await GenealogyApiClient.GetAsync(GenealogyApiEndpoint);

				//Obtenemos los resultados
				var model = GetListResult(result);

				//Devolvemos la respuesta
				if (model != null)
					return await ShowRenderView(ReturnViewTypeId.Json, model, statusCode: StatusCodes.Status200OK);

				//Devolvemos error 
				return await CreateResponse(ReturnViewTypeId.Json, WebStrings.ERROR_GET, StatusCodes.Status400BadRequest);
			} catch (Exception ex) {
				Trace.WriteLine(ex);
				_logger.LogError(ex.Message);
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
			//Configuracmos la vista
			GetConfiguration(nameof(Create));
			try {
				//Devolvemos la vista
				return await ShowRenderView(PropertiesView.ViewType, new TModel(), statusCode: StatusCodes.Status200OK);
			} catch (Exception ex) {
				Trace.WriteLine(ex);
				_logger.LogError(ex.Message);
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
				//Comprobamos los datos de entrada
				if (!ModelState.IsValid)
					return await CreateResponse(PropertiesView.ViewType, WebStrings.ERROR_MODIFY, statusCode: StatusCodes.Status400BadRequest);
				//return await ShowRenderView(PropertiesView.ViewType, ViewData.Model, statusCode: StatusCodes.Status400BadRequest);

				//Hecemos la llamada a la api
				var response = await GenealogyApiClient.PostAsJsonAsync(GenealogyApiEndpoint, model);

				//Devolvemos error
				if (!response.IsSuccessStatusCode)
					return await CreateResponse(PropertiesView.ViewType, response);

				//Obtenemos los resultados
				var result = GetObjectResult<bool>(response);

				//Devolvemos la respuesta
				if (result.Result)
					return await ShowRenderView(PropertiesView.ViewType, ViewData.Model, statusCode: StatusCodes.Status200OK);

				//Devolvemos error 
				return await CreateResponse(PropertiesView.ViewType, WebStrings.ERROR_MODIFY, StatusCodes.Status400BadRequest);
			} catch (Exception ex) {
				Trace.WriteLine(ex);
				_logger.LogError(ex.Message);
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
				//Comprobamos los datos de entrada
				if (string.IsNullOrEmpty(id))
					return await CreateResponse(ReturnViewTypeId.Json, WebStrings.ERROR_DATA, statusCode: StatusCodes.Status400BadRequest, Url.ActionLink(nameof(Index)));

				//Hecemos la llamada a la api
				var model = await GenealogyApiClient.GetFromJsonAsync<TModel>($"{GenealogyApiEndpoint}/{id}");

				//Devolvemos la respuesta
				if (model != null) {
					ViewData.Model = model;
					return await ShowRenderView(PropertiesView.ViewType, ViewData.Model, statusCode: StatusCodes.Status200OK);
				}

				//Devolvemos error 
				return await CreateResponse(ReturnViewTypeId.Json, WebStrings.ERROR_GET, statusCode: StatusCodes.Status400BadRequest, Url.ActionLink(nameof(Index)));
			} catch (Exception ex) {
				Trace.WriteLine(ex);
				_logger.LogError(ex.Message);
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
				//Comprobamos los datos de entrada
				if (!ModelState.IsValid)
					return await CreateResponse(PropertiesView.ViewType, WebStrings.ERROR_DATA, statusCode: StatusCodes.Status400BadRequest, Url.ActionLink(nameof(Index)));

				//Hecemos la llamada a la api
				var response = await GenealogyApiClient.PutAsJsonAsync($"{GenealogyApiEndpoint}/{model.Id}", model);

				//Obtenemos los resultados
				var result = await GetObjectResult<bool>(response);

				//Devolvemos la respuesta
				if (result)
					return await Task.FromResult(new JsonResult(StatusCodes.Status200OK));

				//Devolvemos error 
				return await CreateResponse(PropertiesView.ViewType, WebStrings.ERROR_MODIFY, statusCode: StatusCodes.Status400BadRequest);
			} catch (Exception ex) {
				Trace.WriteLine(ex);
				_logger.LogError(ex.Message);
				return await CreateResponse(PropertiesView.ViewType, ex);
			}
		}

		[HttpGet]
		public async Task<IActionResult> Details(string id) {
			GetConfiguration(nameof(Details));
			try {
				//Comprobamos los datos de entrada
				if (string.IsNullOrEmpty(id))
					return await CreateResponse(ReturnViewTypeId.Json, WebStrings.ERROR_DATA, statusCode: StatusCodes.Status400BadRequest, Url.ActionLink(nameof(Index)));

				//Hecemos la llamada a la api
				var model = await GenealogyApiClient.GetFromJsonAsync<TModel>($"{GenealogyApiEndpoint}/{id}");

				//Devolvemos la respuesta
				if (model != null)
					return await ShowRenderView(PropertiesView.ViewType, model, statusCode: StatusCodes.Status200OK);

				//Devolvemos error 
				return await CreateResponse(ReturnViewTypeId.Json, WebStrings.ERROR_GET, statusCode: StatusCodes.Status400BadRequest, Url.ActionLink(nameof(Index)));
			} catch (Exception ex) {
				Trace.WriteLine(ex);
				_logger.LogError(ex.Message);
				return await CreateResponse(ReturnViewTypeId.Json, ex);
			}
		}

		////[Authorize(Roles = "SuperAdmin")]
		//[HttpPost]
		//public async Task<IActionResult> Export(IFormFile file) {
		//	try {
		//		if (file == null)
		//			return await CreateResponse(ReturnViewTypeId.Json, WebStrings.ERROR_IMPORT, statusCode: StatusCodes.Status400BadRequest);

		//		TModel model = new();

		//		//Check format file
		//		if (!file.FileName.EndsWith(".csv"))
		//			return await CreateResponse(ReturnViewTypeId.Json, _sharedTranslations["Selecciona un archivo csv"], statusCode: StatusCodes.Status400BadRequest);

		//		//Copy file to import
		//		var pathCopy = FilesHelper.CopyFile(file, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot", file.FileName));

		//		if (string.IsNullOrEmpty(pathCopy) == null)
		//			return await CreateResponse(ReturnViewTypeId.Json, WebStrings.ERROR_IMPORT, statusCode: StatusCodes.Status400BadRequest);

		//		model.ExportModel.FileName = Path.GetFileName(file.FileName);

		//		//Do import
		//		var result = await GenealogyApiClient.PostAsJsonAsync(GenealogyApiEndpoint + $"/Export", model.ExportModel);

		//		var model = result.Content.ReadFromJsonAsAsyncEnumerable<TModel>();
		//		if (model.Export(pathCopy, 0))
		//			return await Task.FromResult(new JsonResult(StatusCodes.Status200OK));
		//		else
		//			return await CreateResponse(ReturnViewTypeId.Json, WebStrings.ERROR_IMPORT, statusCode: StatusCodes.Status400BadRequest);

		//	} catch (Exception ex) {
		//		_logger.LogError(ex.Message);
		//		return await CreateResponse(ReturnViewTypeId.Json, ex);
		//	}
		//}
	}

	public class BaseController<TController, TModel> : Controller
		where TController : Controller
		where TModel : class {

		public static ILogger _logger { get; set; }

		public readonly IStringLocalizer<SharedTranslations> _sharedTranslations;
		public readonly IStringLocalizer<ViewsTranslations> _viewTranslates;
		public readonly IDateTime _date;
		public readonly IViewRender _renderView;
		private readonly string _controllerName;

		public ViewModel Views { get; set; }

		[ViewData]
		public CustomViewModel PropertiesView { get; set; }

		public string ControllerName => _controllerName;

		public BaseController(IStringLocalizer<SharedTranslations> sharedTranslations, IStringLocalizer<ViewsTranslations> viewTranslates, IDateTime date, IViewRender renderView, string controllerName) {
			_logger = GetStaticLogger<TController>();
			_sharedTranslations = sharedTranslations;
			_viewTranslates = viewTranslates;
			_date = date;
			_renderView = renderView;
			_controllerName = controllerName;
		}

		public void GetConfiguration(string action) {
			PropertiesView = Views.CustomViewModels.Find(x => x.ActionName == action && x.ControllerName == ControllerName);
			ViewData.Add("PropertiesView", PropertiesView);
		}

		public void GetConfiguration(string action, TModel model) {
			GetConfiguration(action);
			ViewData.Model = model;
		}

		/// <summary>
		/// Renderiza el html del tipo de vista y los argumentos para una respuesta Javascript/JQuery/Ajax.
		/// </summary>
		/// <typeparam name="TModel">Modelo de la vista.</typeparam>
		/// <param name="viewType"><see cref="ReturnViewTypeId"/>Tipo de modal/vista que queremos renderizar.</param>
		/// <param name="model">Modelo de la vista para renderizar. En caso de que el modal/vista contenga un modelo.</param>
		/// <param name="args">Argumentos para devolver en el resultado.</param>
		/// <param name="statusCode"></param>
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
					if (statusCode != 0)
						return await Task.FromResult(new JsonResult(simpleModalString) { StatusCode = statusCode });
					else
						return await Task.FromResult(Json(new { modal = simpleModalString, args }));


					case ReturnViewTypeId.CustomModal:
					var customModalString = await _renderView.RenderAsync(PropertiesView.ViewPath, ViewData.Model, new ViewDataDictionary(ViewData));
					if (statusCode != 0)
						return await Task.FromResult(new JsonResult(customModalString) { StatusCode = statusCode });
					else
						return await Task.FromResult(Json(new { modal = customModalString }));


					case ReturnViewTypeId.StringView:
					var viewString = await _renderView.RenderAsync(PropertiesView.ViewPath, ViewData.Model, new ViewDataDictionary(ViewData));
					if (statusCode != 0)
						return await Task.FromResult(new JsonResult(viewString) { StatusCode = statusCode });
					else
						return await Task.FromResult(Json(new { view = viewString, args }));


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
				Trace.WriteLine(ex);
				throw;
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
