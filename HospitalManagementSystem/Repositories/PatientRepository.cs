﻿using ApplicationDotnetAssignment1.Contexts;
using ApplicationDotnetAssignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Repositories
{
    public class PatientRepository : Repository<Patient>
    {
        public PatientRepository(HospitalSystemContext context) : base(context)
        {
        }

        public Patient? GetPatientById(int id)
        {
            return base.GetById(id);
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return base.GetAll();
        }

        public IEnumerable<Patient> FindPatients(Func<Patient, bool> predicate)
        {
            return base.Find(predicate);
        }

        public void AddPatient(Patient patient)
        {
            base.Add(patient);
        }

        public void RemovePatient(Patient patient)
        {
            base.Remove(patient);
        }

        public void UpdatePatient(Patient patient)
        {
            base.Update(patient); 
        }
    }
}