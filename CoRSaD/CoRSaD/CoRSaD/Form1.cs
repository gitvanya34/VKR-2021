using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpGL;
using VoxelLibrary;
using VisualVoxelLibrary;
using CalculationStressLibrary;
using System.IO;

namespace CoRSaD
{
    public partial class Form1 : Form
    {
        VisualVoxelLibrary.VisualVoxel visualVoxel = new VisualVoxel();
        VisualVoxelLibrary.CameraVoxel cameraVoxel = new CameraVoxel();
        float rotation = 0.0f;
        bool boolModelTrue = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openglControl1_OpenGLDraw(object sender, RenderEventArgs args)
        {
            if (boolModelTrue)
                OpenGLDraw(openglControl1.OpenGL, openglControl2.OpenGL);        
            
            
        }
        private void OpenGLDraw(OpenGL gl,OpenGL gl2)
        {
            //  Возьмём OpenGL объект
           

            //  Очищаем буфер цвета и глубины
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl2.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            //  Загружаем единичную матрицу
            gl.LoadIdentity();
            gl2.LoadIdentity();

            //  Указываем оси вращения (x, y, z)
            //gl.Rotate(rotation, 0.0f, 0.0f, 1.0f);
            cameraVoxel.Rotate(gl);
            cameraVoxel.Rotate(gl2);

            //visualVoxel.Visualization(gl);
            //visualVoxel.VisualizationTemperatyre2(gl);
           
            visualVoxel.VisualizationTemperatyre3(gl,gl2, boolPauseCalc, textboxSpeedCalc.Text != "" ? Convert.ToInt32(textboxSpeedCalc.Text) : 0);
            currentLayerLog();

            labelTime.Text = Convert.ToString(visualVoxel.getTimeHeatEquation());
            
            //labelTemperatureVoxel.Text = Convert.ToString(visualVoxel.getTemperatureVoxelHeatEquation(1, 1, 1));
            //visualVoxel.VisualizationModelScanning(gl);

            // rotation += 1.5f;
            Look(gl);
            Look(gl2);
        }
        //рисуем полигон по четырем точкам

        // Эту функцию используем для задания некоторых значений по умолчанию
        private void openglControl1_OpenGLInitialized(object sender, EventArgs e)
        {
            OpenGLInitialized(openglControl1.OpenGL);
            OpenGLInitialized(openglControl2.OpenGL);
        }
        private void OpenGLInitialized(OpenGL gl)
        {
            //  Фоновый цвет по умолчанию (в данном случае цвет голубой)
            gl.ClearColor(0.1f, 0.5f, 1.0f, 0);
        }




        private void openglControl1_Resized(object sender, EventArgs e)
        {
            Look(openglControl1.OpenGL);
            Look(openglControl2.OpenGL);
        }

        private void Look(OpenGL gl)
        {
            //  Возьмём OpenGL объект
         //   OpenGL gl = openglControl1.OpenGL;
            //  Зададим матрицу проекции
            gl.MatrixMode(OpenGL.GL_PROJECTION);

            //  Единичная матрица для последующих преобразований
            gl.LoadIdentity();

            //  Преобразовани
            gl.Perspective(100.0f, (double)Width / (double)Height, 0.01, 100.0);


            ////
            cameraVoxel.CameraLookAt(gl);

            //  Зададим модель отображения
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }
        private void openglControl1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.A && e.Control)
            {
                cameraVoxel.RotateUpCameraZ();
                return;
            }


            if (e.KeyCode == Keys.D && e.Control)
            {
                cameraVoxel.RotateDownCameraZ();
                return;
            }

            if (e.KeyCode == Keys.W && e.Control)
            {
                cameraVoxel.RotateUpCameraY();
                return;
            }

            if (e.KeyCode == Keys.S && e.Control)
            {
                cameraVoxel.RotateDownCameraY();
                return;
            }
            if (e.KeyCode == Keys.R && e.Control)
            {
                cameraVoxel.RotateUpCameraX();
                return;
            }
            if (e.KeyCode == Keys.F && e.Control)
            {
                cameraVoxel.RotateDownCameraX();
                return;
            }

            if (e.KeyCode == Keys.A)
            {
                cameraVoxel.LeftCamera();
                return;
            }

