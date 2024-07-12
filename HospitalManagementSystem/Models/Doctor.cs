using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Models
{
    public class Doctor : RegisterableUser
    {
        public ICollection<Patient> Patients { get; } = new List<Patient>(); 
    }
}
