using ApplicationDotnetAssignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Services.Interfaces
{
    public interface IEmailService
    {
        public void SendAppointmentConfirmationEmail(Appointment bookedAppointment);
    }
}
