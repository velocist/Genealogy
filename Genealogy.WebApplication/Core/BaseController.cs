using Genealogy.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using velocist.Services.Core;
using velocist.Services.Core.Interfaces;

namespace Genealogy.WebApplication.Core {



    public class BaseController<TController, TModel> : Controller
        where TController : Controller
        where TModel : class {
        public static ILogger _logger { get; set; }

        public readonly IStringLocalizer<SharedTranslations> _sharedTranslations;
        public readonly IStringLocalizer<ViewsTranslations> _viewTranslates;
        public readonly IDateTime _date;
        public readonly IViewRender _renderView;
        public readonly string _controllerName;

        /// <summary>
        /// Gets the modal configuration.
        /// </summary>
        /// <value>
        /// The modal configuration.
        /// </value>
        public ModalConfiguration<TModel> ModalConfiguration { get; set; }

        //[ViewData]
        public ViewModel Views { get; set; }
        //public ViewModel<TModel> View { get; set; }

        [ViewData]
        public CustomViewModel PropertiesView { get; set; }

        //[ViewData]
        //public CustomModalModel Modal { get; set; }

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
        public async Task<ActionResult> ShowRenderView<TModel>(ReturnViewTypeId viewType, IBasePropertiesView view, TModel model = default, ViewDataDictionary viewData = null, object args = null, int statusCode = 0) {
            try {
                switch (viewType) {
                    case ReturnViewTypeId.InformationModal:
                    case ReturnViewTypeId.SucessModal:
                    case ReturnViewTypeId.WarningModal:
                    case ReturnViewTypeId.ErrorModal:
                    //var simpleModalModel = view.Model as CustomModalModel<TModel>;
                    var simpleModalString = await _renderView.RenderAsync(view.ViewName, ViewData.Model, new ViewDataDictionary(viewData));
                    if (statusCode != 0) {
                        return await Task.FromResult(new JsonResult(simpleModalString) { StatusCode = statusCode });
                    } else {
                        return await Task.FromResult(Json(new { modal = simpleModalString, args }));
                    }
                    case ReturnViewTypeId.CustomModal:
                    //var modal = view.Model as CustomModalModel<TModel>;
                    var customModalString = await _renderView.RenderAsync(view.ViewPath, ViewData.Model, new ViewDataDictionary(viewData));
                    if (statusCode != 0) {
                        return await Task.FromResult(new JsonResult(customModalString) { StatusCode = statusCode });
                    } else {
                        return await Task.FromResult(Json(new { modal = customModalString }));
                    }
                    case ReturnViewTypeId.StringView:
                    //var stringView = view.Model as CustomModalModel<TModel>;
                    var viewString = await _renderView.RenderAsync(view.ViewPath, ViewData.Model, new ViewDataDictionary(viewData));
                    if (statusCode != 0) {
                        return await Task.FromResult(new JsonResult(viewString) { StatusCode = statusCode });
                    } else {
                        return await Task.FromResult(Json(new { view = viewString, args }));
                    }
                    case ReturnViewTypeId.StringPartialView:
                    //var stringPartialView = view.Model as CustomModalModel<TModel>;
                    var partialViewString = await _renderView.RenderAsync(view.ViewPath, ViewData.Model, new ViewDataDictionary(viewData));
                    if (statusCode != 0) {
                        return await Task.FromResult(new JsonResult(partialViewString) { StatusCode = statusCode });
                    } else {
                        return await Task.FromResult(Json(new { view = partialViewString, args }));
                    }
                    case ReturnViewTypeId.View:
                    //var viewModel = view.Model as CustomViewModel<TModel>;
                    if (model != null)
                        return await Task.FromResult(View(view.ViewPath, ViewData.Model));
                    else
                        return await Task.FromResult(View(view.ViewPath));
                    case ReturnViewTypeId.PartialView:
                    return await Task.FromResult(PartialView(view.PartialViewPath, ViewData.Model));
                    default:
                    //Logger<BaseController>.Write("ReturnViewType sin definir.");
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

    }
}
