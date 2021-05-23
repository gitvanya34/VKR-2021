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
        private static double D_dust = 0.24,//сплавленного материала 
                              D_air=0.01,
                              D_metal=0.6,

                              dx = 1,//шаг 
                              dy = 1,
                              dz = 1;

        private double t = 0,
                       dt = (dx * dx) / (2) * T_start,//tay
                       t_laser_voxel = 0.02,//время обработки одного вокселя лазером
                       t_curent_laser_voxel = 0;

        private static double T_start = 20,//температур окружающей среды
                              T_laser = 600,
                              T_fusion_titan=1600,
                              T_fusion_metal;


        private static int
                       a = 0,
                       b = 10,//заменить на voxelmaxXYZ
                       N = (int)(((double)(b - a)) / dx) +2 ;

        double[,,] T_Next = new double[N , N , N ];
        double[,,] T_Curent = new double[N , N , N ];//4измерение время

        double[,,] K_Values = new double[N , N , N ];


        int[][] scaningVoxels;
        int countScanningVoxels=0;

        public HeatEquation(Options option)
        {
            //вводим воксели по порядку сканировнаия для источника 
            D_air = option.get_D_air;
            D_metal = option.get_D_metal;
            T_start = option.get_T_start;//температур окружающей среды
            T_laser = option.get_T_laser;
            T_fusion_metal = option.get_T_fusion_metal;
            t_laser_voxel = option.get_t_laser_voxel;
            // Инициализация массивов в соответсвии с начальными условиями
            for (int k = 0; k < N; k++)
            {
                for (int j = 0; j < N; j++)
                {
                    for (int i = 0; i < N; i++)
                    {
                        T_Curent[i, j, k] = T_start;//начальная всех элементов и окружающей среды                                
                     
                        K_Values[i, j, k] = D_dust;

                        ////так как у нас вокруг объекта есть пустые площади задаем для них отдельный  коэф теплопроводности (снизу можно сдлеать подложку на которой происходит печать)
                        if (i == 0 || i == N - 1)
                            K_Values[i, j, k] = D_air;
                        if (j == 0 || j == N - 1)
                            K_Values[i, j, k] = D_air;
                        if (k == 0 || k == N - 1)
                            K_Values[i, j, k] = D_air;
                    }
                }
            }
        }
        public void setScaningVoxels(int[][] scaningVoxels){
             this.scaningVoxels = scaningVoxels;
        }
        public void CalculationHeatEquation(){
            //Указываем источники их начальную температуру и время из водействия 


            //Расчет следующего значения температуры в сетке
            for (int k = 1; k < N - 1; k++)
            {
                for (int j = 1; j < N - 1; j++)
                {
                    for (int i = 1; i < N - 1; i++)
                    {
                        T_Next[i, j, k] = T_Curent[i, j, k] + (K_Values[i,j,k]*dt / (dx * dx)) * (
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

                        //изменение агрегатного состояния (порошок превратился в металл)
                        if (T_Next[i, j, k] > T_fusion_titan)
                            K_Values[i,j,k] = D_metal;
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
                       
                    }
                }
            }
            //перезаписываем граничные условия в next
            for (int k = 0; k < N; k++)
            {
                for (int j = 0; j < N; j++)
                {
                    for (int i = 0; i < N; i++)
                    {
                        if (i == 0 || i == N - 1)
                            T_Next[i, j, k] = T_start;
                        if (j == 0 || j == N - 1)
                            T_Next[i, j, k] = T_start;
                        if (k == 0 || k == N - 1)
                            T_Next[i, j, k] = T_start;
                    }
                }
            }
            T_Curent = T_Next;

            //измененение шага по времени для устойчивости
            dt = (dx * dx) / (2 * Tmax()) ;//tay
            t += dt;   
            // Console.WriteLine(T_Curent[N-1, N-1, N-1]);
        }
    

        public double Tmax(){ 
            double max=0;

            foreach(double t in T_Curent)
            {
                max = t > max ? t : max;
              
            }
            return max;
        }
        //метод определения источника 
        public double Q_source(double t,int i, int j, int k)
        {
            ////TODO: Проверку является ли воксель  источчником на данном этапе  
            //согласовать период прорисовки(сканирование) одного вокселя 
            //установить порядок сканирования вокселей
            double q = 0;
            if(countScanningVoxels< scaningVoxels.Length)
                if(scaningVoxels[countScanningVoxels][0]+1==i)
                    if(scaningVoxels[countScanningVoxels][1]+1==j)
                        if(scaningVoxels[countScanningVoxels][2]+1==k)
                            if (t-t_curent_laser_voxel < t_laser_voxel)
                            {                        
                                q = T_laser;
                            }
                            else 
                            {
                                t_curent_laser_voxel = t;
                                countScanningVoxels += 1;
                            }
           
            return q;
        }
        public double K_half_plus_i( int i, int j, int k)
        {
            double K_half = 0;

            K_half =  (T_Curent[ i, j, k] + T_Curent[ i + 1, j, k]) / 2;
            return K_half;
        }
        public double K_half_minus_i( int i, int j, int k)
        {
            double K_half = 0;

            K_half =  (T_Curent[i, j, k] + T_Curent[ i - 1, j, k]) / 2;
            return K_half;
        }
        public double K_half_plus_j( int i, int j, int k)
        {
            double K_half = 0;

            K_half= (T_Curent[ i, j, k] + T_Curent[ i, j+1, k]) / 2;
            return K_half;
        }
        public double K_half_minus_j( int i, int j, int k)
        {
            double K_half = 0;

            K_half = (T_Curent[ i, j, k] + T_Curent[ i, j-1, k]) / 2;
            return K_half;
        }
        public double K_half_plus_k( int i, int j, int k)
        {
            double K_half = 0;

            K_half= (T_Curent[ i, j, k] + T_Curent[ i , j, k + 1]) / 2;
            return K_half;
        }
        public double K_half_minus_k( int i, int j, int k)
        {
            double K_half = 0;

            K_half = (T_Curent[ i, j, k] + T_Curent[ i , j, k - 1]) / 2;
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
        

        public int toNormalization(int ijk)    //TODO: Добавить метод производящий нормализацию для выводо при большой точности 
        {
            return ijk * 10;
        }
        
        //если вокслель расплавился то поменялся коэфциент теплопроводности ()
        public bool boolMelted(int i ,int j, int k) //расплавился воксель или нет 
        {
            return K_Values[i, j, k] == D_metal ? true : false; 
        }
    }
   
}
