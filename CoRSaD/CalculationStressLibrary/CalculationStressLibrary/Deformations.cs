using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CalculationStressLibrary
{
    public class Deformations
    {
        //норм видно при  alpha_0 = 0.3; E_crit=-245; куб 10на10


        private double[,,] Ex_Curent;
        private double[,,] Ey_Curent;
        private double[,,] Ez_Curent;

        private double[,,] Ex_Next;
        private double[,,] Ey_Next;
        private double[,,] Ez_Next;

        private double[,,] alpha_cup;
        private double alpha_0 = 0.3;//коэфициент теплового расшире


        private double E_crit=-245;//изменить на значение
        private int N,I,J,K;
        private double dx;

        private double T_start;
 
        public Deformations(Options options, double dx,int I,int J,int K)
        {
            this.I = I;
            this.J = J;
            this.K = K;
            this.dx = dx;
            T_start = options.get_T_start;
            Ex_Curent = new double[I, J, K];
            Ey_Curent = new double[I, J, K];
            Ez_Curent = new double[I, J, K];

            Ex_Next = new double[I,J,K];
            Ey_Next = new double[I,J,K];
            Ez_Next = new double[I, J, K];

            alpha_cup = new double[I, J, K];

            Parallel.For(0, K,
            k =>
            //for (int k = 0; k < N; k++)
            {
                for (int j = 0; j <J; j++)
                {
                    for (int i = 0; i < I; i++)
                    {
                        Ex_Curent[i, j, k] = 0;
                        Ey_Curent[i, j, k] = 0;
                        Ez_Curent[i, j, k] = 0;

                        Ex_Next[i, j, k] = 0;
                        Ey_Next[i, j, k] = 0;
                        Ez_Next[i, j, k] = 0;

                        alpha_cup[i, j, k] = 0;
                    }
                }
            });

            //Ex_Curent[1, 1, 1] = 200500;
            //Ey_Curent[1, 1, 1] = 200500;
            //Ez_Curent[1, 1, 1] = 200500;

        }
        public void CalculationDeformations(double[,,]  T)
        {

            for (int k = 0; k < N; k++)
            {
                for (int j = 0; j < N; j++)
                {
                    for (int i = 0; i < N; i++)
                    {
                        alpha_cup[i,j,k] = alpha_0 * T[i,j,k] - T_start;

                        if (i == 0 || i == N - 1)
                            alpha_cup[i, j, k] = 0;
                        if (j == 0 || j == N - 1)
                            alpha_cup[i, j, k] = 0;
                        if (k == 0 || k == N - 1)
                            alpha_cup[i, j, k] = 0;
                    }
                }
            }

            for (int k = 1; k < N - 1; k++)
            {
                for (int j = 1; j < N - 1; j++)
                {
                    for (int i = 1; i < N - 1; i++)
                    {
                        Ex_Next[i, j, k] = -dx * ((alpha_cup[i + 1, j, k] - alpha_cup[i - 1, j, k]) / 2);
                        Ey_Next[i, j, k] = -dx * ((alpha_cup[i, j + 1, k] - alpha_cup[i, j - 1, k]) / 2);
                        Ez_Next[i, j, k] = -dx * ((alpha_cup[i, j, k + 1] - alpha_cup[i, j, k - 1]) / 2);


                        if (Math.Abs(Ex_Curent[i, j, k]) > E_crit)   
                            if (Math.Abs(Ex_Next[i, j, k]) < Math.Abs(Ex_Curent[i, j, k]))
                                Ex_Next[i, j, k] = Ex_Curent[i, j, k];
                         

                        if (Math.Abs(Ey_Curent[i, j, k]) > E_crit)
                            if (Math.Abs(Ey_Next[i, j, k]) < Math.Abs(Ey_Curent[i, j, k]))
                                Ey_Next[i, j, k] = Ey_Curent[i, j, k];

                        if (Math.Abs(Ez_Curent[i, j, k]) > E_crit)
                            if (Math.Abs(Ez_Next[i, j, k]) < Math.Abs(Ez_Curent[i, j, k]))
                                Ez_Next[i, j, k] = Ez_Curent[i, j, k];
                    }
                }
            }
            Ex_Curent = Ex_Next;
            Ey_Curent = Ey_Next;
            Ez_Curent = Ez_Next;
        }
        public void CalculationDeformations(double[,,]  T, bool[,,] boolPrinted)
        {
            Parallel.For(0, K,
            k =>
            //for (int k = 0; k < N; k++)
            {
                for (int j = 0; j < J; j++)
                {
                    for (int i = 0; i < I; i++)
                    {
                        if (boolPrinted[i, j, k])
                            alpha_cup[i, j, k] = alpha_0 * (T[i, j, k] - T_start);
                        //else
                        //    alpha_cup[i, j, k] = 0;

                    }
                }
            });


            Parallel.For(1, K - 1,
            k =>
            //for (int k = 1; k < N - 1; k++)
            {
                for (int j = 1; j < J - 1; j++)
                {
                    for (int i = 1; i < I - 1; i++)
                    {


                        Ex_Next[i, j, k] = -dx * ((alpha_cup[i + 1, j, k] - alpha_cup[i - 1, j, k]) / 2);
                        Ey_Next[i, j, k] = -dx * ((alpha_cup[i, j + 1, k] - alpha_cup[i, j - 1, k]) / 2);
                        Ez_Next[i, j, k] = -dx * ((alpha_cup[i, j, k + 1] - alpha_cup[i, j, k - 1]) / 2);


                        if (Math.Abs(Ex_Curent[i, j, k]) > Math.Abs(E_crit))
                            if (Math.Abs(Ex_Next[i, j, k]) < Math.Abs(Ex_Curent[i, j, k]))
                                Ex_Next[i, j, k] = Ex_Curent[i, j, k];



                        if (Math.Abs(Ey_Curent[i, j, k]) > Math.Abs(E_crit))
                            if (Math.Abs(Ey_Next[i, j, k]) < Math.Abs(Ey_Curent[i, j, k]))
                                Ey_Next[i, j, k] = Ey_Curent[i, j, k];



                        if (Math.Abs(Ez_Curent[i, j, k]) > Math.Abs(E_crit))
                            if (Math.Abs(Ez_Next[i, j, k]) < Math.Abs(Ez_Curent[i, j, k]))
                                Ez_Next[i, j, k] = Ez_Curent[i, j, k];




                    }
                }
            });


            Parallel.For(0, K, k =>
            //for (int k = 0; k < N; k++)
            {
                for (int j = 0; j < J; j++)
                {
                    for (int i = 0; i < I; i++)
                    {
                        Ex_Curent[i, j, k] = Ex_Next[i, j, k];
                        Ey_Curent[i, j, k] = Ey_Next[i, j, k];
                        Ez_Curent[i, j, k] = Ez_Next[i, j, k];
                    }
                }
            });

            // ExporttoFileCSV();

        }
        public double getDeformationX(int x, int y, int z)
        {
            return Ex_Curent[x,y,z];
        }
        public  void ExportDeformationsToCSV(StreamWriter myStream)
        {
          
                for (int k = 1; k < K - 1; k++)
                {
                    for (int j = 1; j < J - 1; j++)
                    {
                        for (int i = 1; i < I - 1; i++)
                        {
                            myStream.Write(Ex_Curent[i, j, k].ToString() + ";");
                            myStream.Write(Ey_Curent[i, j, k].ToString() + ";");
                            myStream.Write(Ez_Curent[i, j, k].ToString() + ";\n");
                         
                        }
                    }
                }
            
        }
        public double getDeformationY(int x, int y, int z)
        {
            return Ey_Curent[x,y,z];
        }
        public double getDeformationZ(int x, int y, int z)
        {
            return Ez_Curent[x,y,z];
        }

    }
}
