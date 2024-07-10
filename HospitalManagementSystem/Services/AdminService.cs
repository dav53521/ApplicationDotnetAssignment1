using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Services
{
    public class AdminService : UserService
    {
        public AdminService(Admin loggedInUser)
        {
        }

        public override void PrintMainMenu()
        {
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth) / 2, Console.CursorTop);
            Console.WriteLine("Admin Menu");
            Console.WriteLine($"Welcome to the hospital service system\n");
        }
    }
}
