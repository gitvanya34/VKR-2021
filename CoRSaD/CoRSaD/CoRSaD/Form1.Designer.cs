
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
            this.label11 = new System.Windows.Forms.Label();
            this.textboxSpeedCalc = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxLOG = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonExportCSV = new System.Windows.Forms.Button();
            this.buttonStartRestart = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_E_crit = new System.Windows.Forms.TextBox();
            this.textBox_alpha_0 = new System.Windows.Forms.TextBox();
            this.textBox_t_laser_voxel = new System.Windows.Forms.TextBox();
            this.textBox_T_fusion_metal = new System.Windows.Forms.TextBox();
            this.textBox_T_laser = new System.Windows.Forms.TextBox();
            this.textBox_T_start = new System.Windows.Forms.TextBox();
            this.textBox_d_metal = new System.Windows.Forms.TextBox();
            this.textBox_d_air = new System.Windows.Forms.TextBox();
            this.textBox_d_dust = new System.Windows.Forms.TextBox();
            this.buttonImportXYZ = new System.Windows.Forms.Button();
            this.buttonImportCSV = new System.Windows.Forms.Button();
            this.buttonImportSTL = new System.Windows.Forms.Button();
            this.openglControl2 = new SharpGL.OpenGLControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelTimeHead = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.openglControl1 = new SharpGL.OpenGLControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.tabControl1.Size = new System.Drawing.Size(1442, 1080);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.textboxSpeedCalc);
            this.tabPage1.Controls.Add(this.panel4);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.buttonImportXYZ);
            this.tabPage1.Controls.Add(this.buttonImportCSV);
            this.tabPage1.Controls.Add(this.buttonImportSTL);
            this.tabPage1.Controls.Add(this.openglControl2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.openglControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1434, 1042);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Расчет";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(946, 459);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(157, 25);
            this.label11.TabIndex = 3;
            this.label11.Text = "Скорость расчета";
            // 
            // textboxSpeedCalc
            // 
            this.textboxSpeedCalc.Location = new System.Drawing.Point(1138, 456);
            this.textboxSpeedCalc.Name = "textboxSpeedCalc";
            this.textboxSpeedCalc.Size = new System.Drawing.Size(98, 31);
            this.textboxSpeedCalc.TabIndex = 17;
            this.textboxSpeedCalc.Text = "1";
            this.textboxSpeedCalc.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.textBoxLOG);
            this.panel4.Location = new System.Drawing.Point(860, 555);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(547, 465);
            this.panel4.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 25);
            this.label10.TabIndex = 17;
            this.label10.Text = " Log";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxLOG
            // 
            this.textBoxLOG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxLOG.Location = new System.Drawing.Point(20, 62);
            this.textBoxLOG.Multiline = true;
            this.textBoxLOG.Name = "textBoxLOG";
            this.textBoxLOG.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLOG.Size = new System.Drawing.Size(506, 385);
            this.textBoxLOG.TabIndex = 18;
            this.textBoxLOG.Text = "Логирование";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.buttonExportCSV);
            this.panel3.Controls.Add(this.buttonStartRestart);
            this.panel3.Controls.Add(this.buttonPause);
            this.panel3.Location = new System.Drawing.Point(417, 555);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(413, 465);
            this.panel3.TabIndex = 23;
            // 
            // buttonExportCSV
            // 
            this.buttonExportCSV.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonExportCSV.Location = new System.Drawing.Point(36, 36);
            this.buttonExportCSV.Name = "buttonExportCSV";
            this.buttonExportCSV.Size = new System.Drawing.Size(343, 111);
            this.buttonExportCSV.TabIndex = 20;
            this.buttonExportCSV.Text = "Экспорт .csv";
            this.buttonExportCSV.UseVisualStyleBackColor = true;
            this.buttonExportCSV.Click += new System.EventHandler(this.buttonExportCSV_Click);
            // 
            // buttonStartRestart
            // 
            this.buttonStartRestart.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonStartRestart.Location = new System.Drawing.Point(36, 320);
            this.buttonStartRestart.Name = "buttonStartRestart";
            this.buttonStartRestart.Size = new System.Drawing.Size(343, 111);
            this.buttonStartRestart.TabIndex = 21;
            this.buttonStartRestart.Text = "Начать моделирование ";
            this.buttonStartRestart.UseVisualStyleBackColor = true;
            this.buttonStartRestart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonPause.Location = new System.Drawing.Point(36, 174);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(343, 112);
            this.buttonPause.TabIndex = 22;
            this.buttonPause.Text = "Пауза";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.textBox_E_crit);
            this.panel2.Controls.Add(this.textBox_alpha_0);
            this.panel2.Controls.Add(this.textBox_t_laser_voxel);
            this.panel2.Controls.Add(this.textBox_T_fusion_metal);
            this.panel2.Controls.Add(this.textBox_T_laser);
            this.panel2.Controls.Add(this.textBox_T_start);
            this.panel2.Controls.Add(this.textBox_d_metal);
            this.panel2.Controls.Add(this.textBox_d_air);
            this.panel2.Controls.Add(this.textBox_d_dust);
            this.panel2.Location = new System.Drawing.Point(59, 554);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(326, 466);
            this.panel2.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(105, 400);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 25);
            this.label9.TabIndex = 16;
            this.label9.Text = "E_crit";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(85, 358);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 25);
            this.label7.TabIndex = 15;
            this.label7.Text = "alpha_0";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(48, 321);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 25);
            this.label8.TabIndex = 14;
            this.label8.Text = "t_laser_voxel";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 274);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 25);
            this.label5.TabIndex = 13;
            this.label5.Text = "T_fusion_metal";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(93, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "T_laser";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(94, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "T_start";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(83, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "d_metal";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "d_air";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "d_dust";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox_E_crit
            // 
            this.textBox_E_crit.Location = new System.Drawing.Point(163, 397);
            this.textBox_E_crit.Name = "textBox_E_crit";
            this.textBox_E_crit.Size = new System.Drawing.Size(98, 31);
            this.textBox_E_crit.TabIndex = 8;
            this.textBox_E_crit.Text = "-245";
            // 
            // textBox_alpha_0
            // 
            this.textBox_alpha_0.Location = new System.Drawing.Point(163, 355);
            this.textBox_alpha_0.Name = "textBox_alpha_0";
            this.textBox_alpha_0.Size = new System.Drawing.Size(98, 31);
            this.textBox_alpha_0.TabIndex = 7;
            this.textBox_alpha_0.Text = " 0,3";
            // 
            // textBox_t_laser_voxel
            // 
            this.textBox_t_laser_voxel.Location = new System.Drawing.Point(163, 318);
            this.textBox_t_laser_voxel.Name = "textBox_t_laser_voxel";
            this.textBox_t_laser_voxel.Size = new System.Drawing.Size(98, 31);
            this.textBox_t_laser_voxel.TabIndex = 6;
            this.textBox_t_laser_voxel.Text = "0,02";
            // 
            // textBox_T_fusion_metal
            // 
            this.textBox_T_fusion_metal.Location = new System.Drawing.Point(163, 271);
            this.textBox_T_fusion_metal.Name = "textBox_T_fusion_metal";
            this.textBox_T_fusion_metal.Size = new System.Drawing.Size(98, 31);
            this.textBox_T_fusion_metal.TabIndex = 5;
            this.textBox_T_fusion_metal.Text = "1600";
            // 
            // textBox_T_laser
            // 
            this.textBox_T_laser.Location = new System.Drawing.Point(163, 220);
            this.textBox_T_laser.Name = "textBox_T_laser";
            this.textBox_T_laser.Size = new System.Drawing.Size(98, 31);
            this.textBox_T_laser.TabIndex = 4;
            this.textBox_T_laser.Text = "1000000";
            // 
            // textBox_T_start
            // 
            this.textBox_T_start.Location = new System.Drawing.Point(163, 171);
            this.textBox_T_start.Name = "textBox_T_start";
            this.textBox_T_start.Size = new System.Drawing.Size(98, 31);
            this.textBox_T_start.TabIndex = 3;
            this.textBox_T_start.Text = "20";
            // 
            // textBox_d_metal
            // 
            this.textBox_d_metal.Location = new System.Drawing.Point(163, 120);
            this.textBox_d_metal.Name = "textBox_d_metal";
            this.textBox_d_metal.Size = new System.Drawing.Size(98, 31);
            this.textBox_d_metal.TabIndex = 2;
            this.textBox_d_metal.Text = "0,6";
            // 
            // textBox_d_air
            // 
            this.textBox_d_air.Location = new System.Drawing.Point(163, 69);
            this.textBox_d_air.Name = "textBox_d_air";
            this.textBox_d_air.Size = new System.Drawing.Size(98, 31);
            this.textBox_d_air.TabIndex = 1;
            this.textBox_d_air.Text = "0,01";
            // 
            // textBox_d_dust
            // 
            this.textBox_d_dust.Location = new System.Drawing.Point(163, 22);
            this.textBox_d_dust.Name = "textBox_d_dust";
            this.textBox_d_dust.Size = new System.Drawing.Size(98, 31);
            this.textBox_d_dust.TabIndex = 0;
            this.textBox_d_dust.Text = "0,24";
            // 
            // buttonImportXYZ
            // 
            this.buttonImportXYZ.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonImportXYZ.Location = new System.Drawing.Point(47, 173);
            this.buttonImportXYZ.Name = "buttonImportXYZ";
            this.buttonImportXYZ.Size = new System.Drawing.Size(338, 95);
            this.buttonImportXYZ.TabIndex = 16;
            this.buttonImportXYZ.Text = "Импорт .xyz";
            this.buttonImportXYZ.UseVisualStyleBackColor = true;
            this.buttonImportXYZ.Click += new System.EventHandler(this.buttonImportXYZ_Click);
            // 
            // buttonImportCSV
            // 
            this.buttonImportCSV.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonImportCSV.Location = new System.Drawing.Point(47, 333);
            this.buttonImportCSV.Name = "buttonImportCSV";
            this.buttonImportCSV.Size = new System.Drawing.Size(338, 95);
            this.buttonImportCSV.TabIndex = 15;
            this.buttonImportCSV.Text = "Импотр .csv";
            this.buttonImportCSV.UseVisualStyleBackColor = true;
            // 
            // buttonImportSTL
            // 
            this.buttonImportSTL.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelTimeHead);
            this.panel1.Controls.Add(this.labelTime);
            this.panel1.Location = new System.Drawing.Point(417, 437);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(454, 76);
            this.panel1.TabIndex = 12;
            // 
            // labelTimeHead
            // 
            this.labelTimeHead.AutoSize = true;
            this.labelTimeHead.Location = new System.Drawing.Point(18, 24);
            this.labelTimeHead.Name = "labelTimeHead";
            this.labelTimeHead.Size = new System.Drawing.Size(68, 25);
            this.labelTimeHead.TabIndex = 2;
            this.labelTimeHead.Text = "Время:";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(157, 24);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(0, 25);
            this.labelTime.TabIndex = 1;
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
            this.tabPage2.Size = new System.Drawing.Size(1434, 1042);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Инфо";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1439, 1117);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "CoRSaD";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.Label labelTimeHead;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.TabPage tabPage2;
        public SharpGL.OpenGLControl openglControl1;
        public System.Windows.Forms.Panel panel1;
        public SharpGL.OpenGLControl openglControl2;
        public System.Windows.Forms.Button buttonExportCSV;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.TextBox textBoxLOG;
        public System.Windows.Forms.Button buttonImportXYZ;
        public System.Windows.Forms.Button buttonImportCSV;
        public System.Windows.Forms.Button buttonImportSTL;
        private System.Windows.Forms.TextBox textBox_E_crit;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox_T_fusion_metal;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox_T_start;
        private System.Windows.Forms.TextBox textBox_d_metal;
        private System.Windows.Forms.TextBox textBox_d_air;
        private System.Windows.Forms.TextBox textBox_d_dust;
        private System.Windows.Forms.TextBox textBox_T_laser;
        private System.Windows.Forms.TextBox textBox_t_laser_voxel;
        private System.Windows.Forms.TextBox textBox_alpha_0;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button buttonPause;
        public System.Windows.Forms.Button buttonStartRestart;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textboxSpeedCalc;
        private System.Windows.Forms.Label label11;
    }
}

