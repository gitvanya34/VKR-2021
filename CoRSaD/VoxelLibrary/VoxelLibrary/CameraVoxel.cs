using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace VoxelLibrary
{
    public  class CameraVoxel
    {
        private float cameraPositionX;
        private float cameraPositionY;
        private float cameraPositionZ;

        private float cameraRouteVectorX;
        private float cameraRouteVectorY;
        private float cameraRouteVectorZ;

        private float cameraUpVectorX;
        private float cameraUpVectorY;
        private float cameraUpVectorZ;

        private float rotationX;
        private float rotationY;
        private float rotationZ;

        public CameraVoxel()
        {
            cameraPositionX = 0;
            cameraPositionY = 100;
            cameraPositionZ = 0;

            cameraRouteVectorX = 1;
            cameraRouteVectorY = 0;
            cameraRouteVectorZ = 0;

            cameraUpVectorX = 0;
            cameraUpVectorY = 0;
            cameraUpVectorZ = 1;
        }
        public void  CameraLookAt(OpenGL gl) 
        {
            //  Данная функция позволяет установить камеру и её положение
            gl.LookAt(cameraPositionX, cameraPositionY, cameraPositionZ,    // Позиция самой камеры 5, 6, -7,0, 1, 0,    0, 1, 0);
                       cameraRouteVectorX, cameraRouteVectorY, cameraRouteVectorZ,     // Направление, куда мы смотрим
                       cameraUpVectorX, cameraUpVectorY, cameraUpVectorZ);    // Верх камеры  
        }
        public void UpCamera()
        {
            cameraPositionZ++;
            Console.WriteLine("Пока мир...");
        }
        public void DownCamera()
        {
            cameraPositionZ--;
            Console.WriteLine("Пока мир...");
        }
        public void LeftCamera()
        {
            cameraPositionX--;
            Console.WriteLine("Пока мир...");
        }
        public void RightCamera()
        {

            cameraPositionX++;
            Console.WriteLine("Пока мир...");
        }
        public void BackCamera()
        {
            cameraPositionY++;
            Console.WriteLine("Пока мир...");
        }
        public void ForwardCamera()
        {
            cameraPositionY--;

        }

    }
}
