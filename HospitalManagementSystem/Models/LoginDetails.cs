using ApplicationDotnetAssignment1.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Models
{
    public class LoginDetails : ILoginDetails
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
