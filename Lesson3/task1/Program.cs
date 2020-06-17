using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace task1
{
    class Program
    {
        static int countQuickShort;
        static void Main(string[] args)
        {
            #region Хоп
            //Выполнил Ищенко Дмитрий
            //1.Попробовать оптимизировать пузырьковую сортировку.
            //Сравнить количество операций сравнения оптимизированной и не оптимизированной программы.
            //Написать функции сортировки, которые возвращают количество операций.
            #endregion
            int[] intArray = new int[20];
            Random rand = new Random();
            for (int i = 0; i < intArray.Length; i++)
            {
                intArray[i] = rand.Next(-255, 255);
            }
            WriteArray(intArray);
            WriteArray(SortArray(intArray));
            int[] arrayQuick = new int[intArray.Length];
            intArray.CopyTo(arrayQuick,0);
            QuickSort(arrayQuick);
            Console.WriteLine($"Количество операций замен в QuickSort= {countQuickShort}");
            WriteArray(arrayQuick);
            ShakerSort(intArray);
            WriteArray(intArray);
        }
        static int[] SortArray(int[] arrayRef)
        {
            int[] array = new int[arrayRef.Length];
            arrayRef.CopyTo(array, 0);
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int z = i; z < array.Length; z++)
                {
                    if (array[i]>array[z])
                    {
                        int buf=array[i];
                        array[i] = array[z];
                        array[z] = buf;
                        count++;
                    }
                }
            }
            Console.WriteLine($"Количество операций замен в класическом пузырьковом методе= {count}");
            return array;
        }
        static void WriteArray(int[] a)
        {
            foreach (int i in a)
                Console.Write("{0}|", i.ToString());
            Console.Write("\n");
        }
        static void Swap(ref int x, ref int y)
        {
            var t = x;
            x = y;
            y = t;
            countQuickShort++;
        }

        //метод возвращающий индекс опорного элемента
        static int Partition(int[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }

        //быстрая сортировка
        static int[] QuickSort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }

        static int[] QuickSort(int[] array)
        {
            countQuickShort = 0;
            return QuickSort(array, 0, array.Length - 1);
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
            Console.WriteLine($"Количество операций замен в ShakerSort = {count}");
        }
        static void Swap(int[] arraySwap, int i, int j)
        {
            int glass = arraySwap[i];
            arraySwap[i] = arraySwap[j];
            arraySwap[j] = glass;
        }
    }
}
