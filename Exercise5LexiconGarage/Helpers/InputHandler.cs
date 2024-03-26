using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5LexiconGarage.Helpers
{
    public static class InputHandler
    {
        public static int GetIntegerInput(string prompt)
        {
            int result;
            bool isValidInput;

            do
            {
                Console.WriteLine(prompt);
                isValidInput = int.TryParse(Console.ReadLine(), out result);

                if (!isValidInput)
                {
                    Console.WriteLine("Invalid Input, please enter a integer value");
                }

            } while (!isValidInput);

            return result;
        }

        public static double GetDoubleInput(string prompt)
        {
            double result;
            bool isValidInput;

            do
            {
                Console.WriteLine(prompt);
                isValidInput = double.TryParse(Console.ReadLine(), out result);

                if (!isValidInput)
                {
                    Console.WriteLine("Invalid Input, please enter a double value");
                }

            } while (!isValidInput);

            return result;
        }

        public static string GetStringInput(string prompt)
        {
            string input;
            do
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine()?.Trim(); // Read input and trim whitespace

                if (string.IsNullOrWhiteSpace(input)) // Check if input is empty or whitespace
                {
                    Console.WriteLine("Input cannot be empty. Please try again.");
                }
            } while (string.IsNullOrWhiteSpace(input)); // Repeat until a non-empty input is provided

            return input;
        }


    }





}
