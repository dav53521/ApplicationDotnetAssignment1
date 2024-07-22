using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.Services.Interfaces;
using ApplicationDotnetAssignment1.UnitOfWork;
using ApplicationDotnetAssignment1.UnitOfWork.Interface;

namespace ApplicationDotnetAssignment1.Services
{
    public abstract class UserService<T> : IUserService<T> where T : User
    {
        protected T LoggedInUser { get; }
        protected HospitalSystemUnitOfWork UnitOfWork { get; }
        protected bool isLoggedIn = true;
        protected IConsoleService ConsoleHelper { get; }

        public UserService(T loggedInUser, HospitalSystemUnitOfWork unitOfWork, IConsoleService consoleService)
        {
            LoggedInUser = loggedInUser;
            UnitOfWork = unitOfWork;
            ConsoleHelper = consoleService;
        }

        public virtual void OpenMainMenu()
        {
            while (isLoggedIn)
            {
                string menuTitle = $"{LoggedInUser.GetType().Name} Menu";
                Console.Clear();
                ConsoleHelper.PrintInCenter(menuTitle);
                Console.WriteLine($"Welcome to the DOTNET Hospital Management System {LoggedInUser.Name.ToString()}\n");
                Console.WriteLine("Please choose an option:");

                PrintMenuOptions();
                GetUserOptionChoice();
            }
        }

        protected abstract void PrintMenuOptions();

        protected abstract void GetUserOptionChoice();

        protected void Exit()
        {
            Console.WriteLine("Goodbye");
            UnitOfWork.Save();
            Environment.Exit(0);
        }
    }
}
