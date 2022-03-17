using System;

namespace OS_Hub
{
    class Program
    {
        private static int b;
        private static int c;
        private static int i_max;
        private static void OS_Initial()
        {
            Console.WriteLine("\n Эта программа посчитает вам значение этого выражения:");
            Console.WriteLine("\n f(i + 1) = f(i) + sum[n = 1...10^8](2b + c - n)");
            Console.WriteLine("\n на разных языках программирования\n\n");
            _OS_b:
            try
            {
                Console.Write(" Введите значение b > ");
                b = Int32.Parse(Console.ReadLine());
            } catch { goto _OS_b; }
        _OS_c:
            try
            {
                Console.Write(" Введите значение c > ");
                c = Int32.Parse(Console.ReadLine());
            }
            catch { goto _OS_c; }
        _OS_imax:
            try
            {
                Console.Write(" Введите значение i_max > ");
                i_max = Int32.Parse(Console.ReadLine());
            }
            catch { goto _OS_imax; }
        }
        static void Main(string[] args)
        {
            OS_Initial();
            Console.WriteLine();
            Console.WriteLine(" Язык        Результат   Время работы");
            Console.WriteLine(" C++         undef       undef");
            Console.WriteLine(" Java        undef       undef");
            Console.WriteLine(" Python      undef       undef");
            Console.WriteLine(" Assembler   undef       undef");
        }
    }
}
