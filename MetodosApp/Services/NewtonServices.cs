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
    class NewtonServices : IRequeriments<Newton>
    {
        private double _tol { get; set; } = 0.01;
        private int _n { get; set; } = 20;
        private int iteraciones { get; set; } = 0;

        private List<Newton> results { get; set; }
        private Newton _newton { get; set; }

        public Action<double, double> NotificarPadre { get; set; }

        public NewtonServices(double Xi, double tol, int n)
        {
            results = new List<Newton>();
            _newton = new Newton(Xi);
            iteraciones = 0;

            this._tol = tol;
            this._n = n;

            results.Add(_newton);
        }

        public List<Newton> GetAllResult()
        {
            Logic();
            return results;
        }

        public void Logic()
        {
            Regex matchdecimal = new Regex(_tol.ToString());

            while (_newton.FXI > _tol || results.Count != _n)
            {
                iteraciones++;
                _newton.N = iteraciones;

                if (_newton.FXI == 0.0000 || Math.Abs(Math.Round(_newton.FXI, 2)) <= _tol || matchdecimal.IsMatch(_newton.FXI.ToString()))
                {
                    MessageBox.Show($"La raiz es {_newton.Xi}");

                    NotificarPadre?.Invoke(_newton.Xi, _newton.FXI);
                    break;

                }

                if (results.Count == _n)
                    break;

                _newton = new Newton(_newton.X2);

                results.Add(_newton);
            }

            if(results.Count == _n && results.Last().FXI > _tol)
            {
                MessageBox.Show($"La raiz no fue encontrada", "No Encontrada", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
