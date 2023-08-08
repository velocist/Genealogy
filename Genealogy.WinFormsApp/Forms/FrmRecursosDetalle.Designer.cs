namespace Genealogy.WinFormsApp.Forms {
    partial class FrmRecursosDetalle {
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
            this.BtnSave = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.gbxId = new System.Windows.Forms.GroupBox();
            this.TxtId = new System.Windows.Forms.TextBox();
            this.gbxName = new System.Windows.Forms.GroupBox();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.gbxDescription = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.gbxTown = new System.Windows.Forms.GroupBox();
            this.TxtTown = new System.Windows.Forms.TextBox();
            this.gbProvince = new System.Windows.Forms.GroupBox();
            this.TxtProvince = new System.Windows.Forms.TextBox();
            this.gbxCity = new System.Windows.Forms.GroupBox();
            this.TxtCity = new System.Windows.Forms.TextBox();
            this.gbxCountry = new System.Windows.Forms.GroupBox();
            this.CmbCountry = new System.Windows.Forms.ComboBox();
            this.gbxJudicialParty = new System.Windows.Forms.GroupBox();
            this.TxtJudicialParty = new System.Windows.Forms.TextBox();
            this.gbxUrl = new System.Windows.Forms.GroupBox();
            this.TxtUrl = new System.Windows.Forms.TextBox();
            this.gbNotes = new System.Windows.Forms.GroupBox();
            this.TxtNotes = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.gbxId.SuspendLayout();
            this.gbxName.SuspendLayout();
            this.gbxDescription.SuspendLayout();
            this.gbxTown.SuspendLayout();
            this.gbProvince.SuspendLayout();
            this.gbxCity.SuspendLayout();
            this.gbxCountry.SuspendLayout();
            this.gbxJudicialParty.SuspendLayout();
            this.gbxUrl.SuspendLayout();
            this.gbNotes.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnSave);
            this.groupBox1.Location = new System.Drawing.Point(9, 338);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1148, 64);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.Location = new System.Drawing.Point(1041, 20);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(96, 38);
            this.BtnSave.TabIndex = 0;
            this.BtnSave.Text = "Guardar";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.gbxId);
            this.flowLayoutPanel2.Controls.Add(this.gbxName);
            this.flowLayoutPanel2.Controls.Add(this.gbxDescription);
            this.flowLayoutPanel2.Controls.Add(this.gbxTown);
            this.flowLayoutPanel2.Controls.Add(this.gbProvince);
            this.flowLayoutPanel2.Controls.Add(this.gbxCity);
            this.flowLayoutPanel2.Controls.Add(this.gbxCountry);
            this.flowLayoutPanel2.Controls.Add(this.gbxJudicialParty);
            this.flowLayoutPanel2.Controls.Add(this.gbxUrl);
            this.flowLayoutPanel2.Controls.Add(this.gbNotes);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1143, 320);
            this.flowLayoutPanel2.TabIndex = 18;
            // 
            // gbxId
            // 
            this.gbxId.Controls.Add(this.TxtId);
            this.gbxId.Location = new System.Drawing.Point(3, 3);
            this.gbxId.Name = "gbxId";
            this.gbxId.Size = new System.Drawing.Size(68, 54);
            this.gbxId.TabIndex = 0;
            this.gbxId.TabStop = false;
            this.gbxId.Text = "#Id";
            // 
            // TxtId
            // 
            this.TxtId.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtId.Location = new System.Drawing.Point(6, 22);
            this.TxtId.Name = "TxtId";
            this.TxtId.Size = new System.Drawing.Size(56, 23);
            this.TxtId.TabIndex = 3;
            // 
            // gbxName
            // 
            this.gbxName.Controls.Add(this.TxtName);
            this.gbxName.Location = new System.Drawing.Point(77, 3);
            this.gbxName.Name = "gbxName";
            this.gbxName.Size = new System.Drawing.Size(384, 54);
            this.gbxName.TabIndex = 6;
            this.gbxName.TabStop = false;
            this.gbxName.Text = "Nombre";
            // 
            // TxtName
            // 
            this.TxtName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtName.Location = new System.Drawing.Point(6, 22);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(372, 23);
            this.TxtName.TabIndex = 4;
            // 
            // gbxDescription
            // 
            this.gbxDescription.Controls.Add(this.txtDescription);
            this.gbxDescription.Location = new System.Drawing.Point(467, 3);
            this.gbxDescription.Name = "gbxDescription";
            this.gbxDescription.Size = new System.Drawing.Size(673, 54);
            this.gbxDescription.TabIndex = 7;
            this.gbxDescription.TabStop = false;
            this.gbxDescription.Text = "Descripción";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(6, 22);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(661, 23);
            this.txtDescription.TabIndex = 4;
            // 
            // gbxTown
            // 
            this.gbxTown.Controls.Add(this.TxtTown);
            this.gbxTown.Location = new System.Drawing.Point(3, 63);
            this.gbxTown.Name = "gbxTown";
            this.gbxTown.Size = new System.Drawing.Size(355, 54);
            this.gbxTown.TabIndex = 8;
            this.gbxTown.TabStop = false;
            this.gbxTown.Text = "Pueblo";
            // 
            // TxtTown
            // 
            this.TxtTown.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtTown.Location = new System.Drawing.Point(6, 22);
            this.TxtTown.Name = "TxtTown";
            this.TxtTown.Size = new System.Drawing.Size(343, 23);
            this.TxtTown.TabIndex = 4;
            // 
            // gbProvince
            // 
            this.gbProvince.Controls.Add(this.TxtProvince);
            this.gbProvince.Location = new System.Drawing.Point(364, 63);
            this.gbProvince.Name = "gbProvince";
            this.gbProvince.Size = new System.Drawing.Size(202, 54);
            this.gbProvince.TabIndex = 10;
            this.gbProvince.TabStop = false;
            this.gbProvince.Text = "Província";
            // 
            // TxtProvince
            // 
            this.TxtProvince.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtProvince.Location = new System.Drawing.Point(6, 22);
            this.TxtProvince.Name = "TxtProvince";
            this.TxtProvince.Size = new System.Drawing.Size(194, 23);
            this.TxtProvince.TabIndex = 4;
            // 
            // gbxCity
            // 
            this.gbxCity.Controls.Add(this.TxtCity);
            this.gbxCity.Location = new System.Drawing.Point(572, 63);
            this.gbxCity.Name = "gbxCity";
            this.gbxCity.Size = new System.Drawing.Size(357, 54);
            this.gbxCity.TabIndex = 9;
            this.gbxCity.TabStop = false;
            this.gbxCity.Text = "Ciudad";
            // 
            // TxtCity
            // 
            this.TxtCity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtCity.Location = new System.Drawing.Point(6, 22);
            this.TxtCity.Name = "TxtCity";
            this.TxtCity.Size = new System.Drawing.Size(345, 23);
            this.TxtCity.TabIndex = 4;
            // 
            // gbxCountry
            // 
            this.gbxCountry.Controls.Add(this.CmbCountry);
            this.gbxCountry.Location = new System.Drawing.Point(935, 63);
            this.gbxCountry.Name = "gbxCountry";
            this.gbxCountry.Size = new System.Drawing.Size(203, 54);
            this.gbxCountry.TabIndex = 11;
            this.gbxCountry.TabStop = false;
            this.gbxCountry.Text = "País";
            // 
            // CmbCountry
            // 
            this.CmbCountry.FormattingEnabled = true;
            this.CmbCountry.Location = new System.Drawing.Point(6, 22);
            this.CmbCountry.Name = "CmbCountry";
            this.CmbCountry.Size = new System.Drawing.Size(191, 23);
            this.CmbCountry.TabIndex = 0;
            // 
            // gbxJudicialParty
            // 
            this.gbxJudicialParty.Controls.Add(this.TxtJudicialParty);
            this.gbxJudicialParty.Location = new System.Drawing.Point(3, 123);
            this.gbxJudicialParty.Name = "gbxJudicialParty";
            this.gbxJudicialParty.Size = new System.Drawing.Size(243, 54);
            this.gbxJudicialParty.TabIndex = 12;
            this.gbxJudicialParty.TabStop = false;
            this.gbxJudicialParty.Text = "Partido judicial";
            // 
            // TxtJudicialParty
            // 
            this.TxtJudicialParty.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtJudicialParty.Location = new System.Drawing.Point(6, 22);
            this.TxtJudicialParty.Name = "TxtJudicialParty";
            this.TxtJudicialParty.Size = new System.Drawing.Size(231, 23);
            this.TxtJudicialParty.TabIndex = 4;
            // 
            // gbxUrl
            // 
            this.gbxUrl.Controls.Add(this.TxtUrl);
            this.gbxUrl.Location = new System.Drawing.Point(252, 123);
            this.gbxUrl.Name = "gbxUrl";
            this.gbxUrl.Size = new System.Drawing.Size(888, 56);
            this.gbxUrl.TabIndex = 13;
            this.gbxUrl.TabStop = false;
            this.gbxUrl.Text = "Url";
            // 
            // TxtUrl
            // 
            this.TxtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtUrl.Location = new System.Drawing.Point(6, 22);
            this.TxtUrl.Multiline = true;
            this.TxtUrl.Name = "TxtUrl";
            this.TxtUrl.Size = new System.Drawing.Size(876, 23);
            this.TxtUrl.TabIndex = 4;
            // 
            // gbNotes
            // 
            this.gbNotes.Controls.Add(this.TxtNotes);
            this.gbNotes.Location = new System.Drawing.Point(3, 185);
            this.gbNotes.Name = "gbNotes";
            this.gbNotes.Size = new System.Drawing.Size(1137, 132);
            this.gbNotes.TabIndex = 13;
            this.gbNotes.TabStop = false;
            this.gbNotes.Text = "Notas";
            // 
            // TxtNotes
            // 
            this.TxtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtNotes.Location = new System.Drawing.Point(6, 22);
            this.TxtNotes.Multiline = true;
            this.TxtNotes.Name = "TxtNotes";
            this.TxtNotes.Size = new System.Drawing.Size(1125, 104);
            this.TxtNotes.TabIndex = 4;
            // 
            // FrmRecursosDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 406);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmRecursosDetalle";
            this.Text = "FrmRecurso";
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.gbxId.ResumeLayout(false);
            this.gbxId.PerformLayout();
            this.gbxName.ResumeLayout(false);
            this.gbxName.PerformLayout();
            this.gbxDescription.ResumeLayout(false);
            this.gbxDescription.PerformLayout();
            this.gbxTown.ResumeLayout(false);
            this.gbxTown.PerformLayout();
            this.gbProvince.ResumeLayout(false);
            this.gbProvince.PerformLayout();
            this.gbxCity.ResumeLayout(false);
            this.gbxCity.PerformLayout();
            this.gbxCountry.ResumeLayout(false);
            this.gbxJudicialParty.ResumeLayout(false);
            this.gbxJudicialParty.PerformLayout();
            this.gbxUrl.ResumeLayout(false);
            this.gbxUrl.PerformLayout();
            this.gbNotes.ResumeLayout(false);
            this.gbNotes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.GroupBox gbxId;
        private System.Windows.Forms.TextBox TxtId;
        private System.Windows.Forms.GroupBox gbxName;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.GroupBox gbxDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.GroupBox gbxTown;
        private System.Windows.Forms.TextBox TxtTown;
        private System.Windows.Forms.GroupBox gbProvince;
        private System.Windows.Forms.TextBox TxtProvince;
        private System.Windows.Forms.GroupBox gbxCity;
        private System.Windows.Forms.TextBox TxtCity;
        private System.Windows.Forms.GroupBox gbxCountry;
        private System.Windows.Forms.ComboBox CmbCountry;
        private System.Windows.Forms.GroupBox gbxJudicialParty;
        private System.Windows.Forms.TextBox TxtJudicialParty;
        private System.Windows.Forms.GroupBox gbxUrl;
        private System.Windows.Forms.TextBox TxtUrl;
        private System.Windows.Forms.GroupBox gbNotes;
        private System.Windows.Forms.TextBox TxtNotes;
    }
}