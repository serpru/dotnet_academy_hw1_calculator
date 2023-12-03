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
            if (!parseSuccess) { return -1; }
            if (parsedOption < 0) { return -1; }
            var maxEnumVal = Enum.GetValues(typeof(MenuOption)).Cast<MenuOption>().Max();
            if (parsedOption > (int)maxEnumVal) {  return -1; }
            return parsedOption;
        }
        public void TakeOneParameterFromUser()
        {
            Console.WriteLine("Enter first parameter.");
            FirstNumber = TakeInput();
            while (double.IsNaN(FirstNumber))
            {
                Console.WriteLine("Invalid input parameter. Try again.");
                FirstNumber = TakeInput();
            }
        }
        public void TakeParametersFromUser()
        {
            TakeOneParameterFromUser();
            Console.WriteLine("Enter second parameter");
            SecondNumber = TakeInput();
            while (double.IsNaN(SecondNumber))
            {
                Console.WriteLine("Invalid input parameter. Try again.");
                SecondNumber = TakeInput();
            }
        }
        public void Run()
        {
            int option = -1;
            while (option != (int)MenuOption.QUIT)
            {
                Console.WriteLine("Choose option:\n0 - Quit\n1 - Sum\n2 - Diff\n3 - Multiply" +
                "\n4 - Divide\n5 - Exponential\n6 - Factorial");
                option = TakeOption();

                while (option == -1)
                {
                    Console.WriteLine("Invalid option. Choose option:\n0 - Quit\n1 - Sum\n2 - Diff\n3 - Multiply"
                        + "\n4 - Divide\n5 - Exponential\n6 - Factorial");
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
                        Console.WriteLine($"{FirstNumber} * {SecondNumber} = {Calculator.Multiply(FirstNumber, SecondNumber)}");
                        break;
                    case MenuOption.DIVIDE:
                        TakeParametersFromUser();
                        var result = Calculator.Divide(FirstNumber, SecondNumber);
                        if (double.IsNaN(result))
                        {
                            Console.WriteLine("Cannot divide by zero, sorry!");
                        }
                        else
                        {
                            Console.WriteLine($"{FirstNumber} / {SecondNumber} = {result}");
                        }
                        break;
                    case MenuOption.EXP:
                        TakeParametersFromUser();
                        Console.WriteLine($"{FirstNumber} ^ {SecondNumber} = {Calculator.Exp(FirstNumber, SecondNumber)}");
                        break;
                    case MenuOption.FAC:
                        TakeOneParameterFromUser();
                        Console.WriteLine($"{(int)FirstNumber}! = {Calculator.Fact((int)FirstNumber)}");
                        break;
                }
            }

        }

    }
}

