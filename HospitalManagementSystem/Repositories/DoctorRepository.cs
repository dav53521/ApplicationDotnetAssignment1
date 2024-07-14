﻿using ApplicationDotnetAssignment1.Contexts;
using ApplicationDotnetAssignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Repositories
{
    public class DoctorRepository : Repository<Doctor>
    {
        public DoctorRepository(HospitalSystemContext context) : base(context) 
        {
        }

        public Doctor? GetDoctorById(int id)
        {
            return base.GetById(id);
        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            return base.GetAll();
        }

        public IEnumerable<Doctor> FindDoctors(Func<Doctor, bool> predicate)
        {
            return base.Find(predicate);
        }

        public void AddDoctor(Doctor patient)
        {
            base.Add(patient);
        }

        public void RemoveDoctor(Doctor patient)
        {
            base.Remove(patient);
        }

        public void UpdateDoctor(Doctor patient)
        {
            base.Update(patient);
        }
    }
}
