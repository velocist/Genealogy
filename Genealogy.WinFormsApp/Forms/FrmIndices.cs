using Genealogy.WinFormsApp.Forms.Export;
using MathNet.Numerics.Statistics.Mcmc;
using velocist.Services.Json;

namespace Genealogy.WinFormsApp.Forms {
    public class BaseForm<TForm, TService> : Form {

        protected static ILogger<TForm> _logger;
        protected static TService _service;

        public BaseForm(TService service) {
            _logger = LogServiceContainer.GetLog<TForm>();
            _service = service;
        }


    }
    public partial class FrmIndices : Form {

        private static ILogger<FrmIndices> _logger;
        private static IBaseService<IndiceModel, Indices, AppEntitiesContext> _service;

        public FrmIndices(IndiceService service)  {
            InitializeComponent();
            _logger = LogServiceContainer.GetLog<FrmIndices>();
            _service = service;
        }

        private void FrmIndices_Load(object sender, EventArgs e) => LoadTable(DgvData);

        private static void LoadTable(DataGridView dataGridView, int employeeId = 0) {
            try {
                var list = _service.GetAll().ToList();
                if (list != null)
                    _ = dataGridView.LoadTable(list, allowAddNewRow: true);
            } catch (Exception ex) {
                _logger.LogError(ex, ex.Message);
                throw new Exception(ex.Message);
            }
        }

        private void BtnExport_Click(object sender, EventArgs e) {
            try {
                var entities = JsonAppHelper<IndiceModel>.GetListFromObject(DgvData.DataSource);
                _service.Export(frmGenericExport1.OutputFilename,entities,);
                
            } catch (Exception ex) {
                _logger.LogError(ex, ex.Message);
                _ = MessageBox.Show(ex.Message);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e) {
            try {
                var mdodel = JsonConvertHelper<IndiceModel>.GetListFromObject(DgvData.DataSource);
                var list = _service.AddAll(mdodel);
            } catch (Exception ex) {
                _logger.LogError(ex, ex.Message);
                _ = MessageBox.Show(ex.Message);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e) {
            try {
                this.Close();
            } catch (Exception ex) {
                _logger.LogError(ex, ex.Message);
                _ = MessageBox.Show(ex.Message);
            }
        }
    }
}