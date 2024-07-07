using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.Services.Interfaces;
using ApplicationDotnetAssignment1.UnitOfWork;
using ApplicationDotnetAssignment1.UnitOfWork.Repositories;
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
        public void Login()
        {
            var unitOfWork = new HospitalSystemUnitOfWork();
            bool loginSuccessful = false;

            Console.SetCursorPosition((Console.WindowWidth) / 2, Console.CursorTop); //This line is being used to place the "Login Please" text in the center of the console
            Console.WriteLine("Login");
            Console.WriteLine("Please Enter Your Login Details Below:");

            while (!loginSuccessful) 
            {
                int inputtedId = GetIdFromUser();
                string inputtedPassword = GetPasswordFromUser();

                Func<User, bool> findUserWithMatchingInfoDelegate = filter => filter.Id == inputtedId && filter.Password == inputtedPassword;
                User? foundLogin = unitOfWork.UserRepository.GetUsersByCustomFilter(findUserWithMatchingInfoDelegate).FirstOrDefault();

                Console.WriteLine();

                if (foundLogin != null)
                {
                    loginSuccessful = true;
                    Console.WriteLine("Login successful.");
                    OpenCorrectUserMenu(foundLogin.Role);
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

        void OpenCorrectUserMenu(string userRole)
        {
            switch (userRole)
            {
                case "Admin":
                    break;
                case "Patient":
                    break;
                case "Doctor":
                    break;
            }
        }
    }
}
