using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SharpGL;

namespace OpenGL_lesson_CSharp
{
    public partial class SharpGLForm : Form
    {
        float rotation = 0.0f;
        public SharpGLForm()
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

            // рисуем крышу
            //gl.Begin(OpenGL.GL_TRIANGLES);

            //gl.Color(1f, 0.2f, 0.0f); // здесь задаём цвет для каждой плоскости
            //gl.Vertex(0.0f, 2.5f, 0.0f);
            //gl.Vertex(2.0f, 1.5f, -2.0f);
            //gl.Vertex(2.0f, 1.5f, 2.0f);

            //gl.Color(1f, 0.3f, 0.0f);
            //gl.Vertex(-2.0f, 1.5f, -2.0f);
            //gl.Vertex(-2.0f, 1.5f, 2.0f);
            //gl.Vertex(0.0f, 2.5f, 0.0f);

            //gl.Color(1f, 0.4f, 0.0f);
            //gl.Vertex(0.0f, 2.5f, 0.0f);
            //gl.Vertex(2.0f, 1.5f, -2.0f);
            //gl.Vertex(-2.0f, 1.5f, -2.0f);

            //gl.Color(1f, 0.1f, 0.0f);
            //gl.Vertex(0.0f, 2.5f, 0.0f);
            //gl.Vertex(-2.0f, 1.5f, 2.0f);
            //gl.Vertex(2.0f, 1.5f, 2.0f);

            //gl.End();


            //// передняя часть дома
            //gl.Begin(OpenGL.GL_POLYGON);
            //gl.Color(1f, 1f, 0f);
            //gl.Vertex(2f, 1.5f, -2f);
            //gl.Vertex(2f, 0f, -2f);
            //gl.Vertex(-2f, 0f, -2f);
            //gl.Vertex(-2f, 1.5f, -2f);

            //gl.End();

            //// правая часть дома
            //gl.Begin(OpenGL.GL_POLYGON);
            //gl.Color(1f, 0.8f, 0f);
            //gl.Vertex(2f, 0f, -2f);
            //gl.Vertex(2f, 0f, 2f);
            //gl.Vertex(2f, 1.5f, 2f);
            //gl.Vertex(2f, 1.5f, -2f);
            //gl.End();

            //// задняя часть дома
            //gl.Begin(OpenGL.GL_POLYGON);
            //gl.Color(1f, 0.7f, 0f);
            //gl.Vertex(2f, 0f, 2f);
            //gl.Vertex(-2f, 0f, 2f);
            //gl.Vertex(-2f, 1.5f, 2f);
            //gl.Vertex(2f, 1.5f, 2f);
            //gl.End();

            //// левая часть дома
            //gl.Begin(OpenGL.GL_POLYGON);
            //gl.Color(1f, 0.9f, 0f);
            //gl.Vertex(-2f, 0f, -2f);
            //gl.Vertex(-2f, 0f, 2f);
            //gl.Vertex(-2f, 1.5f, 2f);
            //gl.Vertex(-2f, 1.5f, -2f);
            //gl.End();

            //// дверь (передняя стена)
            //gl.Begin(OpenGL.GL_POLYGON);
            //gl.Color(1f, 0.5f, 0f);
            //gl.Vertex(0.3f, 0f, -2.01f);
            //gl.Vertex(-0.3f, 0f, -2.01f);
            //gl.Vertex(-0.3f, 1.2f, -2.01f);
            //gl.Vertex(0.3f, 1.2f, -2.01f);
            //gl.End();

            //// рисуем землю            
            //gl.Begin(OpenGL.GL_POLYGON);
            //gl.Color(0f, 1f, 0f);
            //gl.Vertex(-10f, 0f, -10f);
            //gl.Vertex(10f, 0f, -10f);
            //gl.Vertex(10f, 0f, 10f);
            //gl.Vertex(-10f, 0f, 10f);
            //gl.End();            

