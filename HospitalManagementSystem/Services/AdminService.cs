using ApplicationDotnetAssignment1.ExtensionMethods;
using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.Services.Interfaces;
using ApplicationDotnetAssignment1.UnitOfWork.Interface;

namespace ApplicationDotnetAssignment1.Services
{
    public class AdminService : UserService<Admin>
    {
        //This constructor is being used to pass up the logged in user and the necessary depndency inections into it's parent class which is the user service so they can be stored in the user service's fields
        public AdminService(Admin loggedInUser, IHospitalSystemUnitOfWork unitOfWork, IConsoleService consoleService) : base(loggedInUser, unitOfWork, consoleService)
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
                        IsLoggedIn = false;
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
            ConsoleService.PrintInCenter("All Doctors");
            Console.WriteLine();
            UnitOfWork.DoctorRepository.GetAllDoctors().PrintTableOfEntities("No doctors registered");
        }

        void PrintSpecificDoctorDetails()
        {
            Console.Clear();
            ConsoleService.PrintInCenter("Doctor Details");
            int doctorToFindId = ConsoleService.GetIdFromUser("Plese enter the ID of the doctor who's detail you want to see: ");
            Doctor? foundDoctor = UnitOfWork.DoctorRepository.GetDoctorById(doctorToFindId);

            PrintEntityDetails(foundDoctor, $"Details for the doctor with Id {doctorToFindId}:", "No Doctor with that ID was found");
        }

        void PrintAllPatients()
        {
            Console.Clear();
            ConsoleService.PrintInCenter("All Patients");
            UnitOfWork.PatientRepository.GetAllPatients().PrintTableOfEntities("No patients registered");
        }

        void PrintSpecificPatientDetails()
        {
            Console.Clear();
            ConsoleService.PrintInCenter("Doctor Details");
            int patientToFindId = ConsoleService.GetIdFromUser("Plese enter the ID of the patient who's detail you want to see: ");
            Patient? foundPatient = UnitOfWork.PatientRepository.GetPatientById(patientToFindId);

            PrintEntityDetails(foundPatient, $"Details for the patient with Id {patientToFindId}:", "No Patient with that ID was found");
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

            string password = ConsoleService.GetMaskedInputFromUser("Password: ");

            Patient patientToAdd = new Patient()
            {
                Name = fullName,
                Password = password,
                Email = email,
                PhoneNumber = phoneNumber,
                Address = address
            };

            UnitOfWork.PatientRepository.AddPatient(patientToAdd);

            Console.WriteLine($"A new Patient with the name: {patientToAdd.Name} has been created with the Id: {patientToAdd.Id}");
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

            string password = ConsoleService.GetMaskedInputFromUser("Password: ");

            Doctor doctorToAdd = new Doctor()
            {
                Name = fullName,
                Password = password,
                Email = email,
                PhoneNumber = phoneNumber,
                Address = address
            };

            UnitOfWork.DoctorRepository.AddDoctor(doctorToAdd);

            Console.WriteLine($"A new Doctor with the name: {doctorToAdd.Name} has been created with the Id: {doctorToAdd.Id}");
        }
    }
}
