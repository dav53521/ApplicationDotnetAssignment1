using ApplicationDotnetAssignment1.Models;

namespace ApplicationDotnetAssignment1.Services.Interfaces
{
    public interface IUserService<T> where T : User
    {
        public abstract void OpenMainMenu();
    }
}
