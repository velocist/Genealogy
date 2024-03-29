using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac.Core;
using Genealogy.Objects.Entitiesv1;
using Genealogy.WinFormsApp.Forms.Export;
using velocist.Services.Json;

namespace Genealogy.WinFormsApp.Forms {

    public partial class FrmFamilySearch : Form {

        private static ILogger<FrmFamilySearch> _logger;
        private static IBaseService<FSRecordModel, FSRecord, AppEntitiesContext> _service;

        public FrmFamilySearch(FSRecordService service) {
            InitializeComponent();
            _logger = LogServiceContainer.GetLog<FrmFamilySearch>();
            _service = service;
        }

        private void FrmFamilySearch_Load(object sender, EventArgs e) => LoadTable(DgvData);

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
                if (!this.CheckOpenForms<ModalExport>()) {
                    var list = _service.GetAll().ToList();
                    if (list != null) {
                        ModalExport frm = new(list) {
                            MdiParent = this
                        };
                        frm.Show();
                    } else {
                        MessageBox.Show("No hay registros.");
                    }
                }
            } catch (Exception ex) {
                _logger.LogError(ex, ex.Message);
                _ = MessageBox.Show(ex.Message);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e) {
            try {
                var mdodel = JsonConvertHelper<FSRecordModel>.GetListFromObject(DgvData.DataSource);
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

        private void BtnEliminar_Click(object sender, EventArgs e) {

        }
    }
}