           rotation += 1.5f;
            //drawPolygon(gl, 255, 0, 0, 
            //    0,0,0,
            //    5,0,0,
            //    0,5,0,
            //    0,0,5);
            drawVoxel(gl, 1f, 0, 0, 0, 0, 0);
            drawVoxel(gl, 0.7f, 0, 0, 1, 0, 0);
            drawVoxel(gl, 0.4f, 0, 0, 0, 1, 0);

        }
        /*
         TODO 1)реализоватькласс координат центров и параметров вокселей
              2)реализовать считывание с файла 
              3)создать класс и градиенты цветов 
              4)реализовать поворот и управление мышью 
              5)всунуть в отдельную страницу формы или изменить маштаб не во весь экран 
               
         */
        private void drawPolygon(OpenGL gl, float r, float g, float b,  float x1, float y1, float z1, 
                                                                 float x2, float y2, float z2,
                                                                 float x3, float y3, float z3,
                                                                 float x4, float y4, float z4)
        {
            gl.Begin(OpenGL.GL_POLYGON);
            gl.Color(r, g, b);
            gl.Vertex(x1, y1, z1);
            gl.Vertex(x2, y2, z2);
            gl.Vertex(x3, y3, z3);
            gl.Vertex(x4, y4, z4);
            gl.End();
        }
        private void drawVoxel(OpenGL gl, float r, float g, float b, float xc, float yc, float zc)
        {
            float sizeVoxel = 1;
            float hfs = sizeVoxel / 2;
            float dsqrt = (float)Math.Sqrt(hfs * hfs);
            gl.Begin(OpenGL.GL_POLYGON);
            gl.Color(r, g, b);
            //верхняя грань
            gl.Vertex(xc - dsqrt, yc + hfs, zc - dsqrt);
            gl.Vertex(xc + dsqrt, yc + hfs, zc - dsqrt);
            gl.Vertex(xc + dsqrt, yc + hfs, zc + dsqrt);
            gl.Vertex(xc - dsqrt, yc + hfs, zc + dsqrt);
          

            //нижняя грань
            gl.Vertex(xc - dsqrt, yc - hfs, zc - dsqrt);
            gl.Vertex(xc + dsqrt, yc - hfs, zc - dsqrt);
            gl.Vertex(xc + dsqrt, yc - hfs, zc + dsqrt);
            gl.Vertex(xc - dsqrt, yc - hfs, zc + dsqrt);
          

            //левая грань
            gl.Vertex(xc - hfs, yc - dsqrt, zc - dsqrt);
            gl.Vertex(xc - hfs, yc + dsqrt, zc - dsqrt);
            gl.Vertex(xc - hfs, yc + dsqrt, zc + dsqrt);
            gl.Vertex(xc - hfs, yc - dsqrt, zc + dsqrt);
            

            //правая грань
            gl.Vertex(xc + hfs, yc - dsqrt, zc - dsqrt);
            gl.Vertex(xc + hfs, yc + dsqrt, zc - dsqrt);
            gl.Vertex(xc + hfs, yc + dsqrt, zc + dsqrt);
            gl.Vertex(xc + hfs, yc - dsqrt, zc + dsqrt);
           
            //передняя грань
            gl.Vertex(xc - dsqrt, yc - dsqrt, zc + hfs);
            gl.Vertex(xc + dsqrt, yc - dsqrt, zc + hfs);
            gl.Vertex(xc + dsqrt, yc + dsqrt, zc + hfs);
            gl.Vertex(xc - dsqrt, yc + dsqrt, zc + hfs);
           
            //задняя грань
            gl.Vertex(xc - dsqrt, yc - dsqrt, zc - hfs);
            gl.Vertex(xc + dsqrt, yc - dsqrt, zc - hfs);
            gl.Vertex(xc + dsqrt, yc + dsqrt, zc - hfs);
            gl.Vertex(xc - dsqrt, yc + dsqrt, zc - hfs);
            
            gl.End();
        }
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
            //  Возьмём OpenGL объект
            OpenGL gl = openGLControl.OpenGL;

            //  Зададим матрицу проекции
            gl.MatrixMode(OpenGL.GL_PROJECTION);

            //  Единичная матрица для последующих преобразований
            gl.LoadIdentity();

            //  Преобразование
            gl.Perspective(60.0f, (double)Width / (double)Height, 0.01, 100.0);

            //  Данная функция позволяет установить камеру и её положение
            gl.LookAt( 5, 6, -7,    // Позиция самой камеры
                       0, 1, 0,     // Направление, куда мы смотрим
                       0, 1, 0);    // Верх камеры

            //  Зададим модель отображения
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }

        private void openGLControl_Load(object sender, EventArgs e)
        {

        }
    }
}