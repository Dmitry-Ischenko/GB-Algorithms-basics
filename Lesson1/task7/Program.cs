using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace task7
{
    class Program
    {
        static void Main(string[] args)
        {
            //Выполнил Ищенко Дмитрий
            //7. С клавиатуры вводятся числовые координаты двух полей шахматной доски (x1,y1,x2,y2). Требуется определить, относятся поля к одному цвету или нет.
            //y\x 1, 2, 3, 4, 5, 6, 7, 8
            // 8 б, ч, б, ч, б, ч, б, ч
            // 7 ч, б, ч, б, ч, б, ч, б
            // 6 б, ч, б, ч, б, ч, б, ч
            // 5 ч, б, ч, б, ч, б, ч, б
            // 4 б, ч, б, ч, б, ч, б, ч
            // 3 ч, б, ч, б, ч, б, ч, б
            // 2 б, ч, б, ч, б, ч, б, ч
            // 1 ч, б, ч, б, ч, б, ч, б
            Console.WriteLine("Задача 7\n\t 7. С клавиатуры вводятся числовые координаты двух полей шахматной доски (x1,y1,x2,y2). " +
                "Требуется определить, относятся поля к одному цвету или нет.\n Дана шахматная доска:");
            Console.WriteLine("y\\x 1, 2, 3, 4, 5, 6, 7, 8");
            for (int i = 8; i > 0; i--)
            {
                Console.Write($" {i}  ");
                for (int z = 1; z < 9; z++)
                {
                    if (i % 2 == 0)
                    {
                        if (z % 2 == 0) Console.Write("ч  ");
                        else Console.Write("б  ");
                    }
                    else
                    {
                        if (z % 2 == 0) Console.Write("б  ");
                        else Console.Write("ч  ");
                    }
                }
                Console.Write("\n");
            }
            int x1, y1, x2, y2;
            InputConsole("Введите координаты первой точки (x1,y1): ",out x1,out y1);
            InputConsole("Введите координаты первой точки (x2,y2): ",out x2,out y2);
            Console.WriteLine($"Вы ввели: \n\tКоординаты первой точки: ({x1},{y1})\n\tКоординаты второй точки: ({x2},{y2})");
            if (Black(x1,y1) == Black(x2,y2))
            {
                Console.WriteLine("Обе координаты указывают на поле одного цвета");
            } else Console.WriteLine("Координаты указывают на поля разного цвета");
            Console.ReadKey();
        }
        static bool Black(int x, int y)
        {
            if (y % 2 == 0)
            {
                if (x % 2 == 0) return false;
                else return true;
            }
            else
            {
                if (x % 2 == 0) return true;
                else return false;
            }
        }
        static void InputConsole(string msg, out int x, out int y)
        {
            do
            {
                Console.Write(msg);
                string[] input = Console.ReadLine().Split(',');
                if (input.Length == 2)
                {
                    if (Int32.TryParse(input[0], out x))
                    {
                        if (Int32.TryParse(input[1], out y))
                        {
                            if (y > 0 && y < 9 && x > 0 && x < 9) break;
                        }
                    }
                }
            } while (true);
        }
    }
}
