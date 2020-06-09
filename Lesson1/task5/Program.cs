using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Выполнил Ищенко Дмитрий
            //5.С клавиатуры вводится номер месяца. Требуется определить, к какому времени года он относится.
            Console.WriteLine("Задача 5:\n\t5.С клавиатуры вводится номер месяца. Требуется определить, к какому времени года он относится.");
            int m;
            ConsoleInput("Введите номер месяца: ",out m);
            if (m >= 3 && m <= 5) Console.WriteLine($"{m} месяц - это Весна");
            else if (m>=6 && m <=8) Console.WriteLine($"{m} месяц - это Лето");
            else if (m>=8 && m <=10) Console.WriteLine($"{m} месяц - это Осень");
            else if (m==11 || m<=1 && m <=2) Console.WriteLine($"{m} месяц - это Зима");
            else Console.WriteLine($"{m} - такого номера месяца в земном календаре нету(");
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
