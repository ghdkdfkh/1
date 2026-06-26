using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorV2
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculate calculate = new Calculate();

            string firstNumber;
            string secondNumber;
            bool isWorking = true;

            calculate.UserInput(out firstNumber, out secondNumber);

            isWorking = calculate.ProgramExecution(firstNumber, secondNumber, isWorking);
        }


    }
}
