﻿using ApplicationDotnetAssignment1.Contexts;
using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.Services.Interfaces;
using ApplicationDotnetAssignment1.UnitOfWork;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Services
{
    public class LoginService: ILoginService
    {
        public void Login(int inputtedId, string inputtedPassword, HospitalSystemContext contextManager)
        {
            bool loginSuccessful = false;

            Console.SetCursorPosition((Console.WindowWidth) / 2, Console.CursorTop); //This line is being used to place the "Login Please" text in the center of the console
            Console.WriteLine("Login");
            Console.WriteLine("Please Enter Your Login Details Below:");

            while (!loginSuccessful) 
            {
                inputtedId = GetIdFromUser();
                inputtedPassword = GetPasswordFromUser();

                User? foundUser = FindUserWithGivenCredientials(inputtedId, inputtedPassword, contextManager);

                Console.WriteLine();

                if (foundUser != null)
                {
                    loginSuccessful = true;
                    Console.WriteLine("Login successful.");
                    Thread.Sleep(1000);
                    OpenCorrectUserMenu(foundUser);
                }
                else
                {
                    Console.WriteLine("Login could not be found please try again.");
                }
            }
        }

        int GetIdFromUser()
        {
            do
            {
                Console.Write("ID: ");
                if (Int32.TryParse(Console.ReadLine()!, out int inputedUserId))
                {
                    return inputedUserId;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Please input only digits for the UserId.");
                }
            } while (true);
        }

        string GetPasswordFromUser()
        {
            Console.Write("Password:");

            string password = ""; //Empty string so that if a user presses enter right away then an empty string will be given to the check.
            var keyPressed = Console.ReadKey(true);

            while (keyPressed.Key != ConsoleKey.Enter)
            {
                if (!password.IsNullOrEmpty() && keyPressed.Key == ConsoleKey.Backspace)
                {
                    password = password.Remove(password.Length - 1);
                    Console.Write("\b \b");
                }
                else if (!Char.IsControl(keyPressed.KeyChar))
                {
                    password += keyPressed.KeyChar;
                    Console.Write("*");
                }

                keyPressed = Console.ReadKey(true);
            }

            return password;
        }

        User? FindUserWithGivenCredientials(int id, string password, HospitalSystemContext context)
        {
        }

        void OpenCorrectUserMenu(User loggedInUser)
        {
            switch (loggedInUser.Role)
            {
                case "Admin":
                    var adminService = new AdminService(null);
                    adminService.PrintMainMenu();
                    break;
                case "Patient":
                    var paitentService = new PaitentService(null);
                    paitentService.PrintMainMenu();
                    break;
                case "Doctor":
                    var doctorService = new DoctorService(null);
                    doctorService.PrintMainMenu();
                    break;
            }
        }
    }
}
