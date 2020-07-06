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
            // 1. Реализовать сортировку подсчетом.
            Random rand = new Random();
            int[] array = new int[rand.Next(10,100)];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(0,100);
            }

            Console.WriteLine("Отсортированный массив: {0}", string.Join(", ", CountingSort(array, array.Min(), array.Max()))) ;
            Console.ReadKey();
        }
        static int[] CountingSort(int[] array, int min,int max)
        {
            int[] count = new int[max - min + 1];
            int z = 0;

            for (int i = 0; i < array.Length; i++)
            {
                count[array[i] - min]++;
            }

            for (int i = min; i <= max; i++)
            {
                while (count[i - min]-- > 0)
                {
                    array[z] = i;
                    z++;
                }
            }

            return array;
        }

    }
}
