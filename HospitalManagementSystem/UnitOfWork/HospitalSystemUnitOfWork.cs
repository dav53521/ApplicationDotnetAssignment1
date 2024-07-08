using ApplicationDotnetAssignment1.Contexts;
using ApplicationDotnetAssignment1.UnitOfWork.Interface;
using ApplicationDotnetAssignment1.UnitOfWork.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.UnitOfWork
{
    public class HospitalSystemUnitOfWork : IHospitalSystemUnitOfWork
    {
        HospitalSystemContext systemContext = new HospitalSystemContext();
        UserRepository? userRepository;

        public UserRepository UserRepository 
        { 
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(systemContext);
                }

                return userRepository;
            } 
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
