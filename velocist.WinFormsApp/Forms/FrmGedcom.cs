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

				_ = dataGridView.InitTable(columns);
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
				_ = MessageBox.Show(ex.Message);
			}
		}

		private void BtnLoadResults_Click(object sender, EventArgs e) {
			try {
				var list = GedcomFileManager.Read(TxtOutputFileName.Text).ToList();
				if (list != null)
					_ = DgvData.LoadTable(list);

				TreeNode mainNode = new() {
					Name = "root",
					Text = new FileInfo(TxtOutputFileName.Text).Name,
					Tag = "file"
				};

				GetNode(list, mainNode);
				_ = treeView.Nodes.Add(mainNode);
				treeView.Refresh();

				Gedcom.Core.GedcomConvertHelper.SetGedcomObject(list);
			} catch (Exception ex) {
				_logger.LogError(ex, ex.Message);
				_ = MessageBox.Show(ex.Message);
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
				_ = MessageBox.Show(ex.Message);
			}
		}

		private void TreeView_DoubleClick(object sender, EventArgs e) {
			try {
				if (treeView.SelectedNode.IsSelected) {
					//var data = EnumHelpers.ParseByDescription<ADOPTED_BY_WHICH_PARENT, TagAttribute>(StringTags.HUSBAND, false);
					//GedComFileManager.SetGedcomObject(list);
					//_logger.LogDebug("Data");
				}
			} catch (Exception ex) {
				//_logger.LogError(ex.Message);
				_ = MessageBox.Show(ex.Message);
			}
		}

		private static void GetNode(List<string> list, TreeNode rootNode) {

			var previousLevel = 0;

			TreeNode actualNode;
			var previousNode = rootNode;

			for (var line = 0; line < list.Count; line++) {
				var actualLevel = int.Parse(list[line].Split(" ")[0]);

				actualNode = new TreeNode {
					Name = "Line" + line.ToString(),
					Text = list[line],
					Tag = actualLevel.ToString(),
				};

				if (actualLevel == 0) {
					_ = rootNode.Nodes.Add(actualNode);
				} else if (actualLevel > previousLevel) {
					_ = previousNode.Nodes.Add(actualNode);
				} else if (actualLevel < previousLevel) {
					var levels = previousLevel - actualLevel;
					for (var i = 0; i <= levels; i++) {
						previousNode = previousNode.Parent;
					}

					_ = previousNode.Nodes.Add(actualNode);
				} else if (actualLevel == previousLevel) {
					_ = previousNode.Parent.Nodes.Add(actualNode);
				}

				previousLevel = actualLevel;
				previousNode = actualNode;
			}
		}
	}
}
