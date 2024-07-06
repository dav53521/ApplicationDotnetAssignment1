using ApplicationDotnetAssignment1.Contexts;
using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Repositories
{
    public class UserRepository : IUserRepository
    {
        private HospitalUserContext CurrentUserContext { get; set; }

        public UserRepository(HospitalUserContext currentUserContext) 
        {
            CurrentUserContext = currentUserContext;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return CurrentUserContext.Users;
        }

        public void AddNewUser()
        {
            throw new NotImplementedException();
        }

        public void RemoveUser()
        {
            throw new NotImplementedException();
        }  
    }
}
