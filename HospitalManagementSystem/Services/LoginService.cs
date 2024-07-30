using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.Services.Interfaces;
using ApplicationDotnetAssignment1.UnitOfWork.Interface;

namespace ApplicationDotnetAssignment1.Services
{
    public class LoginService : ILoginService
    {
        IHospitalSystemUnitOfWork _UnitOfWork;
        IConsoleService _ConsoleService;

        public LoginService(IHospitalSystemUnitOfWork unitOfWork, IConsoleService consoleService)
        {
            _UnitOfWork = unitOfWork;
            _ConsoleService = consoleService;
        }

        public void Login()
        {
            //This loop allows removes the need to call this function every time a user logs out as when the user logs out this function will iterate and then prompt the user to login again which removes uncessary insertions into the call stack
            while (true) 
            {
                _ConsoleService.PrintInCenter("Login");
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
                int userToFindId = _ConsoleService.GetIdFromUser("Id:");
                string userToFindPassword = _ConsoleService.GetPasswordFromUser();

                User? foundUser = _UnitOfWork.UserRepository.FindUsers(user => user.Id == userToFindId && user.Password == userToFindPassword).FirstOrDefault();

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
            //This switch works because the switch pattern matching is done on the compile time type of the loggedInUser, which means that the cast has no affect as the cast only changes the type during run time
            switch (loggedInUser)
            {
                case Admin loggedInAdmin:
                    var adminService = new AdminService(loggedInAdmin, _UnitOfWork, _ConsoleService);
                    adminService.OpenMainMenu();
                    break;
                case Patient loggedInPatient:
                    var paitentService = new PatientService(loggedInPatient, _UnitOfWork, _ConsoleService);
                    paitentService.OpenMainMenu();
                    break;
                case Doctor loggedInDoctor:
                    var doctorService = new DoctorService(loggedInDoctor, _UnitOfWork, _ConsoleService);
                    doctorService.OpenMainMenu();
                    break;
            }

            Console.Clear();
        }
    }
}
