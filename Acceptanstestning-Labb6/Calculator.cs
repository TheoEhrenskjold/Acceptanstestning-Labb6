using System;
using System.Collections.Generic;

namespace Acceptanstestning_Labb6
{
    public class Calculator
    {
        List<string> history = new List<string>();

        public void Run()
        {
            while (true)
            {
                mainMenu();
                userinput();
            }
        }

        public void userinput()
        {
            int input;
            if (int.TryParse(Console.ReadLine(), out input) && input >= 1 && input <= 5)
            {
                if (input == 5)
                {
                    ShowHistory();
                }
                else
                {
                    calculate(input);
                }
            }
            else
            {
                Console.WriteLine("Input a number between 1-5");
            }
        }

        public void mainMenu()
        {
            Console.WriteLine("1: Addition");
            Console.WriteLine("2: Subtraction");
            Console.WriteLine("3: Multiplication");
            Console.WriteLine("4: Division");
            Console.WriteLine("5: Show History");
        }

        public decimal calculate(int input)
        {
            Console.WriteLine("Enter the first number:");
            decimal num1 = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Enter the second number:");
            decimal num2 = Convert.ToDecimal(Console.ReadLine());

            decimal result = 0;

            switch (input)
            {
                case 1:
                    result = Addition(num1, num2);
                    break;
                case 2:
                    result = Subtraction(num1, num2);
                    break;
                case 3:
                    result = Multiplication(num1, num2);
                    break;
                case 4:
                    if (num2 != 0)
                    {
                        result = Division(num1, num2);
                    }
                    else
                    {
                        Console.WriteLine("Cannot divide by zero.");
                        return 0;
                    }
                    break;
                    
                    
            }
            return result;
        }

        public decimal Addition(decimal num1, decimal num2)
        {
            var result = num1 + num2;
            var operation = "+";
            Console.WriteLine($"Result: {num1} {operation} {num2} = {result}");
            save(num1, num2, result, operation);
            return result;
        }

        public decimal Subtraction(decimal num1, decimal num2)
        {
            var result = num1 - num2;
            var operation = "-";
            Console.WriteLine($"Result: {num1} {operation} {num2} = {result}");
            save(num1, num2, result, operation);
            return result;
        }

        public decimal Division(decimal num1, decimal num2)
        {
            var result = num1 / num2;
            var operation = "/";
            Console.WriteLine($"Result: {num1} {operation} {num2} = {result}");
            save(num1, num2, result, operation);
            return result;
        }

        public decimal Multiplication(decimal num1, decimal num2)
        {
            var result = num1 * num2;
            var operation = "*";
            Console.WriteLine($"Result: {num1} {operation} {num2} = {result}");
            save(num1, num2, result, operation);
            return result;
        }

        public void save(decimal num1, decimal num2, decimal result, string operation)
        {
            
                history.Add($"{num1} {operation} {num2} = {result}");
            
        }

        public List<string> GetHistory()
        {
            return history;
        }

        public void ShowHistory()
        {
            if (history.Count == 0)
            {
                Console.WriteLine("No history available.");
            }
            else
            {
                Console.Clear();
                foreach (var record in history)
                {
                    Console.WriteLine(record);
                }
            }
        }

        
    }
}
