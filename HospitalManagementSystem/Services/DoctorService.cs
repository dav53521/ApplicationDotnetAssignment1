using ApplicationDotnetAssignment1.ExtensionMethods;
using ApplicationDotnetAssignment1.Models;
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
        public DoctorService(Doctor loggedInDoctor, HospitalSystemUnitOfWork unitOfWork, ConsoleService consoleService) : base(loggedInDoctor, unitOfWork, consoleService)
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

        void PrintParticularPatientDetails()
        {
            Console.Clear();
            ConsoleService.PrintInCenter("Check Patient Details");
            int idOfUserToCheck = ConsoleService.GetIntegerFromUser("Enter the ID of the patient to check: ", "Please enter only numbers for IDs");
            Patient? foundPatient = UnitOfWork.PatientRepository.GetById(idOfUserToCheck);

            if(foundPatient == null)
            {
                Console.WriteLine("No Patient was found");
            }
            else
            {
                Console.WriteLine("{0,-30} | {1,-30} | {2,-30} | {3,-50} | {4}", "Name", "Doctor", "Email Address", "Address", "Phone");
                ConsoleService.PrintSeperator();
                Console.WriteLine(foundPatient.ToString());
            }

            ConsoleService.WaitForKeyPress();
        }

        void PrintAppointmentsWithPatient()
        {
            Console.Clear();
            ConsoleService.PrintInCenter("Appointments With");
            int idOfUserToCheck = ConsoleService.GetIntegerFromUser("Enter the ID of the patient to check: ", "Please enter only numbers for IDs");
            List<Appointment> appointmentsToPrint = UnitOfWork.AppointmentRepository.FindAppointments(a => a.PatientId == idOfUserToCheck);

            if(!appointmentsToPrint.IsNullOrEmpty())
            {
                appointmentsToPrint.PrintAllElements();
            }
            else
            {
                Console.WriteLine("No appointments found");
            }

            ConsoleService.WaitForKeyPress();
        }
    }
}
