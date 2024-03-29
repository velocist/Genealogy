

namespace Genealogy.Controllers {
    public class FileViewerController : Controller {

        #region DEPENDENCE INJECTIONS
        public static ILogger _logger { get; set; }
        private readonly IStringLocalizer<SharedTranslations> _sharedTranslations;
        private readonly IStringLocalizer<ViewsTranslations> _viewTranslates;
        private readonly IDateTime _date;
        private readonly IViewRender _renderView;
        #endregion

        public ModalConfiguration<FileViewerModel> ModalConfiguration { get; }

        /// <summary>
        /// Constructor of the controller
        /// </summary>
        /// <param name="unitOfWork">Unit of work</param>
        /// <param name="sharedTranslations">Shared Translations</param>
        /// <param name="viewTranslates">View translations</param>
        /// <param name="date">Datetime</param>
        /// <param name="renderView">Render view</param>
        public FileViewerController( IStringLocalizer<SharedTranslations> sharedTranslations, IStringLocalizer<ViewsTranslations> viewTranslates, IDateTime date, IViewRender renderView) {
            _sharedTranslations = sharedTranslations;
            _viewTranslates = viewTranslates;
            _date = date;
            _renderView = renderView;
            _logger = GetStaticLogger<FileViewerController>();
            ModalConfiguration = new ModalConfiguration<FileViewerModel>("FileViewer") {
                Title = "Visor",
                UploadFile = false,
                IndexPath = "~/Views/FileViewer/Index.cshtml",
                TableAjaxAction = "/FileViewer/" + Constants.ListAction
            };
        }

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
                ViewBag.UploadFile = ModalConfiguration.UploadFile;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Index() {
            try {
                InitView(Constants.Action.LIST, false);
                if (TempData["Message"] != null && !TempData["Message"].ToString().Equals(string.Empty)) {
                    ModelState.AddModelError(string.Empty, WebStrings.ERROR_SERVER);
                }
                return await Task.FromResult(View(ModalConfiguration.IndexPath));
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                ModelState.AddModelError(string.Empty, WebStrings.ERROR_SERVER);
                return await Task.FromResult(View(nameof(HomeController.Index)));
            }
        }       

        [Authorize(Roles = "User")]
        [Authorize(Roles = "Moderator")]
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file, int row) {
            string strRenderView;
            InitView(Constants.Action.LIST);
            try {
                if (file != null) {
                    //Check format file
                    if (!file.FileName.EndsWith(".csv") && !file.FileName.EndsWith(".xsl") && !file.FileName.EndsWith(".xlsx")) {
                        ModelState.AddModelError(string.Empty, _sharedTranslations["Selecciona un archivo .csv, .xls o .xlsx"]);
                        strRenderView = await _renderView.RenderAsync(ModalConfiguration.PartialNameList, new ArchivoModel(), new ViewDataDictionary(ViewData));
                        return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status400BadRequest });
                    }

                    string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot", "files", file.FileName);
                    if (System.IO.File.Exists(path)) {
                        System.IO.File.Delete(path);
                    }

                    //Copy file to import
                    string pathCopy = FilesHelper.CopyFile(file, path);

                    var model = new List<FileViewerModel>();
                    model.Add(new FileViewerModel());
                    if (pathCopy != null && pathCopy.Length > 0) {
                        model = ExportExcel<FileViewerModel>.Import(pathCopy, row);
                        if (model != null) {
                            strRenderView = await _renderView.RenderAsync(ModalConfiguration.PartialNameList, model, new ViewDataDictionary(ViewData));
                            return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status200OK });
                        } else {
                            ModelState.AddModelError(string.Empty, "Error al importar el archivo.");
                            strRenderView = await _renderView.RenderAsync(ModalConfiguration.IndexPath, new List<FileViewerModel>(), new ViewDataDictionary(ViewData));
                            return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status400BadRequest });
                        }
                    } else {
                        ModelState.AddModelError(string.Empty, WebStrings.ERROR_BAD_REQUEST);
                        strRenderView = await _renderView.RenderAsync(ModalConfiguration.IndexPath, new List<FileViewerModel>(), new ViewDataDictionary(ViewData));
                        return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status400BadRequest });
                    }
                } else {
                    ModelState.AddModelError(string.Empty, WebStrings.ERROR_BAD_REQUEST);
                    strRenderView = await _renderView.RenderAsync(ModalConfiguration.IndexPath, new List<FileViewerModel>(), new ViewDataDictionary(ViewData));
                    return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status400BadRequest });
                }
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                ModelState.AddModelError(string.Empty, WebStrings.ERROR_SERVER);
                strRenderView = await _renderView.RenderAsync(ModalConfiguration.IndexPath, new List<FileViewerModel>(), new ViewDataDictionary(ViewData));
                return await Task.FromResult(new JsonResult(strRenderView) { StatusCode = StatusCodes.Status500InternalServerError });
            }
        }

        /// <summary>
        /// Download tamplate
        /// </summary>
        /// <returns>ActionResult</returns>
        [HttpGet]
        public async Task<ActionResult> DownloadTemplate(string plantilla) {
            InitView(Constants.Action.LIST);
            try {
                if (plantilla == null || plantilla.Equals(string.Empty)) {
                    TempData["Message"] = WebStrings.ERROR_SERVER;//ModelState.AddModelError(string.Empty, Strings.ERROR_SERVER);
                    return await Task.FromResult(RedirectToAction(nameof(HomeController.Index)));
                }

                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot", "files", $"Plantilla{plantilla}.xltx");//PlantillaPadron
                string fileName = Path.GetFileName(filePath);

                if (!System.IO.File.Exists(filePath)) {
                    TempData["Message"] = WebStrings.ERROR_SERVER;//ModelState.AddModelError(string.Empty, Strings.ERROR_SERVER);
                    return await Task.FromResult(RedirectToAction(nameof(HomeController.Index)));
                }

                byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
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
