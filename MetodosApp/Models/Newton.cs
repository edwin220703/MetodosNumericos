using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosApp.Models
{
    class Newton : General
    {
        public double X2 { get; set; }

        public double FXI { get; set; }

        public double dFXI { get; set; }

        public Newton(double Xi)
        {
            this.Xi = Xi;

            this.FXI = GetValueFuntion(Xi);
            this.dFXI = GetValueDerivada(Xi);

            //FUNCION: X2 = Xi  - F(xi) / dF(Xi)
            X2 = Xi - (FXI/dFXI);
        }
    }
}
