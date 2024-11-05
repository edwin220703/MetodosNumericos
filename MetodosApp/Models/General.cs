using MetodosApp.Services.Interfase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosApp.Models
{
    class General
    {
        public double Xi { get; set; }

        public double Xd { get; set; }
//------------------------------------------------------------------------
        //FUNCION X^2-3X+2^-X
        public double GetValueFuntion(double x) => ((Math.Pow(x, 2))) - 3 * x + Math.Pow(2, (-1*x));

        //DERIVADA 2x−3−2^−x*ln(2)
        public double GetValueDerivada(double x) => 2 * x - Math.Log(2) *  Math.Pow(2,(x - 1)) - 3;
    }
}
