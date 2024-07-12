using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Services.Interfaces
{
    public interface IUserService<T>
    {
        public abstract void PrintMainMenu();

        public void Logout();

        public void Exit();
    }
}
