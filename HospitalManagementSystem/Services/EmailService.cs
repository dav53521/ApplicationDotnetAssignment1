using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.UnitOfWork;
using System.Net;
using System.Net.Mail;

namespace ApplicationDotnetAssignment1.Services
{
    public static class EmailService
    {
        public static bool TrySendAppointmentConfirmationEmail(Appointment bookedAppointment, HospitalSystemUnitOfWork unitOfWork)
        {
            try
            {
                (Patient patient, Doctor doctor) = GetPatientAndDoctorFromAppointment(unitOfWork, bookedAppointment.PatientId, bookedAppointment.DoctorId);

                string subject = $"Appointment confirmation for {patient.Name}";

                string body = @$"Dear {patient.Name},
You have sucessfully booked an appointment with {doctor.Name} for the reason {bookedAppointment.Description}
Sincerely,
Dotnet Hospital Management System";

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
                    Body = body,
                    IsBodyHtml = false,
                };

                mailMessage.To.Add(new MailAddress(patient.Email));
                client.Send(mailMessage);

                return true;
            }
            //The when is being used so that it's possible to catch multiple exception types in the one catch statement and also ensure that exceptions that shouldn't be caught such as "out of memory exception" are not caught as they should stop the program
            catch (Exception ex) when (ex is SmtpException or InvalidOperationException or SmtpFailedRecipientException or SmtpFailedRecipientsException)
            {
                Console.WriteLine($"The email failed to send because an error occured: {ex.Message}");
                return false;
            }
        }

        static (Patient, Doctor) GetPatientAndDoctorFromAppointment(HospitalSystemUnitOfWork unitOfWork, int patientToFindId, int doctorToFindId)
        {
            Patient? foundPatient = unitOfWork.PatientRepository.GetPatientById(patientToFindId);
            Doctor? foundDoctor = unitOfWork.DoctorRepository.GetDoctorById(doctorToFindId);
            
            if(foundPatient is null || foundDoctor is null)
            {
                throw new InvalidOperationException("The doctor or patient could not be found");
            }

            return (foundPatient, foundDoctor);
        }
    }
}
