using ApplicationDotnetAssignment1.Contexts;
using ApplicationDotnetAssignment1.Repositories;
using ApplicationDotnetAssignment1.Services;
using Microsoft.IdentityModel.Tokens;

namespace ApplicationDotnetAssignment1;
class Program
{
    static void Main(string[] args)
    {
        HospitalUserContext currentContext = new HospitalUserContext();
        LoginDetailsRepository repository = new LoginDetailsRepository(currentContext);
        LoginService loginService = new LoginService(repository);

        loginService.Login();
    }
}
