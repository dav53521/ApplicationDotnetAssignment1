using ApplicationDotnetAssignment1.Contexts;
using ApplicationDotnetAssignment1.Services;
using ApplicationDotnetAssignment1.UnitOfWork;

namespace ApplicationDotnetAssignment1;
class Program
{
    static void Main(string[] args)
    {
        var context = new HospitalSystemContext();
        HospitalSystemUnitOfWork unitOfWork = new HospitalSystemUnitOfWork(context);
        LoginService loginService = new LoginService();

        loginService.Login(unitOfWork);
    }
}
