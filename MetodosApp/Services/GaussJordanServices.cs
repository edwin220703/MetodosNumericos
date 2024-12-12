using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MetodosApp.Services
{
    public class GaussJordanServices
    {
        private double[,] matriz;
        private int n;
        private List<double[,]> listMatriz;

        public GaussJordanServices(double[,] matriz, int n)
        {
            this.matriz = matriz;
            this.n = n;
        }

        public double[,] GetMatriz()
        {
            listMatriz = new List<double[,]>();

            for (int i = 0; i < n; i++)
            {
                // Hacer el pivote 1 dividiendo toda la fila por el pivote
                double pivot = matriz[i, i];

                if (pivot == 0)
                {
                    MessageBox.Show("El sistema no tiene solución única.");
                }

                for (int j = 0; j <= n; j++)
                {
                    matriz[i, j] /= pivot;
                    listMatriz.Add(matriz);
                }

                // Hacer ceros en la columna del pivote para las otras filas
                for (int k = 0; k < n; k++)
                {
                    if (k != i)
                    {
                        double factor = matriz[k, i];
                        for (int j = 0; j <= n; j++)
                        {
                            matriz[k, j] -= factor * matriz[i, j];
                        }
                    }
                }
            }

            return matriz;
        }
    }
}
