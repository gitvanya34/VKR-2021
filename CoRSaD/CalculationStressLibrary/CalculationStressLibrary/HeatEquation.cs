using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CalculationStressLibrary
{  
    public class HeatEquation
    {
        private static double D = 0.1,//сплавленного материала 
                      dx = 0.1,//шаг 
                      dy = 1,
                      dz = 1;

        private double t = 0,
                       tmax = 0.05,
                       dt = 0.01* (dx * dx) / (2) ;//tay

        private double T_start = 20,//температур аокружающей среды
                       T_laser = 600;
                      

        private static int
                       a = 0,
                       b = 10,//заменить на voxelmaxXYZ
                       N = (int)(((double)(b - a)) / dx) +2 ;

        double[,,] T_Next = new double[N , N , N ];
        double[,,] T_Curent = new double[N , N , N ];//4измерение время

        double[,,] K_Values = new double[N , N , N ];

        public HeatEquation()
        {
            // Инициализация массивов в соответсвии с начальными условиями
            for (int k = 0; k < N; k++)
            {
                for (int j = 0; j < N; j++)
                {
                    for (int i = 0; i < N; i++)
                    {
                        T_Curent[i, j, k] = T_start;//начальная всех элементов и окружающей среды                                
                     
                        K_Values[i, j, k] = D * T_Curent[i, j, k];

                        //так как у нас вокруг объекта есть пустые площади задаем для них отдельный  коэф теплопроводности (снизу можно сдлеать подложку на которой происходит печать)
                        if (i == 0 || i == N-1)
                            K_Values[i, j, k] = (/*1 -*/ D) * T_Curent[i, j, k];
                        if (j == 0 || j == N-1)
                            K_Values[i, j, k] = (/*1 -*/ D) * T_Curent[i, j, k];
                        if (k == 0 || k == N-1)
                            K_Values[i, j, k] = (/*1 -*/ D) * T_Curent[i, j, k];
                    }
                }
            }
            


        }
        public void CalculationHeatEquation()
        {

            //Указываем источники их начальную температуру и время из водействия 


            //Расчет следующего значения температуры в сетке
            for (int k = 1; k < N - 1; k++)
            {
                for (int j = 1; j < N - 1; j++)
                {
                    for (int i = 1; i < N - 1; i++)
                    {
                        T_Next[i, j, k] = T_Curent[i, j, k] + (dt / (dx * dx)) * (
                                                   K_half_plus_i(i, j, k) * (T_Curent[i + 1, j, k] - T_Curent[i, j, k])
                                                 - K_half_minus_i(i, j, k) * (T_Curent[i, j, k] - T_Curent[i - 1, j, k])
                                                 +
                                                 (K_half_plus_j(i, j, k) * (T_Curent[i, j + 1, k] - T_Curent[i, j, k])
                                                 - K_half_minus_j(i, j, k) * (T_Curent[i, j, k] - T_Curent[i, j - 1, k]))
                                                 +
                                                  (K_half_plus_k(i, j, k) * (T_Curent[i, j, k + 1] - T_Curent[i, j, k])
                                                 - K_half_minus_k(i, j, k) * (T_Curent[i, j, k] - T_Curent[i, j, k - 1]))
                                                 )
                                                 + Q_source(t, i, j, k);
                    }
                }
            }
            //перезаписываем значения коэфциентов теплопроводности для всей сетки 
            for (int k = 1; k < N - 1; k++)
            {
                for (int j = 1; j < N - 1; j++)
                {
                    for (int i = 1; i < N - 1; i++)
                    {
                        K_Values[i, j, k] = D * T_Curent[i, j, k];
                        //if (i == 0 || i == N-1)
                        //    K_Values[i, j, k] = (/*1 -*/ 0) * T_Curent[i, j, k];
                        //if (j == 0 || j == N-1)
                        //    K_Values[i, j, k] = (/*1 -*/ 0) * T_Curent[i, j, k];
                        //if (k == 0 || k == N-1)
                        //    K_Values[i, j, k] = (/*1 -*/ 0) * T_Curent[i, j, k];
                    }
                }
            }
            //перезаписываем граничные условия 
            for (int k = 0; k < N; k++)
            {
                for (int j = 0; j < N; j++)
                {
                    for (int i = 0; i < N; i++) 
                    {
                        if (i == 0 || i == N - 1)
                            T_Next[i, j, k]=T_start;
                        if (j == 0 || j == N - 1)
                            T_Next[i, j, k] = T_start;
                        if (k == 0 || k == N - 1)
                            T_Next[i, j, k] = T_start;
                    }
                }
            }
            T_Curent = T_Next;
            t += dt;
           
            // Console.WriteLine(T_Curent[N-1, N-1, N-1]);
        }
        //TODO: Добавить метод производящий нормализацию для выводо при большой точности 

        //метод определения источника 
        public double Q_source(double t,int i, int j, int k)
        {
            double q = 0;
            if (t < tmax)
            {
                if(k==1)
                    if(j==5)
                        if (i==5)
                        {
                            q = T_laser;
                        }


                //T_Curent[6, 6, 1] = T_laser;
                //T_Curent[6, 5, 1] = T_laser;
                //T_Curent[5, 6, 1] = T_laser;
                //T_Curent[5, 5, 1] = T_laser;

                //T_Curent[1, N - 2, 1] = T_laser;
                //T_Curent[1, 1, 1] = T_laser;
                //T_Curent[N - 2, 1, 1] = T_laser;
                //T_Curent[N - 2, N - 2, 1] = T_laser;
            }
            return q;
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
        public double getTemperature(int x, int y, int z)
        {
            return T_Curent[x,y,z];
        }
        public double getTime()
        {
            return t;
        }
        

    }
   
}
