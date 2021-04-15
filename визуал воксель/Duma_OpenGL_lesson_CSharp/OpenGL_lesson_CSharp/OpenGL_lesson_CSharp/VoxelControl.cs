using SharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OpenGL_lesson_CSharp
{
    public partial class VoxelControl : UserControl
    {
        VisualVoxel visualVoxel = new VisualVoxel();
        CameraVoxel cameraVoxel = new CameraVoxel();
        float rotation = 0.0f;
        public VoxelControl()
        {
            InitializeComponent();
        }
        private void openGLControl_OpenGLDraw(object sender, RenderEventArgs e)
        {
            //  Возьмём OpenGL объект
            OpenGL gl = openGLControl.OpenGL;

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
        /*
         TODO 1)сделать контур у углов вокселей в визуализации
              3)создать класс цветов и градиенты цветов 
              4)реализовать поворот и управление мышью !!!
              5)всунуть в отдельную страницу формы или изменить маштаб не во весь экран !!!
        ()сдеалть пользовательский элемент управления для каждой проги
        () поэкспирементировать с вокселизацией модели от простых к сложной
        
               

        complete
          1* убрать знаки переноса из текста в переменной !!!
                1)реализоватькласс координат центров и параметров вокселей
              2)реализовать считывание с файла 
         */
        //рисуем полигон по четырем точкам

        // Эту функцию используем для задания некоторых значений по умолчанию
        private void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            //  Возьмём OpenGL объект
            OpenGL gl = openGLControl.OpenGL;

            //  Фоновый цвет по умолчанию (в данном случае цвет голубой)
            gl.ClearColor(0.1f, 0.5f, 1.0f, 0);
        }

        // Данная функция используется для преобразования изображения 
        // в объёмный вид с перспективой
        private void openGLControl_Resized(object sender, EventArgs e)
        {
            Look();
        }
        private void Look()
        {
            //  Возьмём OpenGL объект
            OpenGL gl = openGLControl.OpenGL;
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

        private void openGLControl_Load(object sender, EventArgs e)
        {

        }

        private void openGLControl_KeyDown(object sender, KeyEventArgs e)
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

    }
}
