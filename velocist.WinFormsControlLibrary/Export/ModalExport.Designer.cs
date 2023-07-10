namespace velocist.WinFormsControlLibrary.Export {
    partial class ModalExport<T> where T : class{
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
            this.label3 = new System.Windows.Forms.Label();
            this.CmbOutputFileType = new System.Windows.Forms.ComboBox();
            this.TxtOutputFileName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnExport = new System.Windows.Forms.Button();
            this.OfdFilePath = new System.Windows.Forms.OpenFileDialog();
            this.FbdPath = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnExamineBrowser);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.CmbOutputFileType);
            this.groupBox2.Controls.Add(this.TxtOutputFileName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(690, 64);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Exportación";
            // 
            // BtnExamineBrowser
            // 
            this.BtnExamineBrowser.Location = new System.Drawing.Point(609, 28);
            this.BtnExamineBrowser.Name = "BtnExamineBrowser";
            this.BtnExamineBrowser.Size = new System.Drawing.Size(75, 24);
            this.BtnExamineBrowser.TabIndex = 4;
            this.BtnExamineBrowser.Text = "Examinar";
            this.BtnExamineBrowser.UseVisualStyleBackColor = true;
            this.BtnExamineBrowser.Click += new System.EventHandler(this.BtnExamineBrowser_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(442, 33);
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
            this.CmbOutputFileType.Location = new System.Drawing.Point(519, 28);
            this.CmbOutputFileType.Name = "CmbOutputFileType";
            this.CmbOutputFileType.Size = new System.Drawing.Size(77, 23);
            this.CmbOutputFileType.TabIndex = 2;
            // 
            // TxtOutputFileName
            // 
            this.TxtOutputFileName.Location = new System.Drawing.Point(105, 30);
            this.TxtOutputFileName.Name = "TxtOutputFileName";
            this.TxtOutputFileName.Size = new System.Drawing.Size(331, 23);
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
            // BtnExport
            // 
            this.BtnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExport.Location = new System.Drawing.Point(321, 82);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(75, 31);
            this.BtnExport.TabIndex = 5;
            this.BtnExport.Text = "Exportar";
            this.BtnExport.UseVisualStyleBackColor = true;
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // OfdFilePath
            // 
            this.OfdFilePath.FileName = "openFileDialog1";
            // 
            // ModalExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 125);
            this.Controls.Add(this.BtnExport);
            this.Controls.Add(this.groupBox2);
            this.Name = "ModalExport";
            this.Text = "ModalExport";
            this.Load += new System.EventHandler(this.ModalExport_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnExamineBrowser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbOutputFileType;
        private System.Windows.Forms.TextBox TxtOutputFileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnExport;
        private System.Windows.Forms.OpenFileDialog OfdFilePath;
        private System.Windows.Forms.FolderBrowserDialog FbdPath;
    }
}