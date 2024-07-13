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

    public static class RegisterableUserExtensions
    {
        public static void PrintAsRow(this RegisterableUser user)
        {
            //https://stackoverflow.com/questions/856845/how-to-best-way-to-draw-table-in-console-app-c
            //https://learn.microsoft.com/en-us/dotnet/standard/base-types/composite-formatting?redirectedfrom=MSDN
            Console.WriteLine("{0,-30} | {1,-30} | {2,-10} | {3}", user.Name, user.Email, user.PhoneNumber, user.Address);
        }
    }
}
