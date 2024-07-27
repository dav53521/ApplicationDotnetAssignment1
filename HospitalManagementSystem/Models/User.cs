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
        public required string Password { get; set; }
        [MaxLength(30)]
        public required string Name { get; set; }
        [MaxLength(30)]
        public required string Email { get; set; }
        [StringLength(10)]
        public required string PhoneNumber { get; set; }
        [MaxLength(30)]
        public required string Address { get; set; }

        public override string ToString()
        {
            return @$"{Name}'s user details:

User Id: {Id}
Full Name: {Name}
Phone Number: {PhoneNumber}
Email: {Email}
Address: {Address}";
        }
    }
}
