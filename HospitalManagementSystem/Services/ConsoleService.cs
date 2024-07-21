using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Services
{
    public class ConsoleService
    {
        public int GetIntegerFromUser(string userPrompt, string errorMessage)
        {
            do
            {
                Console.Write(userPrompt);
                //The line below is being used to make sure that what the user inputs is a number
                if (int.TryParse(Console.ReadLine()!, out int inputedUserId))
                {
                    return inputedUserId;
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
            Console.SetCursorPosition((Console.WindowWidth / 2) - 5, Console.CursorTop);
            Console.WriteLine(thingToPrint);
        }
    }
}
