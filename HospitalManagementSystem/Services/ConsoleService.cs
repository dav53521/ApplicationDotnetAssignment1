using ApplicationDotnetAssignment1.Models;
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
        public int GetIntegerFromUser(string userPrompt, string errorMessage)
        {
            do
            {
                Console.Write(userPrompt);
                //The line below is being used to make sure that what the user inputs is a number
                if (int.TryParse(Console.ReadLine()!, out int inputedNumber))
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

        public bool GetIntegerFromUser(string userPrompt, string errorMessage, char exitCharacter, out int gottenInteger)
        {
            gottenInteger = 0;
            do
            {
                Console.Write(userPrompt);
                string userInput = Console.ReadLine()!;

                if(userInput == exitCharacter.ToString())
                {
                    return false;
                }
                else if (int.TryParse(userInput, out int inputedNumber)) //This line below is being used to make sure that what the user inputs is a number
                {
                    gottenInteger = inputedNumber;
                    return true;
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

        public void PrintTableHeaderForType(string tableType)
        {
            switch (tableType)
            {
                case "Doctor":
                    Console.WriteLine("{0,-30} | {1,-30} | {2,-50} | {3}", "Name", "Email Address", "Address", "Phone");
                    break;
                case "Appointment":
                    Console.WriteLine("{0,-30} | {1,-30} | {2}", "Doctor", "Patient", "Description");
                    break;
                case "Patient":
                    Console.WriteLine("{0,-20} | {1,-20} | {2,-30} | {3,-30} | {4,-10}", "Name", "Doctor", "Email Address", "Address", "Phone");
                    break;
            }
        }
    }
}
