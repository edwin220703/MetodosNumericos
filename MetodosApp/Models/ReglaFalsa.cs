using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosApp.Models
{
    class ReglaFalsa : General
    {
        public double Xm { get; set; }
        public double FXI { get; set; }
        public double FXD { get; set; }
        public double FXM { get; set; }
        public double FXIxFXM { get; set; }

        public ReglaFalsa(double Xi, double Xd)
        {
            this.Xi = Xi;
            this.Xd = Xd;

            //OBTENIENDO LOS VALORES EN F(x)
            this.FXI = GetValueFuntion(Xi);
            this.FXD = GetValueFuntion(Xd);

            //FORMULA: Xi = a F(b) - b F(a) / F(b)-F(a)
            this.Xm = ((Xi * FXD) - (Xd * FXI)) / (FXD - FXI);

            //OBTENIENDO LOS VALORES EN F(x)
            this.FXM = GetValueFuntion(Xm);
            this.FXIxFXM = FXI*FXM;
        }
    }
}
