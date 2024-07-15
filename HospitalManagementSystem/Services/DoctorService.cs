using ApplicationDotnetAssignment1.Helpers;
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
    public class DoctorService
    {
        UserService _userService;
        Doctor _doctor;
        HospitalSystemUnitOfWork _unitOfWork;
        bool loggedIn = true;

        public DoctorService(Doctor loggedInDoctor, HospitalSystemUnitOfWork unitOfWork, UserService userService)
        {
            _doctor = loggedInDoctor;
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public void OpenMainMenu()
        {
            while (loggedIn)
            {
                _userService.OpenMainMenu(_doctor);
                PrintMenuOptions();
                GetUserOptionChoice();
            }
        }

        void PrintMenuOptions()
        {
            Console.WriteLine(@"1. List Patient Details
2. List my doctor details
3. List all appointments
4. List appointments
5. Exit to login
6. Exit System
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
                        PrintPatientDetails();
                        return;
                    case 2:
                        PrintDoctorDetails();
                        return;
                    case 3:
                        ListAssignedAppointments();
                        return;
                    case 4:
                        return;
                    case 5:
                        loggedIn = false;
                        return;
                    case 6:
                        _userService.Exit(_unitOfWork);
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
            Console.WriteLine("{0,-30} | {1,-30} | {2,-10} | {3}", "Name", "Email Address", "Phone", "Address");

            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("-");
            }

            foreach (Patient assignedPatient in _doctor.Patients)
            {
                assignedPatient.PrintAsRow();
            }

            Console.WriteLine();
            Console.WriteLine("Please press any key to return back to the main menu");
            Console.ReadKey();
        }

        void PrintDoctorDetails()
        {
            Console.Clear();
            Console.WriteLine("{0,-30} | {1,-30} | {2,-10} | {3}", "Name", "Email Address", "Phone", "Address");
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("-");
            }
            _doctor.PrintAsRow();

            Console.WriteLine();
            Console.WriteLine("Please press any key to return back to the main menu");
            Console.ReadKey();
        }

        void ListAssignedAppointments()
        {
            Console.Clear();
            List<Appointment> assignedAppointments = _unitOfWork.AppointmentRepository.FindAppointments(a => a.DoctorId == _doctor.Id);

            foreach(Appointment assignedAppointment in assignedAppointments)
            {
                Console.WriteLine(assignedAppointment.ToString());
            }

            Console.WriteLine("Please press any key to return back to the main menu");
            Console.ReadKey();
        }
    }
}
