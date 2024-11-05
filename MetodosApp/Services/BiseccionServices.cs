using MetodosApp.Models;
using MetodosApp.Services.Interfase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MetodosApp.Services
{
    class BiseccionServices : IRequeriments<Biseccion>
    {
        private List<Biseccion> results;
        private Biseccion biseccion;
        private double tol { get; set; } = 0.01;
        private int n { get; set; } = 20;

        public BiseccionServices(double xi, double xd, double tol, int n)
        {
            biseccion = new Biseccion(xi, xd);
            results = new List<Biseccion>();
            this.tol = tol;
            this.n = n;
        }

        public void Logic()
        {
            while (biseccion.FXM > tol || results.Count != n)
            {
                results.Add(biseccion);

                if (biseccion.FXM == 0 || Math.Abs(biseccion.FXM) <= tol)
                {
                    MessageBox.Show($"La raiz fue encontrada en {biseccion.Xm}", "Encontrado", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                if (biseccion.FXIxFXM > 0)
                    biseccion = new Biseccion(biseccion.Xm, biseccion.Xd);
                else
                    biseccion = new Biseccion(biseccion.Xi, biseccion.Xm);
            }

            if (results.Count == n && results.Last().FXM > tol)
            {
                MessageBox.Show($"La raiz no fue encontrada", "No Encontrada", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public List<Biseccion> GetAllResult()
        {
            Logic();
            return results;
        }
    }
}
