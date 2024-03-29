namespace Genealogy.WinFormsApp.Forms {
    partial class FrmFamilySearch {
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
            groupBox1 = new GroupBox();
            BtnExport = new Button();
            BtnSearch = new Button();
            CmbSurname = new ComboBox();
            label1 = new Label();
            DtpDateTo = new DateTimePicker();
            LblFrom = new Label();
            DtpDateFrom = new DateTimePicker();
            DgvData = new DataGridView();
            FrmGenericExport = new velocist.WinFormsControlLibrary.FrmGenericExport();
            buttonControl1 = new velocist.WinFormsControlLibrary.ButtonControl();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvData).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(BtnSearch);
            groupBox1.Controls.Add(CmbSurname);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(DtpDateTo);
            groupBox1.Controls.Add(LblFrom);
            groupBox1.Controls.Add(DtpDateFrom);
            groupBox1.Location = new Point(6, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(817, 82);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtros";
            // 
            // BtnExport
            // 
            BtnExport.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            BtnExport.Location = new Point(748, 494);
            BtnExport.Name = "BtnExport";
            BtnExport.Size = new Size(75, 33);
            BtnExport.TabIndex = 13;
            BtnExport.Text = "Export";
            BtnExport.Click += BtnExport_Click;
            // 
            // BtnSearch
            // 
            BtnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnSearch.Location = new Point(736, 16);
            BtnSearch.Name = "BtnSearch";
            BtnSearch.Size = new Size(75, 33);
            BtnSearch.TabIndex = 16;
            BtnSearch.Text = "Buscar";
            // 
            // CmbSurname
            // 
            CmbSurname.FormattingEnabled = true;
            CmbSurname.Items.AddRange(new object[] { "CSV", "XSL", "XSLS", "TXT" });
            CmbSurname.Location = new Point(436, 20);
            CmbSurname.Name = "CmbSurname";
            CmbSurname.Size = new Size(247, 23);
            CmbSurname.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 53);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 3;
            label1.Text = "Hasta";
            // 
            // DtpDateTo
            // 
            DtpDateTo.Location = new Point(51, 49);
            DtpDateTo.Name = "DtpDateTo";
            DtpDateTo.Size = new Size(247, 23);
            DtpDateTo.TabIndex = 2;
            // 
            // LblFrom
            // 
            LblFrom.AutoSize = true;
            LblFrom.Location = new Point(6, 23);
            LblFrom.Name = "LblFrom";
            LblFrom.Size = new Size(39, 15);
            LblFrom.TabIndex = 1;
            LblFrom.Text = "Desde";
            // 
            // DtpDateFrom
            // 
            DtpDateFrom.Location = new Point(51, 19);
            DtpDateFrom.Name = "DtpDateFrom";
            DtpDateFrom.Size = new Size(247, 23);
            DtpDateFrom.TabIndex = 0;
            // 
            // DgvData
            // 
            DgvData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvData.Location = new Point(6, 100);
            DgvData.Name = "DgvData";
            DgvData.RowTemplate.Height = 25;
            DgvData.Size = new Size(817, 388);
            DgvData.TabIndex = 9;
            // 
            // FrmGenericExport
            // 
            FrmGenericExport.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            FrmGenericExport.InitRowHeader = 0;
            FrmGenericExport.Location = new Point(6, 547);
            FrmGenericExport.MaximumSize = new Size(0, 45);
            FrmGenericExport.MinimumSize = new Size(740, 45);
            FrmGenericExport.Name = "FrmGenericExport";
            FrmGenericExport.OutputFilename = "20232009";
            FrmGenericExport.RowHeader = false;
            FrmGenericExport.Size = new Size(817, 45);
            FrmGenericExport.TabIndex = 18;
            FrmGenericExport.Type = null;
            // 
            // buttonControl1
            // 
            buttonControl1.Location = new Point(6, 598);
            buttonControl1.MaximumSize = new Size(0, 40);
            buttonControl1.MinimumSize = new Size(770, 40);
            buttonControl1.Name = "buttonControl1";
            buttonControl1.Size = new Size(817, 40);
            buttonControl1.TabIndex = 19;
            // 
            // FrmFamilySearch
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(834, 647);
            Controls.Add(BtnExport);
            Controls.Add(buttonControl1);
            Controls.Add(FrmGenericExport);
            Controls.Add(groupBox1);
            Controls.Add(DgvData);
            MaximumSize = new Size(850, 686);
            MinimumSize = new Size(818, 686);
            Name = "FrmFamilySearch";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Family Search";
            Load += FrmFamilySearch_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvData).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private ComboBox CmbSurname;
        private Label label1;
        private DateTimePicker DtpDateTo;
        private Label LblFrom;
        private DateTimePicker DtpDateFrom;
        private DataGridView DgvData;
        private Button BtnExport;
        private Button BtnSearch;
        private velocist.WinFormsControlLibrary.FrmGenericExport FrmGenericExport;
        private velocist.WinFormsControlLibrary.ButtonControl buttonControl1;
    }
}