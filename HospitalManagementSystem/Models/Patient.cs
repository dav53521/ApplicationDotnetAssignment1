using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Models
{
    public class Patient : RegisterableUser
    {
        public int? AssignedDoctorId { get; set; }
        public Doctor? AssignedDoctor { get; set; }
    }
}
