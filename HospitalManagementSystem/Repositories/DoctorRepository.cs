using ApplicationDotnetAssignment1.Contexts;
using ApplicationDotnetAssignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Repositories
{
    public class DoctorRepository : Repository<Doctor>
    {
        public DoctorRepository(HospitalSystemContext context) : base(context) 
        {
        }

        //This is a wrapper function that just calls the base function
        public Doctor? GetDoctorById(int id)
        {
            return base.GetById(id);
        }

        public List<Doctor> GetAllDoctors()
        {
            return base.GetAll();
        }

        public List<Doctor> FindDoctors(Func<Doctor, bool> predicate)
        {
            return base.Find(predicate);
        }

        public void AddDoctor(Doctor doctorToAdd)
        {
            base.Add(doctorToAdd);
        }
    }
}
