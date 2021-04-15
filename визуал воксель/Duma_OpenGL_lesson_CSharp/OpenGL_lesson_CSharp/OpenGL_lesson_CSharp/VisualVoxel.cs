using SharpGL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OpenGL_lesson_CSharp
{
    

    class  VisualVoxel
    {
        private OpenGL gl;
        private int[] voxelX;
        private int[] voxelY;
        private int[] voxelZ;

        private int countVoxelXYZ;

        private int[,] voxelXYZ;

        public VisualVoxel(OpenGL Gl)
        {gl = Gl; }
        public VisualVoxel()
        { ImportXYZ(); }

        public void Visualization(OpenGL gl)
        {
            for (int i = 0; i < voxelXYZ.Length/3; i++)
                drawVoxel(gl, 0.4f, 0, 0, voxelXYZ[0,i], voxelXYZ[1,i], voxelXYZ[2,i]);
        }
        //convert_Data_from_FileXYZ получает на вход необаботанную строку возвращает три масссива координат вокселей
        private void convert_Data_from_FileXYZ(string fileData)
        {
            string[] words = fileData.Split(' ');
            int k = words.Length / 3;

            Console.WriteLine(k);

            voxelXYZ = new int[3, k];
            //voxelX = new int[k];
            //voxelY = new int[k];
            //voxelZ = new int[k];

            int j = 0;
            for (int i = 0; i < k; i += 2)
            {
                voxelXYZ[0, j] = Convert.ToInt32(words[i]);
                voxelXYZ[1, j] = Convert.ToInt32(words[i + 1]);
                voxelXYZ[2, j] = Convert.ToInt32(words[i + 2]);
                //voxelX[j] = Convert.ToInt32(words[i + 0]);
                //voxelY[j] = Convert.ToInt32(words[i + 1]);
                //voxelZ[j] = Convert.ToInt32(words[i + 2]);
                j++;
            }
            Console.WriteLine(voxelXYZ);    
        }
        private  void ImportXYZ()
        {
            string path = @"D:\\StudentData\\VKR-2020\\Вокселизация змеюка\\voxel pyton";
            StreamReader sr = new StreamReader($"{path}\\output.xyz");
            string numbers = sr.ReadToEnd();      
            numbers = numbers.Replace("\r", "").Replace("\n", " ");
            convert_Data_from_FileXYZ(numbers);

        }
        private void drawPolygon(OpenGL gl, float r, float g, float b, float x1, float y1, float z1,
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

        //рисуем воксель по точке(центр куба) обект gl ,входные ргб цвет, координаты центров 
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

       
    }
}
