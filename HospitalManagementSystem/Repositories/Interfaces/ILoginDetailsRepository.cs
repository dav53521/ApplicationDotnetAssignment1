using ApplicationDotnetAssignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Repositories.Interfaces
{
    public interface ILoginDetailsRepository
    {
        public IEnumerable<Users> GetAllLogins();
        public IEnumerable<Users> GetLoginsByInputtedFilter(Func<Users, bool> filter);
    }
}
