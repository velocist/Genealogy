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
                //_logger.LogError(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnLoadResults_Click(object sender, EventArgs e) {
            try {
                List<string> list = GedcomFileManager.Read(TxtOutputFileName.Text).ToList();
                if (list != null)
                    DgvData.LoadTable(list);

                TreeNode mainNode = new() {
                    Name = "root",
                    Text = new FileInfo(TxtOutputFileName.Text).Name,
                    Tag = "file"
                };

                GetNode(list, mainNode);
                treeView.Nodes.Add(mainNode);
                treeView.Refresh();

                Gedcom.Core.GedcomConvertHelper.SetGedcomObject(list);
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                MessageBox.Show(ex.Message);
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

        private void treeView_DoubleClick(object sender, EventArgs e) {
            try {
                if (treeView.SelectedNode.IsSelected) {
                    //var data = EnumHelpers.ParseByDescription<ADOPTED_BY_WHICH_PARENT, TagAttribute>(StringTags.HUSBAND, false);
                    //GedComFileManager.SetGedcomObject(list);
                    //_logger.LogDebug("Data");
                }
            } catch (Exception ex) {
                //_logger.LogError(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void GetNode(List<string> list, TreeNode rootNode) {

            int previousLevel = 0;

            TreeNode actualNode;
            TreeNode previousNode = rootNode;

            for (int line = 0; line < list.Count; line++) {
                int actualLevel = int.Parse(list[line].Split(" ")[0]);

                actualNode = new TreeNode {
                    Name = "Line" + line.ToString(),
                    Text = list[line],
                    Tag = actualLevel.ToString(),
                };

                if (actualLevel == 0) {
                    rootNode.Nodes.Add(actualNode);
                } else if (actualLevel > previousLevel) {
                    previousNode.Nodes.Add(actualNode);
                } else if (actualLevel < previousLevel) {
                    int levels = previousLevel - actualLevel;
                    for (int i = 0; i <= levels; i++) {
                        previousNode = previousNode.Parent;
                    }
                    previousNode.Nodes.Add(actualNode);
                } else if (actualLevel == previousLevel) {
                    previousNode.Parent.Nodes.Add(actualNode);
                }

                previousLevel = actualLevel;
                previousNode = actualNode;
            }
        }
    }
}
