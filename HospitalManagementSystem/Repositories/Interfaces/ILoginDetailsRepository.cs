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
        public IEnumerable<LoginDetails> GetAllLogins();
        public IEnumerable<LoginDetails> GetLoginsByInputtedFilter(Func<LoginDetails, bool> filter);
    }
}
