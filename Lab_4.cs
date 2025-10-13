using System;

namespace OOP_Tereshko
{
    public class TextObject
    {
        public string TextValue { get; }
        
        public TextObject(string text)
        {
            TextValue = text ?? "";
        }
        
        public static explicit operator int(TextObject obj)
        {
            return obj.TextValue.Length;
        }
        
        public static explicit operator char(TextObject obj)
        {
            if (string.IsNullOrEmpty(obj.TextValue))
            {
                throw new InvalidOperationException("Неможливо отримати символ з порожнього рядка.");
            }
            return obj.TextValue[0];
        }
        
        public static implicit operator TextObject(int number)
        {
            if (number < 0)
            {
                return new TextObject("");
            }
            return new TextObject(new string('+', number));
        }
        
        public override string ToString()
        {
            return $"Об'єкт із текстовим полем: \"{TextValue}\"";
        }
    }
    
    public static class lab4
    {
        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("Лабораторна робота №4");
            
            Console.Write("\nВведіть будь-який текст для створення об'єкта: ");
            string? userInput = Console.ReadLine();
            TextObject myObject = new TextObject(userInput);
            Console.WriteLine($"1. Створено об'єкт на основі вашого вводу: {myObject}");
            
            try
            {
                int length = (int)myObject; 
                Console.WriteLine($"2. Перетворення об'єкта в int (кількість символів): {length}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"   Помилка: {ex.Message}");
            }
            
            try
            {
                char firstChar = (char)myObject; 
                Console.WriteLine($"3. Перетворення об'єкта в char (перший символ): '{firstChar}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"   Помилка: {ex.Message}");
            }
            
            try
            {
                Console.Write("\nВведіть ціле число для перетворення на об'єкт: ");
                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    TextObject fromNumber = number; 
                    Console.WriteLine($"4. Перетворення числа {number} в об'єкт:");
                    Console.WriteLine($"   Результат: {fromNumber}");
                }
                else
                {
                    Console.WriteLine("   Помилка: введено не число.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"   Помилка: {ex.Message}");
            }
        }
    }
}

