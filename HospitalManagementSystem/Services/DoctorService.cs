using ApplicationDotnetAssignment1.ExtensionMethods;
using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.Services.Interfaces;
using ApplicationDotnetAssignment1.UnitOfWork.Interface;

namespace ApplicationDotnetAssignment1.Services
{
    public class DoctorService : UserService<Doctor>
    {
        public DoctorService(Doctor loggedInDoctor, IHospitalSystemUnitOfWork unitOfWork, IConsoleService consoleService) : base(loggedInDoctor, unitOfWork, consoleService)
        {
        }

        //This override is for the template method in the UserService as the Patient menu options are unique so the printing of the menu must be defined here
        protected override void PrintMenuOptions()
        {
            Console.WriteLine(@"1. List Doctor Details
2. List patients
3. List appointments
4. Check particular patient
5. List appointments with patient
6. Logout
7. Exit
");
        }

        protected override void GetUserOptionChoice()
        {
            int userChoice = ConsoleService.GetNumberFromUser("Please select an option: ", "To select an option please input a number");
            while (true)
            {
                switch(userChoice)
                {
                    case 1:
                        PrintLoggedInUserDetails();
                        return;
                    case 2:
                        PrintAssignedPatients();
                        return;
                    case 3:
                        PrintAssignedAppointments();
                        return;
                    case 4:
                        PrintParticularPatientDetails();
                        return;
                    case 5:
                        PrintAppointmentsWithPatient();
                        return;
                    case 6:
                        IsLoggedIn = false;
                        return;
                    case 7:
                        Exit();
                        return;
                    default:
                        userChoice = ConsoleService.GetNumberFromUser("Please select one of the displayed options: ", "To select an option please input a number");
                        break;
                }
            }
        }

        //This function is used to find all of the patients assigned to the current doctor in the database and then printing all of them out. Also if the doctor doesn't have any assigned patient a message telling the doctor that they have no assigned patients will be printed out
        void PrintAssignedPatients()
        {
            Console.Clear();
            ConsoleService.PrintInCenter("Assigned Patients");
            LoggedInUser.Patients.PrintEntitiesAsTable("No patients assigned");
        }

        //This function is used to find all of the appointments assigned to the current doctor in the database and will print all of them out in a table format. Also if the doctor doesn't have any assigned appointments then a message telling the doctor that they have no appointments will be printed out
        void PrintAssignedAppointments()
        {
            Console.Clear();
            ConsoleService.PrintInCenter("All Appointments");
            LoggedInUser.AssignedAppointments.PrintEntitiesAsTable("No assigned appointments found");
        }

        //This function prompts the doctor for a patient id and then tries to find a patient that meets the inputted id in the database. it will then print out the found patient if one is found or it will print out a message saying that no patient was found
        void PrintParticularPatientDetails()
        {
            Console.Clear();
            ConsoleService.PrintInCenter("Check Patient Details");

            int idOfUserToCheck = ConsoleService.GetIdFromUser("Enter the ID of the patient to check: ");
            Patient? foundPatient = UnitOfWork.PatientRepository.GetPatientById(idOfUserToCheck);

            PrintEntityDetails(foundPatient, $"Found patient with the Id of {idOfUserToCheck}:", "No Patient was found");
        }

        //This function is used to prompt the doctor for a patient id and then it tries to find all the apointments that the doctor have with the patient in the database. If appointments were found it will then print all of them out in a table otherwise it will print out a message telling the doctor that they have no assigned appointments with that patient
        void PrintAppointmentsWithPatient()
        {
            Console.Clear();
            ConsoleService.PrintInCenter("Appointments With");
            int idOfUserToCheck = ConsoleService.GetIdFromUser("Enter the ID of the patient to check: ");
            UnitOfWork.AppointmentRepository.FindAppointments(a => a.PatientId == idOfUserToCheck).PrintEntitiesAsTable("No appointments with choosen patient found");
        }
    }
}
