﻿using SharpGL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using VoxelLibrary;
using CalculationStressLibrary;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace VisualVoxelLibrary
{
    

    public class  VisualVoxel
    {
        private OpenGL gl;
        private int[] voxelX;
        private int[] voxelY;
        private int[] voxelZ;


        private Voxel[] voxels;

        private int countVoxel;

        private int[,] voxelXYZ;

        private ColorVoxel color = new ColorVoxel(0, 1000);


        public VisualVoxel(OpenGL Gl)
        {gl = Gl; }
        public VisualVoxel()
        { ImportXYZ(); }


        
        public void Visualization(OpenGL gl)
        {
            //Вывод изображения воксельной модели без стресса (начальный вывод)
            //for (int i = 0; i < countVoxel; i++)
            //{
            //    color.ColorStressVoxel(/*float valueStress*/ i / 70);//разскоментить когда расчет сделаем
            //    drawVoxel(gl, color, voxels[i]);
            //}

            //вывод в отдельное окно расчитаной модели (возможно понадобится перегрузить функцию и вызывать ее из другого окна опенgl)
            //....
           

            CalculationStressLibrary.ScanningModel scanningModel = new ScanningModel(voxels);//выполняется каждый кадр , нужно  упростить
            foreach(MeshVoxel meshVoxel in scanningModel.getAllMeshVoxels())
            {
                color.ColorStressVoxel(/*float valueStress*/ 70);//разскоментить когда расчет сделаем
                drawVoxel(gl, color, meshVoxel);
            }
        }


        double t = 0; 
              

        //визуализация аналитического решения 
        public void VisualizationTemperatyre(OpenGL gl)
        {
           
        t += 0.0001;
            double temperature = 0;
            CalculationStressLibrary.ScanningModel scanningModel = new ScanningModel(voxels);//выполняется каждый кадр , нужно  упростить
            MeshVoxel[,,] meshVoxels = scanningModel.getAllMeshVoxels();
            for (int z = scanningModel.getMinZ(); z <= scanningModel.getMaxZ(); z++)
            {
                for (int x = scanningModel.getMinX(); x <= scanningModel.getMaxX(); x++)
                {
                    for (int y = scanningModel.getMinY(); y <= scanningModel.getMaxY(); y++)
                    {
                       
                        //temperature = CalculationStress.AnalyticalSolution(x+1,y+1,z+1,t);
                        temperature = CalculationStress.AnalyticalSolutionConvection(x,y,z,t);//x+1,y+1,z+1 так как в массиивк етсь 0 значения 
                        Console.WriteLine("%d,%d,%d", x, y, z, temperature);
                        color.ColorStressVoxel(temperature*1000);//разскоментить когда расчет сделаем
                        drawVoxel(gl, color, meshVoxels[x, y, z]);
                    }
                }
            }
        }


       private  CalculationStress calculationStress = new CalculationStress();
        //визуализация аналитического решения одномерного уравнения теплопроводности
        public void VisualizationTemperatyre2(OpenGL gl)
        {

            
            double temperature = 0;

           
            CalculationStressLibrary.ScanningModel scanningModel = new ScanningModel(voxels);//выполняется каждый кадр , нужно  упростить
            MeshVoxel[,,] meshVoxels = scanningModel.getAllMeshVoxels();
          
            //for (t = 0; t < tmax;t+=0.5)
            //{
                calculationStress.NumbersHeatQuation1D();
                for (int z = scanningModel.getMinZ(); z <= scanningModel.getMaxZ(); z++)
                {
                    for (int x = scanningModel.getMinX(); x <= scanningModel.getMaxX(); x++)
                    {
                        for (int y = scanningModel.getMinY(); y <= scanningModel.getMaxY(); y++)
                        {
                           
                            //temperature = CalculationStress.AnalyticalSolution(x+1,y+1,z+1,t);
                            temperature = calculationStress.getTemperatyre(x,y,z);//x+1,y+1,z+1 так как в массиивк етсь 0 значения 
                            Console.WriteLine("%d,%d,%d", x, y, z, temperature);
                            color.ColorStressVoxel(temperature * 1000);//разскоментить когда расчет сделаем
                            drawVoxel(gl, color, meshVoxels[x, y, z]);
                        }
                    }
                }
            //}
        }


        private HeatEquation heatEquation  = new HeatEquation();
        //визуализация трехмерного уравнения теплопроводности
        public void VisualizationTemperatyre3(OpenGL gl)
        {


            double temperature = 0;


            CalculationStressLibrary.ScanningModel scanningModel = new ScanningModel(voxels);//выполняется каждый кадр , нужно  упростить
            MeshVoxel[,,] meshVoxels = scanningModel.getAllMeshVoxels();

            //for (t = 0; t < tmax;t+=0.5)
            //{
            heatEquation.CalculationHeatEquation();
            for (int z = scanningModel.getMinZ(); z <= scanningModel.getMaxZ(); z++)
            {
                for (int x = scanningModel.getMinX(); x <= scanningModel.getMaxX(); x++)
                {
                    for (int y = scanningModel.getMinY(); y <= scanningModel.getMaxY(); y++)
                    {

                        //temperature = CalculationStress.AnalyticalSolution(x+1,y+1,z+1,t);
                        temperature = heatEquation.getTemperatyre(x, y, z);//x+1,y+1,z+1 так как в массиивк етсь 0 значения 
                        Console.WriteLine("%d,%d,%d", x, y, z, temperature);
                        color.ColorStressVoxel(temperature );//разскоментить когда расчет сделаем
                        drawVoxel(gl, color, meshVoxels[x, y, z]);
                    }
                }
            }
            //}
        }

        System.Diagnostics.Stopwatch sw = new Stopwatch();
        int maxX = 1;
        int maxY =1;
        int maxZ = 1;
        public async void VisualizationModelScanning(OpenGL gl)
        {
            
            //вывод в отдельное окно расчитаной модели (возможно понадобится перегрузить функцию и вызывать ее из другого окна опенgl)
            //....
            CalculationStressLibrary.ScanningModel scanningModel = new ScanningModel(voxels);//выполняется каждый кадр , нужно  упростить
                                                                                             //foreach (MeshVoxel meshVoxel in scanningModel.getAllMeshVoxels())
                                                                                             //{
                                                                                             //    color.ColorStressVoxel(/*float valueStress*/ 70);//разскоментить когда расчет сделаем
            if (maxZ< scanningModel.getMaxZ()) {                                                                                //    drawVoxel(gl, color, meshVoxel); //}
                await Task.Run(() =>
                {
                    if (/*пауза*/true)
                    {
                        maxX++;

                        if (maxY >= scanningModel.getMaxY())
                        {
                            maxY = 1;
                            maxZ += 1;
                        }
                        if (maxX >= scanningModel.getMaxX())
                        {
                            maxX = 1;
                            maxY += 1;
                        }
                    }
                //Thread.Sleep(1);
            });
            }

           
            MeshVoxel[,,] meshVoxels = scanningModel.getAllMeshVoxels();
            for (int z = scanningModel.getMinZ(); z <= maxZ; z++)
            {
                for (int x = scanningModel.getMinX(); x <= maxX; x++)
                {
                    for (int y = scanningModel.getMinY(); y <= maxY; y++)
                {             
                        color.ColorStressVoxel(/*float valueStress*/ 70);//разскоментить когда расчет сделаем
                        drawVoxel(gl, color, meshVoxels[x,y,z]);
                    }
                }
            }
           // Thread.Sleep(1);
        }
        //convert_Data_from_FileXYZ получает на вход необаботанную строку возвращает три масссива координат вокселей
        private void convert_Data_from_FileXYZ(string fileData)
        {
            string[] words = fileData.Split(' ');
             this.countVoxel = words.Length / 3;

            Console.WriteLine(countVoxel);

            voxels = new  Voxel[countVoxel];
            voxelXYZ = new int[3, countVoxel];
            //voxelX = new int[k];
            //voxelY = new int[k];
            //voxelZ = new int[k];

            int j = 0;
            for (int i = 0; i < countVoxel; i += 1)
            {

                voxels[i] = new  Voxel(Convert.ToInt32(words[j]),
                                       Convert.ToInt32(words[j + 1]),
                                       Convert.ToInt32(words[j + 2]) );
                //voxelXYZ[0, j] = Convert.ToInt32(words[i]);
                //voxelXYZ[1, j] = Convert.ToInt32(words[i + 1]);
                //voxelXYZ[2, j] = Convert.ToInt32(words[i + 2]);

                //voxelX[j] = Convert.ToInt32(words[i + 0]);
                //voxelY[j] = Convert.ToInt32(words[i + 1]);
                //voxelZ[j] = Convert.ToInt32(words[i + 2]);
                j+=3;
            }
          //  Console.WriteLine(voxelXYZ);    
        }
        private  void ImportXYZ()
        {
            string path = @"D:\\StudentData\\VKR-2021\\Вокселизация змеюка\\voxel pyton";//заменить на патч 
            StreamReader sr = new StreamReader($"{path}\\cubevoxel.xyz");
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
        private void drawVoxel(OpenGL gl, ColorVoxel color, Voxel voxel /*float xc, float yc, float zc*/)
        {
            float sizeVoxel = 1;
            float hfs = sizeVoxel / 2;
            float dsqrt = (float)Math.Sqrt(hfs * hfs);
            gl.Begin(OpenGL.GL_POLYGON);
            gl.Color(color.getRed(), color.getGreen(), color.getBlue());

            float xc = voxel.getVoxelX();
            float yc=  voxel.getVoxelY();
            float zc=  voxel.getVoxelZ();

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

        private void drawVoxel(OpenGL gl, ColorVoxel color, MeshVoxel voxel /*float xc, float yc, float zc*/)
        {
            if (voxel.getBoolScanned())
            {

                float sizeVoxel = 1;
                float hfs = sizeVoxel / 2;
                float dsqrt = (float)Math.Sqrt(hfs * hfs);
                //рисование полигонов
                gl.Begin(OpenGL.GL_QUADS);
                gl.Color(color.getRed(), color.getGreen(), color.getBlue());

                float xc = voxel.getVoxelX();
                float yc = voxel.getVoxelY();
                float zc = voxel.getVoxelZ();

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
                //gl.Flush();
                //рисование контуров

                gl.Begin(OpenGL.GL_LINE_STRIP);
                gl.Color(0, 0, 0);
                // glLineWidth(w);
                // glColor3d(0, 1, 0);
                // glBegin(GL_LINE_STRIP);
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
                gl.Finish();
            }
        }
    }
}
