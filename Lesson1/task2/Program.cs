using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Выполнил Ищенко Дмитрий
            //2. Найти максимальное из четырех чисел. Массивы не использовать.
            Console.WriteLine("Задача 2: \n 2. Найти максимальное из четырех чисел. Массивы не использовать.\n");
            int num1, num2, num3, num4;
            ConsoleInput("Введите первое число: ",out num1);
            ConsoleInput("Введите второе число: ",out num2);
            ConsoleInput("Введите третье число: ",out num3);
            ConsoleInput("Введите четвертое число: ",out num4);
            int max = num1;
            if (max < num2) max = num2;
            if (max < num3) max = num3;
            if (max < num4) max = num4;
            Console.WriteLine($"Максимальное число из {num1},{num2},{num3},{num4} - {max}");
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
