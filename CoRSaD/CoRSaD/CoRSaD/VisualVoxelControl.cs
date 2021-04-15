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
namespace CoRSaD
{
    public partial class VisualVoxelControl : UserControl
    {
        VoxelLibrary.VisualVoxel visualVoxel = new VisualVoxel();
        VoxelLibrary.CameraVoxel cameraVoxel = new CameraVoxel();
        float rotation = 0.0f;
        public VisualVoxelControl()
        {
            InitializeComponent();
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
            gl.Rotate(rotation, 1.0f, 0.0f, 0.0f);

            visualVoxel.Visualization(gl);
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

        private void openglControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                cameraVoxel.LeftCamera();
            }

            if (e.KeyCode == Keys.D)
            {
                cameraVoxel.RightCamera();
            }

            if (e.KeyCode == Keys.W)
            {
                cameraVoxel.ForwardCamera();
            }

            if (e.KeyCode == Keys.S)
            {
                cameraVoxel.BackCamera();
            }
            if (e.KeyCode == Keys.R)
            {
                cameraVoxel.UpCamera();
            }
            if (e.KeyCode == Keys.F)
            {
                cameraVoxel.DownCamera();
            }
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
            gl.Perspective(100.0f, (double)Width / (double)Height, 0.01, 100.0);


            ////
            cameraVoxel.CameraLookAt(gl);

            //  Зададим модель отображения
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }
        private void openglControl1_Resized(object sender, EventArgs e)
        {
            Look();
        }
    }
}
