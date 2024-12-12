using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosApp.Models
{
    internal class RegressionLineal
    {
        public int N {  get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double X2 { get; }
        public double X3 { get; }
        public double X4 { get; }
        public double X5 { get; }
        public double X6 { get; }
        public double YX { get; set; }
        public double YX2 { get; }
        public double YX3 { get; }

        public RegressionLineal(double x, double y, int n)
        {
            this.X = x;
            this.Y = y;
            N = n;

            this.X2 = Math.Pow(this.X, 2);
            this.X3 = Math.Pow(this.X, 3);
            this.X4 = Math.Pow(this.X, 4);
            this.X5 = Math.Pow(this.X, 5);
            this.X6 = Math.Pow(this.X, 6);

            this.YX = X * Y;
            this.YX2 = X2 * Y;
            this.YX3 = X3 * Y;
        }


    }
}
