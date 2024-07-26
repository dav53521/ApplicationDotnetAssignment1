﻿using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Services
{
    public class ConsoleService : IConsoleService
    {
        public int GetIdFromUser(string userPrompt)
        {
            do
            {
                Console.Write(userPrompt);
                string userInput = Console.ReadLine()!;

                //The line below is being used to make sure that what the user inputs is a number
                if (userInput.Length > 4 && int.TryParse(userInput, out int inputedNumber))
                {
                    return inputedNumber;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Valid IDs are at least 5 characters long and only consist of numbers. Please Try Again");
                }
            } while (true);
        }

        public int GetNumberFromUser(string userPrompt, string errorMessage)
        {
            do
            {
                Console.Write(userPrompt);
                string userInput = Console.ReadLine()!;

                if (int.TryParse(userInput, out int inputedNumber)) //This line below is being used to make sure that what the user inputs is a number
                {
                    return inputedNumber;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine(errorMessage);
                }
            } while (true);
        }

        public string GetMaskedInput(string userPrompt)
        {
            Console.Write(userPrompt);

            string maskedInput = ""; //Empty string so that if a user presses enter right away then an empty string will be returned instead of a null
            var keyPressed = Console.ReadKey(true);

            while (keyPressed.Key != ConsoleKey.Enter)
            {
                if (!maskedInput.IsNullOrEmpty() && keyPressed.Key == ConsoleKey.Backspace)
                {
                    maskedInput = maskedInput.Remove(maskedInput.Length - 1);
                    Console.Write("\b \b");
                }
                else if (!char.IsControl(keyPressed.KeyChar))
                {
                    maskedInput += keyPressed.KeyChar;
                    Console.Write("*");
                }

                keyPressed = Console.ReadKey(true);
            }

            Console.WriteLine(); //This is being used so that the next ouput into the console will be on a new line
            return maskedInput;
        }

        public void PrintSeperator()
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("-");
            }
        }

        public void WaitForKeyPress()
        {
            Console.WriteLine();
            Console.WriteLine("Please press any key to return back to the main menu");
            Console.ReadKey();
        }

        public void PrintInCenter(string thingToPrint)
        {
            Console.SetCursorPosition((Console.WindowWidth / 2) - thingToPrint.Length, Console.CursorTop);
            Console.WriteLine(thingToPrint);
        }
    }
}
