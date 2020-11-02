using System;
using System.Runtime.InteropServices;

/* Тананыкин
 * 
 * а)  С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в 
 * новой строке). Требуется подсчитать сумму всех нечётных положительных 
 * чисел. Сами числа и сумму вывести на экран, используя tryParse.
 * б) Добавить обработку исключительных ситуаций на то, что могут 
 * быть введены некорректные данные. При возникновении ошибки вывести сообщение.
 * Напишите соответствующую функцию;
 */
namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа подсчёта суммы нечётных " +
               "положительных чисел");

            Console.WriteLine("Введите последовательность " +
                "целых чисел (введите число 0 для выхода)");

            int sum = 0;
            while (true)
            {
                string line = Console.ReadLine();
                int number;

                if (!int.TryParse(line, out number))
                {
                    Console.WriteLine("Не правильный формат введённого числа");
                    continue;
                }
                
                if (0 == number)
                    break;

                OddPositiveNumSum(number, ref sum);
            }

            Console.WriteLine("Сумма введённых нечётных " +
                  "положительных чисел равна: {0}. ", sum);

            Console.WriteLine(
               "Нажмите любую клавишу для завершения программы. ");
            Console.ReadKey();
        }

        static void OddPositiveNumSum(int number, ref int sum)
        {
            if (0 < number && 1 == number % 2)
                sum += number;
        }
    }
}
