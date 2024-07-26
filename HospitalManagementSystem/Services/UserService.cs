using ApplicationDotnetAssignment1.ExtensionMethods;
using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.Models.Interface;
using ApplicationDotnetAssignment1.Services.Interfaces;
using ApplicationDotnetAssignment1.UnitOfWork;
using ApplicationDotnetAssignment1.UnitOfWork.Interface;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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

                if(isLoggedIn) //This is so that we can automatically bring back the login screen while also reducing code as there's no need for almost every single method to have "ConsoleService.WaitForKeyPress()"
                {
                    ConsoleService.WaitForKeyPress();
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

        public void PrintEntitiesAsTable(IEnumerable<IPrintableAsTable> listOfEntities)
        {
            Console.WriteLine(); //This is being used to create a bit of space between the table and the header so the screen feels less crowded
            Console.WriteLine(listOfEntities.FirstOrDefault()?.TableHeader);
            ConsoleService.PrintSeperator();

            foreach (IPrintableAsTable item in listOfEntities)
            {
                Console.WriteLine(item.TableBody);
            }
        }

        public void PrintEntitiesAsTable(IEnumerable<IPrintableAsTable> relatedEntitiesToPrint, string successMessage)
        {
            Console.WriteLine(successMessage);
            Console.WriteLine(); //This is being used to create a bit of space between the table and the sucess message so the screen feels less crowded

            Console.WriteLine(relatedEntitiesToPrint.FirstOrDefault()?.TableHeader);
            ConsoleService.PrintSeperator();
            foreach(IPrintableAsTable item in relatedEntitiesToPrint)
            {
                Console.WriteLine(item.TableBody);
            }
        }
    }
}
