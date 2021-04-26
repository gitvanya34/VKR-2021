using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

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
    public  class CalculationStress
    {
        static double D = 1.0,
                     dx = 0.02;

        private double t = 0.0,
                       tmax = 4.0,
                       dt = /*0.5 **/ (dx * dx) / 5;

        static int a = 0,
                   b = 1,
                   N = (int)(((double)(b - a)) / dx);

        double[] T_Curent = new double[N + 2];
        double[] T_Next = new double[N + 2];
        double[] X_Values = new double[N + 2];
        double[] K_Values = new double[N + 2];
        //Timer timer/* = new Timer()*/;

        public CalculationStress()
        {
            double k_0 = 0.0;
            // Инициализация массивов в соответсвии с начальными условиями
            for (int i = 0; i <= N + 1; i++)
            {
                T_Curent[i] = 0;
                T_Next[i] = 0;
                X_Values[i] = i * dx;

                if (X_Values[i] == 0.4)
                {
                    T_Curent[i] = 5;
                }

                K_Values[i] = D * T_Curent[i];
                if (K_Values[i] > k_0)
                {
                    k_0 = K_Values[i];
                }
            }
            dt = 0.5 * (dx * dx) / k_0;
        }
        public void NumbersHeatQuation1D()
        {
            // Установка левого и правого граничного условия
            T_Next[0] = 0;
            T_Next[N + 1] = 0;

            for (int i = 1; i <= N; i++)
                T_Next[i] = (K_half(i) * T_Curent[i + 1] - (K_half(i) + K_half2(i)) * T_Curent[i] + K_half2(i) * T_Curent[i - 1]) * dt / (dx * dx) + T_Curent[i];


            double k_0 = K_Values[0];
            // Теперь текущий слой - только что вычисленный
            for (int i = 0; i <= N + 1; i++)
            {
                T_Curent[i] = T_Next[i];
                K_Values[i] = Math.Pow(T_Curent[i], b);

                if (K_Values[i] > k_0)
                {
                    k_0 = K_Values[i];
                }

            }
            dt = 0.5 * (dx * dx) / k_0;

            //// Очистка компонента формы
            //chart1.Series[0].Points.Clear();

            //// Заполнение компонента формы
            //for (int i = 0; i <= N + 1; i++)
            //{
            //    chart1.Series[0].Points.AddXY(X_Values[i], T_Next[i]);

            //}

            //// Вывод графика на экран
            //chart1.Update();

            t += dt;

            t += dt;
            //if (t >= tmax)
            //{
            //    timer.Enabled = false;
            //} 
             
        }

        private double K_half(int i)
        {
            return (K_Values[i] + K_Values[i + 1]) / 2.0;
        }

        private double K_half2(int i)
        {
            return (K_Values[i - 1] + K_Values[i]) / 2.0;
        }

        public double getTemperatyre(int x, int y, int z, double t)
        {
           return T_Curent[x];
        }
        public double getTime()
        {
           return t;
        }

        //public double NumbersHeatQuation()
        //{

        //    return 0.0;
        //}
        public static double AnalyticalSolution(int x, int y, int z,double t)//для куба 10 на 10
        {
            x += 1;
            y += 1;
            z += 1;
            double Pi = Math.PI;
            x /= 10;
            y /= 10;
            z /= 10;

            return Math.Exp(-3*Pi* Pi * t) * Math.Cos(Pi*x)
                                           * Math.Cos(Pi*y)
                                           * Math.Cos(Pi*z);
        }
        public static double AnalyticalSolutionConvection(int x, int y, int z,double t)
        {
            double v = 10;
            double Pi = Math.PI;
            x /= 10;
            y /= 10;
            z /= 10;

            return Math.Exp(-1*(2 * (Pi * Pi) + 1) * t) * Math.Sin(y-v*t)
                                                    * Math.Cos(Pi*x)
                                                    * Math.Cos(Pi*z);
        }

     
        private static double ToRadians(double angle)
    {
        return angle * Math.PI / 180.0;
    }
    }
}
