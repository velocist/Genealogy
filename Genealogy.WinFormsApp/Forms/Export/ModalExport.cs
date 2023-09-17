using velocist.Services.Import;

namespace Genealogy.WinFormsApp.Forms.Export {

    /// <summary>
    /// Modal export
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class ModalExport : Form {

        private readonly ILogger _logger;
        public dynamic List { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModalExport"/> class.
        /// </summary>
        /// <param name="list">The list.</param>
        public ModalExport(object list) {
            InitializeComponent();
            this.ConfigureForm("Exportación", windowsState: FormWindowState.Normal);
            this.List = list;
            //_logger = GetStaticLogger<ModalExport<TEntity>>();
            _logger = LogServiceContainer.GetLog<ModalExport>();
        }

        /// <summary>
        /// Handles the Load event of the ModalExport control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ModalExport_Load(object sender, EventArgs e) {
            try {
                var result = false;
                result = ExportExcel.Export<dynamic>(List, frmGenericExport.OutputFilename);

                if (result) {
                    _ = MessageBox.Show("Exportación realizada con éxito.");
                    _logger.LogError("Export done succesfully");
                } else {
                    _ = MessageBox.Show("Error al realizar la exportación.");
                    _logger.LogError("Failed to import");
                }
            } catch (Exception ex) {
                _logger.LogError(ex, "{message}", ex.Message);
                _ = MessageBox.Show(ex.Message);
            }
        }
    }
}