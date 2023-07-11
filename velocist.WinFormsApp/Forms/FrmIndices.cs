using velocist.Business.Models;
using velocist.Objects;
using velocist.WinForms;

namespace velocist.WinFormsApp.Forms {

	public partial class FrmIndices : Form {

		private static ILogger<FrmIndices> _logger;

		public FrmIndices() {
			InitializeComponent();
			_logger = LogService.LogServiceContainer.GetLog<FrmIndices>();
		}

		private void FrmIndices_Load(object sender, EventArgs e) {
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
				_logger.LogError(ex, ex.Message);
				throw new Exception(ex.Message);
			}
		}

		private static void LoadTable(DataGridView dataGridView, int employeeId = 0) {
			try {
				var list = new IndicesViewModel().List().ToList();
				if (list != null)
					_ = dataGridView.LoadTable(list);
			} catch (Exception ex) {
				_logger.LogError(ex, ex.Message);
				throw new Exception(ex.Message);
			}
		}

		private void BtnExport_Click(object sender, EventArgs e) {
			try {
				throw new NotImplementedException();
				//if (!this.CheckOpenForms<ModalSearch<RecursosMo>>()) {
				//ModalSearch<IndiceModel> frm = new((List<IndiceModel>)DgvData.DataSource);
				//frm.ShowDialog();
				//}
			} catch (Exception ex) {
				_logger.LogError(ex, ex.Message);
				_ = MessageBox.Show(ex.Message);
			}
		}
	}
}