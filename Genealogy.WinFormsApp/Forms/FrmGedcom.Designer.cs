namespace Genealogy.WinFormsApp.Forms {
    partial class FrmGedcom {
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnExamineBrowser = new System.Windows.Forms.Button();
            this.BtnLoadResults = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbOutputFileType = new System.Windows.Forms.ComboBox();
            this.TxtOutputFileName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.OfdFilePath = new System.Windows.Forms.OpenFileDialog();
            this.DgvData = new System.Windows.Forms.DataGridView();
            this.treeView = new System.Windows.Forms.TreeView();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnExamineBrowser);
            this.groupBox2.Controls.Add(this.BtnLoadResults);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.CmbOutputFileType);
            this.groupBox2.Controls.Add(this.TxtOutputFileName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(611, 93);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Exportación";
            // 
            // BtnExamineBrowser
            // 
            this.BtnExamineBrowser.Location = new System.Drawing.Point(530, 29);
            this.BtnExamineBrowser.Name = "BtnExamineBrowser";
            this.BtnExamineBrowser.Size = new System.Drawing.Size(75, 23);
            this.BtnExamineBrowser.TabIndex = 4;
            this.BtnExamineBrowser.Text = "Examinar";
            this.BtnExamineBrowser.UseVisualStyleBackColor = true;
            this.BtnExamineBrowser.Click += new System.EventHandler(this.BtnExamineBrowser_Click);
            // 
            // BtnLoadResults
            // 
            this.BtnLoadResults.Location = new System.Drawing.Point(530, 59);
            this.BtnLoadResults.Name = "BtnLoadResults";
            this.BtnLoadResults.Size = new System.Drawing.Size(75, 23);
            this.BtnLoadResults.TabIndex = 2;
            this.BtnLoadResults.Text = "Cargar";
            this.BtnLoadResults.UseVisualStyleBackColor = true;
            this.BtnLoadResults.Click += new System.EventHandler(this.BtnLoadResults_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tipo archivo";
            // 
            // CmbOutputFileType
            // 
            this.CmbOutputFileType.FormattingEnabled = true;
            this.CmbOutputFileType.Items.AddRange(new object[] {
            "CSV",
            "XSL",
            "XSLS",
            "TXT"});
            this.CmbOutputFileType.Location = new System.Drawing.Point(105, 59);
            this.CmbOutputFileType.Name = "CmbOutputFileType";
            this.CmbOutputFileType.Size = new System.Drawing.Size(121, 23);
            this.CmbOutputFileType.TabIndex = 2;
            // 
            // TxtOutputFileName
            // 
            this.TxtOutputFileName.Location = new System.Drawing.Point(105, 30);
            this.TxtOutputFileName.Name = "TxtOutputFileName";
            this.TxtOutputFileName.Size = new System.Drawing.Size(406, 23);
            this.TxtOutputFileName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombre archivo";
            // 
            // OfdFilePath
            // 
            this.OfdFilePath.FileName = "openFileDialog1";
            // 
            // DgvData
            // 
            this.DgvData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvData.Location = new System.Drawing.Point(12, 111);
            this.DgvData.Name = "DgvData";
            this.DgvData.RowTemplate.Height = 25;
            this.DgvData.Size = new System.Drawing.Size(611, 431);
            this.DgvData.TabIndex = 17;
            this.DgvData.Click += new System.EventHandler(this.DgvData_Click);
            // 
            // treeView
            // 
            this.treeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView.Location = new System.Drawing.Point(629, 111);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(320, 431);
            this.treeView.TabIndex = 18;
            this.treeView.DoubleClick += new System.EventHandler(this.TreeView_DoubleClick);
            // 
            // FrmGedcom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 554);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.DgvData);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmGedcom";
            this.Text = "FrmGedcom";
            this.Load += new System.EventHandler(this.FrmGedcom_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnExamineBrowser;
        private System.Windows.Forms.Button BtnLoadResults;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbOutputFileType;
        private System.Windows.Forms.TextBox TxtOutputFileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog OfdFilePath;
        private System.Windows.Forms.DataGridView DgvData;
        private System.Windows.Forms.TreeView treeView;
    }
}