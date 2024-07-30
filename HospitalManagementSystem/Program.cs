using ApplicationDotnetAssignment1.Contexts;
using ApplicationDotnetAssignment1.Services;
using ApplicationDotnetAssignment1.UnitOfWork;

namespace ApplicationDotnetAssignment1;
class Program
{
    static void Main(string[] args)
    {
        HospitalSystemUnitOfWork unitOfWork = new HospitalSystemUnitOfWork(new HospitalSystemContext());
        //Below we're beginning the login so the user can login into their desired account
        new LoginService(unitOfWork, new ConsoleService()).Login();
    }
}
