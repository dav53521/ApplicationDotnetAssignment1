using ApplicationDotnetAssignment1.Models.Interface;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Models
{
    public class Doctor : User, IPrintableAsTable
    {
        public virtual List<Patient> Patients { get; } = new List<Patient>();
        public virtual List<Appointment> AssignedAppointments { get; } = new List<Appointment>();

        [NotMapped]
        public string TableHeader
        {
            get 
            {
                return string.Format("{0,-20} | {1,-30} | {2,-30} | {3,-10}", "Name", "Email Address", "Address", "Phone");
            }
        }

        [NotMapped]
        public string TableRow
        {
            get
            {
                // By using string formatting we're able to make it so that the elements are formatted in a way that makes them all line up so we're able to print doctors in a table like format as all columns will be of the same length
                return string.Format("{0,-20} | {1,-30} | {2,-30} | {3,-10}", Name, Email, Address, PhoneNumber);
            }
        }
    }
}
