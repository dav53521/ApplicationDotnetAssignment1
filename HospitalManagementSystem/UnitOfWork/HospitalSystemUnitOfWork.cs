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

        public AdminRepository AppointmentRepository
        {
            get
            {
                if(appointmentRepository == null)
                {
                    appointmentRepository = new AdminRepository(hospitalSystemContext);
                }

                return appointmentRepository;
            }
        }

        AdminRepository? appointmentRepository;

        public DoctorRepository DoctorRepository
        {
            get
            {
                if (doctorRepository == null)
                {
                    doctorRepository = new DoctorRepository(hospitalSystemContext);
                }

                return doctorRepository;
            }
        }

        DoctorRepository? doctorRepository;

        public PatientRepository PatientRepository
        {
            get
            {
                if (patientRepository == null)
                {
                    patientRepository = new PatientRepository(hospitalSystemContext);
                }

                return patientRepository;
            }
        }

        PatientRepository? patientRepository;

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

        public void Save()
        {
            hospitalSystemContext.SaveChanges();
        }
    }
}
