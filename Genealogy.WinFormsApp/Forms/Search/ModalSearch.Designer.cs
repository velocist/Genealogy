namespace Genealogy.WinFormsApp.Search {
    partial class ModalSearch  {
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.LblFrom = new System.Windows.Forms.Label();
            this.DtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DtpDateTo);
            this.groupBox1.Controls.Add(this.LblFrom);
            this.groupBox1.Controls.Add(this.DtpDateFrom);
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 93);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hasta";
            // 
            // DtpDateTo
            // 
            this.DtpDateTo.Location = new System.Drawing.Point(51, 53);
            this.DtpDateTo.Name = "DtpDateTo";
            this.DtpDateTo.Size = new System.Drawing.Size(293, 23);
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
            this.DtpDateFrom.Size = new System.Drawing.Size(293, 23);
            this.DtpDateFrom.TabIndex = 0;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSearch.Location = new System.Drawing.Point(533, 156);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 31);
            this.BtnSearch.TabIndex = 6;
            this.BtnSearch.Text = "Buscar";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // FrmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 199);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmSearch";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DtpDateTo;
        private System.Windows.Forms.Label LblFrom;
        private System.Windows.Forms.DateTimePicker DtpDateFrom;
        private System.Windows.Forms.Button BtnSearch;
    }
}