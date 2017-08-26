using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Schema;

namespace SumDigits
{
	class Program
	{
		static void Main()
		{
			// Variable to hold our input string, from user.
			string input = "";

			// Variables to store our numbers.
			int firstNumber = 0;
			int secondNumber = 0;

			// Variables to store the length of the numbers.
			int lengthOfFirstNumber = 0;
			int lengthOfSecondNumber = 0;

			// Values to use with validation of correct data.
			bool validLength = false;

			// Loop while we have an invalid length, ie lengths don't match.
			while (validLength == false)
			{
				// Get first number.
				firstNumber = GetNumericInput();

				// Get length of number.
				lengthOfFirstNumber = GetNumericLength(firstNumber);

				// Get second number.
				secondNumber = GetNumericInput();

				// Get length of number.
				lengthOfSecondNumber = GetNumericLength(secondNumber);

				// Compare both lengths are the same.
				if (lengthOfFirstNumber == lengthOfSecondNumber)
				{
					// Lengths are the same, stop the while loop.
					validLength = true;
				}
				else
				{
					// Complain to user, useful feedback.
					Console.WriteLine("Numbers must contain the same number of digits.");
				}
			}

			Console.WriteLine();

			// Call DoTheyMatch for a True or False.
			Console.WriteLine("Equates to: " + DoTheyMatch(firstNumber, secondNumber, lengthOfFirstNumber));

			// Stop console window from closing.
			Console.ReadLine();
		}

		/// <summary>
		/// This method get numeric input from the end user, and validates that
		/// it contains only numeric values, return the number as an interger.
		/// </summary>
		/// <returns></returns>
		static int GetNumericInput()
		{
			// Variables to store our values, and loop control.
			string input = "";
			int number = 0;
			bool valid = false;

			// Loop while input is invalid.
			while (valid == false)
			{
				// Prompt, and get user input.
				Console.Write("Enter an integer: ");
				input = Console.ReadLine();

				// Returns true/false, and sends out the converted number if possible.
				valid = Int32.TryParse(input, out number);

				// Provide useful feedback to end user, valid or invalid.
				if (valid != true)
				{
					Console.WriteLine("Number was invalid, not an integer.");
				}
				else
				{
					Console.WriteLine("\tNumber was valid.");
					valid = true;
				}

				Console.WriteLine();
			}

			// Return our valid number.
			return number;
		}

		/// <summary>
		/// Call sum on each digit and check if all summed digits equal the same numbers.
		/// </summary>
		/// <param name="firstNumber"></param>
		/// <param name="secondNumber"></param>
		/// <param name="lengthOfFirstNumber"></param>
		/// <returns></returns>
		static bool DoTheyMatch(int firstNumber, int secondNumber, int lengthOfFirstNumber)
		{
			// Convert our numbers to a string.
			string firstNum = firstNumber.ToString();
			string secondNum = secondNumber.ToString();

			// Create an integer array, to store the computed values of each digit.
			int[] sumArray = new int[lengthOfFirstNumber];

			// Fill the array with the summed values of each digit, an element at a time.
			for (int x = 0; x < firstNum.Length; x++)
			{
				// Does the math, per element.
				sumArray[x] = Sum(Convert.ToInt32(firstNum[x]), Convert.ToInt32(secondNum[x]));
			}

			// Set our match variable for succes, change on fail.
			bool match = true;

			// Loop through our sum array.
			for (int i = 0; i < sumArray.Length - 1; i++)
			{
				// Check that an element matches the next element.
				if (sumArray[i] != sumArray[i + 1])
				{
					// fails once, break out and tell the user.
					match = false;
					break;
				}
			}

			// Returns success or failure, true or false.
			return match;
		}

		/// <summary>
		///  Returns the length of the number input, counts characters in string.
		/// </summary>
		/// <param name="num"></param>
		/// <returns></returns>
		static int GetNumericLength(int num)
		{
			// Return the length, as integer.
			return num.ToString().Length;
		}

		/// <summary>
		/// Adds the two integers together, and returns it.
		/// </summary>
		/// <param name="first">First Integer Number</param>
		/// <param name="second">Second Integer Number</param>
		/// <returns></returns>
		static int Sum(int first, int second)
		{
			// Return the sum of the two digits / integers.
			return first + second;
		}
	}
}
