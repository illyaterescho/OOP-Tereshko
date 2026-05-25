using System;
using System.Collections.Generic;
using System.IO;

namespace OOP_Tereshko
{
    class Lab7
    {
        public static void Run()
        {
            Console.WriteLine("=== Lab 7 (варіант 17) ===");

            Task17();
        }

        private static void Task17()
        {
            Console.WriteLine("\nЗавдання 17 (вар. 17): Робота з дійсними числами у файлах");

            string textFile = "numbers_text.txt";
            string binaryFile = "numbers_binary.dat";

            Console.WriteLine("\n--- Текстовий файл ---");
            IFileNumbers textStorage = new TextFileNumbers(textFile);
            TestStorage(textStorage, "Текстовий файл");

            Console.WriteLine("\n--- Типізований (binary) файл ---");
            IFileNumbers binaryStorage = new BinaryFileNumbers(binaryFile);
            TestStorage(binaryStorage, "Binary файл");
        }

        private static void TestStorage(IFileNumbers storage, string storageType)
        {
            Console.WriteLine($"Тестування: {storageType}");

            storage.Add(3.14);
            storage.Add(-5.5);
            storage.Add(42.0);
            storage.Add(0.0);
            storage.Add(7.77);

            Console.WriteLine("Після додавання елементів:");
            storage.PrintAll();

            Console.WriteLine($"\nПошук 42.0: {(storage.Contains(42.0) ? "Знайдено" : "Не знайдено")}");
            Console.WriteLine($"Пошук 99.99: {(storage.Contains(99.99) ? "Знайдено" : "Не знайдено")}");

            Console.WriteLine("\nВидалення елемента -5.5");
            storage.Remove(-5.5);
            storage.PrintAll();

            storage.Add(100.1);
            Console.WriteLine("\nПісля додавання 100.1:");
            storage.PrintAll();
        }
    }

    public interface IFileNumbers
    {
        void Add(double number);
        bool Remove(double number);
        bool Contains(double number);
        void PrintAll();
    }

    public class TextFileNumbers : IFileNumbers
    {
        private readonly string filePath;

        public TextFileNumbers(string filePath)
        {
            this.filePath = filePath;
        }

        public void Add(double number)
        {
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine(number);
            }
        }

        public bool Remove(double number)
        {
            if (!File.Exists(filePath)) return false;

            var numbers = ReadAll();
            bool removed = numbers.RemoveAll(x => Math.Abs(x - number) < 1e-9) > 0;

            if (removed) RewriteFile(numbers);
            return removed;
        }

        public bool Contains(double number)
        {
            if (!File.Exists(filePath)) return false;
            var numbers = ReadAll();
            return numbers.Exists(x => Math.Abs(x - number) < 1e-9);
        }

        public void PrintAll()
        {
            if (!File.Exists(filePath) || new FileInfo(filePath).Length == 0)
            {
                Console.WriteLine("Файл порожній.");
                return;
            }

            foreach (var num in ReadAll())
                Console.WriteLine(num);
        }

        private List<double> ReadAll()
        {
            var list = new List<double>();
            if (!File.Exists(filePath)) return list;

            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (double.TryParse(line, out double value))
                        list.Add(value);
                }
            }
            return list;
        }

        private void RewriteFile(List<double> numbers)
        {
            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                foreach (var num in numbers)
                    sw.WriteLine(num);
            }
        }
    }

    public class BinaryFileNumbers : IFileNumbers
    {
        private readonly string filePath;

        public BinaryFileNumbers(string filePath)
        {
            this.filePath = filePath;
        }

        public void Add(double number)
        {
            using (BinaryWriter bw = new BinaryWriter(File.Open(filePath, FileMode.Append)))
            {
                bw.Write(number);
            }
        }

        public bool Remove(double number)
        {
            if (!File.Exists(filePath)) return false;

            var numbers = ReadAll();
            bool removed = false;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (Math.Abs(numbers[i] - number) < 1e-9)
                {
                    numbers.RemoveAt(i);
                    removed = true;
                    break;
                }
            }

            if (removed) RewriteFile(numbers);
            return removed;
        }

        public bool Contains(double number)
        {
            if (!File.Exists(filePath)) return false;

            using (BinaryReader br = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                while (br.BaseStream.Position < br.BaseStream.Length)
                {
                    if (Math.Abs(br.ReadDouble() - number) < 1e-9)
                        return true;
                }
            }
            return false;
        }

        public void PrintAll()
        {
            if (!File.Exists(filePath) || new FileInfo(filePath).Length == 0)
            {
                Console.WriteLine("Файл порожній.");
                return;
            }

            using (BinaryReader br = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                while (br.BaseStream.Position < br.BaseStream.Length)
                {
                    Console.WriteLine(br.ReadDouble());
                }
            }
        }

        private List<double> ReadAll()
        {
            var list = new List<double>();
            if (!File.Exists(filePath)) return list;

            using (BinaryReader br = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                while (br.BaseStream.Position < br.BaseStream.Length)
                    list.Add(br.ReadDouble());
            }
            return list;
        }

        private void RewriteFile(List<double> numbers)
        {
            using (BinaryWriter bw = new BinaryWriter(File.Open(filePath, FileMode.Create)))
            {
                foreach (var num in numbers)
                    bw.Write(num);
            }
        }
    }
}
