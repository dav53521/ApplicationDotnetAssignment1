using ApplicationDotnetAssignment1.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Services.Interfaces
{
    public interface ILoginService
    {
        public void Login(int inputtedId, string password, HospitalSystemContext contextManager);
    }
}
