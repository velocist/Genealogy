using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;
using velocist.Gedcom.Core;
using velocist.WinForms;

namespace velocist.WinFormsApp.Forms {
    public partial class FrmGedcom : Form {

        private readonly ILogger<FrmGedcom> _logger;

        public FrmGedcom() {
            InitializeComponent();
            _logger = LogService.LogServiceContainer.GetLog<FrmGedcom>();
        }

        private static void InitTable(DataGridView dataGridView) {
            try {
                //var combo = MainModel.GetRegisters().ToList();
                Dictionary<int, object> columns = new() {
                    { 0, DataGridViewExtension.CreateTextBox("Linea", "Linea") },
                };

                dataGridView.InitTable(columns);
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        private void BtnExamineBrowser_Click(object sender, EventArgs e) {
            try {
                if (OfdFilePath.ShowDialog() == DialogResult.OK) {
                    TxtOutputFileName.Text = OfdFilePath.FileName;
                }
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private int line = 0;
        private int root = 0;

        private void BtnLoadResults_Click(object sender, EventArgs e) {
            try {
                List<string> list = GedComFileManager.Read(TxtOutputFileName.Text).ToList();
                if (list != null)
                    DgvData.LoadTable(list);

                GedComFileManager.SetGedcomObject(list);

                TreeNode mainNode = new TreeNode {
                    Text = new FileInfo(TxtOutputFileName.Text).Name,
                    Tag = "file"
                };

                for (line = 0; line < list.Count; line++) {

                    TreeNode subNode = new TreeNode();
                    if (line != list.Count && list[line].StartsWith("0")) {
                        root = 0;
                        subNode.Text = list[line];
                        subNode.Tag = "node" + line.ToString();
                        var node = mainNode.Nodes.Add(list[line]);
                        line++;

                        TreeNode subNode2 = new TreeNode();
                        if (line != list.Count && !list[line].StartsWith((root).ToString())) {
                            subNode2.Text = list[line];
                            subNode2.Tag = "node" + line.ToString();
                            node.Nodes.Add(subNode2);
                            root++;
                            line++;

                            bool continued = true;
                            while (continued) {
                                continued = GetNode(list, subNode2);
                            }
                        }
                    }
                }
                treeView.Nodes.Add(mainNode);
            } catch (Exception ex) {
                //_logger.LogError(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private bool GetNode(List<string> list, TreeNode subNode) {
            if (line != list.Count && list[line].StartsWith((root + 1).ToString())) {
                TreeNode subNode2 = new TreeNode {
                    Text = list[line],
                    Tag = "node" + line.ToString()
                };
                subNode.Nodes.Add(subNode2);
                line++;
                return true;
            } else {
                return false;
            }
        }

        private void FrmGedcom_Load(object sender, EventArgs e) =>
            //InitTable(DgvData);
            DgvData.ConfigureTable();

        private void DgvData_Click(object sender, EventArgs e) {
            try {
                //if (DgvData.SelectedRows.Count > 0) {
                //    var row = DgvData.SelectedRows[0];
                //}
            } catch (Exception ex) {
                //_logger.LogError(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
    }
}
