
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonExportCSV = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxLOG = new System.Windows.Forms.TextBox();
            this.buttonStartRestart = new System.Windows.Forms.Button();
            this.buttonImportXYZ = new System.Windows.Forms.Button();
            this.buttonImportCSV = new System.Windows.Forms.Button();
            this.buttonImportSTL = new System.Windows.Forms.Button();
            this.openglControl2 = new SharpGL.OpenGLControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelTemperatureVoxel = new System.Windows.Forms.Label();
            this.labelTemperatureVoxelhead = new System.Windows.Forms.Label();
            this.labelTimeHead = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.openglControl1 = new SharpGL.OpenGLControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.openglControl2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.openglControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1442, 1266);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonPause);
            this.tabPage1.Controls.Add(this.buttonExportCSV);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.textBoxLOG);
            this.tabPage1.Controls.Add(this.buttonStartRestart);
            this.tabPage1.Controls.Add(this.buttonImportXYZ);
            this.tabPage1.Controls.Add(this.buttonImportCSV);
            this.tabPage1.Controls.Add(this.buttonImportSTL);
            this.tabPage1.Controls.Add(this.openglControl2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.openglControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1434, 1228);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(721, 1053);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(613, 156);
            this.buttonPause.TabIndex = 21;
            this.buttonPause.Text = "Пауза";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // buttonExportCSV
            // 
            this.buttonExportCSV.Location = new System.Drawing.Point(933, 554);
            this.buttonExportCSV.Name = "buttonExportCSV";
            this.buttonExportCSV.Size = new System.Drawing.Size(454, 95);
            this.buttonExportCSV.TabIndex = 20;
            this.buttonExportCSV.Text = "Экспорт .csv";
            this.buttonExportCSV.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(59, 554);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(836, 466);
            this.panel2.TabIndex = 19;
            // 
            // textBoxLOG
            // 
            this.textBoxLOG.Location = new System.Drawing.Point(933, 702);
            this.textBoxLOG.Multiline = true;
            this.textBoxLOG.Name = "textBoxLOG";
            this.textBoxLOG.Size = new System.Drawing.Size(454, 317);
            this.textBoxLOG.TabIndex = 18;
            this.textBoxLOG.Text = "Логирование";
            // 
            // buttonStartRestart
            // 
            this.buttonStartRestart.Location = new System.Drawing.Point(59, 1055);
            this.buttonStartRestart.Name = "buttonStartRestart";
            this.buttonStartRestart.Size = new System.Drawing.Size(613, 156);
            this.buttonStartRestart.TabIndex = 17;
            this.buttonStartRestart.Text = "Начать моделирование ";
            this.buttonStartRestart.UseVisualStyleBackColor = true;
            this.buttonStartRestart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonImportXYZ
            // 
            this.buttonImportXYZ.Location = new System.Drawing.Point(47, 173);
            this.buttonImportXYZ.Name = "buttonImportXYZ";
            this.buttonImportXYZ.Size = new System.Drawing.Size(338, 95);
            this.buttonImportXYZ.TabIndex = 16;
            this.buttonImportXYZ.Text = "Импорт .xyz";
            this.buttonImportXYZ.UseVisualStyleBackColor = true;
            // 
            // buttonImportCSV
            // 
            this.buttonImportCSV.Location = new System.Drawing.Point(47, 333);
            this.buttonImportCSV.Name = "buttonImportCSV";
            this.buttonImportCSV.Size = new System.Drawing.Size(338, 95);
            this.buttonImportCSV.TabIndex = 15;
            this.buttonImportCSV.Text = "Импотр .csv";
            this.buttonImportCSV.UseVisualStyleBackColor = true;
            // 
            // buttonImportSTL
            // 
            this.buttonImportSTL.Location = new System.Drawing.Point(47, 9);
            this.buttonImportSTL.Name = "buttonImportSTL";
            this.buttonImportSTL.Size = new System.Drawing.Size(338, 95);
            this.buttonImportSTL.TabIndex = 14;
            this.buttonImportSTL.Text = "Импорт .stl";
            this.buttonImportSTL.UseVisualStyleBackColor = true;
            // 
            // openglControl2
            // 
            this.openglControl2.DrawFPS = true;
            this.openglControl2.Location = new System.Drawing.Point(933, 9);
            this.openglControl2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.openglControl2.Name = "openglControl2";
            this.openglControl2.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openglControl2.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openglControl2.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openglControl2.Size = new System.Drawing.Size(454, 419);
            this.openglControl2.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelTemperatureVoxel);
            this.panel1.Controls.Add(this.labelTemperatureVoxelhead);
            this.panel1.Controls.Add(this.labelTimeHead);
            this.panel1.Controls.Add(this.labelTime);
            this.panel1.Location = new System.Drawing.Point(417, 448);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(454, 76);
            this.panel1.TabIndex = 12;
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
            // labelTemperatureVoxelhead
            // 
            this.labelTemperatureVoxelhead.AutoSize = true;
            this.labelTemperatureVoxelhead.Location = new System.Drawing.Point(9, 34);
            this.labelTemperatureVoxelhead.Name = "labelTemperatureVoxelhead";
            this.labelTemperatureVoxelhead.Size = new System.Drawing.Size(170, 25);
            this.labelTemperatureVoxelhead.TabIndex = 3;
            this.labelTemperatureVoxelhead.Text = "Температура(5,6,1):";
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
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(185, 9);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(87, 25);
            this.labelTime.TabIndex = 1;
            this.labelTime.Text = "labelTime";
            // 
            // openglControl1
            // 
            this.openglControl1.DrawFPS = true;
            this.openglControl1.Location = new System.Drawing.Point(417, 9);
            this.openglControl1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.openglControl1.Name = "openglControl1";
            this.openglControl1.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openglControl1.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openglControl1.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openglControl1.Size = new System.Drawing.Size(454, 419);
            this.openglControl1.TabIndex = 11;
            this.openglControl1.OpenGLInitialized += new System.EventHandler(this.openglControl1_OpenGLInitialized);
            this.openglControl1.OpenGLDraw += new SharpGL.RenderEventHandler(this.openglControl1_OpenGLDraw);
            this.openglControl1.Resized += new System.EventHandler(this.openglControl1_Resized);
            this.openglControl1.Load += new System.EventHandler(this.openglControl1_Load_1);
            this.openglControl1.DoubleClick += new System.EventHandler(this.openglControl1_Click);
            this.openglControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.openglControl1_KeyDown);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1434, 1228);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1439, 1254);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.openglControl2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.openglControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label labelTemperatureVoxel;
        private System.Windows.Forms.Label labelTemperatureVoxelhead;
        private System.Windows.Forms.Label labelTimeHead;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.TabPage tabPage2;
        public SharpGL.OpenGLControl openglControl1;
        public System.Windows.Forms.Panel panel1;
        public SharpGL.OpenGLControl openglControl2;
        public System.Windows.Forms.Button buttonExportCSV;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.TextBox textBoxLOG;
        public System.Windows.Forms.Button buttonStartRestart;
        public System.Windows.Forms.Button buttonImportXYZ;
        public System.Windows.Forms.Button buttonImportCSV;
        public System.Windows.Forms.Button buttonImportSTL;
        public System.Windows.Forms.Button buttonPause;
    }
}

