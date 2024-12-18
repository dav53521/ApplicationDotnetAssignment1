﻿using ApplicationDotnetAssignment1.Models.Interface;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationDotnetAssignment1.Models
{
    public class Patient : User, IPrintableAsTable
    {
        public int? AssignedDoctorId { get; set; }
        public virtual Doctor? AssignedDoctor { get; set; }
        public virtual List<Appointment> BookedAppointments { get; } = new List<Appointment>();

        public override string ToString()
        {
            //This to string adds onto the base type as it adds the assigned doctor to the user details as the patient's assigned doctor needs to be seen when showing hte details of a patient
            return base.ToString() + $@"
Assigned Doctor's Name: {AssignedDoctor?.Name ?? string.Empty}";
        }

        [NotMapped]
        public string EntityAsTableRow
        {
            get
            {
                //By using string formatting we're able to make it so that the elements are formatted in a way that makes them all line up so we're able to print doctors in a table like format as all columns will be of the same length
                //Further as the patient may not have a doctor we use a null cascade to print out an empty string and ensure that no null dereferencing occurs and also provide a way to tell the user that the paitent has no doctor
                return string.Format("{0,-20} | {1,-20} | {2,-30} | {3,-40} | {4,-10}", Name, AssignedDoctor?.Name ?? "", Email, Address, PhoneNumber);
            }
        }
    }
}