            if (e.KeyCode == Keys.D)
            {
                cameraVoxel.RightCamera();
                return;
            }

            if (e.KeyCode == Keys.W)
            {
                cameraVoxel.ForwardCamera();
                return;
            }

            if (e.KeyCode == Keys.S)
            {
                cameraVoxel.BackCamera();
                return;
            }
            if (e.KeyCode == Keys.R)
            {
                cameraVoxel.UpCamera();
                return;
            }
            if (e.KeyCode == Keys.F)
            {
                cameraVoxel.DownCamera();
                return;
            }


        }


        //Timer timer = new Timer();
        private void openglControl1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2(); //где Form2 - название вашей формы
            frm2.Show();
            //CalculationStress calculationStress = new CalculationStress();


            //// Call this procedure when the application starts.  
            //// Set to 1 second.  
            //timer.Interval = 1;
            //timer.Tick += new EventHandler(calculationStress.timer_Tick);

            //// Enable timer.  
            //timer.Enabled = true;


        }

        private void openglControl1_Load_1(object sender, EventArgs e)
        {

        }

        int value=-1;
        public void currentLayerLog()
        {
           
            if(value != visualVoxel.HeatEquation.CountScanningVoxels)
            if (visualVoxel.HeatEquation.CountScanningVoxels <
                                                        visualVoxel.HeatEquation.ScaningVoxels.Length && boolPauseCalc)
            {
                textBoxLOG.AppendText("\r\n" + DateTime.Now + ":" + " Отсканированно вокселей " + visualVoxel.HeatEquation.CountScanningVoxels + "/" + visualVoxel.HeatEquation.ScaningVoxels.Length + "\r\n ");
                    value = visualVoxel.HeatEquation.CountScanningVoxels;
            }
            
        }

        private bool boolPauseCalc = false;
        private void buttonStart_Click(object sender, EventArgs e)
        {
            createOptionsCalc();
            boolPauseCalc = !boolPauseCalc;
        }

        public void createOptionsCalc()
        {
            CalculationStressLibrary.Options options = new Options(
                                                          Convert.ToDouble(textBox_d_dust.Text),
                                                          Convert.ToDouble(textBox_d_air.Text),
                                                          Convert.ToDouble(textBox_d_metal.Text),
                                                          Convert.ToDouble(textBox_T_start.Text),
                                                          Convert.ToDouble(textBox_T_laser.Text),
                                                          Convert.ToDouble(textBox_T_fusion_metal.Text),
                                                          Convert.ToDouble(textBox_t_laser_voxel.Text),
                                                          Convert.ToDouble(textBox_alpha_0.Text),
                                                          Convert.ToDouble(textBox_E_crit.Text));
            visualVoxel.optionsToHeatEquation(options);
            cameraVoxel = new CameraVoxel();
        }
        private void buttonPause_Click(object sender, EventArgs e)
        {

            boolPauseCalc = !boolPauseCalc;
        }

        private void buttonExportCSV_Click(object sender, EventArgs e)
        {
            StreamWriter myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
           
            
            saveFileDialog1.Filter = "deformation (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                myStream = new System.IO.StreamWriter(saveFileDialog1.OpenFile());
                if (myStream  != null)
                {
                    visualVoxel.getHeatEquation.getDeformation.ExportDeformationsToCSV(myStream);
                    myStream.Close();
                }
            }
         
            textBoxLOG.Text += "\r\n"+DateTime.Now+":" +" Файл " + saveFileDialog1.FileName+".csv" + " сохранен в "+saveFileDialog1.InitialDirectory + "\r\n ";
          
        }

        private void buttonImportXYZ_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "D:\\StudentData\\VKR-2021\\Вокселизация змеюка\\voxel pyton";
                openFileDialog.Filter = "txt files (*.xyz)|*.xyz|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = openFileDialog.FileName;

                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        visualVoxel.ImportXYZ(reader);
                            
                        textBoxLOG.Text += "\r\n" + DateTime.Now + ": Импортирован файл" + filePath + "\r\n ";

                        
                    }
                    if (openFileDialog.FileName != null)
                    {
                        createOptionsCalc();
                        boolModelTrue = true;
                       
                    }
                }
            }

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
