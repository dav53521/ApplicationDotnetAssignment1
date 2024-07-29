using ApplicationDotnetAssignment1.Models;

namespace ApplicationDotnetAssignment1.Services.Interfaces
{
    public interface IEmailService
    {
        public void SendAppointmentConfirmationEmail(int bookedAppointmentId);
    }
}
