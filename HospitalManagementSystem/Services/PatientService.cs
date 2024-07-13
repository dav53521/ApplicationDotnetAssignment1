using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Services
{
    public class PatientService : UserService<Patient>
    {
        public PatientService(Patient loggedInUser, HospitalSystemUnitOfWork unitOfWork) : base(loggedInUser, unitOfWork)
        {
        }

        public override void OpenMainMenu()
        {
            base.OpenMainMenu();
        }
    }
}
