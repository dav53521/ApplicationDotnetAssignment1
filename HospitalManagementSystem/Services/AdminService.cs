using ApplicationDotnetAssignment1.ExtensionMethods;
using ApplicationDotnetAssignment1.Migrations;
using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.Models.Interface;
using ApplicationDotnetAssignment1.Services.Interfaces;
using ApplicationDotnetAssignment1.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            int userChoice = ConsoleService.GetNumberFromUser("Please select an option: ", "To select an option please input a number");
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
                        userChoice = ConsoleService.GetNumberFromUser("Please select one of the displayed options: ", "To select an option please input a number");
                        break;
                }
            }
        }

        void ListAllDoctors()
        {
            Console.Clear();
            List<Doctor> allDoctors = UnitOfWork.DoctorRepository.GetAllDoctors().GetAllValidElements();
            ConsoleService.PrintInCenter("All Doctors");
            Console.WriteLine();
            PrintEntitiesAsTable(allDoctors, "All doctors registered to DOTNET Hospital Management System", "No doctors have been registered");
        }

        void PrintSpecificDoctorDetails()
        {
            Console.Clear();
            ConsoleService.PrintInCenter("Doctor Details");
            int doctorToFind = ConsoleService.GetIdFromUser("Plese enter the ID of the doctor who's detail you want to see: ");
            Doctor? foundDoctor = UnitOfWork.DoctorRepository.GetDoctorById(doctorToFind);

            if(foundDoctor != null)
            {
                Console.WriteLine($"Details for {foundDoctor.Name}\n");
                Console.WriteLine(foundDoctor.ToString());
            }
            else
            {
                Console.WriteLine("No Doctor with that ID was found");
            }
        }

        void PrintAllPatients()
        {
            Console.Clear();
            List<Patient> patientsToPrint = UnitOfWork.PatientRepository.GetAllPatients().GetAllValidElements();
            ConsoleService.PrintInCenter("All Patients");
            PrintEntitiesAsTable(patientsToPrint, "All patients registered to DOTNET Hospital Management System", "No patients have been registered");
        }

        void PrintSpecificPatientDetails()
        {
            Console.Clear();
            ConsoleService.PrintInCenter("Doctor Details");
            int patientToFind = ConsoleService.GetIdFromUser("Plese enter the ID of the patient who's detail you want to see: ");
            Patient? foundPatient = UnitOfWork.PatientRepository.GetPatientById(patientToFind);

            if (foundPatient != null)
            {
                Console.WriteLine($"Details for {foundPatient.Name}\n");
                Console.WriteLine(foundPatient.ToString());
            }
            else
            {
                Console.WriteLine("No Patient with that ID was found");
            }
        }

        void AddPatient()
        {
            Console.Clear();
            ConsoleService.PrintInCenter("Add Patient");
            Console.WriteLine("Registering a new patient with the DOTNET Hospital Management System");

            string fullName = ConsoleService.GetFullNameFromUser();

            string email = ConsoleService.GetEmailFromUser();

            string phoneNumber = ConsoleService.GetPhoneNumberFromUser();

            string address = ConsoleService.GetAddressFromUser();

            string password = ConsoleService.GetMaskedInputFromuser("Password: ");

            Patient patientToAdd = new Patient()
            {
                Name = fullName,
                Password = password,
                Email = email,
                PhoneNumber = phoneNumber,
                Address = address
            };

            UnitOfWork.PatientRepository.AddPatient(patientToAdd);

            Console.WriteLine($"Patient {patientToAdd.Name} has been created with the Id {patientToAdd.Id}");
        }

        void AddDoctor()
        {
            Console.Clear();
            ConsoleService.PrintInCenter("Add Doctor");
            Console.WriteLine("Registering a new doctor with the DOTNET Hospital Management System");

            string fullName = ConsoleService.GetFullNameFromUser();

            string email = ConsoleService.GetEmailFromUser();

            string phoneNumber = ConsoleService.GetPhoneNumberFromUser();

            string address = ConsoleService.GetAddressFromUser();

            string password = ConsoleService.GetMaskedInputFromuser("Password: ");

            Doctor doctorToAdd = new Doctor()
            {
                Name = fullName,
                Password = password,
                Email = email,
                PhoneNumber = phoneNumber,
                Address = address
            };

            UnitOfWork.DoctorRepository.AddDoctor(doctorToAdd);

            Console.WriteLine($"Doctor {doctorToAdd.Name} has been created with the Id {doctorToAdd.Id}");
        }
    }
}
