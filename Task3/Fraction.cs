using System;


namespace Task3
{
    class Fraction
    {
        public Fraction()
        {
            Numerator = 0;
            Denomerator = 1;
        }

        public int Numerator{ get; set; }

        private int _denomerator;
        public int Denomerator 
        {
            get
            {
                return _denomerator;
            }
            set 
            {
                if (0 == value)
                    throw new ArgumentException("Знаменатель не может быть равным \"0\"");
                _denomerator = value;
            } 
        }

        public Fraction Plus(Fraction number1) 
        {
            Fraction result = new Fraction();

            result.Denomerator = Denomerator * number1.Denomerator;
            result.Numerator = Numerator * number1.Denomerator + 
                Denomerator * number1.Numerator;

            result.Simplify();

            return result;
        }

        public Fraction Subtract(Fraction number1)
        {
            Fraction result = new Fraction();

            result.Denomerator = Denomerator * number1.Denomerator;
            result.Numerator = Numerator * number1.Denomerator -
                Denomerator * number1.Numerator;

            result.Simplify();

            return result;
        }

        public Fraction Multiply(Fraction number1)
        {
            Fraction result = new Fraction();

            result.Numerator = Numerator * number1.Numerator;
            result.Denomerator = Denomerator * number1.Denomerator;
            
            result.Simplify();

            return result;
        }

        public Fraction Divide(Fraction number1)
        {
            Fraction result = new Fraction();

            if (0 == number1.Numerator)
                throw new ArgumentException("Ошибка деления на ноль.");

            result.Denomerator = Denomerator * number1.Numerator;
            result.Numerator = Numerator * number1.Denomerator;

            result.Simplify();

            return result;
        }

        public override string ToString()
        {
            if (1 == Denomerator)
                return string.Format("{0}", Numerator);

            return string.Format("{0}/{1}", Numerator, Denomerator);
        }

        public double ToDouble()
        {
            return (double)Numerator / (double)Denomerator;
        }

        public void Simplify()
        {
            int nod = Gcd(Math.Abs(Denomerator), Math.Abs(Numerator));
            Numerator /= nod;
            Denomerator /= nod;
        }

        private int Gcd(int a, int b)
        {
            while (0 != a && 0 != b)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a + b;
        }
    }
}
