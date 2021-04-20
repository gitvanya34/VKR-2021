﻿using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace VisualVoxelLibrary
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

            cameraRouteVectorX = 0;
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
                       cameraPositionX, 0, cameraPositionZ,     // Направление, куда мы смотри // если поменять на cameraRouteVectorX = 0; cameraRouteVectorY = 0;cameraRouteVectorZ = 0;то будет всегда смотреть в нули 
                         cameraUpVectorX, cameraUpVectorY, cameraUpVectorZ);    // Верх камеры  
        }
        public void Rotate(OpenGL gl) 
        {
            gl.Rotate(rotationX, 1.0f, 0.0f, 0.0f);
            gl.Rotate(rotationY, 0.0f, 1.0f, 0.0f);
            gl.Rotate(rotationZ, 0.0f, 0.0f, 1.0f);
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


        public void RotateUpCameraX()
        {
            rotationX++;
        }
        public void RotateDownCameraX()
        {
            rotationX--;
        }
        public void RotateUpCameraY()
        {
            rotationY++;
        }
        public void RotateDownCameraY()
        {
            rotationY--;
        }
        public void RotateUpCameraZ()
        {
            rotationZ++;
        }
        public void RotateDownCameraZ()
        {
            rotationZ--;
        }

    }
}
