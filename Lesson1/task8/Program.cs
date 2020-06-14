using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task8
{
    class Program
    {
        static void Main(string[] args)
        {
            //Выполнил Ищенко Дмитрий
            //8. Ввести a и b и вывести квадраты и кубы чисел от a до b.
            Console.WriteLine("Задача 8: \n\tВвести a и b и вывести квадраты и кубы чисел от a до b.");
            int a, b;
            InputConsole("Введите значение a и b через запятую (a,b). Условие, a<b: ",out a,out b);
            for (int i = a; i <= b; i++)
            {
                Console.WriteLine($"{i}^2 = {i*i}, {i}^3={i*i*i}");
            }
            Console.ReadKey();
        }
        static void InputConsole(string msg, out int a, out int b)
        {
            do
            {
                Console.Write(msg);
                string[] input = Console.ReadLine().Split(',');
                if (input.Length == 2)
                {
                    if (Int32.TryParse(input[0], out a))
                    {
                        if (Int32.TryParse(input[1], out b))
                        {
                            if (a  < b) break;
                        }
                    }
                }
            } while (true);
        }
    }
}
