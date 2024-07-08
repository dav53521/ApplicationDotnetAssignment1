using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Models.Interfaces
{
    public interface IPaitentDetails
    {
        public int PaitentUserId { get; set; }
        public int AssignedDoctorId { get; set; }
    }
}
