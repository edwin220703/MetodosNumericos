using MetodosApp.Models;
using MetodosApp.Services.Interfase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosApp.Services
{
    class SecanteServices : IRequeriments<Secante>
    {
        private double _tol { get; set; } = 0.01;
        private int _n { get; set; } = 20;

        private List<Secante> results { get; set; }
        private Secante _secante { get; set; }

        public SecanteServices(double Xi, double Xd, double Tol, int n)
        {
            results = new List<Secante>();

            this._tol = Tol;
            this._n = n;

            _secante = new Secante(Xi, Xd);
            results.Add(_secante);
        }

        public void Logic()
        {
            while (_secante.FXI > _tol || results.Count != _n)
            {

                if (_secante.FXI == 0.0000 || Math.Abs(_secante.FXI) <= _tol)
                {
                    Console.WriteLine($"La raiz es {_secante.Xi}");
                    break;
                }

                _secante = new Secante(_secante.X2,_secante.Xi);

                results.Add(_secante);
            }
        }

        public List<Secante> GetAllResult()
        {
            Logic();
            return results;
        }

    }
}
