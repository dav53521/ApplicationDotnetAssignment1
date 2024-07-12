using ApplicationDotnetAssignment1.Contexts;
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
        public void Login(HospitalSystemUnitOfWork unitOfWork)
        {
            bool loginSuccessful = false;

            Console.SetCursorPosition((Console.WindowWidth) / 2, Console.CursorTop);
            Console.WriteLine("Login");
            Console.WriteLine("Please Enter Your Login Details Below:");

            while (!loginSuccessful) 
            {
                int inputtedId = GetIdFromUser();
                string inputtedPassword = GetPasswordFromUser();

                Console.WriteLine();

                User foundUser = new Doctor();

                if (foundUser != null)
                {
                    loginSuccessful = true;
                    Console.WriteLine("Login successful.");
                    Thread.Sleep(1000); //This is being used to show the message above so the user can see that they have logged in successfully before they are transported to the correct user menu
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

        void OpenCorrectUserMenu(User loggedInUser)
        {
            //This switch works GetType gets the compile time type of the object which means that the cast has no affect as it changes the type during the runtime
            switch (loggedInUser.GetType().Name)
            {
                case "Admin":
                    var adminService = new AdminService((Admin)loggedInUser);
                    adminService.PrintMainMenu();
                    break;
                case "Patient":
                    var paitentService = new PatientService((Patient)loggedInUser);
                    paitentService.PrintMainMenu();
                    break;
                case "Doctor":
                    var doctorService = new DoctorService((Doctor)loggedInUser);
                    doctorService.PrintMainMenu();
                    break;
            }
        }
    }
}
