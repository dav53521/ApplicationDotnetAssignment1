using ApplicationDotnetAssignment1.Contexts;
using ApplicationDotnetAssignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Repositories
{
    public class DoctorRepository : Repository<Doctor>
    {
        public DoctorRepository(HospitalSystemContext context) : base(context) 
        { 
        }
    }
}
