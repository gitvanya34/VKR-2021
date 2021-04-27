using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CalculationStressLibrary
{   /*
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
  ////////
    D - коэффициент теплопроводности
    dx - шаг по координате
    dy - шаг по координате
    dz - шаг по координате
    dt - шаг по времени
    t - время
    tmax - конечное время

    */
    public class HeatEquation
    {
        static double D = 0.9,
                      dx = 1,
                      dy = 1,
                      dz = 1;

        private double t = 0,
                       tmax = 0.05,
                       dt = 0.00005* (dx * dx) / 2 *D;//tay

        private static int
                   a = 0,
                   b = 10,
                   N = (int)(((double)(b - a)) / dx) + 2;

        double[,,] T_Next = new double[N , N , N ];
        double[,,] T_Curent = new double[N , N , N ];//4измерение время
        // double[] T_Next = new double[,];

        double[,,] XYZ_Values = new double[N , N , N ];
        double[] X_Values = new double[N ];
        double[] Y_Values = new double[N ];
        double[] Z_Values = new double[N ];


        double[,,] K_Values = new double[N , N , N ];

        public HeatEquation()
        {

            t = 0;
            // Инициализация массивов в соответсвии с начальными условиями
            for (int k = 0; k < N; k++)
            {
                for (int j = 0; j < N; j++)
                {
                    for (int i = 0; i < N; i++)
                    {
                        T_Curent[i, j, k] = 20;//начальная температура всех 
                                               //  T_Next[i] = 0;
                                               //X_Values[i] = i * dx;
                                               //Y_Values[j] = j * dy;
                                               //Z_Values[k] = k * dz;

                        //XYZ_Values[i, j, k] = i * dx;

                        //if (X_Values[i] == 0.4)
                        //{
                        //    T_Curent[i] = 5;
                     
                        K_Values[i, j, k] = D * T_Curent[i, j, k];

                        if (i == 0 || i == N)
                            K_Values[i, j, k] = (1 - D) * T_Curent[i, j, k];
                        if (j == 0 || j == N)
                            K_Values[i, j, k] = (1 - D) * T_Curent[i, j, k];
                        if (k == 0 || k == N)
                            K_Values[i, j, k] = (1 - D) * T_Curent[i, j, k];
                    }
                }
            }
            // T_Curent[1, 1, 1] = 5000;

            ////Задача начального источника 
            //for (int k = 0; k < N; k++)
            //{
            //    for (int j = 0; j < N; j++)
            //    {
            //        for (int i = 0; i < N; i++)
            //        {

            //            K_Values[i, j, k] = D/* * T_Curent[i, j, k]*/;
            //            //if (i==0 || i==N)
            //        }
            //    }
            //}



           // T_Curent[5, 5, 1] = 10000;


        }
        public void CalculationHeatEquation()
        {
            if(t<0.005)
            {
                T_Curent[6, 6, 1] = 10000;
                T_Curent[6, 5, 1] = 10000;
                T_Curent[5, 6, 1] = 10000;
                T_Curent[5, 5, 1] = 10000;
            }
            for (int k = 1; k < N-1; k++)
            {
                for (int j = 1; j < N-1; j++)
                {
                    for (int i = 1; i < N-1; i++)
                    {
                        T_Next[i, j, k] = T_Curent[i, j, k] + (dt / (dx * dx)) * (
                                                   K_half_plus_i(i, j, k) * (T_Curent[i + 1, j, k] - T_Curent[i, j, k])
                                                 - K_half_minus_i(i, j, k) * (T_Curent[i, j, k] - T_Curent[i - 1, j, k])

                                                 + K_half_plus_j(i, j, k) * (T_Curent[i, j + 1, k] - T_Curent[i, j, k])
                                                 - K_half_minus_j(i, j, k) * (T_Curent[i, j, k] - T_Curent[i, j - 1, k])

                                                  + K_half_plus_k(i, j, k) * (T_Curent[i, j, k + 1] - T_Curent[i, j, k])
                                                 - K_half_minus_k(i, j, k) * (T_Curent[i, j, k] - T_Curent[i, j, k - 1])
                                                 );

                       
                    }
                }
            }

           // T_Curent[1, 1, 1] = 1000;

            for (int k = 0; k < N; k++)
            {
                for (int j = 0; j < N; j++)
                {
                    for (int i = 0; i < N; i++)
                    {                    
                        K_Values[i, j, k] = D * T_Curent[i, j, k];
                        //if (i == 0 || i == N)
                        //    K_Values[i, j, k] = (1 - D) * T_Curent[i, j, k];
                        //if (j == 0 || j == N)
                        //    K_Values[i, j, k] = (1 - D) * T_Curent[i, j, k];
                        //if (k == 0 || k == N)
                        //    K_Values[i, j, k] = (1 - D) * T_Curent[i, j, k];
                    }
                }
            }
           
            T_Curent = T_Next;
            t += dt;
           
            // Console.WriteLine(T_Curent[N-1, N-1, N-1]);
        }
        public double K_half_plus_i( int i, int j, int k)
        {
            double K_half = 0;

            K_half=  (K_Values[ i, j, k] + K_Values[ i + 1, j, k]) / 2;
            return K_half;
        }
        public double K_half_minus_i( int i, int j, int k)
        {
            double K_half = 0;

            K_half =  (K_Values[i, j, k] + K_Values[ i - 1, j, k]) / 2;
            return K_half;
        }
        public double K_half_plus_j( int i, int j, int k)
        {
            double K_half = 0;

            K_half= (K_Values[ i, j, k] + K_Values[ i, j+1, k]) / 2;
            return K_half;
        }
        public double K_half_minus_j( int i, int j, int k)
        {
            double K_half = 0;

            K_half = (K_Values[ i, j, k] + K_Values[ i, j-1, k]) / 2;
            return K_half;
        }
        public double K_half_plus_k( int i, int j, int k)
        {
            double K_half = 0;

            K_half= (K_Values[ i, j, k] + K_Values[ i , j, k + 1]) / 2;
            return K_half;
        }
        public double K_half_minus_k( int i, int j, int k)
        {
            double K_half = 0;

            K_half = (K_Values[ i, j, k] + K_Values[ i , j, k - 1]) / 2;
            return K_half;
        }
        public double getTemperatyre(int x, int y, int z)
        {
            return T_Curent[x*1,y*1,z*1];
        }
    }
   
}
