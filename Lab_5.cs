namespace OOP_Tereshko
{
    class Point2D
    {
        public double X;
        public double Y;

        public Point2D()
        {
            X = 0;
            Y = 0; 
        }

        public Point2D(double x, double y)
        {
            X = x;
            Y = y;
        }
    }


    class TLine2D
    {
        public double A;
        public double B;
        public double C;

        public TLine2D()
        {
            A = 0;
            B = 0;
            C = 0; 
        }

        public TLine2D(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        public TLine2D(TLine2D other)
        {
            A = other.A;
            B = other.B;
            C = other.C;
        }


        public void Output()
        {
            Console.WriteLine($"Пряма: {A}*x + {B}*y + {C} = 0");
        }

        public bool IsPointOnLine(Point2D p)
        {
            return (A * p.X + B * p.Y + C) == 0;
        }

        public Point2D Intersect(TLine2D other)
        {
            double det = A * other.B - other.A * B;
            if (det == 0)
                return null;
            double x = (B * other.C - other.B * C) / det;
            double y = (other.A * C - A * other.C) / det;
            return new Point2D(x, y);
        }

        public static TLine2D operator +(TLine2D l1, TLine2D l2)
        {
            return new TLine2D(l1.A + l2.A, l1.B + l2.B, l1.C + l2.C);
        }

        public static TLine2D operator -(TLine2D l1, TLine2D l2)
        {
            return new TLine2D(l1.A - l2.A, l1.B - l2.B, l1.C - l2.C);
        }
    }


    class TLine3D : TLine2D
    {
        public double D;

        public TLine3D() : base()
        {
            D = 0;
        }
        public TLine3D(double a, double b, double c, double d) : base(a, b, c)
        {
            D = d;
        }
        public TLine3D(TLine3D other) : base(other)
        {
            D = other.D;
        }

        public new void Output()
        {
            Console.WriteLine($"Пряма в 3D: {A}*x + {B}*y + {C} + {D}*z = 0");
        }

        public bool IsPointOnLine(double x, double y, double z)
        {
            return (A * x + B * y + C + D * z) == 0;
        }
    }


    class Lab5
    {
        public static void Run()
        {
            Console.WriteLine("=== Lab 5 ===");

            TLine2D line1 = new TLine2D(1, -1, -2);
            TLine2D line2 = new TLine2D(2, 1, -3);
            line1.Output();
            line2.Output();

            Point2D? p = line1.Intersect(line2);
            if (p != null)
                Console.WriteLine($"Перетин у точці: ({p.X}, {p.Y})");
            else
                Console.WriteLine("Прямі паралельні");

            Console.WriteLine($"Точка (1,1) на line1? {line1.IsPointOnLine(new Point2D(1, 1))}");

            TLine2D lineSum = line1 + line2;
            lineSum.Output();

            TLine2D lineDiff = line1 - line2;
            lineDiff.Output();

            TLine3D line3d = new TLine3D(1, 2, -3, 4);
            line3d.Output();
            Console.WriteLine($"Точка (1,1,1) на line3d? {line3d.IsPointOnLine(1,1,1)}");
        }
    }
}
