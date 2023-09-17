namespace Genealogy.WinFormsApp.Forms {
    public partial class FrmRecursosDetalle : Form {

        private readonly ILogger<FrmRecursosDetalle> _logger;
        private static RecursoService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmRecursosDetalle"/> class.
        /// </summary>
        public FrmRecursosDetalle(RecursoService service) {
            InitializeComponent();
            _logger = LogServiceContainer.GetLog<FrmRecursosDetalle>();
            _ = LoadComboCountry(CmbCountry);
            _service = service;

            this.ConfigureForm("Recurso", FormWindowState.Maximized);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FrmRecursosDetalle"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public FrmRecursosDetalle(int id) {
            InitializeComponent();
            _ = LoadComboCountry(CmbCountry);

            this.ConfigureForm("Recurso", FormWindowState.Maximized);
            LoadForm(id);
        }

        /// <summary>
        /// Loads the form with specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        private void LoadForm(int id) {
            try {
                var item = _service.GetById(id);
                if (item != null) {
                    TxtId.Text = item.Id.ToString();
                    TxtName.Text = item.Nombre;
                    txtDescription.Text = item.Descripcion;
                    TxtTown.Text = item.Pueblo;
                    TxtCity.Text = item.Pueblo;
                    TxtProvince.Text = item.Provincia;
                    TxtNotes.Text = item.Observaciones;
                    TxtUrl.Text = item.Url;
                    //TxtJudicialParty.Text = item.Model.
                }
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                _ = MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Loads the combo country.
        /// </summary>
        /// <param name="combo">The combo.</param>
        /// <returns></returns>
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
        private void BtnSave_Click(object sender, EventArgs e) {
            try {

            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                _ = MessageBox.Show(ex.Message);
            }
        }
    }
}
