using Genealogy.WinFormsApp.Forms.Export;
using velocist.WinForms.ComboBoxControl;
using velocist.WinForms.DataGridViewControl;
using velocist.WinForms.FormControl;
using velocist.WinFormsControlLibrary.Types;

namespace Genealogy.WinFormsApp.Forms {

    /// <summary>
    /// Form for resources
    /// </summary>
    /// <seealso cref="Form" />
    public partial class FrmRecursos : Form {

        private static ILogger _logger;
        private static IRecursoService<RecursoModel, Recurso, AppEntitiesContext> _service;
        private static List<RecursoModel> _listModel;
        private static BaseForm<RecursoModel> _form;

        private static UserConfiguration _userConfiguration { get; set; }
        private string ExportPath;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmRecursos"/> class.
        /// </summary>
        /// <param name="recursoService">The recurso service.</param>
        public FrmRecursos(RecursoService recursoService) {
            InitializeComponent();
            _logger = GetStaticLogger<FrmRecursos>();
            _service = recursoService;

            _form = new BaseForm<RecursoModel>(this, "Recursos");

            //ToolBtnAdd.Click += new EventHandler(BtnAdd_Click);
            //ToolBtnSave.Click += new EventHandler(BtnSave_Click);
            //ToolBtnDelete.Click += new EventHandler(BtnDelete_Click);
            //ToolBtnEdit.Click += new EventHandler(BtnEdit_Click);
            //ToolBtnCancel.Click += new EventHandler(BtnCancel_Click);
            //ToolBtnExport.Click += new EventHandler(ToolBtnExport_Click);
            //ToolBtnImport.Click += new EventHandler(ToolBtnImport_Click);

            var btnAdd = CustomTable.Controls.Find("BtnAdd", false)[0];
            btnAdd.Click += new EventHandler(BtnAdd_Click);

            var btnSave = CustomTable.Controls.Find("BtnSave", false)[0];
            btnSave.Click += new EventHandler(BtnSave_Click);

            var btnEdit = CustomTable.Controls.Find("BtnEdit", false)[0];
            btnEdit.Click += new EventHandler(BtnEdit_Click);

            var btnDelete = CustomTable.Controls.Find("BtnDelete", false)[0];
            btnDelete.Click += new EventHandler(BtnDelete_Click);

            var btnCancel = CustomTable.Controls.Find("BtnCancelar", false)[0];
            btnCancel.Click += new EventHandler(BtnCancel_Click);

            var dgvData = CustomTable.Controls.Find("DgvData", false)[0];
            dgvData.Click += new EventHandler(DgvData_Click);

            var btnSearch = FrmSearch.Controls.Find("BtnSearch", false)[0];
            btnSearch.Click += new EventHandler(BtnSearch_Click);

            //var btnExport = FrmExport.Controls.Find("BtnExport", false)[0];
            //btnExport.Click += new EventHandler(BtnExport_Click);

            //var btnImport = FrmExport.Controls.Find("BtnImport", false)[0];
            //btnImport.Click += new EventHandler(BtnImport_Click);

        }

