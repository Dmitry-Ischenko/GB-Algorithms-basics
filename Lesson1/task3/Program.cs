using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Выполнил Ищенко Дмитрий
            //3. Написать программу обмена значениями двух целочисленных переменных:
            //a.с использованием третьей переменной;
            //b. * без использования третьей переменной.
            Console.WriteLine("Задача 3: \n3. Написать программу обмена значениями двух целочисленных переменных: \n a.с использованием третьей переменной;");
            int a, b;
            ConsoleInput("Введите значение переменной (a): ", out a);
            ConsoleInput("Введите значение переменной (b): ", out b);
            Console.WriteLine($"Вы ввели a={a}, b={b}");
            int buffer;
            buffer = a;
            a = b;
            b = buffer;
            Console.WriteLine($"результат: a={a}, b={b}");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Задача 3: \n3. Написать программу обмена значениями двух целочисленных переменных: \n b. * без использования третьей переменной.");
            Console.WriteLine($"Вы ввели a={a}, b={b} (нажмите любую кнопку, что бы продолжить)");
            Console.ReadKey();
            a = a + b;
            b = a - b;
            a = a - b;
            Console.WriteLine($"результат: a={a}, b={b}");
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
