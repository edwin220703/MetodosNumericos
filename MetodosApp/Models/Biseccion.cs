using MetodosApp.Services.Interfase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosApp.Models
{
    class Biseccion : General
    {
        public double Xm { get; set; }
        public double FXI { get; set; }
        public double FXD { get; set; }
        public double FXM { get; set; }
        public double FXIxFXM { get; set; }

        public Biseccion(double Xi,double Xd)
        {
            this.Xi = Xi;
            this.Xd = Xd;

            //FORMULA: PUNTO MEDIO
            this.Xm = (Xi + Xd) / 2;

            //OBTENIENDO LOS VALORES EN F(x)
            this.FXI = GetValueFuntion(Xi);
            this.FXD = GetValueFuntion(Xd);
            this.FXM = GetValueFuntion(Xm);
            this.FXIxFXM = FXI * FXM;
        }
    }

}
