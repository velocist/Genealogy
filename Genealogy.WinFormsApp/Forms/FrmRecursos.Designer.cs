namespace Genealogy.WinFormsApp.Forms {
    partial class FrmRecursos {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRecursos));
            GbxData = new GroupBox();
            label8 = new Label();
            TxtTipo = new TextBox();
            label7 = new Label();
            TxtDescription = new TextBox();
            label6 = new Label();
            TxtPartidoJudicial = new TextBox();
            label5 = new Label();
            TxtProvince = new TextBox();
            label4 = new Label();
            TxtTown = new TextBox();
            label3 = new Label();
            TxtName = new TextBox();
            FrmSearch = new FrmSearch();
            CustomTable = new CustomTable();
            CommonDataControl = new CommonData();
            ToolTrip = new ToolStrip();
            ToolBtnAdd = new ToolStripButton();
            ToolBtnSave = new ToolStripButton();
            ToolBtnEdit = new ToolStripButton();
            ToolBtnDelete = new ToolStripButton();
            ToolBtnCancel = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            ToolBtnImport = new ToolStripButton();
            ToolBtnExport = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            printToolStripButton = new ToolStripButton();
            printPreviewToolStripButton = new ToolStripButton();
            toolStripSeparator9 = new ToolStripSeparator();
            helpToolStripButton = new ToolStripButton();
            GbxData.SuspendLayout();
            ToolTrip.SuspendLayout();
            SuspendLayout();
            // 
            // GbxData
            // 
            GbxData.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            GbxData.Controls.Add(label8);
            GbxData.Controls.Add(TxtTipo);
            GbxData.Controls.Add(label7);
            GbxData.Controls.Add(TxtDescription);
            GbxData.Controls.Add(label6);
            GbxData.Controls.Add(TxtPartidoJudicial);
            GbxData.Controls.Add(label5);
            GbxData.Controls.Add(TxtProvince);
            GbxData.Controls.Add(label4);
            GbxData.Controls.Add(TxtTown);
            GbxData.Controls.Add(label3);
            GbxData.Controls.Add(TxtName);
            GbxData.Location = new Point(12, 545);
            GbxData.Name = "GbxData";
            GbxData.Size = new Size(984, 120);
            GbxData.TabIndex = 29;
            GbxData.TabStop = false;
            GbxData.Text = "Detalle";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(285, 63);
            label8.Name = "label8";
            label8.Size = new Size(30, 15);
            label8.TabIndex = 33;
            label8.Text = "Tipo";
            // 
            // TxtTipo
            // 
            TxtTipo.Enabled = false;
            TxtTipo.Location = new Point(285, 81);
            TxtTipo.Name = "TxtTipo";
            TxtTipo.Size = new Size(132, 23);
            TxtTipo.TabIndex = 32;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(423, 63);
            label7.Name = "label7";
            label7.Size = new Size(69, 15);
            label7.TabIndex = 31;
            label7.Text = "Descripción";
            // 
            // TxtDescription
            // 
            TxtDescription.Enabled = false;
            TxtDescription.Location = new Point(423, 81);
            TxtDescription.Name = "TxtDescription";
            TxtDescription.Size = new Size(511, 23);
            TxtDescription.TabIndex = 30;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 63);
            label6.Name = "label6";
            label6.Size = new Size(86, 15);
            label6.TabIndex = 29;
            label6.Text = "Partido judicial";
            // 
            // TxtPartidoJudicial
            // 
            TxtPartidoJudicial.Enabled = false;
            TxtPartidoJudicial.Location = new Point(6, 81);
            TxtPartidoJudicial.Name = "TxtPartidoJudicial";
            TxtPartidoJudicial.Size = new Size(273, 23);
            TxtPartidoJudicial.TabIndex = 28;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(645, 19);
            label5.Name = "label5";
            label5.Size = new Size(56, 15);
            label5.TabIndex = 27;
            label5.Text = "Provincia";
            // 
            // TxtProvince
            // 
            TxtProvince.Enabled = false;
            TxtProvince.Location = new Point(645, 37);
            TxtProvince.Name = "TxtProvince";
            TxtProvince.Size = new Size(289, 23);
            TxtProvince.TabIndex = 26;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(366, 16);
            label4.Name = "label4";
            label4.Size = new Size(44, 15);
            label4.TabIndex = 25;
            label4.Text = "Pueblo";
            // 
            // TxtTown
            // 
            TxtTown.Enabled = false;
            TxtTown.Location = new Point(367, 37);
            TxtTown.Name = "TxtTown";
            TxtTown.Size = new Size(272, 23);
            TxtTown.TabIndex = 24;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 19);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 23;
            label3.Text = "Name";
            // 
            // TxtName
            // 
            TxtName.Enabled = false;
            TxtName.Location = new Point(6, 37);
            TxtName.Name = "TxtName";
            TxtName.Size = new Size(355, 23);
            TxtName.TabIndex = 22;
            // 
            // FrmSearch
            // 
            FrmSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            FrmSearch.Location = new Point(12, 28);
            FrmSearch.MinimumSize = new Size(595, 30);
            FrmSearch.Name = "FrmSearch";
            FrmSearch.Size = new Size(984, 30);
            FrmSearch.TabIndex = 27;
            FrmSearch.TxtTextToSearch = null;
            // 
            // CustomTable
            // 
            CustomTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CustomTable.Columns = null;
            CustomTable.Location = new Point(12, 63);
            CustomTable.Name = "CustomTable";
            CustomTable.Size = new Size(984, 382);
            CustomTable.TabIndex = 32;
            // 
            // CommonDataControl
            // 
            CommonDataControl.AddDate = null;
            CommonDataControl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CommonDataControl.Id = null;
            CommonDataControl.LastChange = null;
            CommonDataControl.Location = new Point(12, 451);
            CommonDataControl.Name = "CommonDataControl";
            CommonDataControl.Observations = null;
            CommonDataControl.Size = new Size(984, 88);
            CommonDataControl.TabIndex = 43;
            CommonDataControl.Url = null;
            // 
            // ToolTrip
            // 
            ToolTrip.BackColor = Color.LightSteelBlue;
            ToolTrip.GripStyle = ToolStripGripStyle.Hidden;
            ToolTrip.Items.AddRange(new ToolStripItem[] { ToolBtnAdd, ToolBtnSave, ToolBtnEdit, ToolBtnDelete, ToolBtnCancel, toolStripSeparator1, ToolBtnImport, ToolBtnExport, toolStripSeparator2, printToolStripButton, printPreviewToolStripButton, toolStripSeparator9, helpToolStripButton });
            ToolTrip.Location = new Point(0, 0);
            ToolTrip.Name = "ToolTrip";
            ToolTrip.RenderMode = ToolStripRenderMode.Professional;
            ToolTrip.Size = new Size(1008, 25);
            ToolTrip.TabIndex = 44;
            ToolTrip.Text = "Acciones";
            // 
            // ToolBtnAdd
            // 
            ToolBtnAdd.BackColor = Color.Transparent;
            ToolBtnAdd.Image = (Image)resources.GetObject("ToolBtnAdd.Image");
            ToolBtnAdd.ImageTransparentColor = Color.Black;
            ToolBtnAdd.Name = "ToolBtnAdd";
            ToolBtnAdd.Size = new Size(62, 22);
            ToolBtnAdd.Text = "Nuevo";
            ToolBtnAdd.Click += BtnAdd_Click;
            // 
            // ToolBtnSave
            // 
            ToolBtnSave.BackColor = Color.Transparent;
            ToolBtnSave.Image = (Image)resources.GetObject("ToolBtnSave.Image");
            ToolBtnSave.ImageTransparentColor = Color.Black;
            ToolBtnSave.Name = "ToolBtnSave";
            ToolBtnSave.Size = new Size(69, 22);
            ToolBtnSave.Text = "Guardar";
            ToolBtnSave.Click += BtnSave_Click;
            // 
            // ToolBtnEdit
            // 
            ToolBtnEdit.BackColor = Color.Transparent;
            ToolBtnEdit.Image = (Image)resources.GetObject("ToolBtnEdit.Image");
            ToolBtnEdit.ImageTransparentColor = Color.Magenta;
            ToolBtnEdit.Name = "ToolBtnEdit";
            ToolBtnEdit.Size = new Size(57, 22);
            ToolBtnEdit.Text = "Editar";
            ToolBtnEdit.Click += BtnEdit_Click;
            // 
            // ToolBtnDelete
            // 
            ToolBtnDelete.BackColor = Color.Transparent;
            ToolBtnDelete.Image = (Image)resources.GetObject("ToolBtnDelete.Image");
            ToolBtnDelete.ImageTransparentColor = Color.Magenta;
            ToolBtnDelete.Name = "ToolBtnDelete";
            ToolBtnDelete.Size = new Size(70, 22);
            ToolBtnDelete.Text = "Eliminar";
            ToolBtnDelete.ToolTipText = "Eliminar";
            ToolBtnDelete.Click += BtnDelete_Click;
            // 
            // ToolBtnCancel
            // 
            ToolBtnCancel.BackColor = Color.Transparent;
            ToolBtnCancel.Image = (Image)resources.GetObject("ToolBtnCancel.Image");
            ToolBtnCancel.ImageTransparentColor = Color.Magenta;
            ToolBtnCancel.Name = "ToolBtnCancel";
            ToolBtnCancel.Size = new Size(73, 22);
            ToolBtnCancel.Text = "Cancelar";
            ToolBtnCancel.Click += BtnCancel_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // ToolBtnImport
            // 
            ToolBtnImport.BackColor = Color.Transparent;
            ToolBtnImport.Image = (Image)resources.GetObject("ToolBtnImport.Image");
            ToolBtnImport.ImageTransparentColor = Color.Magenta;
            ToolBtnImport.Name = "ToolBtnImport";
            ToolBtnImport.Size = new Size(73, 22);
            ToolBtnImport.Text = "Importar";
            ToolBtnImport.Click += ToolBtnImport_Click;
            // 
            // ToolBtnExport
            // 
            ToolBtnExport.BackColor = Color.Transparent;
            ToolBtnExport.Image = (Image)resources.GetObject("ToolBtnExport.Image");
            ToolBtnExport.ImageTransparentColor = Color.Black;
            ToolBtnExport.Name = "ToolBtnExport";
            ToolBtnExport.Size = new Size(71, 22);
            ToolBtnExport.Text = "Exportar";
            ToolBtnExport.Click += ToolBtnExport_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // printToolStripButton
            // 
            printToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            printToolStripButton.Image = (Image)resources.GetObject("printToolStripButton.Image");
            printToolStripButton.ImageTransparentColor = Color.Black;
            printToolStripButton.Name = "printToolStripButton";
            printToolStripButton.Size = new Size(23, 22);
            printToolStripButton.Text = "Imprimir";
            // 
            // printPreviewToolStripButton
            // 
            printPreviewToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            printPreviewToolStripButton.Image = (Image)resources.GetObject("printPreviewToolStripButton.Image");
            printPreviewToolStripButton.ImageTransparentColor = Color.Black;
            printPreviewToolStripButton.Name = "printPreviewToolStripButton";
            printPreviewToolStripButton.Size = new Size(23, 22);
            printPreviewToolStripButton.Text = "Vista previa de impresión";
            // 
            // toolStripSeparator9
            // 
            toolStripSeparator9.Name = "toolStripSeparator9";
            toolStripSeparator9.Size = new Size(6, 25);
            // 
            // helpToolStripButton
            // 
            helpToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            helpToolStripButton.Image = (Image)resources.GetObject("helpToolStripButton.Image");
            helpToolStripButton.ImageTransparentColor = Color.Black;
            helpToolStripButton.Name = "helpToolStripButton";
            helpToolStripButton.Size = new Size(23, 22);
            helpToolStripButton.Text = "Ayuda";
            // 
            // FrmRecursos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1008, 677);
            Controls.Add(ToolTrip);
            Controls.Add(CommonDataControl);
            Controls.Add(CustomTable);
            Controls.Add(GbxData);
            Controls.Add(FrmSearch);
            MinimumSize = new Size(980, 625);
            Name = "FrmRecursos";
            Text = "FrmRecurso";
            Load += FrmRecurso_Load;
            GbxData.ResumeLayout(false);
            GbxData.PerformLayout();
            ToolTrip.ResumeLayout(false);
            ToolTrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label8;
        private TextBox TxtTipo;
        private Label label7;
        private TextBox TxtDescription;
        private Label label6;
        private TextBox TxtPartidoJudicial;
        private Label label5;
        private TextBox TxtProvince;
        private Label label4;
        private TextBox TxtTown;
        private Label label3;
        private TextBox TxtName;
        private FrmSearch FrmSearch;
        private ButtonControllerVertical BtnControllerVertical;
        private CustomTable CustomTable;
        private GroupBox GbxData;
        private CommonData CommonDataControl;
        private ToolStrip ToolTrip;
        private ToolStripButton ToolBtnAdd;
        private ToolStripButton ToolBtnSave;
        private ToolStripButton ToolBtnDelete;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton ToolBtnImport;
        private ToolStripButton ToolBtnExport;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton printToolStripButton;
        private ToolStripButton printPreviewToolStripButton;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripButton helpToolStripButton;
        private ToolStripButton ToolBtnCancel;
        private ToolStripButton ToolBtnEdit;
    }
}