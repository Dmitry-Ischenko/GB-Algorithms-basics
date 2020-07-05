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
            //Выполнил Ищенко Дмитрий
            // 2. Переписать программу, реализующую двоичное дерево поиска.
            //а) Добавить в него обход дерева различными способами;
            //б) Реализовать поиск в двоичном дереве поиска;

            var tree = new BinaryTree();
            Random rand = new Random();
            int forMax = rand.Next(10,40);
            for (int i = 0; i < forMax; i++)
            {
                tree.Insert(rand.Next(0,200));
            }
            BinaryTreeExtensions.Print(tree);
            int find = rand.Next(0,200);
            Console.WriteLine("Попробуем найти число {0}",find);
            var finded = tree.Find(find);
            if (finded == null) Console.WriteLine("Значение {0}, не удалось найти", find);
            else {
                if (finded.Parent == null) Console.WriteLine("Мы нашли значение в корневом элементе!");
                else Console.WriteLine("Мы нашли значение в элементе, чей родитель содержит значение {0}!",finded.Parent.Data);
            }
            Console.ReadKey();
        }
    }
}
