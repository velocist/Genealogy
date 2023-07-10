using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;
using velocist.Services.Import;
using velocist.WinForms;

namespace velocist.WinFormsControlLibrary.Export {
    public partial class ModalExport<T> : Form where T : class {

        private readonly ILogger<ModalExport<T>> _logger;
        private string _outputFilename;
        private readonly object list;

        public ModalExport( object list) {
            InitializeComponent();
            this.list = list;
            this.ConfigureForm("Exportación", windowsState: FormWindowState.Normal);
            _logger = LogService.LogServiceContainer.GetLog<ModalExport<T>>();
        }

        private void ModalExport_Load(object sender, EventArgs e) {
            try {
                _outputFilename = "Export_" + DateTime.Now.ToString("yyyyddMM");
                TxtOutputFileName.Text = _outputFilename;
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnExamineBrowser_Click(object sender, EventArgs e) {
            try {
                if (FbdPath.ShowDialog() == DialogResult.OK) {
                    TxtOutputFileName.Text = Path.Combine(FbdPath.SelectedPath, _outputFilename);
                }
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnExport_Click(object sender, EventArgs e) {
            try {
                bool result = false;
                    result = ExportExcel.Export<T>((List<T>)list, TxtOutputFileName.Text);

                if (result) {
                    MessageBox.Show("Exportación realizada con éxito.");
                } else {
                    MessageBox.Show("Error al realizar la exportación.");
                }
                this.Close();

            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

    }
}
