using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.Services.Interfaces;
using ApplicationDotnetAssignment1.UnitOfWork;
using ApplicationDotnetAssignment1.UnitOfWork.Interface;

namespace ApplicationDotnetAssignment1.Services
{
    public abstract class UserService<T> : IUserService<T> where T : User
    {
        protected T LoggedInUser { get; }
        protected IHospitalSystemUnitOfWork UnitOfWork { get; }
        protected bool isLoggedIn = true;
        protected IConsoleService ConsoleService { get; }

        //This constructor is being used for dependency injecting the unit of work and console service so coupling is reduced and also is used to store the logged in user so the program can keep track of who is logged in for the current session
        public UserService(T loggedInUser, IHospitalSystemUnitOfWork unitOfWork, IConsoleService consoleService)
        {
            LoggedInUser = loggedInUser;
            UnitOfWork = unitOfWork;
            ConsoleService = consoleService;
        }

        public void OpenMainMenu()
        {
            while (isLoggedIn)
            {
                //The reason why base type is being used to get the user's role is because I'm using proxy lazy loading which means that a proxy is being used which means that to use the type as the role I need to get the base type as the LoggedInUser's actual type will be something like `AdminProxy`
                string menuTitle = $"{LoggedInUser.GetType().BaseType?.Name} Menu";
                Console.Clear();
                ConsoleService.PrintInCenter(menuTitle);
                Console.WriteLine($"Welcome to the DOTNET Hospital Management System {LoggedInUser.Name.ToString()}\n");
                Console.WriteLine("Please choose an option:");

                PrintMenuOptions();
                GetUserOptionChoice();

                if(isLoggedIn) //This is so that we can automatically bring back the login screen while also reducing code as there's no need for almost every single method to have code to wait for a user's input to return to the main screen as that will lead to a violation of DRY principles
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
            UnitOfWork.Save(); //Doing a save just to ensure that no data loss occurs before termination
            Environment.Exit(0);
        }

        protected void PrintLoggedInUserDetails()
        {
            Console.Clear();
            ConsoleService.PrintInCenter("My Details");
            Console.WriteLine(LoggedInUser.ToString());
        }

        protected void PrintEntityDetails<TEntityToPrint>(TEntityToPrint? entityToPrint, string successMessage, string noEntityMessage)
        {
            if(entityToPrint != null)
            {
                Console.WriteLine(successMessage);
                Console.WriteLine();
                Console.WriteLine(entityToPrint.ToString());
            }
            else
            {
                Console.WriteLine(noEntityMessage);
            }
        }
    }
}
