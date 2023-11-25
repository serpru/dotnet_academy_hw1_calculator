using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_academy_hw1_calculator
{
    enum MenuOption
    {
        QUIT = 0,
        SUM = 1,
        DIFF = 2,
        MULTIPLY = 3,
        DIVIDE = 4,
        EXP = 5,
        FAC = 6,
    }
    internal class ConsoleApp
    {
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }
        public ConsoleApp()
        {
            FirstNumber = double.NaN;
            SecondNumber = double.NaN;
        }

        public double TakeInput()
        {
            var numString = Console.ReadLine();
            double parsedValue;
            if (!double.TryParse(numString, out parsedValue))
            {
                return double.NaN;
            }
            return parsedValue;
        }
        public int TakeOption()
        {
            var optionString = Console.ReadLine();
            int parsedOption;
            bool parseSuccess = int.TryParse(optionString, out parsedOption);
            //bool parseSuccess = int.TryParse(optionString, NumberStyles.Float, CultureInfo.GetCultureInfo("en-US"), out  parsedOption);
            if (!parseSuccess) { return -1; }
            if (parsedOption < 0) { return -1; }
            return parsedOption;
        }
        public void TakeOneParameterFromUser()
        {
            Console.WriteLine("Enter first parameter.");
            FirstNumber = TakeInput();
            while (FirstNumber == double.NaN)
            {
                Console.WriteLine("Invalid input parameter. Try again.");
                FirstNumber = TakeInput();
            }
            Console.WriteLine("Enter second parameter");
        }
        public void TakeParametersFromUser()
        {
            TakeOneParameterFromUser();
            SecondNumber = TakeInput();
            while (SecondNumber == double.NaN)
            {
                Console.WriteLine("Invalid input parameter. Try again.");
                SecondNumber = TakeInput();
            }
        }
        public void Run()
        {
            Console.WriteLine("Choose option:\n0 - Quit\n1 - Sum\n2 - Diff\n3 - Multiply" +
                "\n4 - Divide\n5 - Exponential\n6 - Factorial");
            var option = TakeOption();

            while (option == -1)
            {
                Console.WriteLine("Invalid option.");
                option = TakeOption();
            }
            switch ((MenuOption)option)
            {
                case MenuOption.QUIT:
                    Console.WriteLine("Goodbye.");
                    break;
                case MenuOption.SUM:
                    TakeParametersFromUser();
                    Console.WriteLine($"{FirstNumber} + {SecondNumber} = {Calculator.Sum(FirstNumber, SecondNumber)}");
                    break;
                case MenuOption.DIFF:
                    TakeParametersFromUser();
                    Console.WriteLine(Calculator.Diff(FirstNumber, SecondNumber));
                    break;
                case MenuOption.MULTIPLY:
                    TakeParametersFromUser();
                    Calculator.Multiply(FirstNumber, SecondNumber);
                    break;
                case MenuOption.DIVIDE:
                    TakeParametersFromUser();
                    Calculator.Divide(FirstNumber, SecondNumber);
                    break;
                case MenuOption.EXP:
                    TakeParametersFromUser();
                    Calculator.Exp(FirstNumber, SecondNumber);
                    break;
                case MenuOption.FAC:
                    TakeOneParameterFromUser();
                    Calculator.Fact((int)FirstNumber);
                    break;
            }
        }

    }
}

