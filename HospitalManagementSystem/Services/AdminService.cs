using ApplicationDotnetAssignment1.ExtensionMethods;
using ApplicationDotnetAssignment1.Migrations;
using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.Services.Interfaces;
using ApplicationDotnetAssignment1.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Services
{
    public class AdminService : UserService<Admin>
    {

        public AdminService(Admin loggedInUser, HospitalSystemUnitOfWork unitOfWork, IConsoleService consoleService) : base(loggedInUser, unitOfWork, consoleService)
        {
        }

        protected override void PrintMenuOptions()
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

        protected override void GetUserOptionChoice()
        {
            int userChoice = ConsoleHelper.GetIntegerFromUser("Please select an option: ", "To select an option please input a number");
            while (true)
            {
                switch (userChoice)
                {
                    case 1:
                        ListAllDoctors();
                        return;
                    case 2:
                        PrintSpecificDoctorDetails();
                        return;
                    case 3:
                        PrintAllPatients();
                        return;
                    case 4:
                        PrintSpecificPatientDetails();
                        return;
                    case 5:
                        AddDoctor();
                        return;
                    case 6:
                        AddPatient();
                        return;
                    case 7:
                        isLoggedIn = false;
                        return;
                    case 8:
                        Exit();
                        break;
                    default:
                        userChoice = ConsoleHelper.GetIntegerFromUser("Please select one of the displayed options: ", "To select an option please input a number");
                        break;
                }
            }
        }

        void ListAllDoctors()
        {
            Console.Clear();
            List<Doctor> allDoctors = UnitOfWork.DoctorRepository.GetAllDoctors();
            ConsoleHelper.PrintInCenter("All Doctors\n");
            Console.WriteLine("All doctors registered to DOTNET Hospital Management System\n");
            ConsoleHelper.PrintTableHeaderForType("Doctor");
            allDoctors.PrintAllValidElements(ConsoleHelper);
            ConsoleHelper.WaitForKeyPress();
        }

        void PrintSpecificDoctorDetails()
        {
            Console.Clear();
            ConsoleHelper.PrintInCenter("Doctor Details");
            int doctorToFind = ConsoleHelper.GetIntegerFromUser("Plese enter the ID of the doctor who's detail you want to see: ", "Please only enter numbers for IDs");
            Doctor? foundDoctor = UnitOfWork.DoctorRepository.GetDoctorById(doctorToFind);

            if(foundDoctor != null)
            {
                Console.WriteLine($"Details for {foundDoctor.Name}\n");
                ConsoleHelper.PrintTableHeaderForType("Doctor");
                ConsoleHelper.PrintSeperator();
                Console.WriteLine(foundDoctor.ToString());
            }
            else
            {
                Console.WriteLine("No Doctor with that ID was found");
            }
            ConsoleHelper.WaitForKeyPress();
        }

        void PrintAllPatients()
        {
            Console.Clear();
            List<Patient> allPatients = UnitOfWork.PatientRepository.GetAllPatients();
            ConsoleHelper.PrintInCenter("All Patients\n");
            Console.WriteLine("All patients registered to DOTNET Hospital Management System\n");
            ConsoleHelper.PrintTableHeaderForType("Patient");
            allPatients.PrintAllValidElements(ConsoleHelper);
            ConsoleHelper.WaitForKeyPress();
        }

        void PrintSpecificPatientDetails()
        {
            Console.Clear();
            ConsoleHelper.PrintInCenter("Doctor Details");
            int patientToFind = ConsoleHelper.GetIntegerFromUser("Plese enter the ID of the patient who's detail you want to see: ", "Please only enter numbers for IDs");
            Patient? foundPatient = UnitOfWork.PatientRepository.GetPatientById(patientToFind);

            if (foundPatient != null)
            {
                Console.WriteLine($"\nDetails for {foundPatient.Name}\n");
                ConsoleHelper.PrintTableHeaderForType("Patient");
                ConsoleHelper.PrintSeperator();
                Console.WriteLine(foundPatient.ToString());
            }
            else
            {
                Console.WriteLine("No Patient with that ID was found");
            }
            ConsoleHelper.WaitForKeyPress();
        }

        void AddPatient()
        {
            Console.Clear();
            ConsoleHelper.PrintInCenter("Add Patient");
            Console.WriteLine("Registering a new patient with the DOTNET Hospital Management System");

            Console.Write("First Name: ");
            string firstName = Console.ReadLine()!;

            Console.Write("Last Name: ");
            string lastName = Console.ReadLine()!;

            Console.Write("Email: ");
            string email = Console.ReadLine()!;

            int phoneNumber = ConsoleHelper.GetIntegerFromUser("Phone: 04", "Please Only Enter Numbers");

            int streetNumber = ConsoleHelper.GetIntegerFromUser("Street Number: ", "Please Only Enter Numbers");

            Console.Write("Street: ");
            string street = Console.ReadLine()!;

            Console.Write("City: ");
            string city = Console.ReadLine()!;

            Console.Write("State: ");
            string state = Console.ReadLine()!;

            string password = ConsoleHelper.GetMaskedInput("Password: ");

            Patient patientToAdd = new Patient()
            {
                Name = $"{firstName} {lastName}",
                Password = password,
                Email = email,
                PhoneNumber = "04" + phoneNumber.ToString(),
                Address = $"{streetNumber} {street} {city} {state}"
            };

            UnitOfWork.PatientRepository.AddPatient(patientToAdd);
            UnitOfWork.Save();

            Console.WriteLine($"Patient {patientToAdd.Name} has been created");
            ConsoleHelper.WaitForKeyPress();
        }

        void AddDoctor()
        {
            Console.Clear();
            ConsoleHelper.PrintInCenter("Add Doctor");
            Console.WriteLine("Registering a new doctor with the DOTNET Hospital Management System");

            Console.Write("First Name: ");
            string firstName = Console.ReadLine()!;

            Console.Write("Last Name: ");
            string lastName = Console.ReadLine()!;

            Console.Write("Email: ");
            string email = Console.ReadLine()!;

            int phoneNumber = ConsoleHelper.GetIntegerFromUser("Phone: 04", "Please Only Enter Numbers");

            int streetNumber = ConsoleHelper.GetIntegerFromUser("Street Number: ", "Please Only Enter Numbers");

            Console.Write("Street: ");
            string street = Console.ReadLine()!;

            Console.Write("City: ");
            string city = Console.ReadLine()!;

            Console.Write("State: ");
            string state = Console.ReadLine()!;

            string password = ConsoleHelper.GetMaskedInput("Password: ");

            Doctor doctorToAdd = new Doctor()
            {
                Name = $"{firstName} {lastName}",
                Password = password,
                Email = email,
                PhoneNumber = "04" + phoneNumber.ToString(),
                Address = $"{streetNumber} {street} {city} {state}"
            };

            UnitOfWork.DoctorRepository.AddDoctor(doctorToAdd);
            UnitOfWork.Save();

            Console.WriteLine($"Doctor {doctorToAdd.Name} has been created");
            ConsoleHelper.WaitForKeyPress();
        }
    }
}
