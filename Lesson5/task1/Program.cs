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
            //Выполнил Ищенко Дмитрий
            //1. Реализовать перевод из десятичной в двоичную систему счисления с использованием стека.
            int inputNumber;
            ConsoleInput("Введите десятичное число: ", out inputNumber);
            Console.Write($"Вы ввели {inputNumber}, в двоичной системе это: ");
            Stack<int> resultBin = new Stack<int>();
            do
            {
                int R = inputNumber / 2;
                if ( R>= 1)
                {
                    resultBin.Push(inputNumber-R*2);
                    inputNumber = R;
                } else
                {
                    resultBin.Push(inputNumber - R * 2);
                }
            } while (inputNumber > 1);
            resultBin.Push(inputNumber);
            foreach (var item in resultBin)
            {
                Console.Write($"{item}");
            }
            Console.ReadKey();
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
