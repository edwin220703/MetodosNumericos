using MetodosApp.Models;
using MetodosApp.Services.Interfase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace MetodosApp.Services
{
    class ReglaFalsaServices : IRequeriments<ReglaFalsa>
    {
        private List<ReglaFalsa> results;
        private ReglaFalsa reglaFalsa;
        private double tol { get; set; } = 0.01;
        private int n { get; set; } = 20;
        private int iteraciones { get; set; } = 0;

        public Action<double, double> NotificarPadre { get; set; }

        public ReglaFalsaServices(double Xi,double Xd, double tol, int n)
        {
            results = new List<ReglaFalsa>();
            reglaFalsa = new ReglaFalsa(Xi, Xd);
            this.tol = tol;
            this.n = n;
            this.iteraciones = 0;
        }

        public void Logic()
        {
            Regex matchdecimal = new Regex(tol.ToString());

            while (reglaFalsa.FXM > tol || results.Count != n)
            {
                iteraciones++;
                reglaFalsa.N = iteraciones;

                results.Add(reglaFalsa);

                if (reglaFalsa.FXM == 0.0000 || Math.Abs(Math.Round(reglaFalsa.FXM,2)) <= tol || matchdecimal.IsMatch(reglaFalsa.FXM.ToString()))
                {
                    MessageBox.Show($"La raiz fue encontrada en {reglaFalsa.Xm}", "Encontrado", MessageBoxButton.OK, MessageBoxImage.Information);
                    NotificarPadre?.Invoke(reglaFalsa.Xm, reglaFalsa.FXM);
                    return;
                }

                if (results.Count == n)
                    break;

                if (reglaFalsa.FXIxFXM > 0)
                    reglaFalsa = new ReglaFalsa(reglaFalsa.Xm, reglaFalsa.Xd);
                else
                    reglaFalsa = new ReglaFalsa(reglaFalsa.Xi, reglaFalsa.Xm);

            }

            if (results.Count == n && results.Last().FXM > tol)
            {
                MessageBox.Show($"La raiz no fue encontrada", "No Encontrada", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public List<ReglaFalsa> GetAllResult()
        {
            Logic();
            return results;
        }
    }
}
