using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        [Required]
        public int PatientId { get; set; }
        public Patient? Patient { get; set; }
        [Required]
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }

        public override string ToString()
        {
            //By using string formatting we're able to make it so that the elements are formatted in a way that makes them all line up so we're able to print doctors in a table like format as all columns will be of the same length
            //We're using the null forgiving operator `!` as the Doctor and Patient should not be blank as they're required meaning that it is not possible to create an appointment without them and if one does get created then the program should stop as something has gone wrong.
            return string.Format("{0,-30} | {1,-30} | {2}", Doctor!.Name, Patient!.Name, Description);
        }
    }
}
