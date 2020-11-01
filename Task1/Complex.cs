using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexMath
{
    class Complex
    {
        public double Im { get; set; }
        public double Re { get; set; }

        public Complex Plus(Complex x2)
        {
            Complex result = new Complex();
            result.Re = Re + x2.Re;
            result.Im = Im + x2.Im;
            return result;
        }

        public Complex Subtract(Complex x2)
        {
            Complex result = new Complex();
            result.Re = Re - x2.Re;
            result.Im = Im - x2.Im;
            return result;
        }

        public Complex Multi(Complex x2)
        {
            Complex result = new Complex();
            result.Re = Re * x2.Re - Im * x2.Im;
            result.Im = Re * x2.Im + Im * x2.Re;
            return result;
        }

        public override string ToString()
        {
            return Re + " + " + Im + " * i";
        }
    }
}
