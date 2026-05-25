namespace OOP
{
    class Lab6
    {
        public static void Run()
        {
            Console.WriteLine("=== Lab 6 (варіант 6) ===");

            Task1_1();
            Task1_2();
            Task1_3();
            Task2_1();
            Task2_2();
            Task2_3();
        }

        private static void Task1_1()
        {
            Console.WriteLine("\nЗавдання 1.1 (вар. 6): Найменше серед додатних елементів");
            double[] x = { -3.5, 2.1, -1.2, 0.0, 4.7, 0.5, -2.8, 3.0, 1.9 };
            Console.Write("Масив: ");
            PrintArray(x);

            double minPositive = double.MaxValue;
            bool hasPositive = false;

            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] > 0 && x[i] < minPositive)
                {
                    minPositive = x[i];
                    hasPositive = true;
                }
            }

            if (hasPositive)
                Console.WriteLine($"Найменше додатне число: {minPositive}");
            else
                Console.WriteLine("Додатних чисел немає");
        }

        private static void Task1_2()
        {
            Console.WriteLine("\nЗавдання 1.2 (вар. 6): Чи паралельні два вектори");
            double[] x = { 1.0, 2.0, 3.0 };
            double[] y = { 2.0, 4.0, 6.0 };

            Console.Write("Вектор x: ");
            PrintArray(x);
            Console.Write("Вектор y: ");
            PrintArray(y);

            bool parallel = AreVectorsParallel(x, y);
            Console.WriteLine($"Вектори {(parallel ? "паралельні" : "НЕ паралельні")}");
        }

        private static bool AreVectorsParallel(double[] x, double[] y)
        {
            if (x.Length != y.Length || x.Length == 0) return false;

            double k = 0;
            bool firstNonZero = true;

            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] != 0)
                {
                    if (firstNonZero)
                    {
                        k = y[i] / x[i];
                        firstNonZero = false;
                    }
                    else if (Math.Abs(y[i] - k * x[i]) > 1e-9)
                        return false;
                }
                else if (y[i] != 0)
                    return false;
            }
            return true;
        }

        private static void Task1_3()
        {
            Console.WriteLine("\nЗавдання 1.3 (вар. 6): Нулі спочатку, потім інші елементи");
            double[] arr = { 0, 5.5, 0, -2.3, 0, 3.7, 0, 1.1, -4.0 };
            Console.Write("Початковий масив: ");
            PrintArray(arr);

            TransformZerosFirst(arr);

            Console.Write("Після перетворення: ");
            PrintArray(arr);
        }

        private static void TransformZerosFirst(double[] arr)
        {
            int n = arr.Length;
            double[] temp = new double[n];
            int idx = 0;

            // спочатку всі нулі
            for (int i = 0; i < n; i++)
                if (arr[i] == 0)
                    temp[idx++] = 0;

            for (int i = 0; i < n; i++)
                if (arr[i] != 0)
                    temp[idx++] = arr[i];

            for (int i = 0; i < n; i++)
                arr[i] = temp[i];
        }

        private static void Task2_1()
        {
            Console.WriteLine("\nЗавдання 2.1 (вар. 6): Сортування непарних рядків за спаданням");
            int[,] matrix = new int[4, 4]
            {
                { 5, 1, 4, 2 },
                { 3, 8, 6, 7 },
                { 9, 0, 2, 5 },
                { 4, 3, 8, 1 }
            };

            Console.WriteLine("Матриця до сортування:");
            PrintMatrix(matrix);

            for (int row = 1; row < matrix.GetLength(0); row += 2)
                BubbleSortRowDescending(matrix, row);

            Console.WriteLine("\nМатриця після сортування непарних рядків:");
            PrintMatrix(matrix);
        }

        private static void BubbleSortRowDescending(int[,] m, int row)
        {
            int cols = m.GetLength(1);
            for (int i = 0; i < cols - 1; i++)
            {
                for (int j = 0; j < cols - 1 - i; j++)
                {
                    if (m[row, j] < m[row, j + 1])
                    {
                        int temp = m[row, j];
                        m[row, j] = m[row, j + 1];
                        m[row, j + 1] = temp;
                    }
                }
            }
        }

        private static void Task2_2()
        {
            Console.WriteLine("\nЗавдання 2.2 (вар. 6): Сума елементів у стовпцях з від'ємними");
            int[,] matrix = new int[3, 4]
            {
                {  1, -2,  3,  4 },
                { -5,  6, -7,  8 },
                {  9, 10, 11, -12 }
            };

            Console.WriteLine("Матриця:");
            PrintMatrix(matrix);

            int total = SumColumnsWithNegative(matrix);
            Console.WriteLine($"Сума елементів у стовпцях, що містять хоча б один від'ємний елемент: {total}");
        }

        private static int SumColumnsWithNegative(int[,] m)
        {
            int rows = m.GetLength(0);
            int cols = m.GetLength(1);
            int sum = 0;

            for (int c = 0; c < cols; c++)
            {
                bool hasNegative = false;
                for (int r = 0; r < rows; r++)
                {
                    if (m[r, c] < 0)
                    {
                        hasNegative = true;
                        break;
                    }
                }
                if (hasNegative)
                {
                    for (int r = 0; r < rows; r++)
                        sum += m[r, c];
                }
            }
            return sum;
        }

        private static void Task2_3()
        {
            Console.WriteLine("\nЗавдання 2.3 (вар. 6): Сідлові точки матриці");
            int[,] matrix = new int[4, 4]
            {
                { 5, 3, 8, 2 },
                { 1, 7, 4, 6 },
                { 9, 0, 5, 3 },
                { 2, 8, 1, 4 }
            };

            Console.WriteLine("Матриця:");
            PrintMatrix(matrix);

            FindSaddlePoints(matrix);
        }

        private static void FindSaddlePoints(int[,] m)
        {
            int rows = m.GetLength(0);
            int cols = m.GetLength(1);
            bool found = false;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int val = m[i, j];

                    bool isRowMin = true;
                    for (int c = 0; c < cols; c++)
                    {
                        if (m[i, c] < val)
                        {
                            isRowMin = false;
                            break;
                        }
                    }

                    if (isRowMin)
                    {
                        bool isColMax = true;
                        for (int r = 0; r < rows; r++)
                        {
                            if (m[r, j] > val)
                            {
                                isColMax = false;
                                break;
                            }
                        }

                        if (isColMax)
                        {
                            Console.WriteLine($"Сідлова точка: рядок {i + 1}, стовпець {j + 1} (значення = {val})");
                            found = true;
                        }
                    }
                }
            }

            if (!found)
                Console.WriteLine("Сідлових точок не знайдено.");
        }

        private static void PrintArray(double[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }

        private static void PrintMatrix(int[,] m)
        {
            int rows = m.GetLength(0);
            int cols = m.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    Console.Write(m[i, j] + "\t");
                Console.WriteLine();
            }
        }
    }
}
