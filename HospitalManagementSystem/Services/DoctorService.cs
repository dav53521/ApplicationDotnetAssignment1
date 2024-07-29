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

        void PrintAssignedPatients()
        {
            Console.Clear();
            ConsoleService.PrintInCenter("Assigned Patients");
            LoggedInUser.Patients.PrintEntitiesAsTable("No patients assigned");
        }

        void PrintAssignedAppointments()
        {
            Console.Clear();
            ConsoleService.PrintInCenter("All Appointments");
            LoggedInUser.AssignedAppointments.PrintEntitiesAsTable("No assigned appointments found");
        }

        void PrintParticularPatientDetails()
        {
            Console.Clear();
            ConsoleService.PrintInCenter("Check Patient Details");

            int idOfUserToCheck = ConsoleService.GetIdFromUser("Enter the ID of the patient to check: ");
            Patient? foundPatient = UnitOfWork.PatientRepository.GetPatientById(idOfUserToCheck);

            PrintEntityDetails(foundPatient, $"Found patient with the Id of {idOfUserToCheck}:", "No Patient was found");
        }

        void PrintAppointmentsWithPatient()
        {
            Console.Clear();
            ConsoleService.PrintInCenter("Appointments With");
            int idOfUserToCheck = ConsoleService.GetIdFromUser("Enter the ID of the patient to check: ");
            UnitOfWork.AppointmentRepository.FindAppointments(a => a.PatientId == idOfUserToCheck).PrintEntitiesAsTable("No appointments with choosen patient found");
        }
    }
}
