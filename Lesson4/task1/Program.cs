using System;
using System.Collections.Generic;
using System.Drawing;
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
            //1. *Количество маршрутов с препятствиями. 
            //Реализовать чтение массива с препятствием и нахождение количество маршрутов.
            int[,] map = {
                { 1,1,0,1,1,1,1,0},
                { 0,1,1,1,0,0,1,0},
                { 0,1,0,0,0,0,1,1},
                { 1,1,0,0,0,0,0,1},
                { 1,0,0,0,0,0,1,1},
                { 1,1,1,1,0,0,1,0},
                { 0,0,0,1,0,1,1,0},
                { 0,0,0,1,1,1,1,1}
            };
            Console.WriteLine("Карта:");
            Console.WriteLine("x\\y 0 1 2 3 4 5 6 7");
            for (int i = 0; i < map.GetLength(1); i++)
            {
                Console.Write($" {i}  ");
                for (int z = 0; z < map.GetLength(0); z++)
                {
                    Console.Write($"{map[i,z]} ");
                }
                Console.Write("\n");
            }
            Point start = new Point(0,0);
            Point finish = new Point(map.GetUpperBound(1), map.GetUpperBound(0));
            // 0 - y, 1 - x
            Console.WriteLine($"Start: [{start.X},{start.Y}]\nFinish: [{finish.X},{finish.Y}]");
            Console.ReadKey();
        }
        private static string GetRoute(int[,] map, Point start, Point finish)
        {
            if ((start.X-1) > 0)
            {
                if(map[start.X-1,start.Y] == 1)
                {
                    GetRoute(map,new Point(start.X-1,start.Y),finish);
                }
            }
            return "";
        }
    }
}
