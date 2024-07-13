using ApplicationDotnetAssignment1.Helpers;
using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Services
{
    public class DoctorService : UserService<Doctor>
    {
        public DoctorService(Doctor loggedInDoctor, HospitalSystemUnitOfWork unitOfWork) : base(loggedInDoctor, unitOfWork)
        {
        }

        protected override void PrintMenuOptions()
        {
            ((RegisterableUser)LoggedInUser).PrintAsRow();
            Console.WriteLine(@"1. List Patient Details
2. List my doctor details
3. List all appointments
4. Book appointments
5. Exit to login
6. Exit System
");
        }

        protected override void GetUserOptionChoice()
        {
            int userChoice = ConsoleHelper.GetIntegerFromUser("Please select an option: ", "To select an option please input a number");
            while (true)
            {
                switch(userChoice)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        Logout();
                        break;
                    case 6:
                        Exit();
                        break;
                }
            }
        }
    }
}
