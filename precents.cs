using System;

namespace precent
{
    class precentCalc
    {
        public static double Calculate(string userInput)
        {
            string[] x = userInput.Split(' ');
            double deposit = double.Parse(x[0]);
            double percent = double.Parse(x[1]);
            double months = double.Parse(x[2]);
            return deposit * (Math.Pow(1 + percent / 1200, months));
        }
    }
}
