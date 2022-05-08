using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using velocist.Business.Models;
using velocist.Business.Models.App;
using velocist.Objects;
using velocist.WinForms;


namespace velocist.WinFormsApp.Forms {
    public partial class FrmRecursos : Form {
        public FrmRecursos() {
            InitializeComponent();
            this.ConfigureForm("Recursos", FormWindowState.Maximized);
        }

        private void FrmRecurso_Load(object sender, EventArgs e) {
            InitTable(DgvData);
            LoadTable(DgvData);
            DgvData.ConfigureTable();
            LoadComboCountry(CmbCountry);
        }

        private static void InitTable(DataGridView dataGridView) {
            try {
                //var combo = MainModel.GetRegisters().ToList();
                Dictionary<int, object> columns = new() {
                    { 0, DataGridViewExtension.CreateTextBox(MappingsDB.Columna_Id, "#") },
                    { 1, DataGridViewExtension.CreateTextBox(MappingsDB.Columna_Nombre, "Nombre") },
                    { 2, DataGridViewExtension.CreateTextBox(MappingsDB.Columna_Descripcion, "Descripcion") },
                    { 3, DataGridViewExtension.CreateTextBox(MappingsDB.Columna_PartidoJudicial, "Partido judicial") },
                    { 4, DataGridViewExtension.CreateTextBox(MappingsDB.Columna_Pueblo, "Pueblo") },
                    { 5, DataGridViewExtension.CreateTextBox(MappingsDB.Columna_Provincia, "Provincia") },
                    { 6, DataGridViewExtension.CreateTextBox(MappingsDB.Columna_Pais, "Pais") },
                    { 7, DataGridViewExtension.CreateTextBox(MappingsDB.Columna_Notas, "Notas") },
                    { 8, DataGridViewExtension.CreateTextBox(MappingsDB.Columna_Url, "Url") },
                };

                dataGridView.InitTable(columns);
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        private void LoadTable(DataGridView dataGridView) {
            try {
                var list = new RecursosViewModel().List().ToList();
                if (list != null)
                    dataGridView.LoadTable(list);
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        private ComboBox LoadComboCountry(ComboBox combo) {
            try {
                combo.LoadCombo<CountryModel>(MappingsDB.Columna_Id, "Name", new CountryModel().List().ToList());
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return combo;
        }

        private void BtnSave_Click(object sender, EventArgs e) {
            try {


            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }


    }
}
