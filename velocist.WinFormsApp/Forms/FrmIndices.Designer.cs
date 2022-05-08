using System.Windows.Forms;

namespace velocist.WinFormsApp.Forms {
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
            this.DgvData = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.LblFrom = new System.Windows.Forms.Label();
            this.DtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.CmbSurname = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvData)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvData
            // 
            this.DgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvData.Location = new System.Drawing.Point(12, 131);
            this.DgvData.Name = "DgvData";
            this.DgvData.RowTemplate.Height = 25;
            this.DgvData.Size = new System.Drawing.Size(777, 307);
            this.DgvData.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CmbSurname);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DtpDateTo);
            this.groupBox1.Controls.Add(this.LblFrom);
            this.groupBox1.Controls.Add(this.DtpDateFrom);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(777, 113);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(304, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hasta";
            // 
            // DtpDateTo
            // 
            this.DtpDateTo.Location = new System.Drawing.Point(349, 24);
            this.DtpDateTo.Name = "DtpDateTo";
            this.DtpDateTo.Size = new System.Drawing.Size(247, 23);
            this.DtpDateTo.TabIndex = 2;
            // 
            // LblFrom
            // 
            this.LblFrom.AutoSize = true;
            this.LblFrom.Location = new System.Drawing.Point(6, 30);
            this.LblFrom.Name = "LblFrom";
            this.LblFrom.Size = new System.Drawing.Size(39, 15);
            this.LblFrom.TabIndex = 1;
            this.LblFrom.Text = "Desde";
            // 
            // DtpDateFrom
            // 
            this.DtpDateFrom.Location = new System.Drawing.Point(51, 24);
            this.DtpDateFrom.Name = "DtpDateFrom";
            this.DtpDateFrom.Size = new System.Drawing.Size(247, 23);
            this.DtpDateFrom.TabIndex = 0;
            // 
            // CmbSurname
            // 
            this.CmbSurname.FormattingEnabled = true;
            this.CmbSurname.Items.AddRange(new object[] {
            "CSV",
            "XSL",
            "XSLS",
            "TXT"});
            this.CmbSurname.Location = new System.Drawing.Point(51, 53);
            this.CmbSurname.Name = "CmbSurname";
            this.CmbSurname.Size = new System.Drawing.Size(247, 23);
            this.CmbSurname.TabIndex = 4;
            // 
            // FrmIndices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DgvData);
            this.Name = "FrmIndices";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmIndices_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView DgvData;
        private GroupBox groupBox1;
        private Label label1;
        private DateTimePicker DtpDateTo;
        private Label LblFrom;
        private DateTimePicker DtpDateFrom;
        private ComboBox CmbSurname;
    }
}