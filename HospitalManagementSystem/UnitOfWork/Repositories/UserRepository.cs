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
        private HospitalSystemContext Context { get; set; }

        public UserRepository(HospitalSystemContext Context)
        {
            this.Context = Context;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return Context.Users;
        }

        public IEnumerable<User> GetUsersByCustomFilter(Func<User, bool> filter)
        {
            return Context.Users.Where(filter);
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
