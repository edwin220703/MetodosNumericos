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

            //NOTA:USE ESTA FORMA PORQUE NO TOMABA LA FORMULA DIRECTAMENTE, HABIA QUE HACERLA POR ORDEN ATT:EDWIN
            X2 = Xi - (FXI * (Xd - Xi)/(FXD-FXI));


        }
    }
}
