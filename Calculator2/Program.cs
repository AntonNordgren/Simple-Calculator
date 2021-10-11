using System;

namespace Calculator
{
    public class Calculator
    {
        public double currentValue;
        public int userInput;

        bool isExecuting = true;

        public Calculator()
        {
            currentValue = 0;
            // The start function needs to be commented out when testing
            // Start();
        }

        public void Addition(double input)
        {
            if (!double.IsNaN(input))
            {
                currentValue += input;
            }
        }

        public void Addition(double[] values)
        {

            foreach (double value in values)
            {
                if (!double.IsNaN(value))
                {
                    currentValue += value;
                }
            }
        }

        public void Subtraction(double input)
        {

            if (!double.IsNaN(input))
            {
                currentValue -= input;
            }
        }

        public void Subtraction(double[] input)
        {
            foreach (double value in input)
            {
                if (!double.IsNaN(value))
                {
                    currentValue -= value;
                }
            }
        }

        public void Multiplication(double input)
        {
            if (!double.IsNaN(input))
            {
                currentValue *= input;
            }
        }

        public void Multiplication(double[] input)
        {
            foreach (double value in input)
            {
                if (!double.IsNaN(value))
                {
                    currentValue *= value;
                }
            }
        }

        public void Division(double input)
        {
            if (!double.IsNaN(input) && input != 0)
            {
                currentValue /= input;
            }
        }

        public void Division(double[] input)
        {
            foreach (double value in input)
            {
                if (!double.IsNaN(value) && value != 0)
                {
                    currentValue /= value;
                }
            }
        }

        public void Reset()
        {
            currentValue = 0;
        }

        public double ConvertUserInputSingle(string userInput)
        {
            double result;

            try
            {
                result = double.Parse(userInput);
            }
            catch
            {
                result = double.NaN;
            }

            return result;
        }

        public double[] ConvertUserInputArray(string userInput)
        {
            string[] stringValues = userInput.Split(" ");
            double[] result = new double[stringValues.Length];

            for (int i = 0; i < stringValues.Length; i++)
            {
                try
                {
                    result[i] = double.Parse(stringValues[i]);
                }
                catch
                {
                    result[i] = double.NaN;
                }
            }

            return result;
        }

        public void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Simple Calculator");
            Console.WriteLine();
            Console.WriteLine("Current Value: " + currentValue);
            Console.WriteLine();
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine();
            Console.WriteLine("9. Reset");
            Console.WriteLine("0. Exit");
            Console.WriteLine();
            Console.Write("Choose operation: ");
        }

        public void Start()
        {
            while (isExecuting)
            {
                PrintMenu();

                try
                {
                    userInput = int.Parse(Console.ReadLine());

                    if (userInput == 0)
                    {
                        Console.WriteLine("Exiting...");
                        isExecuting = false;
                    }

                    switch (userInput)
                    {
                        case 1:
                            Console.Write("What do you want to add with: ");
                            string input = Console.ReadLine();
                            if (!input.Contains(" "))
                            {
                                Addition(ConvertUserInputSingle(input));
                            }
                            else
                            {
                                Addition(ConvertUserInputArray(input));
                            }
                            break;
                        case 2:
                            Console.Write("What do you want to subtract with: ");
                            input = Console.ReadLine();
                            if (!input.Contains(" "))
                            {
                                Subtraction(ConvertUserInputSingle(input));
                            }
                            else
                            {
                                Subtraction(ConvertUserInputArray(input));
                            }
                            break;
                        case 3:
                            Console.Write("What do you want to multiply with: ");
                            input = Console.ReadLine();
                            if (!input.Contains(" "))
                            {
                                Multiplication(ConvertUserInputSingle(input));
                            }
                            else
                            {
                                Multiplication(ConvertUserInputArray(input));
                            }
                            break;
                        case 4:

                            Console.Write("What do you want to divide with: ");
                            input = Console.ReadLine();
                            if (!input.Contains(" "))
                            {
                                Division(ConvertUserInputSingle(input));
                            }
                            else
                            {
                                Division(ConvertUserInputArray(input));
                            }
                            break;
                        case 9:
                            Reset();
                            break;
                        default:
                            PromptInvalidMessage();
                            break;
                    }

                }
                catch
                {
                    PromptInvalidMessage();
                }

            }
        }

        public void PromptInvalidMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Invalid input, try again");
            Console.Write("Enter any key to continue: ");
            Console.ReadKey();
        }
    }

    class Program
    {
        static void Main()
        {
            new Calculator();
        }
    }
}