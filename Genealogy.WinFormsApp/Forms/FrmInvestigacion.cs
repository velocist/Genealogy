

namespace Genealogy.WinFormsApp.Forms {
	public partial class FrmInvestigacion : Form {
		public FrmInvestigacion() {
			InitializeComponent();
		}

		private void FrmInvestigacion_Load(object sender, EventArgs e) {
			InitTable(DgvData);
			LoadTable(DgvData);
		}

		private static void InitTable(DataGridView dataGridView) {
			try {
				//var combo = MainModel.GetRegisters().ToList();
				Dictionary<int, object> columns = new() {
					{ 0, DataGridViewExtension.CreateTextBox(MappingsDB.Columna_Id, "#") },
					{ 1, DataGridViewExtension.CreateTextBox(MappingsDB.Columna_Nombre, "Nombreo") },
					{ 2, DataGridViewExtension.CreateTextBox(MappingsDB.Columna_Notas, "Notas") },
				};

				_ = dataGridView.InitTable(columns);
			} catch (Exception ex) {
				throw new Exception(ex.Message);
			}
		}

		private static void LoadTable(DataGridView dataGridView) {
			try {
				var list = new InvestigacionesViewModel().List().ToList();
				if (list != null)
					_ = dataGridView.LoadTable(list);
			} catch (Exception ex) {
				throw new Exception(ex.Message);
			}
		}
	}
}
