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
            //We are able to union the three tables together as we all have to do is upcast the tables into their parent type
            return new List<User>().Union(context.Admins).Union(context.Doctors).Union(context.Patients);
        }

        public new User? GetById(int id)
        {
            return GetAllUsers().Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
