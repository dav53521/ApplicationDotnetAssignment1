using ApplicationDotnetAssignment1.Contexts;
using ApplicationDotnetAssignment1.Repositories;
using ApplicationDotnetAssignment1.UnitOfWork.Interface;

namespace ApplicationDotnetAssignment1.UnitOfWork
{
    public class HospitalSystemUnitOfWork : IHospitalSystemUnitOfWork
    {
        HospitalSystemContext _hospitalSystemContext;

        public HospitalSystemUnitOfWork(HospitalSystemContext context)
        {
            //Getting the passed in context and storing it so that it can be passed into each repository so they can access the database
            _hospitalSystemContext = context;
        }

        public AppointmentRepository AppointmentRepository
        {
            get
            {
                //This getter will be used to either create or get the existing Appointment repository depending on whether it exists or not which means that the user repository is stored and created in the unit of work
                if (appointmentRepository == null)
                {
                    appointmentRepository = new AppointmentRepository(_hospitalSystemContext);
                }

                return appointmentRepository;
            }
        }

        AppointmentRepository? appointmentRepository;

        public DoctorRepository DoctorRepository
        {
            //This getter will be used to either create or get the existing Doctor repository depending on whether it exists or not which means that the user repository is stored and created in the unit of work
            get
            {
                if (doctorRepository == null)
                {
                    doctorRepository = new DoctorRepository(_hospitalSystemContext);
                }

                return doctorRepository;
            }
        }

        DoctorRepository? doctorRepository;

        public PatientRepository PatientRepository
        {
            //This getter will be used to either create or get the existing Patient repository depending on whether it exists or not which means that the user repository is stored and created in the unit of work
            get
            {
                if (patientRepository == null)
                {
                    patientRepository = new PatientRepository(_hospitalSystemContext);
                }

                return patientRepository;
            }
        }

        PatientRepository? patientRepository;

        public UserRepository UserRepository
        {
            //This getter will be used to either create or get the existing User repository depending on whether it exists or not which means that the user repository is stored and created in the unit of work
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(_hospitalSystemContext);
                }

                return userRepository;
            }
        }

        UserRepository? userRepository;

        //This is exposing a save function so it's possible to save the database without making any changes
        public void Save()
        {
            _hospitalSystemContext.SaveChanges();
        }
    }
}
