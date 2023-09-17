namespace Genealogy.WinFormsApp.Forms {
    partial class FrmIndices {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            DgvData = new DataGridView();
            groupBox1 = new GroupBox();
            CmbSurname = new ComboBox();
            label1 = new Label();
            DtpDateTo = new DateTimePicker();
            LblFrom = new Label();
            DtpDateFrom = new DateTimePicker();
            BtnExport = new Button();
            frmGenericExport1 = new velocist.WinFormsControlLibrary.FrmGenericExport();
            BtnCancel = new Button();
            BtnSave = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel2 = new Panel();
            flowLayoutPanel3 = new FlowLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)DgvData).BeginInit();
            groupBox1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // DgvData
            // 
            DgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvData.Location = new Point(12, 131);
            DgvData.Name = "DgvData";
            DgvData.RowTemplate.Height = 25;
            DgvData.Size = new Size(777, 156);
            DgvData.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(CmbSurname);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(DtpDateTo);
            groupBox1.Controls.Add(LblFrom);
            groupBox1.Controls.Add(DtpDateFrom);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(777, 113);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtros";
            // 
            // CmbSurname
            // 
            CmbSurname.FormattingEnabled = true;
            CmbSurname.Items.AddRange(new object[] { "CSV", "XSL", "XSLS", "TXT" });
            CmbSurname.Location = new Point(51, 53);
            CmbSurname.Name = "CmbSurname";
            CmbSurname.Size = new Size(247, 23);
            CmbSurname.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(304, 30);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 3;
            label1.Text = "Hasta";
            // 
            // DtpDateTo
            // 
            DtpDateTo.Location = new Point(349, 24);
            DtpDateTo.Name = "DtpDateTo";
            DtpDateTo.Size = new Size(247, 23);
            DtpDateTo.TabIndex = 2;
            // 
            // LblFrom
            // 
            LblFrom.AutoSize = true;
            LblFrom.Location = new Point(6, 30);
            LblFrom.Name = "LblFrom";
            LblFrom.Size = new Size(39, 15);
            LblFrom.TabIndex = 1;
            LblFrom.Text = "Desde";
            // 
            // DtpDateFrom
            // 
            DtpDateFrom.Location = new Point(51, 24);
            DtpDateFrom.Name = "DtpDateFrom";
            DtpDateFrom.Size = new Size(247, 23);
            DtpDateFrom.TabIndex = 0;
            // 
            // BtnExport
            // 
            BtnExport.Location = new Point(84, 3);
            BtnExport.Name = "BtnExport";
            BtnExport.Size = new Size(75, 33);
            BtnExport.TabIndex = 0;
            BtnExport.Text = "Export";
            BtnExport.Click += BtnExport_Click;
            // 
            // frmGenericExport1
            // 
            frmGenericExport1.Location = new Point(12, 514);
            frmGenericExport1.MaximumSize = new Size(675, 70);
            frmGenericExport1.MinimumSize = new Size(675, 70);
            frmGenericExport1.Name = "frmGenericExport1";
            frmGenericExport1.OutputFilename = "Export_20231609";
            frmGenericExport1.Size = new Size(675, 70);
            frmGenericExport1.TabIndex = 4;
            // 
            // BtnCancel
            // 
            BtnCancel.Location = new Point(5, 3);
            BtnCancel.Name = "BtnCancel";
            BtnCancel.Size = new Size(65, 33);
            BtnCancel.TabIndex = 0;
            BtnCancel.Text = "Cancelar";
            BtnCancel.UseVisualStyleBackColor = true;
            BtnCancel.Click += BtnCancel_Click;
            // 
            // BtnSave
            // 
            BtnSave.Location = new Point(76, 3);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(75, 33);
            BtnSave.TabIndex = 1;
            BtnSave.Text = "Guardar";
            BtnSave.Click += BtnSave_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.Controls.Add(BtnSave);
            flowLayoutPanel1.Controls.Add(BtnCancel);
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(622, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(154, 39);
            flowLayoutPanel1.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(flowLayoutPanel3);
            panel2.Controls.Add(flowLayoutPanel2);
            panel2.Controls.Add(flowLayoutPanel1);
            panel2.Location = new Point(12, 590);
            panel2.Name = "panel2";
            panel2.Size = new Size(779, 45);
            panel2.TabIndex = 7;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel3.Location = new Point(168, 3);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(453, 39);
            flowLayoutPanel3.TabIndex = 8;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel2.Controls.Add(button1);
            flowLayoutPanel2.Controls.Add(BtnExport);
            flowLayoutPanel2.Location = new Point(3, 3);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(162, 39);
            flowLayoutPanel2.TabIndex = 7;
            // 
            // button1
            // 
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(75, 33);
            button1.TabIndex = 1;
            button1.Text = "Export";
            // 
            // FrmIndices
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(802, 647);
            Controls.Add(panel2);
            Controls.Add(frmGenericExport1);
            Controls.Add(groupBox1);
            Controls.Add(DgvData);
            MaximumSize = new Size(818, 686);
            MinimumSize = new Size(818, 686);
            Name = "FrmIndices";
            Text = "Form1";
            Load += FrmIndices_Load;
            ((System.ComponentModel.ISupportInitialize)DgvData).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DgvData;
        private GroupBox groupBox1;
        private Label label1;
        private DateTimePicker DtpDateTo;
        private Label LblFrom;
        private DateTimePicker DtpDateFrom;
        private ComboBox CmbSurname;
        private Button BtnExport;
        private velocist.WinFormsControlLibrary.FrmGenericExport frmGenericExport1;
        private Button BtnCancel;
        private Button BtnSave;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel2;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel3;
        private Button button1;
    }
}