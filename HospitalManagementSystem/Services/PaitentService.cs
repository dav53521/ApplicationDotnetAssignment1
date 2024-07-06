using ApplicationDotnetAssignment1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Services
{
    public class PaitentService : UserService<PaitentRepository>
    {
        PaitentService(PaitentRepository repository)
        {
            Repository = repository;
        }

        public override void PrintMainMenu()
        {
            Console.WriteLine();
        }
    }
}
