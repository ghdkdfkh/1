using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorV2
{
    class Calculate
    {
        const string plus = "1";
        const string minus = "2";
        const string division = "3";
        const string multiplication = "4";
        const string exit = "0";

        internal  void UserInput(out string firstNumber, out string secondNumber)
        {
            Console.WriteLine("Введите первое число");
            firstNumber = Console.ReadLine();

            Console.WriteLine("Введите второе число");
            secondNumber = Console.ReadLine();
        }
        internal  bool ProgramExecution(string firstNumber, string secondNumber, bool isWorking)
        {
            while (isWorking == true)
            {
                double.TryParse(firstNumber, out double result1);
                double.TryParse(secondNumber, out double result2);

                Console.WriteLine($"Выберите дейстивие\n" +
                    $"{plus} - сложение\n" +
                    $"{minus} - отнимание\n" +
                    $"{division} - деление\n" +
                    $"{multiplication} - умножение\n" +
                    $"{exit} - выход\n");

                isWorking = ChooseAction(isWorking, result1, result2);
            }

            return isWorking;
        }

        private static bool ChooseAction(bool isWorking, double result1, double result2)
        {
            switch (Console.ReadLine())
            {
                case plus:
                    Addition(result1, result2);
                    break;

                case minus:
                    Subtracktion(result1, result2);
                    break;

                case division:
                    Division(result1, result2);
                    break;

                case multiplication:
                    Multiplication(result1, result2);
                    break;

                case exit:
                    isWorking = false;
                    break;

                default:
                    Console.WriteLine("Введена не верная команда");
                    break;
            }

            return isWorking;
        }

        private static void Multiplication(double result1, double result2)
        {
            Console.Write("Ответ ");
            Console.WriteLine(result1 * result2);
            Console.WriteLine();
        }

        private static void Division(double result1, double result2)
        {
            Console.Write("Ответ ");
            Console.WriteLine(result1 / result2);
            Console.WriteLine();
        }

        private static void Subtracktion(double result1, double result2)
        {
            Console.Write("Ответ ");
            Console.WriteLine(result1 - result2);
            Console.WriteLine();
        }

        private static void Addition(double result1, double result2)
        {
            Console.Write("Ответ ");
            Console.WriteLine(result1 + result2);
            Console.WriteLine();
        }
    }
}
