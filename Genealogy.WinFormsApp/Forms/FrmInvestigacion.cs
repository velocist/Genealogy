using velocist.WinForms.DataGridViewControl;
using velocist.WinForms.FormControl;

namespace Genealogy.WinFormsApp.Forms {

    /// <summary>
    /// Form for investigacion
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class FrmInvestigacion : Form {

        private static ILogger _logger;
        private static IInvestigacionService<InvestigacionModel, Investigacion, AppEntitiesContext> _service;
        private List<InvestigacionModel> _listModel;
        private static UserConfiguration _userConfiguration { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmInvestigacion"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public FrmInvestigacion(InvestigacionService service) {
            InitializeComponent();
            _logger = GetStaticLogger<FrmInvestigacion>();
            _service = service;

            this.ConfigureForm("Investigacion");

            var btnAdd = CustomTable.Controls.Find("BtnAdd", false)[0];
            btnAdd.Click += new EventHandler(BtnAdd_Click);

            var btnSave = CustomTable.Controls.Find("BtnSave", false)[0];
            btnSave.Click += new EventHandler(BtnSave_Click);

            var btnEdit = CustomTable.Controls.Find("BtnEdit", false)[0];
            btnEdit.Click += new EventHandler(BtnEdit_Click);

            var btnDelete = CustomTable.Controls.Find("BtnDelete", false)[0];
            btnDelete.Click += new EventHandler(BtnDelete_Click);

            var dgvData = CustomTable.Controls.Find("DgvData", false)[0];
            dgvData.Click += new EventHandler(DgvData_Click);

            var btnSearch = FrmSearch.Controls.Find("BtnSearch", false)[0];
            btnSearch.Click += new EventHandler(BtnSearch_Click);

            var btnExport = FrmExport.Controls.Find("BtnExport", false)[0];
            btnExport.Click += new EventHandler(BtnExport_Click);

            var btnImport = FrmExport.Controls.Find("BtnImport", false)[0];
            btnImport.Click += new EventHandler(BtnImport_Click);
        }

        /// <summary>
        /// Handles the Load event of the FrmInvestigacion control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmInvestigacion_Load(object sender, EventArgs e) {
            try {
                LoadTable();
            } catch (Exception ex) {
                _logger.LogError(ex, "{message}", ex.Message);
                _ = MessageBox.Show(ex.Message);
            }
        }

        #region DATAGRID

