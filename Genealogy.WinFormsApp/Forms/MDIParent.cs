namespace Genealogy.WinFormsApp.Forms {
	public partial class MDIParent : Form {

		private int childFormNumber = 0;

		//private readonly UserManager<User> _userManager;
		//private readonly SignInManager<User> _signInManager;
		private readonly ILogger<MDIParent> _logger;

		/// <summary>
		/// Initializes a new instance of the <see cref="MDIParent"/> class.
		/// </summary>
		[Obsolete]
		public MDIParent() {
			InitializeComponent();
			//_userManager = (UserManager<User>)serviceProvider.GetService(typeof(UserManager<User>));
			//_signInManager = (SignInManager<User>)serviceProvider.GetService(typeof(SignInManager<User>)); ;
			_logger = LogServiceContainer.GetLog<MDIParent>();
			this.ConfigureForm("Genealogia");
		}

		/// <summary>
		/// Shows the new form.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void ShowNewForm(object sender, EventArgs e) {
			Form childForm = new() {
				MdiParent = this,
				Text = "Ventana " + childFormNumber++
			};
			childForm.Show();
		}

		/// <summary>
		/// Opens the file.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void OpenFile(object sender, EventArgs e) {
			OpenFileDialog openFileDialog = new() {
				InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal),
				Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"
			};
			if (openFileDialog.ShowDialog(this) == DialogResult.OK) {
				//TODO string FileName = openFileDialog.FileName;
			}
		}

		/// <summary>
		/// Handles the Click event of the SaveAsToolStripMenuItem control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e) {
			SaveFileDialog saveFileDialog = new() {
				InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal),
				Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"
			};
			if (saveFileDialog.ShowDialog(this) == DialogResult.OK) {
				//TODO string FileName = saveFileDialog.FileName;
			}
		}

		private void ExitToolsStripMenuItem_Click(object sender, EventArgs e) => Close();

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
			foreach (var childForm in MdiChildren) {
				childForm.Close();
			}
		}

		[Obsolete]
		private void FrmIndices_Click(object sender, EventArgs e) {
			try {
				if (!this.CheckOpenForms<FrmIndices>()) {
					FrmIndices frm = new() {
						MdiParent = this
					};
					frm.Show();
				}
			} catch (Exception ex) {
				_logger.LogError(ex.Message);
				_ = MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		[Obsolete]
		private void FrmRecursos_Click(object sender, EventArgs e) {
			try {
				if (!this.CheckOpenForms<FrmRecursos>()) {
					FrmRecursos frm = new() {
						MdiParent = this
					};
					frm.Show();
				}
			} catch (Exception ex) {
				_logger.LogError(ex.Message);
				_ = MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		[Obsolete]
		private void GedcomToolStripMenuItem_Click(object sender, EventArgs e) {
			try {
				if (!this.CheckOpenForms<FrmGedcom>()) {
					FrmGedcom frm = new() {
						MdiParent = this
					};
					frm.Show();
				}
			} catch (Exception ex) {
				_logger.LogError(ex.Message);
				_ = MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void SignInToolStripMenuItem_Click(object sender, EventArgs e) {
			try {
				//if (!this.CheckOpenForms<FrmLogin>()) {
				//    FrmLogin frm = new(_signInManager,_userManager);
				//    frm.MdiParent = this;
				//    frm.Show();
				//}
			} catch (Exception ex) {
				_logger.LogError(ex.Message);
				_ = MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
