using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Выполнил Ищенко Дмитрий
            // 4. Написать программу нахождения корней заданного квадратного уравнения.
            Console.WriteLine("Задача 4: \n 4. Написать программу нахождения корней заданного квадратного уравнения.");
            double a, b, c;
            Console.WriteLine("Квадратное уравнение   —   это уравнение вида: ax 2 + bx + c = 0");
            do
            {
                ConsoleInput("Введите первый или старший коэффициент (a) не равный 0: ", out a);
                if (a == 0) Console.WriteLine($"(a) = {a}, (a) не должен равнятся 0 ");
                else break;
            } while (true);
            ConsoleInput("Введите второй коэффициент или коэффициент при х (b): ", out b);
            ConsoleInput("Введите свободный член (c): ", out c);
            double d;
            d = (b * b) - (4 * a * c);
            if (d < 0) Console.WriteLine($"D = {d} < 0, уровнение не имеет корней");
            else if (d == 0) Console.WriteLine($"D = {d} == 0, квадратное уравнение имеет один корень X = -{b}/2{a}");
            else Console.WriteLine($"D = {d} > 0, уравнение имеет два корня:\n\tX1 = (-{b} + √{d})/2{a} \t X2 = (-{b} - √{d})/2{a}");
            Console.ReadKey();

        }
        static void ConsoleInput(string msg, out double arg)
        {
            do
            {
                Console.Write(msg);
                if (Double.TryParse(Console.ReadLine(), out arg)) break;
                else Console.WriteLine("Введенное значение, не удалось пробразовать к типу Double, попробуйте снова.");
            } while (true);
        }
    }
}
