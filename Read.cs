using System;
using System.Globalization;

namespace ChessQueens
{
    public class Read
    {
        public static int ReadIntNumber(string s, int min = int.MinValue, int max = int.MaxValue)
        {
            Console.WriteLine(s);
            bool format = false;
            format = int.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out int num);
            if (!format || num > max || num < min)
            {
                Console.WriteLine("Ошибка: Неверный формат ввода");
                return ReadIntNumber(s, min, max);
            }
            else
                return num;
        }
        public static double ReadDoubleNumber(string s, double min = double.MinValue, double max = double.MaxValue)
        {
            Console.WriteLine(s);
            bool format = false;
            format = double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out double num);
            if (!format || num > max || num < min)
            {
                Console.WriteLine("Ошибка: Неверный формат ввода");
                return ReadDoubleNumber(s, min, max);
            }
            else
                return num;
        }
    }
}