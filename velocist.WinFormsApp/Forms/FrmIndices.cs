using System;
using System.Collections.Generic;
using System.Windows.Forms;
using velocist.Objects;
using velocist.WinForms;

namespace velocist.WinFormsApp.Forms {

    public partial class FrmIndices : Form {
        public FrmIndices() {
            InitializeComponent();
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

                dataGridView.InitTable(columns);
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        private void LoadTable(DataGridView dataGridView, int employeeId = 0) {
            try {
                //var list = new IndicesViewModel().List().ToList();
                //if (list != null)
                //    dataGridView.LoadTable<IndiceModel>(list);
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
    }
}