﻿using ApplicationDotnetAssignment1.Helpers;
using ApplicationDotnetAssignment1.Models;
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
        public PatientService(Patient loggedInUser, HospitalSystemUnitOfWork unitOfWork) : base(loggedInUser, unitOfWork)
        {
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
                        PrintPatientDoctorDetails();
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

        void PrintPatientDoctorDetails()
        {
            Console.Clear();
            LoggedInUser.AssignedDoctor.PrintAsRow();
            Console.WriteLine("Press any key to return to the main menu");
            Console.ReadKey();
        }
    }
}
