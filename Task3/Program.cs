using System;


/*Тананыкин
 * 
 * *Описать класс дробей - рациональных чисел, являющихся отношением двух 
 * целых чисел. 
 * Предусмотреть методы сложения, вычитания, умножения и деления дробей. 
 * Написать программу, демонстрирующую все разработанные 
 * элементы класса. Достаточно решить 2 задачи.

** Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение
ArgumentException("Знаменатель не может быть равен 0");
Добавить упрощение дробей.
 */

namespace Task3
{
    class Program
    {


        static void Main(string[] args)
        {
            Random rnd = new Random();
            const int maxRand = 10;
            const int minRand = -10;

            SimplifyAndPrinDouble(rnd, minRand, maxRand);
            FractionOperations(rnd, minRand, maxRand);

            ZeroDenomerator();

            Console.ReadKey();
        }

        static void FractionOperations(Random rnd, int minRand, int maxRand)
        {
            Console.WriteLine("\n--------------------------------------");
            Console.WriteLine("Операции с дробными числами");

            Fraction number1 = new Fraction()
            {
                Numerator = rnd.Next(minRand, maxRand),
                Denomerator = rnd.Next(1, maxRand)
            };

            Fraction number2 = new Fraction()
            {
                Numerator = rnd.Next(minRand, maxRand),
                Denomerator = rnd.Next(1, maxRand)
            };

            number1.Simplify();
            number2.Simplify();

            Console.WriteLine("Первое дробное число: {0}", number1.ToString());
            Console.WriteLine("Второе дробное число: {0}", number2.ToString());

            Fraction result = number1.Plus(number2);
            Console.WriteLine("({0}) + ({1}) = {2}",
                number1.ToString(), number2.ToString(), result.ToString());

            result = number1.Subtract(number2);
            Console.WriteLine("({0}) - ({1}) = {2}",
                number1.ToString(), number2.ToString(), result.ToString());

            result = number1.Multiply(number2);
            Console.WriteLine("({0}) * ({1}) = {2}",
                number1.ToString(), number2.ToString(), result.ToString());

            try
            {
                result = number1.Divide(number2);
                Console.WriteLine("({0}) / ({1}) = {2}",
                    number1.ToString(), number2.ToString(), result.ToString());
            }
            catch (ArgumentException aex)
            {
                Console.WriteLine("Исключение при операции деления: {0}",
                    aex.Message);
            }
        }

        static void ZeroDenomerator()
        {
            Console.WriteLine("\n--------------------------------------");
            Console.WriteLine("Проверка на присваивание знаменателю значения \"0\"");
            try
            {
                Fraction number3 = new Fraction();
                number3.Denomerator = 0;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void SimplifyAndPrinDouble(Random rnd, int minRand,  int maxRand)
        {
            Console.WriteLine("\n--------------------------------------");
            Console.WriteLine("Упрощение дробного числа и его представление в " +
                "формате с плавающей точкой \"0\"");

            int factor = rnd.Next(1, maxRand);
            Fraction number = new Fraction()
            {
                Numerator = rnd.Next(minRand, maxRand) * factor,
                Denomerator = rnd.Next(1, maxRand) * factor
            };

            Console.WriteLine("Дробное число: {0}", number.ToString());

            Console.WriteLine("\nДробное число в формате с плавающей " +
                "точкой: {0}", number.ToDouble());

            number.Simplify();
            Console.WriteLine("\nУпрощение дробного числа: {0}", number);
            Console.WriteLine("Дробное число в формате с плавающей " +
                "точкой: {0}", number.ToDouble());
        }
    }
}
