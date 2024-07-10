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
        private protected HospitalSystemUnitOfWork unitOfWork;

        public UserService()
        {
            this.unitOfWork = unitOfWork;
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
            unitOfWork.Save();
            LoginService loginService = new LoginService();
            Console.Clear();
            //loginService.Login("", "");
        }

        public void Exit()
        {
            unitOfWork.Save();
            Environment.Exit(0);
        }

        public static List<User> GetUsers(HospitalSystemContext context) 
        {
            return null;
        }
    }
}
