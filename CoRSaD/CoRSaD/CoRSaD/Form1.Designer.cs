
namespace CoRSaD
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openglControl1 = new SharpGL.OpenGLControl();
            ((System.ComponentModel.ISupportInitialize)(this.openglControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // openglControl1
            // 
            this.openglControl1.DrawFPS = false;
            this.openglControl1.Location = new System.Drawing.Point(25, 33);
            this.openglControl1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.openglControl1.Name = "openglControl1";
            this.openglControl1.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openglControl1.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openglControl1.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openglControl1.Size = new System.Drawing.Size(1069, 621);
            this.openglControl1.TabIndex = 0;
            this.openglControl1.OpenGLInitialized += new System.EventHandler(this.openglControl1_OpenGLInitialized);
            this.openglControl1.OpenGLDraw += new SharpGL.RenderEventHandler(this.openglControl1_OpenGLDraw);
            this.openglControl1.Resized += new System.EventHandler(this.openglControl1_Resized);
            this.openglControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.openglControl1_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 720);
            this.Controls.Add(this.openglControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.openglControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SharpGL.OpenGLControl openglControl1;
    }
}

