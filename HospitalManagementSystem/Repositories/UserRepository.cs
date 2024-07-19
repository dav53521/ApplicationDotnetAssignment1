using ApplicationDotnetAssignment1.Contexts;
using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(HospitalSystemContext context) : base(context)
        {
        }

        public List<User> GetAllUsers()
        {
            //We are able to union the three tables together as we all have to do is upcast each table representation into parent class of user which allows for all admins, patients and doctors to be retrieved
            //The include in the unioning of the doctors and paitent ensures that the many relationships are loaded as they are lazy loaded meaning that they have to be specifically gotten via include
            return new List<User>().Union(context.Admins).Union(context.Doctors.Include(x => x.Patients).Include(x => x.AssignedAppointments)).Union(context.Patients.Include(x => x.BookedAppointments)).ToList();
        }

        public User? GetUserById(int id)
        {
            return GetAllUsers().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<User> FindUsers(Func<User, bool> predicate)
        {
            return GetAllUsers().Where(predicate).ToList();
        }
    }
}
