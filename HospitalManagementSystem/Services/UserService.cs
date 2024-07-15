using ApplicationDotnetAssignment1.Helpers;
using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.Services.Interfaces;
using ApplicationDotnetAssignment1.UnitOfWork;

namespace ApplicationDotnetAssignment1.Services
{
    public class UserService
    {
        public virtual void OpenMainMenu(User user)
        {
            string menuTitle = $"{user.GetType().Name} Menu";
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth / 2) - menuTitle.Length, Console.CursorTop);
            Console.WriteLine(menuTitle);
            Console.WriteLine($"Welcome to the DOTNET Hospital Management System {user.Name.ToString()}\n");
            Console.WriteLine("Please choose an option:");
        }

        public void Logout(HospitalSystemUnitOfWork unitOfWork)
        {
            LoginService loginService = new LoginService();
            Console.Clear();
            loginService.Login(unitOfWork);
        }

        public void Exit(HospitalSystemUnitOfWork unitOfWork)
        {
            Console.WriteLine("Goodbye");
            Thread.Sleep(500);
            unitOfWork.UserRepository.Save();
            Environment.Exit(0);
        }
    }
}
