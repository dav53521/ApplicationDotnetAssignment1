using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Models
{
    //This class will be inherited by users that are registerable e.g. patients and doctors as they need more information compared to a non-registerable user like an Admin
    public class RegisterableUser : User
    {
        [StringLength(30)]
        public string Email { get; set; }
        [StringLength(10)]
        public string PhoneNumber { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
    }
}
