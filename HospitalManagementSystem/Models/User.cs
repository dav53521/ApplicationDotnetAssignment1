using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Models
{
    //This class is being used for inheritance as all doctors,
    public abstract class User
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}
