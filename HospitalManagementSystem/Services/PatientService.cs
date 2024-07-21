using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.Services.Interfaces;
using ApplicationDotnetAssignment1.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Services
{
    public class PatientService : UserService<Patient>
    {
        IEmailService _emailService;

        public PatientService(Patient loggedInUser, HospitalSystemUnitOfWork unitOfWork, IConsoleService consoleService) : base(loggedInUser, unitOfWork, consoleService)
        {
            _emailService = new EmailService(unitOfWork);
        }

        protected override void PrintMenuOptions()
        {
            Console.WriteLine(@"1. List patient details
2. List my doctor details
3. List all appointments
4. Book appointments
5. Exit to Login
6. Exit System
");
        }

        protected override void GetUserOptionChoice()
        {
            int userChoice = ConsoleHelper.GetIntegerFromUser("Please select an option: ", "To select an option please input a number");
            while (true)
            {
                switch(userChoice)
                {
                    case 1:
                        return;
                    case 2:
                        PrintAssignedDoctorDetails();
                        return;
                    case 3:
                        return;
                    case 4:
                        return;
                    case 5:
                        isLoggedIn = false;
                        return;
                    case 6:
                        Exit();
                        return;
                    default:
                        userChoice = ConsoleHelper.GetIntegerFromUser("Please select one of the displayed options: ", "To select an option please input a number");
                        break;
                }
            }
        }

        void PrintAssignedDoctorDetails()
        {
            Console.Clear();
            ConsoleHelper.PrintInCenter("Assigned Doctor");
            Console.WriteLine(LoggedInUser.AssignedDoctor?.ToString() ?? "You do not have an assigned doctor");
            ConsoleHelper.WaitForKeyPress();
        }

        void PrintPatientDetails()
        {
            Console.WriteLine("{0,-30} | {1,-30} | {2,-30} | {3,-50} | {4}", "Name", "Doctor", "Email Address", "Address", "Phone");
            ConsoleHelper.PrintSeperator();
            Console.WriteLine(LoggedInUser.ToString());
            ConsoleHelper.WaitForKeyPress();
        }
    }
}
