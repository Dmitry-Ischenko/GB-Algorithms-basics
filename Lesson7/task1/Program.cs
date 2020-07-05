using System;
using System.Collections.Generic;
using System.IO;
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
            // 1. Написать функции, которые считывают матрицу смежности из файла и выводят ее на экран.
            Console.WriteLine("Написать функции, которые считывают матрицу смежности из файла и выводят ее на экран.");
            bool exit = true;
            do {
                Console.WriteLine(" 1. Создать файл и заполнить его заготовленной матрицой смежности \n 2. Загрузить матрицу смежности из файла и вывести ее на экран");
                int checkChoice;
                do
                {
                    Console.Write("[1-2]: ");
                    if (Int32.TryParse(Console.ReadLine(),out checkChoice))
                    {
                        if (checkChoice == 1 || checkChoice == 2) break;
                    }
                    Console.WriteLine("Введите 1 или 2");

                } while (true);
                switch (checkChoice) {
                    case 1: {
                            SaveToFile();
                            break;
                        }
                    case 2:
                        {
                            LoadFormFile();
                            exit = false;
                            break;
                        }
                }
                Console.WriteLine();
            } while (exit);
            Console.ReadKey();

        }

        private static void LoadFormFile()
        {
            int[,] adjacencyMatrix;
            string[] read;
            string path = "adjacencyMatrix.txt";
            if (File.Exists(path))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        
                        read = sr.ReadToEnd().Split('\n');
                        sr.Close();
                        int row = read.GetLength(0) - 1;
                        int col = read[read.GetLowerBound(0)].Length / 2;
                        adjacencyMatrix = new int[row, col];
                        for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
                        {
                            string[] buffer = read[i].Split(',');
                            if (buffer.GetLength(0) == adjacencyMatrix.GetLength(1))
                            {
                                for (int z = 0; z < adjacencyMatrix.GetLength(1); z++)
                                {
                                    int.TryParse(buffer[z], out adjacencyMatrix[i, z]);
                                }
                            }

                        }
                        Console.WriteLine();
                        for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
                        {
                            for (int z = 0; z < adjacencyMatrix.GetLength(1); z++)
                            {
                                if (z > 0) Console.Write(",");
                                Console.Write(adjacencyMatrix[i, z]);
                            }
                            Console.WriteLine();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

        }

        static void SaveToFile() {
            int[,] adjacencyMatrix =
            {
                { 1,1,0,0,1,0 },
                { 1,0,1,0,1,0 },
                { 0,1,0,1,0,0 },
                { 0,0,1,0,1,1 },
                { 1,1,0,1,0,0 },
                { 0,0,0,1,0,0 }
            };
            string path = "adjacencyMatrix.txt";
            try {
                using (StreamWriter file = new StreamWriter(path))
                {
                    for (int i = 0; i < adjacencyMatrix.GetLength(0); i++)
                    {
                        StringBuilder buffer = new StringBuilder();
                        for (int z = 0; z < adjacencyMatrix.GetLength(1); z++)
                        {
                            if (buffer.Length > 0) buffer.Append(",");
                            buffer.Append(adjacencyMatrix[i, z]);
                        }
                        file.WriteLine(buffer);
                    }
                    file.Flush();
                    file.Close();
                }
                Console.WriteLine($"Фйал записан: {Directory.GetCurrentDirectory()}\\{path}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            

        }
    }
}
