﻿using ApplicationDotnetAssignment1.Contexts;
using ApplicationDotnetAssignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Repositories
{
    public class PatientRepository : Repository<Patient>
    {
        public PatientRepository(HospitalSystemContext context) : base(context)
        {
        }
    }
}
