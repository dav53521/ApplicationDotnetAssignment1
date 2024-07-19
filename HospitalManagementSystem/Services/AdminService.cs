using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Services
{
    public class AdminService : UserService<Admin>
    {

        public AdminService(Admin loggedInUser, HospitalSystemUnitOfWork unitOfWork) : base(loggedInUser, unitOfWork)
        {
        }

        protected override void PrintMenuOptions()
        {
            Console.WriteLine(@"1. List all doctors
2. Check doctor details
3. List all patients
4. Check patient details
5. Add doctor
6. Add patient
7. Logout
8. Exit
");
        }

        protected override void GetUserOptionChoice()
        {
            int userChoice = ConsoleService.GetIntegerFromUser("Please select an option: ", "To select an option please input a number");
            while (true)
            {
                switch (userChoice)
                {
                    case 1:
                        return;
                    case 2:
                        return;
                    case 3:
                        return;
                    case 4:
                        return;
                    case 5:
                        return;
                    case 6:
                        return;
                    case 7:
                        isLoggedIn = false;
                        return;
                    case 8:
                        Exit();
                        break;
                }
            }
        }
    }
}
