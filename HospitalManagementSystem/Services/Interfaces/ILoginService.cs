using ApplicationDotnetAssignment1.Contexts;
using ApplicationDotnetAssignment1.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Services.Interfaces
{
    public interface ILoginService
    {
        public void Login(HospitalSystemUnitOfWork unitOfWork);
    }
}
