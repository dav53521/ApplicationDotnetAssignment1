using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Services
{
    public class AdminService : UserService<Admin>
    {

        public AdminService(Admin loggedInUser, HospitalSystemUnitOfWork unitOfWork) : base(loggedInUser, unitOfWork)
        {
        }

        public override void PrintMainMenu()
        {
            base.PrintMainMenu();
        }
    }
}
