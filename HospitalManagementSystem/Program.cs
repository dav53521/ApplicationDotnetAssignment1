using ApplicationDotnetAssignment1.Contexts;
using ApplicationDotnetAssignment1.Services;
using ApplicationDotnetAssignment1.UnitOfWork;

namespace ApplicationDotnetAssignment1;
class Program
{
    static void Main(string[] args)
    {
        HospitalSystemUnitOfWork unitOfWork = new HospitalSystemUnitOfWork(new HospitalSystemContext());
        new LoginService(unitOfWork, new ConsoleService()).Login();
    }
}
