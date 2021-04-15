namespace OpenGL_lesson_CSharp
{
    partial class SharpGLForm
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
            this.voxelControl1 = new OpenGL_lesson_CSharp.VoxelControl();
            this.SuspendLayout();
            // 
            // voxelControl1
            // 
            this.voxelControl1.Location = new System.Drawing.Point(94, 66);
            this.voxelControl1.Name = "voxelControl1";
            this.voxelControl1.Size = new System.Drawing.Size(615, 508);
            this.voxelControl1.TabIndex = 4;
            // 
            // SharpGLForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 692);
            this.Controls.Add(this.voxelControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SharpGLForm";
            this.Text = "SharpGL Form";
            this.ResumeLayout(false);

        }

        #endregion
        private VoxelControl voxelControl1;
    }
}

