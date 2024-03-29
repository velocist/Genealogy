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
            groupBox2 = new GroupBox();
            label8 = new Label();
            TxtNumber = new TextBox();
            label7 = new Label();
            label6 = new Label();
            TxtFormat = new TextBox();
            label5 = new Label();
            label4 = new Label();
            TxtAuthor = new TextBox();
            label3 = new Label();
            TxtName = new TextBox();
            FrmExport = new FrmExport();
            CustomTable = new CustomTable();
            FrmSearch = new FrmSearch();
            CommonDataControl = new CommonData();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(TxtNumber);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(TxtFormat);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(TxtAuthor);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(TxtName);
            groupBox2.Location = new Point(12, 438);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(940, 136);
            groupBox2.TabIndex = 30;
            groupBox2.TabStop = false;
            groupBox2.Text = "Detalle";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(286, 63);
            label8.Name = "label8";
            label8.Size = new Size(51, 15);
            label8.TabIndex = 33;
            label8.Text = "Número";
            // 
            // TxtNumber
            // 
            TxtNumber.Location = new Point(286, 81);
            TxtNumber.Name = "TxtNumber";
            TxtNumber.Size = new Size(132, 23);
            TxtNumber.TabIndex = 32;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(424, 63);
            label7.Name = "label7";
            label7.Size = new Size(33, 15);
            label7.TabIndex = 31;
            label7.Text = "Nota";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(7, 63);
            label6.Name = "label6";
            label6.Size = new Size(52, 15);
            label6.TabIndex = 29;
            label6.Text = "Formato";
            // 
            // TxtFormat
            // 
            TxtFormat.Location = new Point(7, 81);
            TxtFormat.Name = "TxtFormat";
            TxtFormat.Size = new Size(273, 23);
            TxtFormat.TabIndex = 28;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(646, 19);
            label5.Name = "label5";
            label5.Size = new Size(64, 15);
            label5.TabIndex = 27;
            label5.Text = "Publicador";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(367, 16);
            label4.Name = "label4";
            label4.Size = new Size(44, 15);
            label4.TabIndex = 25;
            label4.Text = "Author";
            // 
            // TxtAuthor
            // 
            TxtAuthor.Location = new Point(368, 37);
            TxtAuthor.Name = "TxtAuthor";
            TxtAuthor.Size = new Size(272, 23);
            TxtAuthor.TabIndex = 24;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 19);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 23;
            label3.Text = "Name";
            // 
            // TxtName
            // 
            TxtName.Location = new Point(7, 37);
            TxtName.Name = "TxtName";
            TxtName.Size = new Size(355, 23);
            TxtName.TabIndex = 22;
            // 
            // FrmExport
            // 
            FrmExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            FrmExport.InitRowHeader = 0;
            FrmExport.Location = new Point(362, 308);
            FrmExport.MinimumSize = new Size(590, 30);
            FrmExport.Name = "FrmExport";
            FrmExport.OutputFilename = "20232809";
            FrmExport.RowHeader = false;
            FrmExport.Size = new Size(590, 30);
            FrmExport.TabIndex = 38;
            // 
            // CustomTable
            // 
            CustomTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CustomTable.Columns = null;
            CustomTable.Location = new Point(12, 47);
            CustomTable.Name = "CustomTable";
            CustomTable.Size = new Size(940, 255);
            CustomTable.TabIndex = 37;
            // 
            // FrmSearch
            // 
            FrmSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            FrmSearch.Location = new Point(12, 12);
            FrmSearch.MinimumSize = new Size(595, 30);
            FrmSearch.Name = "FrmSearch";
            FrmSearch.Size = new Size(940, 30);
            FrmSearch.TabIndex = 36;
            FrmSearch.TxtTextToSearch = null;
            // 
            // CommonDataControl
            // 
            CommonDataControl.AddDate = null;
            CommonDataControl.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CommonDataControl.Id = null;
            CommonDataControl.LastChange = null;
            CommonDataControl.Location = new Point(19, 344);
            CommonDataControl.Name = "CommonDataControl";
            CommonDataControl.Observations = null;
            CommonDataControl.Size = new Size(933, 88);
            CommonDataControl.TabIndex = 39;
            CommonDataControl.Url = null;
            // 
            // FrmIndices
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(964, 586);
            Controls.Add(CommonDataControl);
            Controls.Add(FrmExport);
            Controls.Add(CustomTable);
            Controls.Add(FrmSearch);
            Controls.Add(groupBox2);
            MinimumSize = new Size(980, 625);
            Name = "FrmIndices";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += FrmIndices_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox2;
        private Label label8;
        private TextBox TxtNumber;
        private Label label7;
        private Label label6;
        private TextBox TxtFormat;
        private Label label5;
        private Label label4;
        private TextBox TxtAuthor;
        private Label label3;
        private TextBox TxtName;
        private FrmExport FrmExport;
        private CustomTable CustomTable;
        private FrmSearch FrmSearch;
        private CommonData CommonDataControl;
    }
}