        /// <summary>
        /// Handles the Click event of the DgvData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void DgvData_Click(object sender, EventArgs e) {
            try {
                if (CustomTable.TableData.SelectedRows.Count == 1) {
                    LoadDetails();
                }
            } catch (Exception ex) {
                _logger.LogError(ex, "{message}", ex.Message);
                _ = MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region FILTER MODULE

        /// <summary>
        /// Handles the Click event of the BtnSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnSearch_Click(object sender, EventArgs e) {
            try {
                var list = _service.Search(FrmSearch.TxtTextToSearch).ToList();
                if (list != null)
                    _ = CustomTable.TableData.LoadTable(list);
            } catch (Exception ex) {
                _logger.LogError(ex, "{message}", ex.Message);
                _ = MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region BUTTON MODULE

        private void BtnAdd_Click(object sender, EventArgs e) {
            try {
                groupBox2.CleanControls();
            } catch (Exception ex) {
                _logger.LogError(ex, "{message}", ex.Message);
                _ = MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Handles the Click event of the BtnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <exception cref="Exception"></exception>
        private void BtnSave_Click(object sender, EventArgs e) {
            try {
                var model = GetObject();
                if (model.Id > 0) {
                    var list = _service.Edit(model);
                } else {
                    var list = _service.Add(model);
                }

                LoadTable();
            } catch (Exception ex) {
                _logger.LogError(ex, "{message}", ex.Message);
                _ = MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Handles the Click event of the BtnEdit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnEdit_Click(object sender, EventArgs e) {
            try {
                LoadDetails();
            } catch (Exception ex) {
                _logger.LogError(ex, "{message}", ex.Message);
                _ = MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Handles the Click event of the BtnDelete control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnDelete_Click(object sender, EventArgs e) {
            try {
                if (int.Parse(CommonDataControl.Id) > 0) {
                    var list = _service.RemoveById(CommonDataControl.Id);
                }

                LoadTable();
            } catch (Exception ex) {
                _logger.LogError(ex, "{message}", ex.Message);
                _ = MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region EXPORT MODULE

        /// <summary>
        /// Handles the Click event of the BtnImport control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnImport_Click(object sender, EventArgs e) {
            try {
                var result = Import();

                if (result.Any()) {
                    _service.AddAll(result);
                    _ = MessageBox.Show("Importación realizada con éxito.");
                    LoadTable();
                } else {
                    _ = MessageBox.Show("Error al realizar la importación.");
                }
            } catch (Exception ex) {
                _logger.LogError(ex, "{message}", ex.Message);
                _ = MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Handles the Click event of the BtnExport control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnExport_Click(object sender, EventArgs e) {
            try {
                var result = Export();

                if (result) {
                    _ = MessageBox.Show("Exportación realizada con éxito.");
                } else {
                    _ = MessageBox.Show("Error al realizar la exportación.");
                }
            } catch (Exception ex) {
                _logger.LogError(ex, "{message}", ex.Message);
                _ = MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region COMMON PRIVATES 

        /// <summary>
        /// Initializes the table.
        /// </summary>
        /// <exception cref="Exception"></exception>
        private void InitTable() {
            try {
                Dictionary<int, object> columns = new() {
                    { 0, DataGridViewExtension.CreateTextBox(MappingsDB.Columna_Id, "#", 0) },
                    { 1, DataGridViewExtension.CreateTextBox(MappingsDB.Columna_Observations, "Observaciones", 7) },
                    { 2, DataGridViewExtension.CreateTextBox(MappingsDB.Columna_Url, "Url", 8) },
                    { 3, DataGridViewExtension.CreateTextBox("Version", "Version", 10) },
                    { 4, DataGridViewExtension.CreateTextBox("AddDate", "AddDate", 11) },
                    { 5, DataGridViewExtension.CreateTextBox("LastChange", "LastChange", 12) },
                };

                _ = CustomTable.TableData.InitTable(columns);

                //CustomTable.TableData.ConfigureTable();

            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Loads the table.
        /// </summary>
        /// <exception cref="Exception"></exception>
        private void LoadTable() {
            var list = _service.GetAll().ToList();
            if (list != null) {
                _ = CustomTable.TableData.LoadTable(list);
                _listModel = list;
            }
        }

        /// <summary>
        /// Loads the details.
        /// </summary>
        private void LoadDetails() {
			CommonDataControl.Id = CustomTable.GetSelectedCellValue("Id")?.ToString();
			CommonDataControl.AddDate = CustomTable.GetSelectedCellValue("AddDate")?.ToString();
			CommonDataControl.LastChange = CustomTable.GetSelectedCellValue("LastChange")?.ToString();
			CommonDataControl.Observations = CustomTable.GetSelectedCellValue(MappingsDB.Columna_Observaciones)?.ToString();
			CommonDataControl.Url = CustomTable.GetSelectedCellValue(MappingsDB.Columna_Url)?.ToString();
		}

        /// <summary>
        /// Loads the model.
        /// </summary>
        /// <returns></returns>
        private InvestigacionModel LoadModel() => new() {
            Id = int.Parse(CommonDataControl.Id),
            Observaciones = CommonDataControl.Observations,
            Url = CommonDataControl.Url,
        };

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<InvestigacionModel> GetList() => JsonHelper<InvestigacionModel>.ConvertToList(_listModel);

        /// <summary>
        /// Gets the object.
        /// </summary>
        /// <returns></returns>
        private InvestigacionModel GetObject() => JsonHelper<InvestigacionModel>.ConverToObject(LoadModel());

        /// <summary>
        /// Imports this instance.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<InvestigacionModel> Import() => ExportExcel<List<InvestigacionModel>>.Import(FrmExport.OutputFilename, 0);

        /// <summary>
        /// Exports this instance.
        /// </summary>
        /// <returns></returns>
        private bool Export() => ExportExcel<InvestigacionModel>.Export(_listModel, FrmExport.OutputFilename, true);

        #endregion

    }
}
