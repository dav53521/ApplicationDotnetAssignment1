using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Models.Interfaces
{
    public interface ILoginDetails
    {
        int Id { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
