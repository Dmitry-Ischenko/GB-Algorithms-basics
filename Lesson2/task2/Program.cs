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
            //Выполнил Дмитрий Ищенко 
            //2. Реализовать функцию возведения числа a в степень b:
            int a, b;
            InputConsole("Введите число a в степени b (a^b):",out a,out b);
            //a.без рекурсии;
            int result=1;
            for (int i = 0; i < b; i++)
            {
                result *= a;
            }
            Console.WriteLine($"без рекурсии a^b: {result}");
            Console.ReadKey();
            //b.рекурсивно;
            Console.WriteLine($"без рекурсии a^b: {Exponentiation(a,b)}");
            Console.ReadKey();
            //c. * рекурсивно, используя свойство четности степени.
            //При возведении отрицательного числа в степень, все зависит от
            //четности степени. Если степень четная, то и число получится четное,
            //если степень нечетная, то число останется со знаком «минус».

            //предыдущие решение удовлетворяет это условие
        }

        private static int Exponentiation(int a, int b)
        {
            if (b>1)
            {
                return Exponentiation(a, b - 1) * a;
            }
            return a;
        }

        static void InputConsole(string msg, out int a, out int b)
        {
            do
            {
                Console.Write(msg);
                string[] input = Console.ReadLine().Split('^');
                if (input.Length == 2)
                {
                    if (Int32.TryParse(input[0], out a))
                    {
                        if (Int32.TryParse(input[1], out b))
                        {
                            break;
                        }
                    }
                }
            } while (true);
        }
    }
}
