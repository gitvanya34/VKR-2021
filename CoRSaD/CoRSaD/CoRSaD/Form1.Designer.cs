
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
            this.labelTime = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelTimeHead = new System.Windows.Forms.Label();
            this.labelTemperatureVoxelhead = new System.Windows.Forms.Label();
            this.labelTemperatureVoxel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.openglControl1)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.openglControl1.Load += new System.EventHandler(this.openglControl1_Load);
            this.openglControl1.Click += new System.EventHandler(this.openglControl1_Click);
            this.openglControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.openglControl1_KeyDown);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(185, 9);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(87, 25);
            this.labelTime.TabIndex = 1;
            this.labelTime.Text = "labelTime";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelTemperatureVoxel);
            this.panel1.Controls.Add(this.labelTemperatureVoxelhead);
            this.panel1.Controls.Add(this.labelTimeHead);
            this.panel1.Controls.Add(this.labelTime);
            this.panel1.Location = new System.Drawing.Point(779, 663);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(494, 76);
            this.panel1.TabIndex = 2;
            // 
            // labelTimeHead
            // 
            this.labelTimeHead.AutoSize = true;
            this.labelTimeHead.Location = new System.Drawing.Point(9, 9);
            this.labelTimeHead.Name = "labelTimeHead";
            this.labelTimeHead.Size = new System.Drawing.Size(68, 25);
            this.labelTimeHead.TabIndex = 2;
            this.labelTimeHead.Text = "Время:";
            // 
            // labelTemperatureVoxelhead
            // 
            this.labelTemperatureVoxelhead.AutoSize = true;
            this.labelTemperatureVoxelhead.Location = new System.Drawing.Point(9, 34);
            this.labelTemperatureVoxelhead.Name = "labelTemperatureVoxelhead";
            this.labelTemperatureVoxelhead.Size = new System.Drawing.Size(170, 25);
            this.labelTemperatureVoxelhead.TabIndex = 3;
            this.labelTemperatureVoxelhead.Text = "Температура(5,6,1):";
            // 
            // labelTemperatureVoxel
            // 
            this.labelTemperatureVoxel.AutoSize = true;
            this.labelTemperatureVoxel.Location = new System.Drawing.Point(185, 34);
            this.labelTemperatureVoxel.Name = "labelTemperatureVoxel";
            this.labelTemperatureVoxel.Size = new System.Drawing.Size(189, 25);
            this.labelTemperatureVoxel.TabIndex = 4;
            this.labelTemperatureVoxel.Text = "labelTemperatureVoxel";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 751);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.openglControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.openglControl1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SharpGL.OpenGLControl openglControl1;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelTimeHead;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label labelTemperatureVoxel;
        private System.Windows.Forms.Label labelTemperatureVoxelhead;
    }
}

