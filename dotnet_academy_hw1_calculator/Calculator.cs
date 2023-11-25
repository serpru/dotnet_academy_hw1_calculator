using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_academy_hw1_calculator
{
    internal static class Calculator
    {
        public static double Sum(double x, double y)
        {
            return x + y;
        }
        public static double Diff(double x, double y)
        {
            return x - y;
        }
        public static double Multiply(double x, double y)
        {
            return x * y;
        }
        public static double Divide(double x, double y)
        {
            if (y == 0)
            {
                return double.NaN;
                //throw new DivideByZeroException("Attempted dividing by zero");
            }
            return x / y;
        }
        public static double Exp(double x, double y)
        {
            return Math.Pow(x, y);
        }
        public static int Fact(int x)
        {
            if (x < 0)
            {
                return -1;
            }
            if (x == 0 || x == 1) { return 1; }
            int result = 1;
            for (int i = x; i > 0; i--)
            {
                result *= i;
            }
            return result;
        }
    }
}
