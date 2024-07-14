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

        public IEnumerable<User> GetAllUsers()
        {
            //We are able to union the three tables together as we all have to do is upcast each table representation into parent class of user which allows for all admins, patients and doctors to be retrieved
            return new List<User>().Union(context.Admins).Union(context.Doctors).Union(context.Patients);
        }

        public User? GetUserById(int id)
        {
            return GetAllUsers().Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<User> FindUsers(Func<User, bool> predicate)
        {
            return GetAllUsers().Where(predicate);
        }
    }
}
