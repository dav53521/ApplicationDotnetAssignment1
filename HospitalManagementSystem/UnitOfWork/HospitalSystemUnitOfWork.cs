using ApplicationDotnetAssignment1.Contexts;
using ApplicationDotnetAssignment1.Repositories;
using ApplicationDotnetAssignment1.UnitOfWork.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.UnitOfWork
{
    public class HospitalSystemUnitOfWork : IHospitalSystemUnitOfWork
    {
        public HospitalSystemContext hospitalSystemContext;

        public HospitalSystemUnitOfWork(HospitalSystemContext context)
        {
            hospitalSystemContext = context;
        }

        public UserRepository UserRepository
        {
            get 
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(hospitalSystemContext);
                }

                return userRepository;
            }
        }

        UserRepository? userRepository;
    }
}
