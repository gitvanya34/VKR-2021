
namespace CoRSaD
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this.openglControl1)).BeginInit();
            this.openglControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.openglControl2)).BeginInit();
            this.SuspendLayout();
            // 
            // openglControl1
            // 
            this.openglControl1.Controls.Add(this.buttonExportCSV);
            this.openglControl1.Controls.Add(this.openglControl2);
            this.openglControl1.Location = new System.Drawing.Point(-62, 0);
            this.openglControl1.Size = new System.Drawing.Size(1500, 1216);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(977, 1055);
            // 
            // openglControl2
            // 
            this.openglControl2.Location = new System.Drawing.Point(0, 0);
            this.openglControl2.Visible = false;
            // 
            // buttonExportCSV
            // 
            this.buttonExportCSV.Location = new System.Drawing.Point(0, 0);
            this.buttonExportCSV.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(1486, 1568);
            this.panel2.Size = new System.Drawing.Size(846, 466);
            this.panel2.Visible = false;
            // 
            // textBoxLOG
            // 
            this.textBoxLOG.Location = new System.Drawing.Point(0, 0);
            this.textBoxLOG.Visible = false;
            // 
            // buttonStart
            // 
            this.buttonStartRestart.Location = new System.Drawing.Point(0, 0);
            this.buttonStartRestart.Size = new System.Drawing.Size(1328, 90);
            this.buttonStartRestart.Visible = false;
            // 
            // buttonImportXYZ
            // 
            this.buttonImportXYZ.Location = new System.Drawing.Point(0, 0);
            this.buttonImportXYZ.Visible = false;
            // 
            // buttonImportCSV
            // 
            this.buttonImportCSV.Location = new System.Drawing.Point(0, 0);
            this.buttonImportCSV.Visible = false;
            // 
            // buttonImportSTL
            // 
            this.buttonImportSTL.Location = new System.Drawing.Point(0, 0);
            this.buttonImportSTL.Visible = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1456, 1252);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.openglControl1)).EndInit();
            this.openglControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.openglControl2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}