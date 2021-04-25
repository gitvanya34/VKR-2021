using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationStressLibrary
{
    /*
   D - коэффициент теплопроводности
   dx - шаг по координате
   dy - шаг по координате
   dz - шаг по координате
   dt - шаг по времени
   t - время
   tmax - конечное время
   a - начальная точка
   b - конечная точка
   N - количество узлов
   T_Curent - значения температуры на текущем временном слое
   T_Next - значения температуры на вычисляемом (следующем) временном слое
   X_Values - значения по оси Ox
   K_Values - значения переменного коэффициента D * T_Current
  */
    public static class CalculationStress
    {
        //private double dx=0;
        //private double dy =0;
        //private double dz=0;
        //private double dt=0.1;
        //private double t;
        //private double tmax;
        //private double Pi = Math.PI;
        //public void T_Curent(int x,int y,int z)
        //{
            
        //}
        public static double AnalyticalSolution(int x, int y, int z,double t)
        {
            double Pi = Math.PI;
            x /= 10;
            y /= 10;
            z /= 10;

            return Math.Exp(-3*Pi* Pi * t) * Math.Cos(Pi*x)
                                           * Math.Cos(Pi*y)
                                           * Math.Cos(Pi*z);
        }
    }
}
