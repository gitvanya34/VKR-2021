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
namespace CoRSaD
{
    public partial class Form1 : Form
    {
        VisualVoxelLibrary.VisualVoxel visualVoxel = new VisualVoxel();
        VisualVoxelLibrary.CameraVoxel cameraVoxel = new CameraVoxel();
        float rotation = 0.0f;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openglControl1_OpenGLDraw(object sender, RenderEventArgs args)
        {
            //  Возьмём OpenGL объект
            OpenGL gl = openglControl1.OpenGL;

            //  Очищаем буфер цвета и глубины
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            //  Загружаем единичную матрицу
            gl.LoadIdentity();

            //  Указываем оси вращения (x, y, z)
            //gl.Rotate(rotation, 0.0f, 0.0f, 1.0f);
            cameraVoxel.Rotate(gl);

            //visualVoxel.Visualization(gl);
            //visualVoxel.VisualizationTemperatyre2(gl);
            visualVoxel.VisualizationTemperatyre3(gl);
            labelTime.Text=Convert.ToString( visualVoxel.getTimeHeatEquation());
            labelTemperatureVoxel.Text = Convert.ToString(visualVoxel.getTemperatureVoxelHeatEquation(1, 1, 1));
            //visualVoxel.VisualizationModelScanning(gl);

            // rotation += 1.5f;
            Look();
        }

        //рисуем полигон по четырем точкам

        // Эту функцию используем для задания некоторых значений по умолчанию
        private void openglControl1_OpenGLInitialized(object sender, EventArgs e)
        {
            //  Возьмём OpenGL объект
            OpenGL gl = openglControl1.OpenGL;

            //  Фоновый цвет по умолчанию (в данном случае цвет голубой)
            gl.ClearColor(0.1f, 0.5f, 1.0f, 0);
        }

       
        private void openglControl1_Resized(object sender, EventArgs e)
        {
            Look();
        }

        private void Look()
        {
            //  Возьмём OpenGL объект
            OpenGL gl = openglControl1.OpenGL;
            //  Зададим матрицу проекции
            gl.MatrixMode(OpenGL.GL_PROJECTION);

            //  Единичная матрица для последующих преобразований
            gl.LoadIdentity();

            //  Преобразование
            gl.Perspective(75.0f, (double)Width / (double)Height, 0.01, 100.0);


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

        private void openglControl1_Load(object sender, EventArgs e)
        {

        }


        //Timer timer = new Timer();
        private void openglControl1_Click(object sender, EventArgs e)
        {
            //CalculationStress calculationStress = new CalculationStress();


            //// Call this procedure when the application starts.  
            //// Set to 1 second.  
            //timer.Interval = 1;
            //timer.Tick += new EventHandler(calculationStress.timer_Tick);

            //// Enable timer.  
            //timer.Enabled = true;


        }
    }
}
