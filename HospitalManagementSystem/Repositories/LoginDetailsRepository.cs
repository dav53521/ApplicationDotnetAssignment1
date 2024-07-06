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
    public class LoginDetailsRepository : ILoginDetailsRepository
    {
        private HospitalUserContext CurrentUserContext { get; set; }

        public LoginDetailsRepository(HospitalUserContext currentUserContext) 
        {
            CurrentUserContext = currentUserContext;
        }

        public IEnumerable<LoginDetails> GetAllLogins()
        {
            return CurrentUserContext.Users;
        }

        public IEnumerable<LoginDetails> GetLoginsByInputtedFilter(Func<LoginDetails, bool> filter)
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
