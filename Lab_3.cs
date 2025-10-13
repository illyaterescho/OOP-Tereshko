using System;
using System.Linq;

namespace OOP_Tereshko
{
    public class TSMatrix
    {
        private readonly int[,] _matrix;
        private readonly int _size;
        public TSMatrix()
        {
            _size = 3;
            _matrix = new int[_size, _size];
        }
        
        public TSMatrix(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Розмір матриці має бути додатнім числом.", nameof(size));
            }
            _size = size;
            _matrix = new int[_size, _size];
        }
        
        public TSMatrix(TSMatrix other)
        {
            _size = other._size;
            _matrix = new int[_size, _size];
            Array.Copy(other._matrix, _matrix, other._matrix.Length);
        }
        
        public void FillRandomly()
        {
            Random rand = new Random();
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    _matrix[i, j] = rand.Next(1, 100); 
                }
            }
        }
        public void Print()
        {
            Console.WriteLine("Матриця:");
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    Console.Write($"{_matrix[i, j],4}");
                }
                Console.WriteLine();
            }
        }
        
        public int GetSum() => _matrix.Cast<int>().Sum();
        
        public int GetMaxValue()
        {
            CheckIfAllElementsAreSame();
            return _matrix.Cast<int>().Max();
        }
        
        public int GetMinValue()
        {
            CheckIfAllElementsAreSame();
            return _matrix.Cast<int>().Min();
        }
        
        private void CheckIfAllElementsAreSame()
        {
            int firstElement = _matrix[0, 0];
            if (_matrix.Cast<int>().All(element => element == firstElement))
            {
                throw new InvalidOperationException("Всі елементи матриці однакові.");
            }
        }
        
        public static TSMatrix operator +(TSMatrix a, TSMatrix b)
        {
            if (a._size != b._size)
            {
                throw new ArgumentException("Матриці повинні мати однакову розмірність для додавання.");
            }

            TSMatrix result = new TSMatrix(a._size);
            for (int i = 0; i < a._size; i++)
            {
                for (int j = 0; j < a._size; j++)
                {
                    result._matrix[i, j] = a._matrix[i, j] + b._matrix[i, j];
                }
            }
            return result;
        }
        
        public static TSMatrix operator -(TSMatrix a, TSMatrix b)
        {
            if (a._size != b._size)
            {
                throw new ArgumentException("Матриці повинні мати однакову розмірність для віднімання.");
            }

            TSMatrix result = new TSMatrix(a._size);
            for (int i = 0; i < a._size; i++)
            {
                for (int j = 0; j < a._size; j++)
                {
                    result._matrix[i, j] = a._matrix[i, j] - b._matrix[i, j];
                }
            }
            return result;
        }
    }
    
    public static class lab3
    {
        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("Лабораторна робота №3");
            
            TSMatrix matrixA = null;
            TSMatrix matrixB = null;

            try
            {
                Console.Write("Введіть розмірність для матриць (напр. 3): ");
                int size = Convert.ToInt32(Console.ReadLine());
                matrixA = new TSMatrix(size);
                matrixA.FillRandomly();
                
                matrixB = new TSMatrix(size);
                matrixB.FillRandomly();

                Console.WriteLine("\nСтворено дві випадкові матриці.");
                Console.WriteLine("\nМатриця A:");
                matrixA.Print();
                Console.WriteLine("\nМатриця B:");
                matrixB.Print();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nПомилка при створенні матриць: {ex.Message}");
                return; 
            }

            bool running = true;
            while (running)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Знайти найбільший/найменший елемент в матриці A");
                Console.WriteLine("2. Знайти суму елементів матриці A");
                Console.WriteLine("3. Додати матриці A і B");
                Console.WriteLine("4. Відняти матрицю B від A");
                Console.WriteLine("5. Вихід до головного меню");
                Console.Write("Виберіть опцію: ");

                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        try
                        {
                            Console.WriteLine($"\nНайбільший елемент в матриці A: {matrixA.GetMaxValue()}");
                            Console.WriteLine($"Найменший елемент в матриці A: {matrixA.GetMinValue()}");
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine($"\nВиняткова ситуація: {ex.Message}");
                        }
                        finally
                        {
                            Console.WriteLine("-> Операцію пошуку завершено.");
                        }
                        break;

                    case "2":
                        Console.WriteLine($"\nСума елементів матриці A: {matrixA.GetSum()}");
                        break;

                    case "3":
                        Console.WriteLine("\nРезультат додавання (A + B):");
                        TSMatrix sumMatrix = matrixA + matrixB;
                        sumMatrix.Print();
                        break;
                        
                    case "4":
                        Console.WriteLine("\nРезультат віднімання (A - B):");
                        TSMatrix diffMatrix = matrixA - matrixB;
                        diffMatrix.Print();
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

