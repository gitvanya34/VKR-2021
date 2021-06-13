using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationStressLibrary
{
    public class Options
    {
        private double D_dust;
        private double D_air=0.01;
        private double D_metal=0.6; 

        private double T_start = 20;//температур окружающей среды
        private double T_laser = 600;
        private double T_fusion_metal=1600;

        private double t_laser_voxel = 0.02;//время обработки

        private double alpha_0 = 0.3;//коэфициент теплового расшире
        private double E_crit = -245;//изменить на значение
        public Options()
        {
            D_air = 0.01;
            D_metal = 0.6;

            T_start = 20;//температур окружающей среды
            T_laser = 600;
            T_fusion_metal = 1600;
            t_laser_voxel = 0.02;

           alpha_0 = 0.3;//коэфициент теплового расшире
           E_crit = -245;//изменить на значение
    }

        public Options(double d_dust, double d_air, double d_metal, double start, double laser, double fusion_metal, double laser_voxel, double alpha_0, double e_crit)
        {
            D_dust = d_dust;
            D_air = d_air;
            D_metal = d_metal;
            T_start = start;
            T_laser = laser;
            T_fusion_metal = fusion_metal;
            t_laser_voxel = laser_voxel;
            this.alpha_0 = alpha_0;
            E_crit = e_crit;
        }

        public double get_D_dust { get => D_dust; set => D_dust = value; }
        public double get_D_air { get => D_air; set => D_air = value; }
        public double get_D_metal { get => D_metal; set => D_metal = value; }
        public double get_T_start { get => T_start; set => T_start = value; }
        public double get_T_laser { get => T_laser; set => T_laser = value; }
        public double get_T_fusion_metal { get => T_fusion_metal; set => T_fusion_metal = value; }
        public double get_t_laser_voxel { get => t_laser_voxel; set => t_laser_voxel = value; }
        public double get_Alpha_0 { get => alpha_0; set => alpha_0 = value; }
        public double get_E_crit { get => E_crit; set => E_crit = value; }
    }
}
