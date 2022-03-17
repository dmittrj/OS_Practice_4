using System;

namespace OS_Hub
{
    class Program
    {
        private static int b;
        private static int c;
        private static int i_max;
        private static int cur_position = 1;
        private static string[] OS_Results = { "undef", "undef" , "undef" , "undef" };
        private static string[] OS_Time = { "undef", "undef", "undef", "undef" };
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
        
        private static void OS_PrintCursor(int p)
        {
            if (p == cur_position) Console.Write(">");
            else Console.Write(" ");
        }
        private static void OS_PrintTable()
        {
            while (true) {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("  Язык        Результат   Время работы");
                OS_PrintCursor(1);
                Console.Write(" C++         ");
                Console.Write(OS_Results[0]);
                Console.Write("       ");
                Console.WriteLine("undef");
                OS_PrintCursor(2);
                Console.Write(" Java        ");
                Console.Write(OS_Results[1]);
                Console.Write("       ");
                Console.WriteLine("undef");
                OS_PrintCursor(3);
                Console.Write(" Python      ");
                Console.Write(OS_Results[2]);
                Console.Write("       ");
                Console.WriteLine("undef");
                OS_PrintCursor(4);
                Console.Write(" Assembler   ");
                Console.Write(OS_Results[3]);
                Console.Write("       ");
                Console.WriteLine("undef");
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.DownArrow:
                        cur_position++;
                        break;
                    case ConsoleKey.UpArrow:
                        cur_position--;
                        break;
                }
            }
        }
        
        static void Main(string[] args)
        {
            OS_Initial();
            OS_PrintTable();
        }
    }
}
