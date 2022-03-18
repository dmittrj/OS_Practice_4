﻿using System;
using System.Diagnostics;
using System.IO;

namespace OS_Hub
{
    enum OS_Language { CPlusPlus = 1, Java, Python, Assembler }
    class Program
    {
        private static int b;
        private static int c;
        private static int i_max;
        private static string path;
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
            path = Directory.GetCurrentDirectory();
            DirectoryInfo info = new(path);
            while (path != "" && info.Name != "OS_Practice_4" )
            {
                info = info.Parent;
                path = info.FullName;
            }
            //FileInfo info = new(path + @"\OS_Info.txt");
            //info.CreateText();
            StreamWriter writer = new(path + @"\OS_Hub\bin\Debug\net5.0\OS_Info.txt");
            writer.WriteLine(b.ToString() + "," + c.ToString() + "," + i_max.ToString());
            writer.Close();
        }
        
        private static void OS_Calculate(OS_Language lang)
        {
            Console.Write("\n\nНачинается выполнение программы на языке ");
            DirectoryInfo solFolder = new DirectoryInfo(path);
            FileInfo codeFile;
            switch (lang)
            {
                case OS_Language.CPlusPlus:
                    Console.WriteLine("C++");
                    Console.WriteLine(solFolder.FullName + @"\Debug\OS_Cpp.exe");
                    codeFile = new FileInfo(solFolder.FullName + @"\Debug\OS_Cpp.exe");
                    if (codeFile.Exists)
                        Process.Start(codeFile.FullName);
                    break;
                case OS_Language.Java:
                    Console.WriteLine("Java");
                    break;
                case OS_Language.Python:
                    Console.WriteLine("Python");
                    break;
                case OS_Language.Assembler:
                    Console.WriteLine("Assembler");
                    break;
                default:
                    break;
            }
            Console.ReadKey();
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
                    case ConsoleKey.Enter:
                        OS_Calculate((OS_Language)cur_position);
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
