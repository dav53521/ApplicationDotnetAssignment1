﻿using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.Services.Interfaces;
using ApplicationDotnetAssignment1.UnitOfWork.Interface;
using System.Net;
using System.Net.Mail;

namespace ApplicationDotnetAssignment1.Services
{
    public class EmailService : IEmailService
    {
        IHospitalSystemUnitOfWork _UnitOfWork;

        public EmailService(IHospitalSystemUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        public void SendAppointmentConfirmationEmail(int bookedAppointmentId)
        {
            //Getting the appointment from the database so that it can be used to fill in the email details such as the patient email and the doctor's name
            Appointment? bookedAppointment = _UnitOfWork.AppointmentRepository.GetAppointmentById(bookedAppointmentId);

            if(bookedAppointment != null)
            {
                Console.WriteLine("Sending Email");
                try
                {
                    string subject = $"Appointment confirmation for {bookedAppointment!.Patient!.Name}";
                    string body = @$"Dear {bookedAppointment.Patient!.Name},
You have sucessfully booked an appointment with Doctor {bookedAppointment.Doctor!.Name} for the reason {bookedAppointment.Description}";
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

                    mailMessage.To.Add(new MailAddress(bookedAppointment.Patient!.Email));
                    client.Send(mailMessage);
                }
                //The when is being used so that it's possible to catch multiple exception types in the one catch statement while also ensuring that exceptions that shouldn't be caught such as "out of memory exception" are thrown as they should stop the program
                catch (Exception ex) when (ex is SmtpException or InvalidOperationException or SmtpFailedRecipientException or SmtpFailedRecipientsException)
                {
                    Console.WriteLine($"The email failed to send because an error occured: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine($"The appointment with Id {bookedAppointmentId} could not be found");
            }
        }
    }
}
