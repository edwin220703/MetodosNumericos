using MetodosApp.Models;
using MetodosApp.Services.Interfase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosApp.Services
{
    class NewtonServices : IRequeriments<Newton>
    {
        private double _tol { get; set; } = 0.01;
        private int _n { get; set; } = 20;

        private List<Newton> results {  get; set; }
        private Newton _newton { get; set; }


        public NewtonServices(double Xi, double tol, int n)
        {
            results = new List<Newton>();
            _newton = new Newton(Xi);

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
            while (_newton.FXI > _tol || results.Count != _n)
            {

                if (_newton.FXI == 0.0000 || Math.Abs(_newton.FXI) <= _tol)
                {
                    Console.WriteLine($"La raiz es {_newton.Xi}");
                    break;
                }

                _newton = new Newton(_newton.X2);

                results.Add(_newton);
            }
        }
    }
}
