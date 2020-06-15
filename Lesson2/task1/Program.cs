using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Выполнил Дмитрий Ищенко 
            //1. Реализовать функцию перевода из десятичной системы в двоичную, используя рекурсию.
            int inputNumber;
            Console.WriteLine("Введите число для перевода в двоечную систему исчеления");
            ConsoleInput("Введите число: ",out inputNumber);
            Console.WriteLine($"В двоичной системе исчесления, число [{inputNumber}] соответсвует [{ConvertToBinary(inputNumber)}]");
            Console.ReadKey();
        }

        private static string ConvertToBinary(int inputNumber)
        {
            if (inputNumber>1)
            {
                int R = inputNumber / 2;
                if (R >= 1)
                {
                    return ConvertToBinary(R) + $"{inputNumber - R * 2}";
                }
                else return $"{inputNumber - R * 2}";
            }
            return $"{inputNumber}";            
        }

        static void ConsoleInput(string msg, out int arg)
        {
            do
            {
                Console.Write(msg);
                if (Int32.TryParse(Console.ReadLine(), out arg)) break;
                else Console.WriteLine("Введенное значение, не удалось пробразовать к типу Int32, попробуйте снова.");
            } while (true);
        }
    }
}
