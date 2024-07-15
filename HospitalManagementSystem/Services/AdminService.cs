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
    public class AdminService
    {
        UserService _userService;
        Admin _admin;
        HospitalSystemUnitOfWork _unitOfWork;
        bool loggedIn = true;

        public AdminService(Admin loggedInUser, HospitalSystemUnitOfWork unitOfWork, UserService userService)
        {
            _userService = userService;
            _admin = loggedInUser;
            _unitOfWork = unitOfWork;
        }

        public void OpenMainMenu()
        {
            while (loggedIn)
            {
                _userService.OpenMainMenu(_admin);
                PrintMenuOptions();
                GetUserOptionChoice();
            }
        }

        void PrintMenuOptions()
        {
            Console.WriteLine(@"1. List all doctors
2. Check doctor details
3. List all patients
4. Check patient details
5. Add doctor
6. Add patient
7. Logout
8. Exit
");
        }

        void GetUserOptionChoice()
        {
            int userChoice = ConsoleHelper.GetIntegerFromUser("Please select an option: ", "To select an option please input a number");
            while (true)
            {
                switch (userChoice)
                {
                    case 1:
                        printAllDoctors();
                        return;
                    case 2:
                        return;
                    case 3:
                        printAllPatients();
                        return;
                    case 4:
                        return;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        loggedIn = false;
                        return;
                    case 8:
                        _userService.Exit(_unitOfWork);
                        return;
                }
            }
        }

        void printAllDoctors()
        {
            Console.Clear();
            List<Doctor> allDoctors = _unitOfWork.DoctorRepository.GetAll();
            foreach (Doctor doctor in allDoctors)
            {
                doctor.PrintAsRow();
            }
            Console.WriteLine("To go back to the main menu please press any key");
            Console.ReadKey();
        }

        void printAllPatients()
        {
            Console.Clear();
            List<Patient> allPatients = _unitOfWork.PatientRepository.GetAll();
            foreach (Patient patient in allPatients)
            {
                patient.PrintAsRow();
            }
            Console.WriteLine("To go back to the main menu please press any key");
            Console.ReadKey();
        }
    }
}
