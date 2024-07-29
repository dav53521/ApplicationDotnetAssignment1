using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.Models.Interface;
using Microsoft.IdentityModel.Tokens;

namespace ApplicationDotnetAssignment1.ExtensionMethods
{
    public static class ListExtension
    {
        public static void PrintEntitiesAsTable(this List<Patient> patients, string noPatientsMessage)
        {
            List<Patient>? validPatientsToPrint = patients?.Where(p => p != null).ToList();

            if (!validPatientsToPrint.IsNullOrEmpty())
            {
                Console.WriteLine("{0,-20} | {1,-20} | {2,-30} | {3,-40} | {4,-10}", "Name", "Doctor", "Email Address", "Address", "Phone");
                PrintEntities(validPatientsToPrint!); //The list cannot be null or empty as we guard against nulls in the if statement so the null forgiving operator is used
            }
            else
            {
                Console.WriteLine(noPatientsMessage);
            }
        }

        public static void PrintEntitiesAsTable(this List<Doctor> doctors, string noDoctorsMessage)
        {
            List<Doctor>? validDoctorsToPrint = doctors?.Where(d => d != null).ToList();

            if (!validDoctorsToPrint.IsNullOrEmpty())
            {
                Console.WriteLine("{0,-20} | {1,-30} | {2,-40} | {3,-10}", "Name", "Email Address", "Address", "Phone");
                PrintEntities(validDoctorsToPrint!); //The list cannot be null or empty as we guard against nulls in the if statement so the null forgiving operator is used
            }
            else
            {
                Console.WriteLine(noDoctorsMessage);
            }
        }

        public static void PrintEntitiesAsTable(this List<Appointment> appointments, string noAppointmentsMessage)
        {
            List<Appointment> validAppointsToPrint = appointments.Where(a => a != null).ToList();

            if (!appointments.IsNullOrEmpty())
            {
                Console.WriteLine("{0,-20} | {1,-20} | {2}", "Doctor", "Patient", "Description");
                PrintEntities(validAppointsToPrint); //The list cannot be null or empty as we guard against nulls in the if statement so the null forgiving operator is used
            }
            else
            {
                Console.WriteLine(noAppointmentsMessage);
            }
        }

        static void PrintEntities(IEnumerable<IPrintableAsTable> entityToPrints) //This is where the table rows are printed out as this is shared logic amongst all the methods so moving it here helps enforce DRY
        {
            PrintSeperator();
            foreach (IPrintableAsTable entity in entityToPrints)
            {
                Console.WriteLine(entity.EntityAsTableRow);
            }
        }

        static void PrintSeperator() //This is in its own method because it helps enforce single responsibility as the methods that print the entities shouldn't be concerned with printing a seperator as that's different logic in my opinion
        {
            for(int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write('-');
            }
            Console.WriteLine();
        }

    }
}