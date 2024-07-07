using ApplicationDotnetAssignment1.Contexts;
using ApplicationDotnetAssignment1.Repositories;
using ApplicationDotnetAssignment1.Services;
using Microsoft.IdentityModel.Tokens;

namespace ApplicationDotnetAssignment1;
class Program
{
    static void Main(string[] args)
    {
        HospitalSystemContext currentContext = new HospitalSystemContext();
        UserRepository repository = new UserRepository(currentContext);
        LoginService loginService = new LoginService(repository);

        loginService.Login();
    }
}
