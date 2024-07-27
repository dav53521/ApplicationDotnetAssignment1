using ApplicationDotnetAssignment1.ExtensionMethods;
using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.Models.Interface;
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
            int userChoice = ConsoleService.GetNumberFromUser("Please select an option: ", "Please input a number as your option");
            while (true)
            {
                switch(userChoice)
                {
                    case 1:
                        PrintLoggedInUserDetails();
                        return;
                    case 2:
                        PrintAssignedDoctorDetails();
                        return;
                    case 3:
                        PrintAllAppointments();
                        return;
                    case 4:
                        BookNewAppointment();
                        return;
                    case 5:
                        isLoggedIn = false;
                        return;
                    case 6:
                        Exit();
                        return;
                    default:
                        userChoice = ConsoleService.GetNumberFromUser("Please select one of the displayed options: ", "Please input a number as your option");
                        break;
                }
            }
        }


        void PrintAssignedDoctorDetails()
        {
            Console.Clear();
            ConsoleService.PrintInCenter("My Doctor");

            if(LoggedInUser.AssignedDoctor != null)
            {
                Console.WriteLine(LoggedInUser.AssignedDoctor?.ToString());
            }
            else 
            {
                Console.WriteLine("You do not have an assigned doctor");
            }
        }

        void PrintAllAppointments()
        {
            Console.Clear();
            List<Appointment> validAppointments = LoggedInUser.BookedAppointments.GetAllValidElements();

            ConsoleService.PrintInCenter("My Appointments");
            PrintEntitiesAsTable(validAppointments, "No Appointments Booked");
        }

        void BookNewAppointment()
        {
            Console.Clear();

            ConsoleService.PrintInCenter("Book New Appointment");

            if(LoggedInUser.AssignedDoctor == null)
            {
                GetTheDesiredDoctorForPatient();
            }

            Console.WriteLine($"You are booking a new appointment with {LoggedInUser.AssignedDoctor?.Name}");
            Console.Write("Description of the appointment: ");
            string description = Console.ReadLine()!;

            Appointment newAppointment = new Appointment()
            {
                DoctorId = LoggedInUser.AssignedDoctorId!.Value,
                PatientId = LoggedInUser.Id,
                Description = description
            };

            UnitOfWork.AppointmentRepository.AddAppointment(newAppointment);
            Console.WriteLine("Saving Appointment");
            _emailService.SendAppointmentConfirmationEmail(newAppointment);
            Console.WriteLine("The appointment has been booked successfully");
        }

        void GetTheDesiredDoctorForPatient()
        {
            List<Doctor> allDoctors = UnitOfWork.DoctorRepository.GetAllDoctors().GetAllValidElements();
            Console.WriteLine("You are not registered to a doctor! Please choose which doctor you would like to register with");
            for(int i = 0; i < allDoctors.Count; i++)
            {
                Console.WriteLine($"{i + 1} {((IPrintableAsTable)allDoctors[i]).TableRow}");
            }

            bool doctorSelected = false;
            while(!doctorSelected)
            {
                int selectedDoctor = ConsoleService.GetNumberFromUser("Please choose a doctor: ", "Please only enter a number");

                if(selectedDoctor > allDoctors.Count)
                {
                    Console.WriteLine("Invalid selection please try again.");
                }
                else
                {
                    Doctor choosenDoctor = allDoctors[selectedDoctor - 1];
                    LoggedInUser.AssignedDoctorId = choosenDoctor.Id;
                    UnitOfWork.PatientRepository.UpdatePatient(LoggedInUser);
                    doctorSelected = true;
                }
            }
        }
    }
}
