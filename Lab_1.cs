using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_Tereshko
{
    public class DigitSet
    {
        private readonly HashSet<int> _digits;

        public DigitSet()
        {
            _digits = new HashSet<int>();
        }

        public void AddDigit(int digit)
        {
            if (digit >= 0 && digit <= 9)
            {
                if (_digits.Add(digit))
                {
                    Console.WriteLine($"Цифру {digit} успішно додано до множини.");
                }
                else
                {
                    Console.WriteLine($"Цифра {digit} вже є у множині.");
                }
            }
            else
            {
                Console.WriteLine("Помилка: будь ласка, вводьте лише цифри від 0 до 9.");
            }
        }

        public void DisplayDigits()
        {
            if (_digits.Count == 0)
            {
                Console.WriteLine("Множина порожня.");
                return;
            }

            Console.Write("Елементи множини: ");
            foreach (int digit in _digits.OrderBy(d => d))
            {
                Console.Write(digit + " ");
            }
            Console.WriteLine();
        }

        public void FindMaxDigit()
        {
            if (_digits.Count == 0)
            {
                Console.WriteLine("Неможливо знайти максимум, множина порожня.");
                return;
            }

            Console.WriteLine($"Найбільша цифра у множині: {_digits.Max()}");
        }

        public void FindSumOfDigits()
        {
            if (_digits.Count == 0)
            {
                Console.WriteLine("Неможливо знайти суму, множина порожня.");
                return;
            }

            Console.WriteLine($"Сума цифр у множині: {_digits.Sum()}");
        }
    }

    public static class lab1
    {
        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("Лабораторна робота №1");
            DigitSet myDigitSet = new DigitSet();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Додати нову цифру");
                Console.WriteLine("2. Вивести цифри на екран");
                Console.WriteLine("3. Знайти найбільшу цифру");
                Console.WriteLine("4. Знайти суму цифр");
                Console.WriteLine("5. Вихід до головного меню");
                Console.Write("Виберіть опцію: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введіть цифру (0-9): ");
                        if (int.TryParse(Console.ReadLine(), out int digitToAdd))
                        {
                            myDigitSet.AddDigit(digitToAdd);
                        }
                        else
                        {
                            Console.WriteLine("Помилка: введено не число.");
                        }
                        break;
                    case "2":
                        myDigitSet.DisplayDigits();
                        break;
                    case "3":
                        myDigitSet.FindMaxDigit();
                        break;
                    case "4":
                        myDigitSet.FindSumOfDigits();
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
            }
        }
    }
}

