using ApplicationDotnetAssignment1.ExtensionMethods;
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
    public class DoctorService : UserService<Doctor>
    {
        public DoctorService(Doctor loggedInDoctor, HospitalSystemUnitOfWork unitOfWork, IConsoleService consoleService) : base(loggedInDoctor, unitOfWork, consoleService)
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
            int userChoice = ConsoleHelper.GetIntegerFromUser("Please select an option: ", "To select an option please input a number");
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
                        PrintParticularPatientDetails();
                        return;
                    case 5:
                        PrintAppointmentsWithPatient();
                        return;
                    case 6:
                        isLoggedIn = false;
                        return;
                    case 7:
                        Exit();
                        return;
                    default:
                        userChoice = ConsoleHelper.GetIntegerFromUser("Please select one of the displayed options: ", "To select an option please input a number");
                        break;
                }
            }
        }

        void PrintAssignedPatients()
        {
            Console.Clear();
            ConsoleHelper.PrintInCenter("Assigned Patients");
            LoggedInUser.Patients.PrintAllValidElements(ConsoleHelper);
            ConsoleHelper.WaitForKeyPress();
        }

        void PrintDoctorDetails()
        {
            Console.Clear();
            ConsoleHelper.PrintInCenter("My Details");
            Console.WriteLine("{0,-30} | {1,-30} | {2,-50} | {3}", "Name", "Email Address", "Address", "Phone");
            ConsoleHelper.PrintSeperator();
            Console.WriteLine(LoggedInUser.ToString());
            ConsoleHelper.WaitForKeyPress();
        }

        void PrintAssignedAppointments()
        {
            Console.Clear();
            ConsoleHelper.PrintInCenter("All Appointments");
            LoggedInUser.AssignedAppointments.PrintAllValidElements(ConsoleHelper);
            ConsoleHelper.WaitForKeyPress();
        }

        void PrintParticularPatientDetails()
        {
            Console.Clear();
            ConsoleHelper.PrintInCenter("Check Patient Details");
            int idOfUserToCheck = ConsoleHelper.GetIntegerFromUser("Enter the ID of the patient to check: ", "Please enter only numbers for IDs");
            Patient? foundPatient = UnitOfWork.PatientRepository.GetPatientById(idOfUserToCheck);

            if(foundPatient == null)
            {
                Console.WriteLine("No Patient was found");
            }
            else
            {
                Console.WriteLine("{0,-30} | {1,-30} | {2,-30} | {3,-50} | {4}", "Name", "Doctor", "Email Address", "Address", "Phone");
                ConsoleHelper.PrintSeperator();
                Console.WriteLine(foundPatient.ToString());
            }

            ConsoleHelper.WaitForKeyPress();
        }

        void PrintAppointmentsWithPatient()
        {
            Console.Clear();
            ConsoleHelper.PrintInCenter("Appointments With");
            int idOfUserToCheck = ConsoleHelper.GetIntegerFromUser("Enter the ID of the patient to check: ", "Please enter only numbers for IDs");
            List<Appointment> appointmentsToPrint = UnitOfWork.AppointmentRepository.FindAppointments(a => a.PatientId == idOfUserToCheck);

            if(!appointmentsToPrint.IsNullOrEmpty())
            {
                appointmentsToPrint.PrintAllValidElements(ConsoleHelper);
            }
            else
            {
                Console.WriteLine("No appointments found");
            }

            ConsoleHelper.WaitForKeyPress();
        }
    }
}
