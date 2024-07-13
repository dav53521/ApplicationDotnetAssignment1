using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.Services.Interfaces;
using ApplicationDotnetAssignment1.UnitOfWork;

namespace ApplicationDotnetAssignment1.Services
{
    public abstract class UserService<T> : IUserService<T> where T : User
    {
        protected T LoggedInUser { get; }
        protected HospitalSystemUnitOfWork UnitOfWork { get; }

        public UserService(T loggedInUser, HospitalSystemUnitOfWork unitOfWork)
        {
            this.LoggedInUser = loggedInUser;
            UnitOfWork = unitOfWork;
        }

        public virtual void OpenMainMenu()
        {
            string menuTitle = $"{LoggedInUser.GetType().Name} Menu";
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth / 2) - menuTitle.Length, Console.CursorTop);
            Console.WriteLine(menuTitle);
            Console.WriteLine($"Welcome to the DOTNET Hospital Management System {LoggedInUser.Name.ToString()}\n");
            Console.WriteLine("Please choose an option:");
        }

        public void Logout()
        {
            LoginService loginService = new LoginService();
            Console.Clear();
            loginService.Login(UnitOfWork);
        }

        public void Exit()
        {
            UnitOfWork.UserRepository.Save();
            Environment.Exit(0);
        }
    }
}
