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
            // 1. Реализовать простейшую хеш-функцию. На вход функции подается строка, на выходе сумма кодов символов.
            Console.Write("Введите строку: ");
            String inputString = Console.ReadLine();
            int summ = 0;
            foreach (var item in inputString)
            {
                summ += (int)item;
            }
            Console.WriteLine($"Хеш строки [{inputString}] равен {summ}");
            Console.ReadKey();

        }
    }
}
