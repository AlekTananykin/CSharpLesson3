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

            Fraction number1 = new Fraction()
            {
                Numerator = rnd.Next(minRand, maxRand),
                Denomerator = rnd.Next(1, maxRand)
            };

            number1.Simplify();

            int factor = rnd.Next(1, maxRand);
            Fraction number2 = new Fraction()
            {
                Numerator = rnd.Next(minRand, maxRand) * factor,
                Denomerator = rnd.Next(1, maxRand) * factor
            };

            Console.WriteLine("Первое дробное число: {0}", number1.ToString());
            Console.WriteLine("Второе дробное число: {0}", number2.ToString());

            Console.WriteLine("\nВторое дробное число в формате с плавающей " + 
                "точкой: {0}", number2.ToDouble());

            number2.Simplify();
            Console.WriteLine("\nУпрощение второго дробного числа: {0}", number2);
            Console.WriteLine("Второе дробное число в формате с плавающей " + 
                "точкой: {0}", number2.ToDouble());


            Console.WriteLine("\nОперации с дробными числами");

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

            Console.WriteLine("\nПроверка на присваивание знаменателю значения \"0\"");
            try
            {
                Fraction number3 = new Fraction();
                number3.Denomerator = 0;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
