namespace Genealogy.WinFormsApp.Forms {
    public partial class FrmInvestigacion : Form {

        private static ILogger<FrmInvestigacion> _logger;
        private static IBaseService<InvestigacionModel, Investigacion, AppEntitiesContext> _service;

        public FrmInvestigacion(InvestigacionService service) {
            InitializeComponent();
            _logger = LogServiceContainer.GetLog<FrmInvestigacion>();
            _service = service;
        }

        private void FrmInvestigacion_Load(object sender, EventArgs e) => LoadTable(DgvData);

        //private static void InitTable(DataGridView dataGridView) {
        //	try {
        //		//var combo = MainModel.GetRegisters().ToList();
        //		Dictionary<int, object> columns = new() {
        //			{ 0, DataGridViewExtension.CreateTextBox(MappingsDB.Columna_Id, "#") },
        //			{ 1, DataGridViewExtension.CreateTextBox(MappingsDB.Columna_Nombre, "Nombreo") },
        //			{ 2, DataGridViewExtension.CreateTextBox(MappingsDB.Columna_Notas, "Notas") },
        //		};

        //		_ = dataGridView.InitTable(columns);
        //	} catch (Exception ex) {
        //		throw new Exception(ex.Message);
        //	}
        //}

        private static void LoadTable(DataGridView dataGridView) {
            try {
                var list = _service.GetAll().ToList();
                if (list != null)
                    _ = dataGridView.LoadTable(list);
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
    }
}
