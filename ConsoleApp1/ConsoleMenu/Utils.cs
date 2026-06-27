using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu
{
    class Utils
    {
        const string ShowRandomNumCase = "1";
        const string ShowTextCase = "2";
        const string ClearConsoleCase = "3";
        const string ExitCase = "0";

        internal  bool ProgramExecute(bool isWorking, string ShowRandomNumCase, string ShowTextCase, string ClearConsoleCase, string ExitCase)
        {
            while (isWorking == true)
            {
                ShowInfo(ShowRandomNumCase, ShowTextCase, ClearConsoleCase, ExitCase);

                Random random = new Random();
                int randomNum = 0;

                ChooseAction(ref isWorking, random, randomNum);
            }

            return isWorking;
        }

        private static void ChooseAction(ref bool isWorking, Random random, int randomNum)
        {
            switch (Console.ReadLine())
            {
                case ShowRandomNumCase:
                    randomNum = ShowRandomNum(random);
                    break;

                case ShowTextCase:
                    ShowText();
                    break;

                case ClearConsoleCase:
                    ClearConsole();
                    break;

                case ExitCase:
                    isWorking = Exit();
                    break;

                default:
                    Console.WriteLine("Такой команды нет");
                    break;
            }
        }

        private static bool Exit()
        {
            return false;
        }

        private static void ClearConsole()
        {
            Console.Clear();
        }

        private static void ShowText()
        {
            Console.WriteLine("При помощи всего, что вы изучили, создать приложение, которое может обрабатывать команды.\n" +
                                                      "Т.е.вы создаете меню, ожидаете ввода нужной команды," +
                                                      " после чего выполняете действие, которое присвоено этой команде.");
        }

        private static int ShowRandomNum(Random random)
        {
            int randomNum = random.Next(100);
            Console.WriteLine(randomNum);
            return randomNum;
        }

        private static void ShowInfo(string ShowRandomNumCase, string ShowTextCase, string ClearConsoleCase, string ExitCase)
        {
            Console.WriteLine($"{ShowRandomNumCase} -  показать случайное число\n" +
                $"{ShowTextCase} - вывод текста\n" +
                $"{ClearConsoleCase} - очистить консоль\n" +
                $"{ExitCase} - выход\n" +
                $"Введите команду");
        }
    }
}
