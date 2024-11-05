using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosApp.Models
{
    class Secante : General
    {
        public double X2 { get; set; }

        public double FXI { get; set; }

        public double FXD { get; set; }

        public Secante(double Xi, double Xd)
        {
            this.Xi = Xi;
            this.Xd = Xd;

            FXI = GetValueFuntion(Xi);
            FXD = GetValueFuntion(Xd);

            //FORMULA: X2 = X1 - (X1-X0)(FX1)/FX1-FX0
            //this.X2 = Xd - (((Xd - Xi) * FXD)/FXD-FXI);

            X2 = Xi - ((Xd - Xi) / (FXD - FXI)) * FXD;
        }
    }
}
