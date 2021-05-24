﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationStressLibrary
{
    public class Deformations
    {


        double[,,] Ex_Curent;
        double[,,] Ey_Curent;
        double[,,] Ez_Curent;

        double[,,] Ex_Next;
        double[,,] Ey_Next;
        double[,,] Ez_Next;

        double[,,] alpha_cup;
        double alpha_0 = 2.1;//коэфициент теплового расширения

        double E_crit=-20;//изменить на значение
        int N;
        double dx;

        double T_start;

        public Deformations(Options options, double dx,int N)
        {
            this.N = N;
            this.dx = dx;
            T_start = options.get_T_start;
            Ex_Curent = new double[N, N, N];
            Ey_Curent = new double[N, N, N];
            Ez_Curent = new double[N, N, N];

            Ex_Next = new double[N, N, N];
            Ey_Next = new double[N, N, N];
            Ez_Next = new double[N, N, N];

            alpha_cup = new double[N, N, N];

            for (int k = 0; k < N; k++)
            {
                for (int j = 0; j < N; j++)
                {
                    for (int i = 0; i < N; i++)
                    {
                        Ex_Curent[i, j, k] = 0;
                        Ey_Curent[i, j, k] = 0;
                        Ez_Curent[i, j, k] = 0;

                        Ex_Next[i, j, k] = 0;
                        Ey_Next[i, j, k] = 0;
                        Ez_Next[i, j, k] = 0;

                    }
                }
            }



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

            for (int k = 0; k < N; k++)
            {
                for (int j = 0; j < N; j++)
                {
                    for (int i = 0; i < N; i++)
                    {
                        if (boolPrinted[i, j, k])
                            alpha_cup[i, j, k] = alpha_0 * T[i, j, k] - T_start;
                        else
                            alpha_cup[i, j, k] = 0;

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
        public double getDeformationX(int x, int y, int z)
        {
            return Ex_Curent[x,y,z];
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
