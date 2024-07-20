using ApplicationDotnetAssignment1.ExtensionMethods;
using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Services
{
    public class DoctorService : UserService<Doctor>
    {
        public DoctorService(Doctor loggedInDoctor, HospitalSystemUnitOfWork unitOfWork) : base(loggedInDoctor, unitOfWork)
        {
        }

        protected override void PrintMenuOptions()
        {
            Console.WriteLine(@"1. List Doctor Details
2. List patients
3. List appointments
4. Check particular patient
5. List appointments with patient
6. Logout
7. Exit
");
        }

        protected override void GetUserOptionChoice()
        {
            int userChoice = ConsoleService.GetIntegerFromUser("Please select an option: ", "To select an option please input a number");
            while (true)
            {
                switch(userChoice)
                {
                    case 1:
                        PrintDoctorDetails();
                        return;
                    case 2:
                        PrintAssignedPatients();
                        return;
                    case 3:
                        PrintAssignedAppointments();
                        return;
                    case 4:
                        return;
                    case 5:
                        return;
                    case 6:
                        isLoggedIn = false;
                        return;
                    case 7:
                        Exit();
                        return;
                    default:
                        userChoice = ConsoleService.GetIntegerFromUser("Please select one of the displayed options: ", "To select an option please input a number");
                        break;
                }
            }
        }

        void PrintAssignedPatients()
        {
            Console.Clear();
            ConsoleService.PrintInCenter("Assigned Patients");
            LoggedInUser.Patients.PrintAllValidElements();
            ConsoleService.WaitForKeyPress();
        }

        void PrintDoctorDetails()
        {
            Console.Clear();
            Console.WriteLine("{0,-30} | {1,-30} | {2,-50} | {3}", "Name", "Email Address", "Address", "Phone");
            ConsoleService.PrintSeperator();
            Console.WriteLine(LoggedInUser.ToString());
            ConsoleService.WaitForKeyPress();
        }

        void PrintAssignedAppointments()
        {
            Console.Clear();
            ConsoleService.PrintInCenter("All Appointments");
            LoggedInUser.AssignedAppointments.PrintAllElements();
            ConsoleService.WaitForKeyPress();
        }
    }
}
