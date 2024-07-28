﻿using ApplicationDotnetAssignment1.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace ApplicationDotnetAssignment1.Services
{
    public class ConsoleService : IConsoleService
    {
        public int GetIdFromUser(string userPrompt)
        {
            while (true)
            {
                string userInput = GetUserInput(userPrompt);

                //The line below is being used to make sure that what the user inputs is both longer than 4 characters and is also an integer as a valid Id consists of 5 numbers
                if (userInput.Length > 4 && int.TryParse(userInput, out int inputedNumber))
                {
                    return inputedNumber;
                }
                else
                {
                    Console.WriteLine("Valid IDs are at least 5 characters long and only consist of numbers. Please Try Again");
                    Console.WriteLine();
                }
            }
        }

        public int GetNumberFromUser(string userPrompt, string errorMessage)
        {
            while (true)
            {
                string userInput = GetUserInput(userPrompt);

                if (int.TryParse(userInput, out int inputedNumber)) //This line is being used to make sure that what the user inputs is an integer and is also used to convert the input into an integer
                {
                    return inputedNumber;
                }
                else
                {
                    Console.WriteLine(errorMessage);
                    Console.WriteLine();
                }
            }
        }

        public string GetMaskedInputFromUser(string userPrompt)
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

        public void PrintInCenter(string thingToPrint)
        {
            //The line below is moving the cursor so that it's in the top of the screen and will center the middle of the input text
            Console.SetCursorPosition((Console.WindowWidth - thingToPrint.Length / 2), Console.CursorTop);
            Console.WriteLine(thingToPrint);
            Console.WriteLine();
        }

        public string GetPhoneNumberFromUser()
        {
            while(true)
            {
                string? inputtedPhoneNumber = GetUserInput("Please enter your phone number: 04");

                if (inputtedPhoneNumber != null && inputtedPhoneNumber.Length == 8 && int.TryParse(inputtedPhoneNumber, out _))
                {
                    return "04" + inputtedPhoneNumber;
                }
                else
                {
                    Console.WriteLine("Please input a valid phone number.");
                    Console.WriteLine();
                }
            }
        }

        public string GetEmailFromUser()
        {
            while(true)
            {
                string inputtedEmail = GetUserInput("Email: ");

                if (inputtedEmail != null && new EmailAddressAttribute().IsValid(inputtedEmail))
                {
                    return inputtedEmail;
                }
                else
                {
                    Console.WriteLine("Please input a valid email.");
                    Console.WriteLine();
                }
            }
        }

        public string GetFullNameFromUser()
        {
            string firstName = GetUserInput("First Name: ");
            string lastName = GetUserInput("Last Name: ");

            return $"{firstName} {lastName}";
        }

        public string GetAddressFromUser()
        {
            int streetNumber = GetNumberFromUser("Street Number: ", "Please Only Enter Numbers");
            string? streetName = GetUserInput("Street: ");
            string? city = GetUserInput("City: ");
            string? state = GetUserInput("State: ");

            return $"{streetNumber.ToString()} {streetName} {city} {state}";
        }

        public string GetUserInput(string userPrompt)
        {
            while(true)
            {
                Console.Write(userPrompt);
                string? userInput = Console.ReadLine();

                if (userInput != null && userInput != string.Empty) //This makes sure that the user actually inputs something and 
                {
                    return userInput;
                }
                else
                {
                    Console.WriteLine("No input was recieved please try again");
                    Console.WriteLine();
                }
            }
        }
    }
}
