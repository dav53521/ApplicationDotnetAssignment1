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
    public class PatientRepository : Repository<Patient>
    {
        public PatientRepository(HospitalSystemContext context) : base(context)
        {
        }

        //This function searches the patient table and then returns the first result or returns nothing if no results were found 
        public Patient? GetPatientById(int id)
        {
            return base.GetAll().Where(p => p.Id == id).FirstOrDefault();
        }

        //This is a wrapper function that gets all the patients stored in the patient table
        public List<Patient> GetAllPatients()
        {
            return base.GetAll();
        }

        //This is a wrapper function that takes in a delegate type that is then passed into the base function which then gets all the patients that meet that condition specified by the predicate
        public List<Patient> FindPatients(Func<Patient, bool> predicate)
        {
            return base.Find(predicate);
        }

        //This is a wrapper function that adds the passed patient into the patient table 
        public void AddPatient(Patient patient)
        {
            base.Add(patient);
        }

        //This is a wrapper function that updates the passed in patient in the patient table by updating it to match the passed in patient
        public void UpdatePatient(Patient patient)
        {
            base.Update(patient); 
        }
    }
}
