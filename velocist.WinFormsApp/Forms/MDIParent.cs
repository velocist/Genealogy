using System;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;
using velocist.WinForms;
using velocist.WinFormsApp.Forms.Login;

namespace velocist.WinFormsApp.Forms {
    public partial class MDIParent : Form {

        private int childFormNumber = 0;

        private readonly ILogger<MDIParent> _logger;

        public MDIParent() {
            InitializeComponent();
            this.ConfigureForm("Genealogia");
            _logger = LogService.LogServiceContainer.GetLog<MDIParent>();
        }

        private void ShowNewForm(object sender, EventArgs e) {
            Form childForm = new Form {
                MdiParent = this,
                Text = "Ventana " + childFormNumber++
            };
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"
            };
            if (openFileDialog.ShowDialog(this) == DialogResult.OK) {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveFileDialog saveFileDialog = new SaveFileDialog {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"
            };
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK) {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e) => this.Close();

        private void CutToolStripMenuItem_Click(object sender, EventArgs e) {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e) {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e) {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e) => toolStrip.Visible = toolBarToolStripMenuItem.Checked;

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e) => statusStrip.Visible = statusBarToolStripMenuItem.Checked;

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e) => LayoutMdi(MdiLayout.Cascade);

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e) => LayoutMdi(MdiLayout.TileVertical);

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e) => LayoutMdi(MdiLayout.TileHorizontal);

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e) => LayoutMdi(MdiLayout.ArrangeIcons);

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e) {
            foreach (Form childForm in MdiChildren) {
                childForm.Close();
            }
        }

        private void frmIndices_Click(object sender, EventArgs e) {
            try {
                if (!this.CheckOpenForms<FrmIndices>()) {
                    FrmIndices frm = new();
                    frm.MdiParent = this;
                    frm.Show();
                }
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmRecursos_Click(object sender, EventArgs e) {
            try {
                if (!this.CheckOpenForms<FrmRecursos>()) {
                    FrmRecursos frm = new();
                    frm.MdiParent = this;
                    frm.Show();
                }
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exportarToolStripMenuItem_Click_1(object sender, EventArgs e) {
            try {
                //if (!this.CheckOpenForms<FrmExport>()) {
                //    FrmExport frm = new();
                //    frm.MdiParent = this;
                //    frm.Show();
                //}
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gedcomToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                if (!this.CheckOpenForms<FrmGedcom>()) {
                    FrmGedcom frm = new();
                    frm.MdiParent = this;
                    frm.Show();
                }
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SignInToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                if (!this.CheckOpenForms<FrmLogin>()) {
                    FrmLogin frm = new();
                    frm.MdiParent = this;
                    frm.Show();
                }
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
