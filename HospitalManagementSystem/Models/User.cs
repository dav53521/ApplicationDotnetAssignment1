using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Models
{
    //This class is used to represent all users as all user roles will inherit from this class as these fields are required for all users
    public class User
    {
        public int Id { get; set; }
        public string Password { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(30)]
        public string Email { get; set; }
        [StringLength(10)]
        public string PhoneNumber { get; set; }
        [StringLength(30)]
        public string Address { get; set; }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
