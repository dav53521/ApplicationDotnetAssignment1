using ApplicationDotnetAssignment1.ExtensionMethods;
using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.Services.Interfaces;
using ApplicationDotnetAssignment1.UnitOfWork.Interface;

namespace ApplicationDotnetAssignment1.Services
{
    public class AdminService : UserService<Admin>
    {
        public AdminService(Admin loggedInUser, IHospitalSystemUnitOfWork unitOfWork, IConsoleService consoleService) : base(loggedInUser, unitOfWork, consoleService)
        {
        }

        //This override is for the template method in the UserService as the Patient menu options are unique so the printing of the menu must be defined here
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

        //This override is for the template method in the UserService as the Patient menu options are unique so the menu option selection logic must be defined here
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

        //This method gets all the doctors that have been stored in the doctor table and then prints them out as a table
        void ListAllDoctors()
        {
            Console.Clear();
            ConsoleService.PrintInCenter("All Doctors");
            UnitOfWork.DoctorRepository.GetAllDoctors().PrintEntitiesAsTable("No doctors registered");
        }

        //This method finds a specific doctor that has been inputted by the user and then prints out the found user or prints out the passed in error message if a doctor doesn't exist with that Id
        void PrintSpecificDoctorDetails()
        {
            Console.Clear();
            ConsoleService.PrintInCenter("Doctor Details");
            int doctorToFindId = ConsoleService.GetIdFromUser("Plese enter the ID of the doctor who's detail you want to see: ");
            Doctor? foundDoctor = UnitOfWork.DoctorRepository.GetDoctorById(doctorToFindId);

            PrintEntityDetails(foundDoctor, $"Details for the doctor with Id {doctorToFindId}:", "No Doctor with that ID was found");
        }

        //This method gets all the patients in the patient table and then print them out in a table format
        void PrintAllPatients()
        {
            Console.Clear();
            ConsoleService.PrintInCenter("All Patients");
            UnitOfWork.PatientRepository.GetAllPatients().PrintEntitiesAsTable("No patients registered");
        }

        //This method gets an Id from the user and then tries to find a patient with the matching id and then calls a function that will either print out the found patient or will print out an error message if no patient was found
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

            (string fullName, string email, string phoneNumber, string address, string password) = GetNewUserDetails();

            //Creating a new patient based off of the recieved user inputs so that a new patient with the same details can be inserted into the database
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

            (string fullName, string email, string phoneNumber, string address, string password) = GetNewUserDetails();

            //Creating a new doctor based off of the recieved user inputs so that a new doctor with the same details can be inserted into the database
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

        //This function is being used to just get a new user's details so they can be used to create a new user as this function prevents code repetition between the logic for creating a patient or a doctor 
        (string, string, string, string, string) GetNewUserDetails()
        {
            string fullName = ConsoleService.GetFullNameFromUser();
            string email = ConsoleService.GetEmailFromUser();
            string phoneNumber = ConsoleService.GetPhoneNumberFromUser();
            string address = ConsoleService.GetAddressFromUser();
            string password = ConsoleService.GetPasswordFromUser();

            return (fullName, email, phoneNumber, address, password);
        }
    }
}
