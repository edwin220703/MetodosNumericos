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
    class SecanteServices : IRequeriments<Secante>
    {
        private double _tol { get; set; } = 0.01;
        private int _n { get; set; } = 20;

        private List<Secante> results { get; set; }
        private Secante _secante { get; set; }
        private int iteraciones { get; set; } = 0;

        public Action<double, double> ?NotificarPadre { get; set; }

        public SecanteServices(double Xi, double Xd, double Tol, int n)
        {
            results = new List<Secante>();

            this._tol = Tol;
            this._n = n;
            this.iteraciones = 0;

            _secante = new Secante(Xi, Xd);
            results.Add(_secante);
        }

        public void Logic()
        {
            //PARA CALCULAR EL DECIMAL DE LA TOLERANCIA
            Regex matchdecimal = new Regex(_tol.ToString()); 

            while (_secante.FXI > _tol || results.Count != _n)
            {
                iteraciones++;
                _secante.N = iteraciones;

                if (_secante.FXI == 0.0000 || Math.Abs(Math.Round(_secante.FXI, 2)) <= _tol || matchdecimal.IsMatch(_secante.FXI.ToString()))
                {
                    MessageBox.Show($"La raiz es {_secante.Xi}");
                    NotificarPadre?.Invoke(_secante.Xi,_secante.FXI);
                    break;
                }

                if (results.Count == _n)
                    break;

                _secante = new Secante(_secante.X2,_secante.Xi);
                
                results.Add(_secante);
            }

            if(results.Count == _n && results.Last().FXI > _tol)
            {
                MessageBox.Show($"La raiz no fue encontrada", "No Encontrada", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public List<Secante> GetAllResult()
        {
            Logic();
            return results;
        }

    }
}
