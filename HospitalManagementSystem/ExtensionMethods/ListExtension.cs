using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.Models.Interface;
using Microsoft.IdentityModel.Tokens;

namespace ApplicationDotnetAssignment1.ExtensionMethods
{
    public static class ListExtension
    {
        public static List<T> GetAllValidElements<T>(this List<T> listToCheck)
        {
            if (!listToCheck.IsNullOrEmpty())
            {
                List<T> validElements = listToCheck.Where(e => e != null).ToList();

                return validElements;
            }
            else
            {
                return listToCheck ?? new List<T>();
            }
        }

        public static void PrintPatientsAsTable(this List<Patient> patients, string noPatientsMessage)
        {
            List<Patient>? validPatientsToPrint = patients?.Where(p => p != null).ToList();

            if (!validPatientsToPrint.IsNullOrEmpty())
            {
                Console.WriteLine("{0,-20} | {1,-20} | {2,-30} | {3,-40} | {4,-10}", "Name", "Doctor", "Email Address", "Address", "Phone");
                PrintEntities(validPatientsToPrint!); //This cannot be null as we guard against it in the if statement 
            }
            else
            {
                Console.WriteLine(noPatientsMessage);
            }
        }

        public static void PrintDoctorsAsTable(this List<Doctor> doctors, string noDoctorsMessage)
        {
            List<Doctor>? validDoctorsToPrint = doctors?.Where(d => d != null).ToList();

            if (!validDoctorsToPrint.IsNullOrEmpty())
            {
                Console.WriteLine("{0,-20} | {1,-30} | {2,-40} | {3,-10}", "Name", "Email Address", "Address", "Phone");
                PrintEntities(validDoctorsToPrint!); //This cannot be null as we guard against it in the if statement
            }
            else
            {
                Console.WriteLine(noDoctorsMessage);
            }
        }

        public static void PrintAppointmentsAsTable(this List<Appointment> appointments, string noAppointmentsMessage)
        {
            List<Appointment> validAppointsToPrint = appointments.Where(a => a != null).ToList();

            if (!appointments.IsNullOrEmpty())
            {
                Console.WriteLine("{0,-20} | {1,-20} | {2}", "Doctor", "Patient", "Description");
                PrintEntities(validAppointsToPrint);
            }
            else
            {
                Console.WriteLine(noAppointmentsMessage);
            }
        }

        static void PrintEntities(IEnumerable<IPrintableAsTable> entityToPrints)
        {
            PrintSeperator();
            foreach (IPrintableAsTable entity in entityToPrints)
            {
                Console.WriteLine(entity.EntityAsTableRow);
            }
        }

        public static void PrintSeperator()
        {
            for(int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write('-');
            }
            Console.WriteLine();
        }

    }
}