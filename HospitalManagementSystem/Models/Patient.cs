using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Models
{
    public class Patient : User
    {
        public Doctor? AssignedDoctor { get; set; }
    }
}
