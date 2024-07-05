using ApplicationDotnetAssignment1.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Models
{
    public class Doctor: IDoctor
    {
        public int Id { get; set; }

        public virtual User AssociatedUser { get; set; }
    }
}
