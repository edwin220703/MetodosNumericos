using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace MetodosApp.Services
{
    class RegressionLinealServices
    {
        public List<Models.RegressionLineal> models { get; }
        private Models.RegressionLineal regressionLineal;
        private static int N;
        GaussJordanServices GaussJordanServices;

        //SUMATORIAS
        private double SN;
        private double SX;
        private double SY;
        private double SX2;
        private double SX3;
        private double SX4;
        private double SX5;
        private double SX6;
        private double SYX;
        private double SYX2;
        private double SYX3;

        public RegressionLinealServices()
        {
            N = 0;
            models = new List<Models.RegressionLineal>();
        }

        public void AgregarModelo(double x, double y)
        {
            models.Add(new Models.RegressionLineal(x, y, N));

            N++;
            UpdateSum();
        }

        public List<Models.RegressionLineal> GetList() => models;


        public void UpdateSum()
        {
            SN = models.Sum(x => x.N);
            SX = models.Sum(x => x.X);
            SY = models.Sum(x => x.Y);
            SX2 = models.Sum(x => x.X2);
            SX3 = models.Sum(x => x.X3);
            SX4 = models.Sum(x => x.X4);
            SX5 = models.Sum(x => x.X5);
            SX6 = models.Sum(x => x.X6);
            SYX = models.Sum(x => x.YX);
            SYX2 = models.Sum(x => x.YX2);
            SYX3 = models.Sum(x => x.YX3);
        }


        //Seccion Para DEFINIR LINEAL, CUADRATICA Y CUBICA
        public string MetodoLineal() => $"{SY} = {SN}a0 + {SX}a1 \n " +
            $"{SYX} = {SX}a0 + {SX2}";


        public string MetodoCuatratica()
        {
            return $"{SY} = {SN}a0 + {SX}a1 + {SX2}a2 \n " +
                $"{SYX} = {SX}a0 + {SX2}a1 + {SX3}a2 \n" +
                $"{SYX2} = {SX2}a0 + {SX3}a1 + {SX4}a2";
        }

        public string MetodoCubico()
        {
            return $"{SY} = {SN}a0 + {SX}a1 + {SX2}a2 + {SX3}a3\n " +
                 $"{SYX} = {SX}a0 + {SX2}a1 + {SX3}a2 + {SX4}a3 \n" +
                 $"{SYX2} = {SX2}a0 + {SX3}a1 + {SX4}a2 + {SX5}a3 \n" +
                 $"{SYX3} = {SYX3}a0 + {SX4}a1 + {SX5}a2 + {SX6}a3";
        }

        public double[,] GetMatrizLineal()
        {
            double[,] lineal =
            {
                {SN,SX,SY },
                {SX,SX2,SYX }
            };

            GaussJordanServices = new GaussJordanServices(lineal, 2);
            return GaussJordanServices.GetMatriz();
        }

        public double[,] GetMatrizCuadratica()
        {
            double[,] cuadratica =
            {
                {SN,SX,SX2,SY },
                {SX,SX2,SX3,SYX},
                {SX2,SX3,SX4,SYX2}
            };

            GaussJordanServices = new GaussJordanServices(cuadratica, 3);
            return GaussJordanServices.GetMatriz();
        }

        public double[,] GetMatrizCubico()
        {
            double[,] cubica =
{
                {SN,SX,SX2,SX3,SY },
                {SX,SX2,SX3,SX4,SYX},
                {SX2,SX3,SX4,SX5,SYX2},
                {SX3,SX4,SX5,SX6,SYX3}
            };

            GaussJordanServices = new GaussJordanServices(cubica, 4);
            return GaussJordanServices.GetMatriz();
        }
    }
}
