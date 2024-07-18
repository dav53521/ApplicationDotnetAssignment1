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
            while (true) 
            {
                Console.SetCursorPosition((Console.WindowWidth / 2) - 5, Console.CursorTop);
                Console.WriteLine("Login");
                Console.WriteLine("Please Enter Your Login Details Below:");

                User foundUser = GetLoggedInUser(unitOfWork);
                OpenCorrectUserMenu(foundUser, unitOfWork);
            }
        }

        User GetLoggedInUser(HospitalSystemUnitOfWork unitOfWork)
        {
            while (true)
            {
                int userToFindId = ConsoleHelper.GetIntegerFromUser("Id:", "Please only enter numbers for Ids");
                string userToFindPassword = ConsoleHelper.GetMaskedInput("Password:");

                User? foundUser = unitOfWork.UserRepository.FindUsers(user => user.Id == userToFindId && user.Password == userToFindPassword).FirstOrDefault();

                if(foundUser != null)
                {
                    return foundUser;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("User could not be found please try again");
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

            Console.Clear();
        }
    }
}
