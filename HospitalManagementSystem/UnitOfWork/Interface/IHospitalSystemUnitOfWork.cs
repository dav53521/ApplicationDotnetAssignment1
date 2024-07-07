using ApplicationDotnetAssignment1.UnitOfWork.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.UnitOfWork.Interface
{
    public interface IHospitalSystemUnitOfWork
    {
        public UserRepository UserRepository { get; }
    }
}
