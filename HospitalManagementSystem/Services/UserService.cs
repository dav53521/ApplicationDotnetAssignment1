using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.Models.Interface;
using ApplicationDotnetAssignment1.Services.Interfaces;
using ApplicationDotnetAssignment1.UnitOfWork;
using Microsoft.IdentityModel.Tokens;

namespace ApplicationDotnetAssignment1.Services
{
    public abstract class UserService<T> : IUserService<T> where T : User
    {
        protected T LoggedInUser { get; }
        protected HospitalSystemUnitOfWork UnitOfWork { get; }
        protected bool isLoggedIn = true;
        protected IConsoleService ConsoleService { get; }

        public UserService(T loggedInUser, HospitalSystemUnitOfWork unitOfWork, IConsoleService consoleService)
        {
            LoggedInUser = loggedInUser;
            UnitOfWork = unitOfWork;
            ConsoleService = consoleService;
        }

        public void OpenMainMenu()
        {
            while (isLoggedIn)
            {
                string menuTitle = $"{LoggedInUser.GetType().BaseType?.Name} Menu"; //We're getting the base type because I'm using lazy loading via proxies which means that a proxy that inherits the logged in user's role is used so I'm getting the user's role via the base class
                Console.Clear();
                ConsoleService.PrintInCenter(menuTitle);
                Console.WriteLine($"Welcome to the DOTNET Hospital Management System {LoggedInUser.Name.ToString()}\n");
                Console.WriteLine("Please choose an option:");

                PrintMenuOptions();
                GetUserOptionChoice();

                if(isLoggedIn) //This is so that we can automatically bring back the login screen while also reducing code as there's no need for almost every single method to have "ConsoleService.WaitForKeyPress()"
                {
                    Console.WriteLine();
                    Console.WriteLine("Please press any key to return back to the main menu");
                    Console.ReadKey();
                }
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

        protected void PrintLoggedInUserDetails()
        {
            Console.Clear();
            ConsoleService.PrintInCenter("My Details");
            Console.WriteLine(LoggedInUser.ToString());
        }

        protected void PrintEntity<TEntityToPrint>(TEntityToPrint? entityToPrint, string noEntityMessage)
        {
            if(entityToPrint != null)
            {
                Console.WriteLine(entityToPrint.ToString());
            }
            else
            {
                Console.WriteLine(noEntityMessage);
            }
        }
    }
}
