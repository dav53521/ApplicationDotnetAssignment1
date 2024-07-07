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
    public class UserRepository : ILoginDetailsRepository
    {
        private HospitalSystemContext CurrentUserContext { get; set; }

        public UserRepository(HospitalSystemContext currentUserContext) 
        {
            CurrentUserContext = currentUserContext;
        }

        public IEnumerable<Users> GetAllLogins()
        {
            return CurrentUserContext.Users;
        }

        public IEnumerable<Users> GetLoginsByInputtedFilter(Func<Users, bool> filter)
        {
            return CurrentUserContext.Users.Where(filter);
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
