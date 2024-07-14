using ApplicationDotnetAssignment1.Helpers;
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
            while (true)
            {
                string menuTitle = $"{LoggedInUser.GetType().Name} Menu";
                Console.Clear();
                Console.SetCursorPosition((Console.WindowWidth / 2) - menuTitle.Length, Console.CursorTop);
                Console.WriteLine(menuTitle);
                Console.WriteLine($"Welcome to the DOTNET Hospital Management System {LoggedInUser.Name.ToString()}\n");
                Console.WriteLine("Please choose an option:");

                PrintMenuOptions();
                GetUserOptionChoice();
            }
        }

        protected abstract void PrintMenuOptions();

        protected abstract void GetUserOptionChoice();

        protected void Logout()
        {
            LoginService loginService = new LoginService();
            Console.Clear();
            loginService.Login(UnitOfWork);
        }

        protected void Exit()
        {
            Console.WriteLine("Goodbye");
            Thread.Sleep(500);
            UnitOfWork.UserRepository.Save();
            Environment.Exit(0);
        }
    }
}
