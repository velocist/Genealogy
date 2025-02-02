using velocist.WinForms.FormControl;
using velocist.WinFormsControlLibrary.Models;
using velocist.WinFormsControlLibrary.Types;
using System.ComponentModel;

namespace Genealogy.WinFormsApp.Forms.Export {

    /// <summary>
    /// Modal export
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class ModalExport : Form {

        private readonly ILogger _logger;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ExportModel ExportModel { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModalExport"/> class.
        /// </summary>
        /// <param name="type">The type of modal.</param>
        /// <param name="title">The title of modal.</param>
        public ModalExport(ModalTypeId type, string title = "") {
            InitializeComponent();
            if (type == ModalTypeId.Export)
                title = "Exportación";
            else if (type == ModalTypeId.Import)
                title = "Importación";

            this.ConfigureForm(title, windowsState: FormWindowState.Normal);
            ExportModel = new ExportModel();

            var btnAccept = FrmGenericExport.Controls.Find("BtnAccept", false)[0];
            btnAccept.Click += new EventHandler(BtnAccept_Click);
            _logger = GetStaticLogger<ModalExport>();
        }

        /// <summary>
        /// Handles the Click event of the BtnImport control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnAccept_Click(object sender, EventArgs e) {
            try {
                ExportModel.OutputFilename = FrmGenericExport.ExportModel.OutputFilename;
                this.DialogResult = DialogResult.OK;
            } catch (Exception ex) {
                _logger.LogError(ex, "{message}", ex.Message);
                _ = MessageBox.Show(ex.Message);
            }
        }
    }
}