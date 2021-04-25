﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoxelLibrary
{
    public class ColorVoxel
    {
        private double red;
        private double green;
        private double blue;
        private double stressMin;
        private double stressMax;
        private double stepColor;
        public ColorVoxel()
        {
            red = 0;
            green = 0;
            blue = 0;
        }
        public ColorVoxel(float sMin, float sMax)//диапазон напряяжений
        {
            red = 0;
            green = 1;
            blue = 0;
            this.stressMin= sMin;
            this.stressMax = sMax;
            stepColor = 1 / (sMax - sMin);

            //TODO расчет градиента по максимальному и минимальному значению напряжения 
        }
        public void ColorStressVoxel(double valueStress)
        {
            double k= valueStress * stepColor;
            //TODO расчет граддиента и цветов; на вхоод приходит номер вокселя и его значения напрядения ,
            //в это время изменяется значени ргб в объекте , объект отсылается в функцию проприсовки и затем изменяется сново  
            red = k;
            green =1-k;
            blue = 0;
        }
        public double getRed()
        {
            return red;
        }
        public double getGreen()
        {
            return green;
        }
        public double getBlue()
        {
            return blue;
        }
    }
}
