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
        protected bool IsLoggedIn = true;
        protected IConsoleService ConsoleService { get; }

        //This constructor is being used for dependency injecting the unit of work and console service so coupling is reduced and also is used to store the logged in user so the program can keep track of who is logged in for the current session
        public UserService(T loggedInUser, IHospitalSystemUnitOfWork unitOfWork, IConsoleService consoleService)
        {
            LoggedInUser = loggedInUser;
            UnitOfWork = unitOfWork;
            ConsoleService = consoleService;
        }

        //This method follows the template method design pattern as each user role follows a similar pattern for their main menu however, there are a few slight variations so by using this pattern the repeated code is shared whie the variations are defined by the child class
        public void OpenMainMenu()
        {
            while (IsLoggedIn)
            {
                //The reason why base type is being used to get the user's role is because I'm using proxy lazy loading which means that a proxy is being used which means that to use the type as the role I need to get the base type as the LoggedInUser's actual type will be something like `AdminProxy`
                string menuTitle = $"{LoggedInUser.GetType().BaseType?.Name} Menu";
                Console.Clear();
                ConsoleService.PrintInCenter(menuTitle);
                Console.WriteLine($"Welcome to the DOTNET Hospital Management System {LoggedInUser.Name.ToString()}\n");
                Console.WriteLine("Please choose an option:");

                PrintMenuOptions();
                GetUserOptionChoice();

                if (IsLoggedIn) //This is so that we can automatically bring back the login screen as when the user logs out they shouldn't need to press any keys before returning
                {
                    Console.WriteLine();
                    Console.WriteLine("Please press any key to return back to the main menu");
                    Console.ReadKey();
                }
            }
        }

        //This method should be implemented by the inheriting classes as they all have different menu options 
        protected abstract void PrintMenuOptions();

        //This method should be implemented by the inheriting class as they each have different number of options
        protected abstract void GetUserOptionChoice();

        protected void Exit()
        {
            Console.WriteLine("Goodbye");
            UnitOfWork.Save(); //Doing a save just to ensure that no data loss occurs before the program terminates
            Environment.Exit(0);
        }

        //This function is used to simplify the printing out of the logged in user's details as the logged in user should not be null when in a class that derives user service and also the "title" can be the same across all user roles.
        //So this function is used to help enforce DRY as it centerlises the code that prints out the logged in user as there is no need for it to be repeated across multiple services
        protected void PrintLoggedInUserDetails()
        {
            Console.Clear();
            ConsoleService.PrintInCenter("My Details");
            Console.WriteLine(LoggedInUser.ToString());
        }

        //This function is being used to centralise a common method to check if an entity is null and then print it out as this logic is used in all the services that inhert this class so centralising it here reduces repeated code
        protected void PrintEntityDetails<TEntityToPrint>(TEntityToPrint? entityToPrint, string successMessage, string noEntityMessage)
        {
            if(entityToPrint != null)
            {
                Console.WriteLine(successMessage);
                Console.WriteLine(); //Creating a new line here to create some space between the success message and the printing of the entity as I feel like it makes the screen look less crammed
                Console.WriteLine(entityToPrint.ToString());
            }
            else
            {
                Console.WriteLine(noEntityMessage);
            }
        }
    }
}
