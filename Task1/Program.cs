using ComplexMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /* Тананыкин
     * 
     * а) Дописать структуру Complex, добавив метод вычитания комплексных 
     * чисел.Продемонстрировать работу структуры.
     * б) Дописать класс Complex, добавив методы вычитания и произведения 
     * чисел.Проверить работу класса.
     * в) Добавить диалог с использованием switch демонстрирующий работу класса.
    */

    class Program
    {
        static void Main(string[] args)
        {
            ShowStructComplex();

            ShowClassComplex();

            CalculateComplexOperations();

            Console.ReadKey();
        }

        private static void ShowStructComplex()
        {
            Console.WriteLine("а) Демонстрация работы комплексного " +
                "числа на основе структуры\r\n");
            Random rand = new Random();

            LightComplex.Complex complex1, complex2, complexResult;
            complex1.re = rand.Next(0, 100);
            complex1.im = rand.Next(0, 100);
            complex2.re = rand.Next(0, 100);
            complex2.im = rand.Next(0, 100);

            Console.WriteLine("Первое комплексное число: {0}",
                complex1.ToString());
            Console.WriteLine("Второе комплексное число: {0}",
                complex2.ToString());

            complexResult = complex1.Plus(complex2);
            Console.WriteLine("({0}) + ({1}) = {2}", complex1.ToString(),
                complex2.ToString(), complexResult.ToString());

            complexResult = complex1.Subtract(complex2);
            Console.WriteLine("({0}) - ({1}) = {2}", complex1.ToString(),
                complex2.ToString(), complexResult.ToString());

            complexResult = complex1.Multi(complex2);
            Console.WriteLine("({0}) * ({1}) = {2}", complex1.ToString(),
                complex2.ToString(), complexResult.ToString());
        }

        private static void ShowClassComplex()
        {
            Console.WriteLine();
            Console.WriteLine("б) Демонстрация работы комплексного числа " +
                "на основе класса\r\n");
            Random rand = new Random();

            ComplexMath.Complex complex1 = new Complex()
            {
                Re = rand.Next(0, 100),
                Im = rand.Next(0, 100)
            };

            ComplexMath.Complex complex2= new Complex()
            {
                Re = rand.Next(0, 100),
                Im = rand.Next(0, 100)
            };

            ComplexMath.Complex complexResult = null;


            Console.WriteLine("Первое комплексное число: {0}",
                complex1.ToString());
            Console.WriteLine("Второе комплексное число: {0}",
                complex2.ToString());

            complexResult = complex1.Plus(complex2);
            Console.WriteLine("({0}) + ({1}) = {2}", complex1.ToString(),
                complex2.ToString(), complexResult.ToString());

            complexResult = complex1.Subtract(complex2);
            Console.WriteLine("({0}) - ({1}) = {2}", complex1.ToString(),
                complex2.ToString(), complexResult.ToString());

            complexResult = complex1.Multi(complex2);
            Console.WriteLine("({0}) * ({1}) = {2}", complex1.ToString(),
                complex2.ToString(), complexResult.ToString());
        }

        private static void CalculateComplexOperations()
        {
            Console.WriteLine();
            Console.WriteLine("в) Демонстрация работы комплексного " +
                "числа при помощи диалога");

            ComplexMath.Complex complexResult;

            Console.WriteLine();
            Console.WriteLine("Введите первое комплексное число");
            ComplexMath.Complex complex1 = ReadComplex();

            Console.WriteLine();
            Console.WriteLine("Введите второе комплексное число");
            ComplexMath.Complex complex2 = ReadComplex();
            
            Console.WriteLine();
            switch (ReadOperation("Выберете операцию (*, +, -): "))
            {
                case '*':
                {
                    complexResult = complex1.Multi(complex2);
                    Console.WriteLine("({0}) * ({1}) = {2}", complex1.ToString(),
                        complex2.ToString(), complexResult.ToString());
                    break;
                }
                case '+':
                {
                    complexResult = complex1.Plus(complex2);
                    Console.WriteLine("({0}) + ({1}) = {2}", complex1.ToString(),
                        complex2.ToString(), complexResult.ToString());
                    break;
                }
                case '-':
                {
                    complexResult = complex1.Subtract(complex2);
                    Console.WriteLine("({0}) - ({1}) = {2}", complex1.ToString(),
                        complex2.ToString(), complexResult.ToString());
                    break;
                }
            }
        }

        private static Complex ReadComplex()
        {
            double re = ReadDouble("Действительная часть: ");
            double im = ReadDouble("Комплексная часть: ");
            return new Complex()
            {
                Re = re,
                Im = im
            };
        }

        private static double ReadDouble(string msg)
        {
            while(true)
            {
                try
                {
                    Console.Write(msg);
                    return double.Parse(Console.ReadLine());
                }
                catch (FormatException fex)
                {
                    Console.WriteLine(fex.Message);
                }
            }
        }
        
        private static char ReadOperation(string msg)
        {
            char result;
            string line;
            do
            {
                Console.Write(msg);
                line = Console.ReadLine();
                
            } while (!char.TryParse(line, out result) || 
                !IsValidOperation(result));
            return result;
        }

        private static bool IsValidOperation(char operation)
        {
            return '*' == operation || '+' == operation || '-' == operation;
        }
    }
}
