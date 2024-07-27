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

        public void PrintEntitiesAsTable(IEnumerable<IPrintableAsTable> listOfEntities, string noEntitiesMessage)
        {
            if (!listOfEntities.IsNullOrEmpty())
            {
                Console.WriteLine(listOfEntities.First().TableHeader); //This is because the table header is stored on the instance of an entity
                ConsoleService.PrintSeperator();
                foreach (IPrintableAsTable entity in listOfEntities)
                {
                    Console.WriteLine(entity.TableRow);
                }
            }
            else
            {
                Console.WriteLine(noEntitiesMessage);
            }
        }

        public void PrintEntitiesAsTable(IEnumerable<IPrintableAsTable> relatedEntitiesToPrint, string successMessage, string noEntitiesMessage)
        {
            if(!relatedEntitiesToPrint.IsNullOrEmpty())
            {
                Console.WriteLine(successMessage);
                Console.WriteLine(); //This is being used to create a bit of space between the table and the success message so the screen feels less condensed

                Console.WriteLine(relatedEntitiesToPrint.FirstOrDefault()?.TableHeader);
                ConsoleService.PrintSeperator();
                foreach (IPrintableAsTable item in relatedEntitiesToPrint)
                {
                    Console.WriteLine(item.TableRow);
                }
            }
            else
            {
                Console.WriteLine(noEntitiesMessage);
            }
        }
    }
}
