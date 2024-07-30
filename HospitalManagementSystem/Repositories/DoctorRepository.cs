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

        //This function searches the doctor table and then returns the first result or returns nothing if no results were found 
        public Doctor? GetDoctorById(int id)
        {
            return base.GetAll().Where(d => d.Id == id).FirstOrDefault();
        }

        //This is a wrapper function that gets all the doctors stored in the doctor table
        public List<Doctor> GetAllDoctors()
        {
            return base.GetAll();
        }

        //This is a wrapper function that takes in a delegate type that is then passed into the base function which then gets all the doctors that meet that condition specified by the predicate
        public List<Doctor> FindDoctors(Func<Doctor, bool> predicate)
        {
            return base.Find(predicate);
        }

        //This is a wrapper function that adds the passed doctor into the doctor table  
        public void AddDoctor(Doctor doctorToAdd)
        {
            base.Add(doctorToAdd);
        }
    }
}
