using System;

namespace OOP_Tereshko
{
    public struct Point
    {
        public double X { get; }
        public double Y { get; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString() => $"({X:F2}; {Y:F2})";
    }
    public class Trapezoid
    {
        private readonly Point _vertexA, _vertexB, _vertexC, _vertexD;

        public Trapezoid(Point a, Point b, Point c, Point d)
        {
            _vertexA = a;
            _vertexB = b;
            _vertexC = c;
            _vertexD = d;
        }

        private double CalculateSideLength(Point p1, Point p2) => Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        
        public double CalculatePerimeter() => CalculateSideLength(_vertexA, _vertexB) + CalculateSideLength(_vertexB, _vertexC) + CalculateSideLength(_vertexC, _vertexD) + CalculateSideLength(_vertexD, _vertexA);
        
        public double CalculateArea() => 0.5 * Math.Abs(_vertexA.X * _vertexB.Y - _vertexA.Y * _vertexB.X + _vertexB.X * _vertexC.Y - _vertexB.Y * _vertexC.X + _vertexC.X * _vertexD.Y - _vertexC.Y * _vertexD.X + _vertexD.X * _vertexA.Y - _vertexD.Y * _vertexA.X);
        public void DisplayData()
        {
            Console.WriteLine("\nДані об'єкта 'Трапеція'");
            Console.WriteLine($"Координати вершин: A{_vertexA}, B{_vertexB}, C{_vertexC}, D{_vertexD}");
            Console.WriteLine($"Периметр: {CalculatePerimeter():F2}");
            Console.WriteLine($"Площа: {CalculateArea():F2}");
            Console.WriteLine("---------------------------------");
        }
    }
    
    public static class lab2
    {
        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("Лабораторна робота №2");
            Trapezoid myTrapezoid = null;
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Ввести/оновити координати трапеції");
                Console.WriteLine("2. Вивести дані про трапецію");
                Console.WriteLine("3. Вихід до головного меню");
                Console.Write("Виберіть опцію: ");

                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        try
                        {
                            myTrapezoid = new Trapezoid(
                                GetPointFromUser("A"), 
                                GetPointFromUser("B"), 
                                GetPointFromUser("C"), 
                                GetPointFromUser("D"));
                            Console.WriteLine("Трапецію успішно створено/оновлено.");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("\nПомилка: Введено некоректне значення. Будь ласка, вводьте числа.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"\nСталася невідома помилка: {ex.Message}");
                        }
                        break;
                    case "2":
                        if (myTrapezoid != null)
                        {
                            myTrapezoid.DisplayData();
                        }
                        else
                        {
                            Console.WriteLine("\nСпочатку потрібно створити трапецію (опція 1).");
                        }
                        break;
                    case "3":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
            }
        }

        private static Point GetPointFromUser(string pointName)
        {
            Console.WriteLine($"\nВведіть координати для вершини {pointName}:");
            Console.Write($"  {pointName}.X = ");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.Write($"  {pointName}.Y = ");
            double y = Convert.ToDouble(Console.ReadLine());
            return new Point(x, y);
        }
    }
}