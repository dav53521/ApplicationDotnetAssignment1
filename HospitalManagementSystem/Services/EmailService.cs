using ApplicationDotnetAssignment1.Contexts;
using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Services
{
    public static class EmailService
    {
        public static void SendAppointmentConfirmationEmail(Appointment bookedAppointment, HospitalSystemUnitOfWork unitOfWork)
        {
            try
            {
                (Patient bookedPatient, Doctor assignedDoctor) = GetPatientAndDoctorFromAppointment(unitOfWork, bookedAppointment.PatientId, bookedAppointment.DoctorId);

                string subject = $"Appointment confirmation for {bookedPatient.Name}";

                string fromEmail = "davidhospitalmanagmentsystem@gmail.com";

                string password = "bdse mlzl qxrq nyih";

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential(fromEmail, password),
                    EnableSsl = true
                };

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(fromEmail),
                    Subject = subject,
                };

                mailMessage.To.Add(new MailAddress(bookedPatient.Email));
                client.Send(mailMessage);
            }
            //The when is being used so that it's possible to catch multiple exception types in the one catch statement and also ensure that exceptions that shouldn't be caught such as "out of memory exception" are not caught as they should stop the program
            catch (Exception ex) when (ex is SmtpException or InvalidOperationException or SmtpFailedRecipientException or SmtpFailedRecipientsException)
            {
                Console.WriteLine($"The email failed to send because an error occured: {ex.Message}");
            }
        }

        static (Patient, Doctor) GetPatientAndDoctorFromAppointment(HospitalSystemUnitOfWork unitOfWork, int patientToFindId, int doctorToFindId)
        {
            Patient? foundPatient = unitOfWork.PatientRepository.GetPatientById(patientToFindId);
            Doctor? foundDoctor = unitOfWork.DoctorRepository.GetDoctorById(patientToFindId);
            
            if(foundPatient is null || foundDoctor is null)
            {
                throw new InvalidOperationException("The doctor or patient could not be found");
            }

            return (foundPatient, foundDoctor);
        }
    }
}
