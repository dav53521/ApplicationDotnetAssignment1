using ApplicationDotnetAssignment1.Contexts;
using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.UnitOfWork.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.UnitOfWork.Repositories
{
    public class UserRepository : IUserRepository
    {
        private HospitalSystemContext CurrentContext { get; set; }

        public UserRepository(HospitalSystemContext currentContext)
        {
            CurrentContext = currentContext;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return CurrentContext.Users;
        }

        public IEnumerable<User> GetUsersByCustomFilter(Func<User, bool> filter)
        {
            return CurrentContext.Users.Where(filter);
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
