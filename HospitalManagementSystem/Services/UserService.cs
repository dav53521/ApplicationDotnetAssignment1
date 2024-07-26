using ApplicationDotnetAssignment1.ExtensionMethods;
using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.Models.Interface;
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
        protected IConsoleService ConsoleService { get; }

        public UserService(T loggedInUser, HospitalSystemUnitOfWork unitOfWork, IConsoleService consoleService)
        {
            LoggedInUser = loggedInUser;
            UnitOfWork = unitOfWork;
            ConsoleService = consoleService;
        }

        public virtual void OpenMainMenu()
        {
            while (isLoggedIn)
            {
                string menuTitle = $"{LoggedInUser.GetType().Name} Menu";
                Console.Clear();
                ConsoleService.PrintInCenter(menuTitle);
                Console.WriteLine($"Welcome to the DOTNET Hospital Management System {LoggedInUser.Name.ToString()}\n");
                Console.WriteLine("Please choose an option:");

                PrintMenuOptions();
                GetUserOptionChoice();
                ConsoleService.WaitForKeyPress();
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

        public void PrintRelatedEntitiesAsTable(IEnumerable<IPrintableAsTable> listOfEntities, string title)
        {
            ConsoleService.PrintInCenter(title);
            Console.WriteLine(listOfEntities.First().TableHeader);
            ConsoleService.PrintSeperator();

            foreach (Appointment item in listOfEntities)
            {
                Console.WriteLine(item.TableBody);
            }
        }

        public void PrintListOfEntityAsTable(List<IPrintableAsTable> test, string title, string successMessage)
        {
        }
    }
}
