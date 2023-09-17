namespace Genealogy.WinFormsApp.Forms {

    /// <summary>
    /// Form for resources
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class FrmRecursos : Form {

        private readonly ILogger<FrmRecursos> _logger;
        private static RecursoService _service;

        private readonly bool datagridUserActions = false;
        private readonly bool searchRow = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmRecursos"/> class.
        /// </summary>
        public FrmRecursos(RecursoService recursoService) {
            InitializeComponent();
            _logger = LogServiceContainer.GetLog<FrmRecursos>();
            this.ConfigureForm("Recursos", FormWindowState.Maximized);
            _service = recursoService;

        }

        /// <summary>
        /// Handles the Load event of the FrmRecurso control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FrmRecurso_Load(object sender, EventArgs e) {
            InitTable(DgvData);
            LoadTable(DgvData);
            DgvData.ConfigureTable(datagridUserActions, searchRow: searchRow);
        }

        /// <summary>
        /// Initializes the table.
        /// </summary>
        /// <param name="dataGridView">The data grid view.</param>
        /// <exception cref="System.Exception"></exception>
        private static void InitTable(DataGridView dataGridView) {
            try {
                //var combo = MainModel.GetRegisters().ToList();
                Dictionary<int, object> columns = new() {
                    { 0, DataGridViewExtension.CreateTextBox(MappingsDB.Columna_Id, "#") },
                    { 1, DataGridViewExtension.CreateTextBox(MappingsDB.Columna_Nombre, "Nombre") },
                    { 2, DataGridViewExtension.CreateTextBox(MappingsDB.Columna_Descripcion, "Descripcion") },
                    { 3, DataGridViewExtension.CreateTextBox(MappingsDB.Columna_PartidoJudicial, "Partido judicial") },
                    { 4, DataGridViewExtension.CreateTextBox(MappingsDB.Columna_Pueblo, "Pueblo") },
                    { 5, DataGridViewExtension.CreateTextBox(MappingsDB.Columna_Provincia, "Provincia") },
                    { 6, DataGridViewExtension.CreateTextBox(MappingsDB.Columna_Pais, "Pais") },
                    { 7, DataGridViewExtension.CreateTextBox(MappingsDB.Columna_Notas, "Notas") },
                    { 8, DataGridViewExtension.CreateTextBox(MappingsDB.Columna_Url, "Url") },
                };

                _ = dataGridView.InitTable(columns);
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Loads the table.
        /// </summary>
        /// <param name="dataGridView">The data grid view.</param>
        /// <exception cref="System.Exception"></exception>
        private static void LoadTable(DataGridView dataGridView) {
            try {
                var list = _service.GetAll().ToList();
                if (list != null)
                    _ = dataGridView.LoadTable(list, true);
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Loads the combo country.
        /// </summary>
        /// <param name="combo">The combo.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        private ComboBox LoadComboCountry(ComboBox combo) {
            try {
                combo.LoadCombo(MappingsDB.Columna_Id, "Name", _service.GetAll().ToList());
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                _ = MessageBox.Show(ex.Message);
            }

            return combo;
        }

        /// <summary>
        /// Handles the Click event of the BtnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.Exception"></exception>
        private void BtnSave_Click(object sender, EventArgs e) {
            try {
                throw new NotImplementedException();
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Handles the Click event of the BtnExport control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnExport_Click(object sender, EventArgs e) {
            try {
                //if (!this.CheckOpenForms<ModalExport<Model>>()) {
                //	ModalExport<Model> frm = new((GetAll<Model>)DgvData.DataSource);
                //	_ = frm.ShowDialog();
                //}
                throw new NotImplementedException();
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                _ = MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Handles the DoubleClick event of the DgvData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void DgvData_DoubleClick(object sender, EventArgs e) {
            try {
                if (searchRow) {
                    if (DgvData.CurrentRow.Index == 0) {
                        editDgvEc = new DataGridViewTextBoxEditingControl();
                        //editDgvEc. += DataGridView_EditingControlShowing(sender,e);
                    }
                } else {
                    if (DgvData.SelectedRows.Count == 1) {
                        if (!this.CheckOpenForms<FrmRecursosDetalle>()) {
                            FrmRecursosDetalle frm = new(int.Parse(DgvData.SelectedRows[0].Cells[0].Value.ToString()));
                            _ = frm.ShowDialog();
                        }
                    }
                }
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                _ = MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Handles the CellValueChanged event of the DgvData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param>
        private void DgvData_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
            try {
                throw new NotImplementedException();
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                _ = MessageBox.Show(ex.Message);
            }
        }

        private DataGridViewTextBoxEditingControl editDgvEc = null;

        /// <summary>
        /// Handles the EditingControlShowing event of the DataGridView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewEditingControlShowingEventArgs"/> instance containing the event data.</param>
        private void DataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e) {
            // unhook the old handle
            if (editDgvEc != null)
                editDgvEc.TextChanged -= EditDgvEc_TextChanged;
            // store a reference
            editDgvEc = e.Control as DataGridViewTextBoxEditingControl;
            // hook up the TextChanged event
            editDgvEc.TextChanged += EditDgvEc_TextChanged;
        }

        /// <summary>
        /// Handles the TextChanged event of the EditDgvEc control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void EditDgvEc_TextChanged(object sender, EventArgs e) {
            if (DgvData.CurrentCell.RowIndex == 0) {
                var col = DgvData.CurrentCell.ColumnIndex;
                if (editDgvEc.Text == "")
                    DgvData.ClearSelection();
                else
                    foreach (DataGridViewRow row in DgvData.Rows) {
                        if (row.Index > 0)
                            row.Selected =
                            row.Cells[col].Value.ToString().Contains(editDgvEc.Text);
                    }
            }
        }

        /// <summary>
        /// Handles the CellPainting event of the DataGridView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellPaintingEventArgs"/> instance containing the event data.</param>
        private void DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) {
            if (e.ColumnIndex >= 0 || e.RowIndex != 0)
                return;
            e.Graphics.DrawString("$", new Font("Wingdings", 11f), Brushes.Black, e.CellBounds);
            e.Handled = true;
        }
    }
}
