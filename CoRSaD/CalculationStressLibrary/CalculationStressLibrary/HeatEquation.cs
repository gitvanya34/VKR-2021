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
                       dt = 0,//tay
                       t_laser_voxel = 0.02,//время обработки одного вокселя лазером
                       t_curent_laser_voxel = 0;//время для таймера 

        private static double T_start = 20,//температур окружающей среды
                              T_laser = 600,
                              T_fusion_titan=1600,
                              T_fusion_metal;


        private static int
                       a ,b ,N,I,J,K;

        double[,,] T_Next;
        double[,,] T_Curent;
        double[,,] K_Values;
        bool[,,] boolPrinted;//ячейки которые которые прошли обработку 

        int[][] scaningVoxels;
        int countScanningVoxels=0;

        private Deformations deformation;
        public Deformations getDeformation { get => deformation; }
        public int[][] ScaningVoxels { get => scaningVoxels; set => scaningVoxels = value; }
        public int CountScanningVoxels { get => countScanningVoxels; set => countScanningVoxels = value; }

        public HeatEquation(Options option,int Icount,int Jcount,int Kcount)
        {
            a = 0;
           // b = 59;//заменить на voxelmaxXYZ
            I = (int)(((double)(Icount - a)) / dx) + 2;
            J = (int)(((double)(Jcount - a)) / dx) + 2;
            K = (int)(((double)(Kcount - a)) / dx) + 2;

            T_Next = new double[I,J,K];
            T_Curent = new double[I,J,K];//4измерение время
            K_Values = new double[I, J, K];
            boolPrinted = new bool[I,J,K];
            //вводим воксели по порядку сканировнаия для источника 
            D_dust = option.get_D_dust;
            D_air = option.get_D_air;
            D_metal = option.get_D_metal;
            T_start = option.get_T_start;//температур окружающей среды
            T_laser = option.get_T_laser;
            T_fusion_metal = option.get_T_fusion_metal;
            t_laser_voxel = option.get_t_laser_voxel;


            dt = (dx * dx) / (2) * T_start;
                    
            // Инициализация массивов в соответсвии с начальными условиями

            Parallel.For(0, K,
             k =>
             //for (int k = 0; k < K; k++)
             {
               for (int j = 0; j < J; j++)
               {
                   for (int i = 0; i < I; i++)
                   {
                       T_Curent[i, j, k] = T_start;//начальная всех элементов и окружающей среды
                                                   
                         K_Values[i, j, k] = D_air;

                         //if (k == 0)
                         //{ K_Values[i, j, k] = D_metal; }//подложка
                         //if (k == 1)
                         //{ K_Values[i, j, k] = D_dust; }//первый слой 

                         ////так как у нас вокруг объекта есть пустые площади задаем для них отдельный  коэф теплопроводности (снизу можно сдлеать подложку на которой происходит печать)
                       //  if (i == 0 || i == I - 1)
                       //    K_Values[i, j, k] = D_air;
                       //if (j == 0 || j == J - 1)
                       //    K_Values[i, j, k] = D_air;
                       //if (k == 0 || k == K - 1)
                       //    K_Values[i, j, k] = D_air;
                         if (i == 0 || i == I - 1)
                           K_Values[i, j, k] = D_dust;
                       if (j == 0 || j == J - 1)
                           K_Values[i, j, k] = D_dust;
                       if (k == 0 || k == K - 1)
                           K_Values[i, j, k] = D_dust;

                       boolPrinted[i, j, k] = false;
                   }
               }
           });

            deformation = new Deformations(option,dx,I,J,K);

        }
        public void setScaningVoxels(int[][] scaningVoxels){
             this.scaningVoxels = scaningVoxels;
        }

        public void CalculationHeatEquation(){
            //Указываем нанесение слоя на рабочую поверхность
            Parallel.For(1, K - 1,
           k =>
            //for (int k = 1; k < K - 1; k++)
            {
                for (int j = 1; j < J - 1; j++)
                {
                    for (int i = 1; i < I - 1; i++)
                    {
                        if (countScanningVoxels < scaningVoxels.Length)
                            if (scaningVoxels[countScanningVoxels][2] +1  == k && K_Values[i, j, k] == D_air)
                            {
                                K_Values[i, j, k] = D_dust;
                            }

                    }
                }
            });

            //Расчет следующего значения температуры в сетке
            Parallel.For(1, K - 1,
            k =>
            //for (int k = 1; k < K - 1; k++)
            {
                for (int j = 1; j < J - 1; j++)
                {
                    for (int i = 1; i < I - 1; i++)
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
                                                 + (Q_source(t, i, j, k));

                        //изменение агрегатного состояния (порошок превратился в металл)
                        if (T_Next[i, j, k] > T_fusion_metal && scaningVoxels[countScanningVoxels][2] + 1 >= k)
                        {
                            K_Values[i, j, k] = D_metal;
                            boolPrinted[i, j, k] = true;
                        }
                    }
                }

            });
           
            //перезаписываем граничные условия в next
           Parallel.For(0, K,
           k =>
           //for (int k = 0; k < K; k++)
           {
                for (int j = 0; j < J; j++)
                {
                    for (int i = 0; i < I; i++)
                    {
                        if (i == 0 || i == I - 1)
                            T_Next[i, j, k] = T_start;
                        if (j == 0 || j == J - 1)
                            T_Next[i, j, k] = T_start;
                        if (k == 0 || k == K - 1)
                            T_Next[i, j, k] = T_start;
                    }
                }
            });
            /////

            deformation.CalculationDeformations(T_Next, boolPrinted);


            ////
            for (int k = 1; k < K-1; k++)
            {
                for (int j = 1; j < J-1; j++)
                {
                    for (int i = 1; i < I-1; i++)
                    {
                        T_Curent[i, j, k] = T_Next[i, j, k];
                    }
                }
            }
            //  Array.Copy(T_Curent, T_Next, T_Curent.Length);




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

        bool flag = false;
        public double Q_source(double t,int i, int j, int k)
        {     
            ////TODO: Проверку является ли воксель  источчником на данном этапе  
            //согласовать период прорисовки(сканирование) одного вокселя 
            //установить порядок сканирования вокселей
            double q = 0;
                if (countScanningVoxels < scaningVoxels.Length)
                    if (scaningVoxels[countScanningVoxels][0] + 1 == i)
                        if (scaningVoxels[countScanningVoxels][1] + 1 == j)
                            if (scaningVoxels[countScanningVoxels][2] + 1 == k)
                                if (t - t_curent_laser_voxel < t_laser_voxel)
                                {
                                    q = dt * T_laser;
                                }
                                else
                                {
                                    t_curent_laser_voxel = t;
                                    countScanningVoxels += 1;
                                }
            return  q;
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
        public double getDeformationX(int x, int y, int z)
        {
            return deformation.getDeformationX(x,y,z);
        }
        public double getDeformationY(int x, int y, int z)
        {
            return deformation.getDeformationY(x, y, z);
        }
        public double getDeformationZ(int x, int y, int z)
        {
            return deformation.getDeformationZ(x, y, z);
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
            return boolPrinted[i, j, k]; 
        }
    }
   
}
