using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int PatientId { get; set; }
        public Patient? Patient { get; set; }
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }

        public override string ToString()
        {
            return String.Format("{0,-30} | {1,-30} | {2}", Doctor.Name, Patient.Name, Description); ;
        }
    }
}
