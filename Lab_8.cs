using System;
using System.Collections.Generic;

namespace OOP_Tereshko
{
    class Lab8
    {
        public static void Run()
        {
            Console.WriteLine("=== Lab 8 (варіант 6) ===");
            Task6();
        }

        private static void Task6()
        {
            Console.WriteLine("\nЗавдання 6 (вар. 6): Зовнішній векторний добуток (Outer Product)");

            double[] vectorA = { 1.0, 2.0, 3.0 };
            double[] vectorB = { 4.0, 5.0 };

            Console.Write("Вектор A: ");
            PrintVector(vectorA);
            Console.Write("Вектор B: ");
            PrintVector(vectorB);

            Console.WriteLine("\n--- Використання масивів ---");
            double[,] matrixArray = OuterProductArray(vectorA, vectorB);
            PrintMatrix(matrixArray);

            Console.WriteLine("\n--- Використання LinkedList<LinkedList<double>> ---");
            LinkedList<LinkedList<double>> matrixLinked = OuterProductLinked(vectorA, vectorB);
            PrintLinkedMatrix(matrixLinked);
        }

        private static double[,] OuterProductArray(double[] a, double[] b)
        {
            int rows = a.Length;
            int cols = b.Length;
            double[,] result = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = a[i] * b[j];
                }
            }
            return result;
        }

        private static void PrintMatrix(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{matrix[i, j],8:F2}");
                }
                Console.WriteLine();
            }
        }

        private static LinkedList<LinkedList<double>> OuterProductLinked(double[] a, double[] b)
        {
            var result = new LinkedList<LinkedList<double>>();

            foreach (double valA in a)
            {
                var row = new LinkedList<double>();
                foreach (double valB in b)
                {
                    row.AddLast(valA * valB);
                }
                result.AddLast(row);
            }
            return result;
        }

        private static void PrintLinkedMatrix(LinkedList<LinkedList<double>> matrix)
        {
            foreach (var row in matrix)
            {
                foreach (var value in row)
                {
                    Console.Write($"{value,8:F2}");
                }
                Console.WriteLine();
            }
        }

        private static void PrintVector(double[] vector)
        {
            Console.Write("[ ");
            for (int i = 0; i < vector.Length; i++)
            {
                Console.Write(vector[i]);
                if (i < vector.Length - 1) Console.Write(", ");
            }
            Console.WriteLine(" ]");
        }
    }
}