        /// <summary>
        /// Handles the Load event of the FrmRecurso control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmRecurso_Load(object sender, EventArgs e) {
            try {
                InitTable();
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

        /// <summary>
        /// Handles the Click event of the BtnAdd control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnAdd_Click(object sender, EventArgs e) {
            try {
                CommonDataControl.CleanControls();
                GbxData.CleanControls();
                GbxData.SetControlsToReadOnly(false);
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
                //LoadDetails();
                GbxData.SetControlsToReadOnly(false);
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

        private void BtnCancel_Click(object sender, EventArgs e) {
            try {
                CommonDataControl.CleanControls();
                GbxData.CleanControls();
                GbxData.SetControlsToReadOnly(true);
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
                var result = Import(ExportPath);

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
                var result = Export(ExportPath);

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

        private void ToolBtnImport_Click(object sender, EventArgs e) {
            try {
                if (!this.CheckOpenForms<ModalExport>()) {
                    ModalExport frm = new(ModalTypeId.Import) {

                    };
                    if (frm.ShowDialog() == DialogResult.OK) {
                        ExportPath = frm.ExportModel.OutputFilename;
                        BtnImport_Click(sender, e);
                    }
                }
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                _ = MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ToolBtnExport_Click(object sender, EventArgs e) {
            try {
                if (!this.CheckOpenForms<ModalExport>()) {
                    ModalExport frm = new(ModalTypeId.Export) {
                    };
                    if (frm.ShowDialog() == DialogResult.OK) {
                        ExportPath = frm.ExportModel.OutputFilename;
                        BtnExport_Click(sender, e);
                    }
                }
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                _ = MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                //Dictionary<int, object> columns = new() {
                //    { 0, DataGridViewExtension.CreateTextBox(MappingsDB.Columna_Id, "#", 0) },
                //    { 1, DataGridViewExtension.CreateTextBox(MappingsDB.Columna_Nombre, "Nombre", 1) },
                //    { 2, DataGridViewExtension.CreateTextBox(MappingsDB.Columna_Descripcion, "Descripcion", 2) },
                //    { 3, DataGridViewExtension.CreateTextBox(MappingsDB.Columna_PartidoJudicial, "Partido judicial", 3) },
                //    { 4, DataGridViewExtension.CreateTextBox(MappingsDB.Columna_Pueblo, "Pueblo", 4) },
                //    { 5, DataGridViewExtension.CreateTextBox(MappingsDB.Columna_Provincia, "Provincia", 5) },
                //    { 6, DataGridViewExtension.CreateTextBox(MappingsDB.Columna_Pais, "Pais", 6) },
                //    { 7, DataGridViewExtension.CreateTextBox(MappingsDB.Columna_Observations, "Observaciones", 7) },
                //    { 8, DataGridViewExtension.CreateTextBox(MappingsDB.Columna_Url, "Url", 8) },
                //    { 9, DataGridViewExtension.CreateTextBox(MappingsDB.Columna_TipoRecurso, "Tipo", 9) },
                //    { 10, DataGridViewExtension.CreateTextBox("Version", "Version", 10) },
                //    { 11, DataGridViewExtension.CreateTextBox("AddDate", "AddDate", 11) },
                //    { 12, DataGridViewExtension.CreateTextBox("LastChange", "LastChange", 12) },
                //};

                _ = CustomTable.TableData.InitTable<RecursoModel>();

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

            CommonDataControl.Id = CustomTable.TableData.SelectedRows[0].Cells[CustomTable.TableData.Columns[MappingsDB.Columna_Id].Index].Value?.ToString();
            CommonDataControl.AddDate = CustomTable.TableData.SelectedRows[0].Cells[CustomTable.TableData.Columns["AddDate"].Index].Value?.ToString();
            CommonDataControl.LastChange = CustomTable.TableData.SelectedRows[0].Cells[CustomTable.TableData.Columns["LastChange"].Index].Value?.ToString();
            CommonDataControl.Observations = CustomTable.TableData.SelectedRows[0].Cells[CustomTable.TableData.Columns[MappingsDB.Columna_Observaciones].Index].Value?.ToString();
            CommonDataControl.Url = CustomTable.TableData.SelectedRows[0].Cells[CustomTable.TableData.Columns[MappingsDB.Columna_Url].Index].Value?.ToString();

            TxtName.Text = CustomTable.TableData.SelectedRows[0].Cells[CustomTable.TableData.Columns[MappingsDB.Columna_Nombre].Index].Value?.ToString();
            TxtDescription.Text = CustomTable.TableData.SelectedRows[0].Cells[CustomTable.TableData.Columns[MappingsDB.Columna_Descripcion].Index].Value?.ToString();
            TxtTown.Text = CustomTable.TableData.SelectedRows[0].Cells[CustomTable.TableData.Columns[MappingsDB.Columna_Pueblo].Index].Value?.ToString();
            TxtProvince.Text = CustomTable.TableData.SelectedRows[0].Cells[CustomTable.TableData.Columns[MappingsDB.Columna_Provincia].Index].Value?.ToString();
            //TxtPartidoJudicial.Text = CustomTable.TableData.SelectedRows[0].Cells[CustomTable.TableData.Columns[MappingsDB.Columna_PartidoJudicial].Index].Value?.ToString();

        }

        /// <summary>
        /// Loads the model.
        /// </summary>
        /// <returns></returns>
        private RecursoModel LoadModel() => new() {
            Id = int.Parse(CommonDataControl.Id),
            Observaciones = CommonDataControl.Observations,
            Url = CommonDataControl.Url,
        };

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<RecursoModel> GetList() => JsonHelper<RecursoModel>.ConvertToList(_listModel);

        /// <summary>
        /// Gets the object.
        /// </summary>
        /// <returns></returns>
        private RecursoModel GetObject() => JsonHelper<RecursoModel>.ConverToObject(LoadModel());

        /// <summary>
        /// Imports this instance.
        /// </summary>
        /// <returns></returns>
        private List<RecursoModel> Import(string importPath) => ExportExcel<RecursoModel>.ImportList(importPath, 0);

        /// <summary>
        /// Exports this instance.
        /// </summary>
        /// <returns></returns>
        private bool Export(string exportPath) => ExportExcel<RecursoModel>.Export(_listModel, exportPath, allowIgnore: false);

        #endregion

        #region PRIVATES

        /// <summary>
        /// Loads the combo country.
        /// </summary>
        /// <param name="combo">The combo.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private ComboBox LoadComboCountry(ComboBox combo) => combo.LoadCombo(MappingsDB.Columna_Id, "Name", _service.GetAll().ToList());

        #endregion

        ///// <summary>
        ///// Handles the DoubleClick event of the DgvData control.
        ///// </summary>
        ///// <param name="sender">The source of the event.</param>
        ///// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        //private void DgvData_DoubleClick(object sender, EventArgs e) {
        //    try {
        //        if (searchRow) {
        //            if (DgvData.CurrentRow.Index == 0) {
        //                editDgvEc = new DataGridViewTextBoxEditingControl();
        //                //editDgvEc. += DataGridView_EditingControlShowing(sender,e);
        //            }
        //        } else {
        //            if (DgvData.SelectedRows.Count == 1) {
        //                if (!this.CheckOpenForms<FrmRecursosDetalle>()) {
        //                    FrmRecursosDetalle frm = new(int.Parse(DgvData.SelectedRows[0].Cells[0].Value.ToString()));
        //                    _ = frm.ShowDialog();
        //                }
        //            }
        //        }
        //    } catch (Exception ex) {
        //        _logger.LogError(ex.Message);
        //        _ = MessageBox.Show(ex.Message);
        //    }
        //}

        ///// <summary>
        ///// Handles the CellValueChanged event of the DgvData control.
        ///// </summary>
        ///// <param name="sender">The source of the event.</param>
        ///// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param>
        //private void DgvData_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
        //    try {
        //        throw new NotImplementedException();
        //    } catch (Exception ex) {
        //        _logger.LogError(ex.Message);
        //        _ = MessageBox.Show(ex.Message);
        //    }
        //}

        //private DataGridViewTextBoxEditingControl editDgvEc = null;

        ///// <summary>
        ///// Handles the EditingControlShowing event of the DataGridView control.
        ///// </summary>
        ///// <param name="sender">The source of the event.</param>
        ///// <param name="e">The <see cref="DataGridViewEditingControlShowingEventArgs"/> instance containing the event data.</param>
        //private void DataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e) {
        //    // unhook the old handle
        //    if (editDgvEc != null)
        //        editDgvEc.TextChanged -= EditDgvEc_TextChanged;
        //    // store a reference
        //    editDgvEc = e.Control as DataGridViewTextBoxEditingControl;
        //    // hook up the TextChanged event
        //    editDgvEc.TextChanged += EditDgvEc_TextChanged;
        //}

        ///// <summary>
        ///// Handles the TextChanged event of the EditDgvEc control.
        ///// </summary>
        ///// <param name="sender">The source of the event.</param>
        ///// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        //private void EditDgvEc_TextChanged(object sender, EventArgs e) {
        //    if (DgvData.CurrentCell.RowIndex == 0) {
        //        var col = DgvData.CurrentCell.ColumnIndex;
        //        if (editDgvEc.Text == "")
        //            DgvData.ClearSelection();
        //        else
        //            foreach (DataGridViewRow row in DgvData.Rows) {
        //                if (row.Index > 0)
        //                    row.Selected =
        //                    row.Cells[col].Value.ToString().Contains(editDgvEc.Text);
        //            }
        //    }
        //}

        ///// <summary>
        ///// Handles the CellPainting event of the DataGridView control.
        ///// </summary>
        ///// <param name="sender">The source of the event.</param>
        ///// <param name="e">The <see cref="DataGridViewCellPaintingEventArgs"/> instance containing the event data.</param>
        //private void DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) {
        //    if (e.ColumnIndex >= 0 || e.RowIndex != 0)
        //        return;
        //    e.Graphics.DrawString("$", new Font("Wingdings", 11f), Brushes.Black, e.CellBounds);
        //    e.Handled = true;
        //}

    }
}
