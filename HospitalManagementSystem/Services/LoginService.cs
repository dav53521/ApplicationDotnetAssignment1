using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.Services.Interfaces;
using ApplicationDotnetAssignment1.UnitOfWork.Interface;

namespace ApplicationDotnetAssignment1.Services
{
    public class LoginService : ILoginService
    {
        IHospitalSystemUnitOfWork _unitOfWork;
        IConsoleService _consoleService;

        public LoginService(IHospitalSystemUnitOfWork unitOfWork, IConsoleService consoleService)
        {
            _unitOfWork = unitOfWork;
            _consoleService = consoleService;
        }

        public void Login()
        {
            while (true) 
            {
                _consoleService.PrintInCenter("Login");
                Console.WriteLine("Please Enter Your Login Details Below:");

                User foundUser = GetLoggedInUser();
                OpenCorrectUserMenu(foundUser);
            }
        }

        User GetLoggedInUser()
        {
            //This loop is used to keep the user in this function until a valid user has been gotten so that the user cannot enter the login screen until a valid login has been provided
            while (true)
            {
                int userToFindId = _consoleService.GetIdFromUser("Id:");
                string userToFindPassword = _consoleService.GetMaskedInputFromUser("Password:");

                User? foundUser = _unitOfWork.UserRepository.FindUsers(user => user.Id == userToFindId && user.Password == userToFindPassword).FirstOrDefault();

                if(foundUser != null)
                {
                    return foundUser;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("User could not be found please try again");
                }
            }
        }

        void OpenCorrectUserMenu(User loggedInUser)
        {
            //This switch works because the pattern matching is done on the compile time type of the loggedInUser which means that the cast has no affect as that affects the run time type
            switch (loggedInUser)
            {
                case Admin loggedInAdmin:
                    var adminService = new AdminService(loggedInAdmin, _unitOfWork, _consoleService);
                    adminService.OpenMainMenu();
                    break;
                case Patient loggedInPatient:
                    var paitentService = new PatientService(loggedInPatient, _unitOfWork, _consoleService);
                    paitentService.OpenMainMenu();
                    break;
                case Doctor loggedInDoctor:
                    var doctorService = new DoctorService(loggedInDoctor, _unitOfWork, _consoleService);
                    doctorService.OpenMainMenu();
                    break;
            }

            Console.Clear();
        }
    }
}
