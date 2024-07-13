using ApplicationDotnetAssignment1.Contexts;
using ApplicationDotnetAssignment1.Helpers;
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
            Console.SetCursorPosition((Console.WindowWidth / 2) - 5, Console.CursorTop);
            Console.WriteLine("Login");
            Console.WriteLine("Please Enter Your Login Details Below:");

            while (true) 
            {
                int inputtedId = ConsoleHelper.GetIntegerFromUser("Id: ", "An Id can only consists of numbers, please try again");
                string inputtedPassword = ConsoleHelper.GetMaskedInput("Password: ");

                Console.WriteLine();

                User? foundUser = unitOfWork.UserRepository.FindUsers(user => user.Id == inputtedId && user.Password == inputtedPassword).FirstOrDefault();

                if (foundUser != null)
                {
                    Console.WriteLine("Login successful.");
                    Thread.Sleep(800); //This is being used to show the message above so the user can see that they have logged in successfully before they are transported to the correct user menu
                    OpenCorrectUserMenu(foundUser, unitOfWork);
                }
                else
                {
                    Console.WriteLine("Login could not be found please try again.");
                }
            }
        }

        void OpenCorrectUserMenu(User loggedInUser, HospitalSystemUnitOfWork unitOfWork)
        {
            //This switch works GetType gets the compile time type of the object which means that the cast has no affect as it changes the type during the runtime
            switch (loggedInUser.GetType().Name)
            {
                case "Admin":
                    var adminService = new AdminService((Admin)loggedInUser, unitOfWork);
                    adminService.OpenMainMenu();
                    break;
                case "Patient":
                    var paitentService = new PatientService((Patient)loggedInUser, unitOfWork);
                    paitentService.OpenMainMenu();
                    break;
                case "Doctor":
                    var doctorService = new DoctorService((Doctor)loggedInUser, unitOfWork);
                    doctorService.OpenMainMenu();
                    break;
            }
        }
    }
}
