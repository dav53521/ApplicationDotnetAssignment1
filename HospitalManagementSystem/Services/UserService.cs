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
    public abstract class UserService : IUserService
    {
        public UserService()
        {
        }

        public abstract void PrintMainMenu();

        public void PrintUserList()
        {
            throw new NotImplementedException();
        }

        public void PrintListOfUsers<T>()
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
            //loginService.Login("", "");
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
