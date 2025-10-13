using System;

namespace OOP_Tereshko
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine(" Головне меню");
                Console.WriteLine("========================================");
                Console.WriteLine("Оберіть лабораторну роботу:");
                Console.WriteLine("1 - Лабораторна робота №1 (ООП)");
                Console.WriteLine("2 - Лабораторна робота №2 (ООП)");
                Console.WriteLine("3 - Лабораторна робота №3 (ООП)");
                Console.WriteLine("4 - Лабораторна робота №4 (ООП)");
                Console.WriteLine("0 - Вихід");
                Console.WriteLine("----------------------------------------");
                Console.Write("Ваш вибір: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            lab1.Run(); 
                            break;
                        case 2:
                            lab2.Run(); 
                            break;
                        case 3:
                            lab3.Run(); 
                            break;
                        case 4:
                            lab4.Run(); 
                            break;
                        case 0:
                            Console.WriteLine("\nЗавершення роботи програми. До зустрічі!");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("\nНевірний вибір. Спробуйте ще раз.");
                            break;
                    }
                    
                    if (!exit && choice >= 1 && choice <= 4)
                    {
                        Console.WriteLine("\nНатисніть будь-яку клавішу для повернення в головне меню...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("\nПомилка: будь ласка, введіть числове значення.");
                    Console.WriteLine("\nНатисніть будь-яку клавішу для продовження...");
                    Console.ReadKey();
                }
            }
        }
    }
}

