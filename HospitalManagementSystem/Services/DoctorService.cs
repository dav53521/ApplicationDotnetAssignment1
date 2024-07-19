﻿using ApplicationDotnetAssignment1.ExtensionMethods;
using ApplicationDotnetAssignment1.Helpers;
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
            Console.WriteLine(@"1. List Patient Details
2. List my doctor details
3. List all appointments
4. Book appointments
5. Exit to login
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
                        PrintDoctorDetails();
                        return;
                    case 3:
                        PrintBookedAppointments();
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

        void PrintPatientDetails()
        {
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth / 2) - 5, Console.CursorTop);
            Console.WriteLine("Assigned Patient Details");
            Console.WriteLine("{0,-30} | {1,-30} | {2,-30} | {3,-10} | {4}", "Name", "Doctor", "Email Address", "Phone", "Address");

            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("-");
            }

            LoggedInUser.Patients.PrintAllElements();

            Console.WriteLine();
            Console.WriteLine("Please press any key to return back to the main menu");
            Console.ReadKey();
            return;
        }

        void PrintDoctorDetails()
        {
            Console.Clear();
            Console.WriteLine("{0,-30} | {1,-30} | {2,-10} | {3}", "Name", "Email Address", "Phone", "Address");
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("-");
            }

            Console.WriteLine(LoggedInUser.ToString());

            Console.WriteLine();
            Console.WriteLine("Please press any key to return back to the main menu");
            Console.ReadKey();
            return;
        }

        void PrintBookedAppointments()
        {
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth / 2) - 5, Console.CursorTop);
            Console.WriteLine("All Appointments");
            Console.WriteLine("{0,-30} | {1,-30} | {2}", "Doctor", "Patient", "Description");

            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("-");
            }

            LoggedInUser.AssignedAppointments.PrintAllElements();

            Console.WriteLine();
            Console.WriteLine("Please press any key to return back to the main menu");
            Console.ReadKey();
            return;
        }
    }
}
