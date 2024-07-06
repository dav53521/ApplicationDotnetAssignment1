using ApplicationDotnetAssignment1.Repositories;
using ApplicationDotnetAssignment1.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
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

        public bool AreLoginDetailsCorrect(int inputtedId, string password) //This method is mostly being used to enforce single responisbility principle as a method that logins the user shouldn't be checking if the user's details are correct as that's not its job
        {
            //This function is bassicly getting the users from the UOW and then filtering the returned results and then returning if any rows has been found as if one has been found then a user has been found
            return currentRepository.GetAllUsers().Where(user => user.Id == inputtedId && user.Password == password).Any();
        }
    }
}
