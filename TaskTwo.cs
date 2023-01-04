using System;
using System.Collections.Generic;
using System.IO;

namespace Lab_8_
{
    static class TaskTwo
    {
        private static List<string> _date = new();
        private static List<int> _money = new();
        private static List<string> _operation = new();
        private static List<int> _result = new();

        /// <summary>
        /// Считывает данные с файла
        /// </summary>
        private static void ReadFile()
        {
            string[] line = File.ReadAllLines("task2test.txt");
            _result.Add(int.Parse(line[0]));
            for (int i = 1; i < line.Length; i++)
            {
                string[] word = line[i].Split(" | ");
                _date.Add(word[0]);
                if (word.Length == 3)
                {
                    _money.Add(int.Parse(word[1]));
                    _operation.Add(word[2]);
                }
                else
                {
                    _money.Add(0);
                    _operation.Add(word[1]);
                }
                Operation(i - 1);
            }
        }

        /// <summary>
        /// Проверяет, является ли введённая строка пустой выводит результат работы программы
        /// </summary>
        /// <param name="inputData"></param>
        private static void WriteResult(string inputData)
        {
            if (!string.IsNullOrEmpty(inputData))
                Console.WriteLine(_result[_date.IndexOf(inputData)]);
            else
                Console.WriteLine(_result[^1]);
        }

        /// <summary>
        /// Считывает операции с файла
        /// </summary>
        /// <param name="i"></param>
        private static void Operation(int i)
        {
            int result = default;
            switch (_operation[i])
            {
                case "in":
                    result = _result[i] + _money[i];
                    _result.Add(result);
                    break;
                case "out":
                    result = _result[i] - _money[i];
                    CheckError(result);
                    _result.Add(result);
                    break;
                case "revert":
                    _result.Add(_result[i - 2]);
                    break;
            }
        }

        /// <summary>
        /// Получает строку с запросом данных
        /// </summary>
        public static void GetRequest()
        {
            ReadFile();
            Console.WriteLine("Введите дату и время совершённой операции");
            string inputData;
            bool access = false;
            while (true)
            {
                inputData = Console.ReadLine();
                for (int i = 0; i < _date.Count; i++)
                {
                    if (inputData == _date[i] || inputData == string.Empty)
                        access = true;   
                }
                if (access)
                    break;
                else
                    Console.WriteLine("Введите данные корректно");
            }
            WriteResult(inputData);
        }

        /// <summary>
        /// Проверяет корректность данных в файле
        /// </summary>
        /// <param name="result"></param>
        private static void CheckError(int result)
        {
            if (result < 0)
            {
                Console.WriteLine("Error: В файле неверно введены данные");
                Environment.Exit(0);
            }
        }
    }
}
