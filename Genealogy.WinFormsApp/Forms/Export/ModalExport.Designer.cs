namespace Genealogy.WinFormsApp.Forms.Export {
    partial class ModalExport {
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
            frmGenericExport = new velocist.WinFormsControlLibrary.FrmGenericExport();
            SuspendLayout();
            // 
            // frmGenericExport
            // 
            frmGenericExport.Location = new Point(10, 12);
            frmGenericExport.MaximumSize = new Size(675, 70);
            frmGenericExport.MinimumSize = new Size(675, 70);
            frmGenericExport.Name = "frmGenericExport";
            frmGenericExport.OutputFilename = "Export_20230409";
            frmGenericExport.Size = new Size(675, 70);
            frmGenericExport.TabIndex = 0;
            // 
            // ModalExport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(697, 94);
            Controls.Add(frmGenericExport);
            Name = "ModalExport";
            Text = "ModalExport";
            Load += ModalExport_Load;
            ResumeLayout(false);
        }

        #endregion

        private velocist.WinFormsControlLibrary.FrmGenericExport frmGenericExport;
    }
}