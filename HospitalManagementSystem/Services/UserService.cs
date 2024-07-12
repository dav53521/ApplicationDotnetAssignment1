using ApplicationDotnetAssignment1.Contexts;
using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.Services.Interfaces;
using ApplicationDotnetAssignment1.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public virtual void PrintMainMenu()
        {
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth) / 2, Console.CursorTop);
            Console.WriteLine($"{LoggedInUser.GetType().Name} Menu");
            Console.WriteLine($"Welcome to the hospital service system {LoggedInUser.Name.ToString()}\n");
        }

        public void PrintUserList()
        {
            throw new NotImplementedException();
        }

        public void PrintListOfUsers()
        {
            throw new NotImplementedException();
        }

        public void PrintDetails()
        {
            throw new NotImplementedException(); 
        }

        public void Logout()
        {
            LoginService loginService = new LoginService();
            Console.Clear();
            loginService.Login(UnitOfWork);
        }

        public void Exit()
        {
            Environment.Exit(0);
        }

        public static List<User> GetUsers(HospitalSystemContext context) 
        {
            List<User> users = new List<User>();
            https://stackoverflow.com/questions/4493858/elegant-way-to-combine-multiple-collections-of-elements
            users.Concat(context.Doctors).Concat(context.Patients).Concat(context.Admins);
            return users;
        }
    }
}
