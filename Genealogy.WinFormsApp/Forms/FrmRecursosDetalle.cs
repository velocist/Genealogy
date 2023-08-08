namespace Genealogy.WinFormsApp.Forms {
	public partial class FrmRecursosDetalle : Form {

		private readonly ILogger<FrmRecursosDetalle> _logger;

		/// <summary>
		/// Initializes a new instance of the <see cref="FrmRecursosDetalle"/> class.
		/// </summary>
		[Obsolete]
		public FrmRecursosDetalle() {
			InitializeComponent();
			_logger = LogServiceContainer.GetLog<FrmRecursosDetalle>();
			_ = LoadComboCountry(CmbCountry);

			this.ConfigureForm("Recurso", FormWindowState.Maximized);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="FrmRecursosDetalle"/> class.
		/// </summary>
		/// <param name="id">The identifier.</param>
		[Obsolete]
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
		[Obsolete]
		private void LoadForm(int id) {
			try {
				var item = new RecursosViewModel(id).Get();
				if (item != null) {
					TxtId.Text = item.RecursoModel.Id.ToString();
					TxtName.Text = item.RecursoModel.Nombre;
					txtDescription.Text = item.RecursoModel.Descripcion;
					TxtTown.Text = item.RecursoModel.Pueblo;
					TxtCity.Text = item.RecursoModel.Pueblo;
					TxtProvince.Text = item.RecursoModel.Provincia;
					TxtNotes.Text = item.RecursoModel.Notas;
					TxtUrl.Text = item.RecursoModel.Url;
					//TxtJudicialParty.Text = item.RecursoModel.
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
		[Obsolete]
		private ComboBox LoadComboCountry(ComboBox combo) {
			try {
				combo.LoadCombo(MappingsDB.Columna_Id, "Name", new CountryModel().List().ToList());
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
