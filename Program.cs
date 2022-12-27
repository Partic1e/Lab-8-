using System;

namespace Lab_8_
{
    class Program
    {
        /// <summary>
        /// Начинает работу программы
        /// </summary>
        static void StartProgram()
        {
            Console.WriteLine("Выберите номер задания (1, 2 или 3)");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    TaskOne.StartSubtitles();
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    TaskTwo.GetRequest();
                    break;
                case ConsoleKey.D3:
                    Console.Clear();
                    TaskThree.FindAnagrams();
                    break;
                default:
                    Console.WriteLine("Error: Такого задания не существует");
                    break;
            }
        }
        
        /// <summary>
        /// Прекращает работу программы
        /// </summary>
        static void ExitProgram()
        {
            Console.WriteLine("\n\nЕсли вы хотите закрыть программу, нажмите q");
            if (Console.ReadKey().Key == ConsoleKey.Q)
                Environment.Exit(0);
        }

        static void Main(string[] args)
        {
            while (true)
            {
                StartProgram();
                ExitProgram();
                Console.Clear();
            }
        }
    }
}