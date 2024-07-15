﻿using ApplicationDotnetAssignment1.Contexts;
using ApplicationDotnetAssignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Repositories
{
    public class AppointmentRepository : Repository<Appointment>
    {
        public AppointmentRepository(HospitalSystemContext context) : base(context) 
        { 
        }

        public Appointment? GetAppointmentById(int id)
        {
            return base.GetById(id);
        }

        public List<Appointment> GetAllAppointments()
        {
            return base.GetAll();
        }

        public List<Appointment> FindAppointments(Func<Appointment, bool> predicate)
        {
            return base.Find(predicate);
        }

        public void AddAppointment(Appointment patient)
        {
            base.Add(patient);
        }

        public void RemoveAppointment(Appointment patient)
        {
            base.Remove(patient);
        }

        public void UpdateAppointment(Appointment patient)
        {
            base.Update(patient);
        }
    }
}
