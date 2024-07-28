using ApplicationDotnetAssignment1.Repositories;

namespace ApplicationDotnetAssignment1.UnitOfWork.Interface
{
    public interface IHospitalSystemUnitOfWork
    {
        public AppointmentRepository AppointmentRepository { get; }
        public DoctorRepository DoctorRepository { get; }
        public PatientRepository PatientRepository { get; }
        public UserRepository UserRepository { get; }
        public void Save();
    }
}
