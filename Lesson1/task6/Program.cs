using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task6
{
    class Program
    {
        static void Main(string[] args)
        {
            //Выполнил Ищенко Дмитрий
            //6. Ввести возраст человека (от 1 до 150 лет) и вывести его вместе с последующим словом «год», «года» или «лет».
            Console.WriteLine("Задача 6: \n\t6. Ввести возраст человека (от 1 до 150 лет) и вывести его вместе с последующим словом «год», «года» или «лет».");
            int age;
            bool again =true;
            do
            {
                do
                {
                    ConsoleInput("Введите ваш возраст от 1 до 150 лет: ", out age);
                    if (age >= 1 && age <= 150) break;
                } while (true);
                Console.Write($"Вам {age} ");
                if (age % 100 >= 11 && age % 100 <= 14) Console.Write("лет\n");
                else if (age % 10 >= 0 && age % 10 <= 5)
                {
                    switch (age % 10)
                    {
                        case 0:
                            {
                                Console.Write("лет\n");
                                break;
                            }
                        case 1:
                            {
                                Console.Write("год\n");
                                break;
                            }
                        case 2:
                        case 3:
                        case 4:
                            {
                                Console.Write("года\n");
                                break;
                            }
                        case 5:
                            {
                                Console.Write("лет\n");
                                break;
                            }

                    }
                }
                Console.Write("Еще раз? (yes - по умолчанию, no - выход): ");
                if ("no".Equals(Console.ReadLine())) again = false;
            } while (again);

        }
        static void ConsoleInput(string msg, out int arg)
        {
            do
            {
                Console.Write(msg);
                if (Int32.TryParse(Console.ReadLine(), out arg)) break;
                else Console.WriteLine("Введенное значение, не удалось пробразовать к типу Int32, попробуйте снова.");
            } while (true);
        }
    }
}
