using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
//using ArrayExtension;
namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Выполнил Ищенко Дмитрий
            //1. *Количество маршрутов с препятствиями. 
            //Реализовать чтение массива с препятствием и нахождение количество маршрутов.
            Console.WriteLine("1. *Количество маршрутов с препятствиями.\nРеализовать чтение массива с препятствием и нахождение количество маршрутов.\n");
            int[,] map = {
                { 1,1,0,1,1,1,1,0},
                { 0,1,1,1,0,0,1,0},
                { 0,1,0,0,0,0,1,1},
                { 1,1,0,0,0,0,0,1},
                { 1,0,0,0,0,0,0,1},
                { 1,1,1,1,0,0,0,1},
                { 0,0,0,1,0,0,0,1},
                { 0,0,0,1,1,1,1,1}
            };
            Console.WriteLine("Карта:");
            Console.WriteLine("x\\y 0 1 2 3 4 5 6 7");
            for (int i = 0; i < map.GetLength(1); i++)
            {
                Console.Write($" {i}  ");
                for (int z = 0; z < map.GetLength(0); z++)
                {
                    if (map[i, z] == 1 && Console.ForegroundColor != ConsoleColor.Red) Console.ForegroundColor = ConsoleColor.Red;
                    else if (map[i, z] == 0 && Console.ForegroundColor == ConsoleColor.Red) Console.ResetColor();
                    Console.Write($"{map[i,z]} ");
                    
                }
                if (Console.ForegroundColor == ConsoleColor.Red) Console.ResetColor();
                Console.Write("\n");
            }            
            Point start = new Point(0,0);
            Point finish = new Point(map.GetUpperBound(1), map.GetUpperBound(0));            
            // 0 - y, 1 - x
            Console.WriteLine($"Start: [{start.X},{start.Y}]\nFinish: [{finish.X},{finish.Y}]");
            Point[] way = GetRoute(map, start, finish, start);
            if (way.Length > 1)
            {
                Console.Write("Вот такой маршрут нашли (алгоритм нахождения пути): \n");
                for (int i = way.Length - 1; i >= 0; i--)
                {
                    Console.Write($" [{way[i].X},{way[i].Y}]");
                }
                Console.Write("\n");
            }
            Console.WriteLine("-----------------");
            Dictionary<Point, Boolean> cache = new Dictionary<Point, bool>();
            Point[,] way2 = GetRouteV2(map, start, finish, cache);
            Console.WriteLine("Вот такой маршрут нашли (алгоритм нахождения ВСЕХ возможных путей):");
            for (int i = 0; i < way2.GetLength(0); i++)
            {
                for (int z = way2.GetLength(1)-1; z >= 0; z--)
                {
                    //if ((way2[i, z].X !=0 && way2[i, z].Y != 0) || (way2[i, z].X != 0 || way2[i, z].Y != 0)) 
                        Console.Write($" [{way2[i,z].X},{way2[i,z].Y}]");
                }
                Console.Write("\n\n");
            }
            Console.ReadKey();
        }
        private static Point[] GetRoute(int[,] map, Point start, Point finish,Point oldPosition)
        {
            Point[] moveTo = new Point[4];
            if (start.X-1 >= 0)
            {
                if(map[start.X-1,start.Y] == 1 && !oldPosition.Equals(new Point(start.X - 1, start.Y))) moveTo[3] = new Point(start.X - 1, start.Y);
            }
            if (start.X + 1 < map.GetLength(1) )
            {
                if (map[start.X + 1, start.Y] == 1 && !oldPosition.Equals(new Point(start.X + 1, start.Y))) moveTo[1] = new Point(start.X + 1, start.Y);
            }
            if (start.Y - 1 >= 0)
            {
                if (map[start.X, start.Y-1] == 1 && !oldPosition.Equals(new Point(start.X, start.Y-1))) moveTo[2] = new Point(start.X, start.Y - 1);
            }
            if (start.Y + 1 < map.GetLength(0))
            {
                if (map[start.X, start.Y + 1] == 1 && !oldPosition.Equals(new Point(start.X, start.Y+1))) moveTo[0] = new Point(start.X, start.Y + 1);
            }
            for (int i = 0; i < moveTo.Length; i++)
            {
                if (!moveTo[i].Equals(new Point(0,0)))
                {
                    if (finish.Equals(moveTo[i])) {
                        Point[] returnPoint = { moveTo[i] };
                        return returnPoint;
                    } else
                    {
                        Point[] GetPoint = GetRoute(map, moveTo[i], finish, start);
                        if (GetPoint[0].Equals(finish))
                        {
                            Point[] returnPoint = new Point[GetPoint.Length + 1];
                            GetPoint.CopyTo(returnPoint, 0);
                            returnPoint[returnPoint.Length - 1] = moveTo[i];
                            return returnPoint;
                        }
                    }
                    
                }
            }
            Point[] returnPointFall = { start };
            return returnPointFall;
        }
        private static Point[,] GetRouteV2(int[,] map, Point start, Point finish, Dictionary<Point, Boolean> cache)
        {
            Point[] moveTo = new Point[4];
            Point[,] ways = null;
            if (!cache.ContainsKey(start)) cache.Add(start,true);
            //Поиск Соседних клеток с возможностью перемещения в них
            if (start.Y + 1 < map.GetLength(0))
                if (map[start.X, start.Y + 1] == 1) moveTo[0] = new Point(start.X, start.Y + 1);
            if (start.X + 1 < map.GetLength(1))
                if (map[start.X + 1, start.Y] == 1) moveTo[1] = new Point(start.X + 1, start.Y);
            if (start.Y - 1 >= 0)
                if (map[start.X, start.Y - 1] == 1) moveTo[2] = new Point(start.X, start.Y - 1);
            if (start.X - 1 >= 0)
                if (map[start.X - 1, start.Y] == 1 ) moveTo[3] = new Point(start.X - 1, start.Y);
            for (int i = 0; i < moveTo.Length; i++)
            {
                if (!cache.ContainsKey(moveTo[i]))
                {
                    if (finish.Equals(moveTo[i]))
                    {
                        Point[,] returnPoint = { { moveTo[i] } };
                        return returnPoint;
                    } else
                    {
                        Point[,] bufferWays = GetRouteV2(map, moveTo[i], finish, cache);
                        if (bufferWays != null && finish.Equals(bufferWays[bufferWays.GetUpperBound(0), 0]))
                        {
                            
                            if (ways == null)
                            {

                                ways = new Point[bufferWays.GetLength(0), bufferWays.GetLength(1) +1];
                                bufferWays.CopyToInTwoDimensional(ways, 0);
                                int row = ways.GetUpperBound(0);
                                int col = ways.GetUpperBound(1);
                                ways[row, col] = start;
                            } else
                            {
                                Point[,] bufferWays2;
                                bufferWays2 = new Point[ways.GetLength(0) + bufferWays.GetLength(0), ways.GetLength(1) + bufferWays.GetLength(1) + 1];
                                //ways.CopyTo(bufferWays2, 0);
                                //ways.copy
                                ways.CopyToInTwoDimensional(bufferWays2,0);
                                bufferWays.CopyToInTwoDimensional(bufferWays2,ways.GetLength(0));
                                bufferWays2[bufferWays2.GetUpperBound(0), bufferWays2.GetUpperBound(1)] = start;
                                ways = new Point[bufferWays2.GetLength(0), bufferWays2.GetLength(1)];
                                bufferWays2.CopyToInTwoDimensional(ways,0);
                            }
                        }
                    }
                }
            }
            return ways;
        }
    }
    public static class ArrayExtension
    {
        public static void CopyToInTwoDimensional<T>(this T[,] array,T[,] arrayTo, int row)
        {
            int row1 = arrayTo.GetLength(1);
            int col = arrayTo.GetLength(0);
            if (array.GetLength(1) <= arrayTo.GetLength(1) && row + array.GetLength(0)<= arrayTo.GetLength(0))
            {
                int iTo = row;
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int z = 0; z < array.GetLength(1); z++)
                    {
                        arrayTo[iTo, z] = array[i, z];
                    }
                    iTo++;
                }
            } else
            {
                if(row + array.GetLength(0) > arrayTo.GetLength(0))
                {
                    throw new Exception("Область копирования выходит за размер массива");
                }
                if (array.GetLength(1) > arrayTo.GetLength(1))
                {
                    throw new Exception("Размерность массива источника, больше массива назначения");
                }
            }
        }
    }
}
