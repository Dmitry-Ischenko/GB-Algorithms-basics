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
            int[] myint = new int[20];
            Random rand = new Random();
            for (int i = 0; i < myint.Length; i++)
            {
                myint[i] = rand.Next(-255, 255);
                //myint[i] = rand.Next(0, 2);
            }
            WriteArray(myint);
            ShakerSort(myint);
            WriteArray(myint);

            Console.ReadLine();
        }

        static void ShakerSort(int[] myint)
        {
            int left = 0,
                right = myint.Length - 1,
                count = 0;

            while (left < right)
            {
                for (int i = left; i < right; i++)
                {
                    
                    if (myint[i] > myint[i + 1])
                    {
                        Swap(myint, i, i + 1);
                        count++;
                    }              
                }
                right--;

                for (int i = right; i > left; i--)
                {
                    
                    if (myint[i - 1] > myint[i])
                    {
                        count++;
                        Swap(myint, i - 1, i);
                    }          
                }
                left++;
            }
            Console.WriteLine("Количество операций замен = {0}", count.ToString());
        }

        static void Swap(int[] myint, int i, int j)
        {
            int glass = myint[i];
            myint[i] = myint[j];
            myint[j] = glass;
        }

        static void WriteArray(int[] a)
        {
            foreach (int i in a)
                Console.Write("{0}|", i.ToString());
            Console.Write("\n");
        }
    }
}
