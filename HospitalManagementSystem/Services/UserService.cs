using ApplicationDotnetAssignment1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Services
{
    public abstract class UserService<T> : IUserService
    {
        private protected T RepositoryToUse { get; set; }

        public UserService(T RepositoryToUse)
        {
            this.RepositoryToUse = RepositoryToUse;
        }

        public abstract void PrintMainMenu();

        public void Logout()
        {
        }

        public void Exit()
        {
        }
    }
}
