using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Services
{
    public class PaitentService : UserService
    {
        public PaitentService(HospitalSystemUnitOfWork unitOfWork, User loggedInUser) : base(unitOfWork, loggedInUser)
        {
        }

        public override void PrintMainMenu()
        {
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth) / 2, Console.CursorTop);
            Console.WriteLine("Paitent Menu");
            Console.WriteLine($"Welcome to the hospital service system {LoggedInUser.Name}\n");
        }
    }
}
