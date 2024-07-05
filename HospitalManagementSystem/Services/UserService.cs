using ApplicationDotnetAssignment1.Repositories;
using ApplicationDotnetAssignment1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Services
{
    public class UserService: IUserInterface
    {
        UserRepository currentRepository;

        public UserService(UserRepository userRepository) 
        {
            currentRepository = userRepository;
        }

        public bool IsInputtedUserDetailsCorrect(int userId, string password)
        {
            var foundUsers = currentRepository.GetUsers().Where(user => user.Id == userId && user.Password == password);

            return foundUsers.Any();
        }
    }
}
