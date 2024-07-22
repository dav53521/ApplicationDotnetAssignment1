﻿using ApplicationDotnetAssignment1.ExtensionMethods;
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
                        PrintPatientDetails();
                        return;
                    case 2:
                        PrintAssignedDoctorDetails();
                        return;
                    case 3:
                        PrintAllAppointments();
                        return;
                    case 4:
                        BookANewAppointment();
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
            ConsoleHelper.PrintInCenter("My Doctor");

            if(LoggedInUser.AssignedDoctor != null)
            {
                Console.WriteLine("{0,-30} | {1,-30} | {2,-50} | {3}", "Name", "Email Address", "Address", "Phone");
                ConsoleHelper.PrintSeperator();
                Console.WriteLine(LoggedInUser.AssignedDoctor.ToString());
            }
            else 
            {
                Console.WriteLine("You do not have an assigned doctor");
            }
            
            ConsoleHelper.WaitForKeyPress();
        }

        void PrintPatientDetails()
        {
            Console.Clear();
            ConsoleHelper.PrintInCenter("My Details");
            Console.WriteLine("{0,-30} | {1,-30} | {2,-30} | {3,-50} | {4}", "Name", "Doctor", "Email Address", "Address", "Phone");
            ConsoleHelper.PrintSeperator();
            Console.WriteLine(LoggedInUser.ToString());
            ConsoleHelper.WaitForKeyPress();
        }

        void PrintAllAppointments()
        {
            Console.Clear();
            ConsoleHelper.PrintInCenter("My Appointments");
            LoggedInUser.BookedAppointments.PrintAllValidElements();
            ConsoleHelper.WaitForKeyPress();
        }

        void BookANewAppointment()
        {
            Console.Clear();

            if(LoggedInUser.AssignedDoctor == null)
            {
                GetPatientDesiredDoctor();
            }

            Console.WriteLine($"You are booking a new appointment with {LoggedInUser.AssignedDoctor?.Name}");
            Console.Write("Description of the appointment: ");
            string description = Console.ReadLine()!;

            Appointment newAppointment = new Appointment()
            {
                DoctorId = LoggedInUser.AssignedDoctorId!.Value,
                Doctor = LoggedInUser.AssignedDoctor,
                PatientId = LoggedInUser.Id,
                Patient = LoggedInUser,
                Description = description
            };


            if(_emailService.TrySendAppointmentConfirmationEmail(newAppointment))
            {
                UnitOfWork.AppointmentRepository.AddAppointment(newAppointment);
                UnitOfWork.Save();
                Console.WriteLine("The appointment has been booked successfully");
            }
            else
            {
                Console.WriteLine("The appointment could not be booked.");
            }

            ConsoleHelper.WaitForKeyPress();
        }

        void GetPatientDesiredDoctor()
        {
            List<Doctor> allDoctors = UnitOfWork.DoctorRepository.GetAllDoctors();
            Console.WriteLine("You are not registered to a doctor! Please choose which doctor you would like to register with");
            for(int i = 0; i < allDoctors.Count; i++)
            {
                Console.WriteLine($"{i + 1} {allDoctors[i]}");
            }

            bool doctorSelected = false;
            while(!doctorSelected)
            {
                int selectedDoctor = ConsoleHelper.GetIntegerFromUser("Please choose a doctor: ", "Please only enter a number");

                if(selectedDoctor > allDoctors.Count)
                {
                    Console.WriteLine("Invalid selection please try again.");
                }
                else
                {
                    Doctor choosenDoctor = allDoctors[selectedDoctor - 1];
                    LoggedInUser.AssignedDoctorId = choosenDoctor.Id;
                    LoggedInUser.AssignedDoctor = choosenDoctor;
                    doctorSelected = true;
                }
            }
        }
    }
}
