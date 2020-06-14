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
            //1. Ввести вес и рост человека. Рассчитать и вывести индекс массы тела по формуле I=m/(h*h); 
            //где m-масса тела в килограммах, h - рост в метрах.
            Console.WriteLine("Задача 1: \n 1. Ввести вес и рост человека. Рассчитать и вывести индекс массы тела по формуле I=m/(h*h); где m-масса тела в килограммах, h - рост в метрах.");
            double weight, height;
            ConsoleInput("Введите ваш вес в кг: ",out weight);
            ConsoleInput("Введите ваш рост в метрах: ",out height);
            Console.WriteLine($"Ваш индекс масссы тела равен: {weight/(height*height)}");
            Console.ReadKey();

        }
        static void ConsoleInput(string msg,out double arg)
        {
            do
            {
                Console.Write(msg);
                if (Double.TryParse(Console.ReadLine(), out arg)) break;
                else Console.WriteLine("Введенное значение, не удалось пробразовать к типу double, попробуйте снова.");
            } while (true);
        }
    }
}
