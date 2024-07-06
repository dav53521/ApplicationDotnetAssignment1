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
        UserRepository repository = new UserRepository(currentContext);
        UserService userService = new UserService(repository);
        LoginService loginService = new LoginService(userService);

        Console.SetCursorPosition((Console.WindowWidth) / 2, Console.CursorTop); //This line is being used to place the "Login Please" text 
        Console.WriteLine("Login");
        Console.WriteLine("Please Enter Your Login Details Below:");
    }
}
