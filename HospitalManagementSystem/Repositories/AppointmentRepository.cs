using ApplicationDotnetAssignment1.Contexts;
using ApplicationDotnetAssignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Repositories
{
    public class AppointmentRepository : Repository<Appointment>
    {
        public AppointmentRepository(HospitalSystemContext context) : base(context) 
        { 
        }

        //This function searches the Appointment table and then returns the first result or returns nothing if no results were found 
        public Appointment? GetAppointmentById(int id)
        {
            return base.GetAll().Where(a => a.Id == id).FirstOrDefault();
        }

        //This is a wrapper function that gets all the Appointments stored in the Appointment table
        public List<Appointment> GetAllAppointments()
        {
            return base.GetAll();
        }

        //This is a wrapper function that takes in a delegate type that is then passed into the base function which then gets all the Appointments that meet that condition specified by the predicate
        public List<Appointment> FindAppointments(Func<Appointment, bool> predicate)
        {
            return base.Find(predicate).ToList();
        }

        //This is a wrapper function that adds the passed Appointment into the Appointment table  
        public void AddAppointment(Appointment appointmentToAdd)
        {
            base.Add(appointmentToAdd);
        }
    }
}
