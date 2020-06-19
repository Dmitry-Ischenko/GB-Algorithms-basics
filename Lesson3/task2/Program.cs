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
            //Скопировал из вики Ищенко Дмитрий
            // проникся и осознал крутость данного метода
            // 2. *Реализовать шейкерную сортировку.
            int[] intArray = new int[20];
            Random rand = new Random();
            for (int i = 0; i < intArray.Length; i++)
            {
                intArray[i] = rand.Next(-255, 255);
            }
            WriteArray(intArray);
            ShakerSort(intArray);
            WriteArray(intArray);
            Console.ReadKey();
        }

        static void ShakerSort(int[] array)
        {
            int left = 0,
                right = array.Length - 1,
                count = 0;

            while (left < right)
            {
                for (int i = left; i < right; i++)
                {
                    
                    if (array[i] > array[i + 1])
                    {
                        Swap(array, i, i + 1);
                        count++;
                    }              
                }
                right--;

                for (int i = right; i > left; i--)
                {
                    
                    if (array[i - 1] > array[i])
                    {
                        count++;
                        Swap(array, i - 1, i);
                    }          
                }
                left++;
            }
            Console.WriteLine($"Количество операций замен = {count}");
        }

        static void Swap(int[] arraySwap, int i, int j)
        {
            int glass = arraySwap[i];
            arraySwap[i] = arraySwap[j];
            arraySwap[j] = glass;
        }

        static void WriteArray(int[] a)
        {
            foreach (int i in a)
                Console.Write("{0}|", i.ToString());
            Console.Write("\n");
        }
    }
}
