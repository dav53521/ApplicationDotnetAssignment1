﻿using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.Models.Interface;
using Microsoft.IdentityModel.Tokens;

namespace ApplicationDotnetAssignment1.ExtensionMethods
{
    public static class ListExtension
    {
        public static void PrintEntitiesAsTable(this List<Patient> patients, string noPatientsMessage)
        {
            Console.WriteLine(); //Adding a new line before anything is printed so the screen feels less cluttered
            List<Patient>? validPatientsToPrint = patients?.Where(p => p != null).ToList();

            Console.WriteLine(); //adding a line so the screen doesn't feel too crowded
            if (!validPatientsToPrint.IsNullOrEmpty())
            {
                Console.WriteLine("{0,-20} | {1,-20} | {2,-30} | {3,-40} | {4,-10}", "Name", "Doctor", "Email Address", "Address", "Phone");
                PrintEntities(validPatientsToPrint!); //The list cannot be null as we guard against nulls in the if statement so the null forgiving operator is used to stop the warning
            }
            else
            {
                Console.WriteLine(noPatientsMessage);
            }
        }

        public static void PrintEntitiesAsTable(this List<Doctor> doctors, string noDoctorsMessage)
        {
            Console.WriteLine(); //Adding a new line before anything is printed so the screen feels less cluttered
            List<Doctor>? validDoctorsToPrint = doctors?.Where(d => d != null).ToList();

            Console.WriteLine(); //adding a line so the screen doesn't feel too crowded
            if (!validDoctorsToPrint.IsNullOrEmpty())
            {
                Console.WriteLine("{0,-20} | {1,-30} | {2,-40} | {3,-10}", "Name", "Email Address", "Address", "Phone");
                PrintEntities(validDoctorsToPrint!); //The list cannot be null as we guard against nulls in the if statement so the null forgiving operator is used to stop the warning
            }
            else
            {
                Console.WriteLine(noDoctorsMessage);
            }
        }

        public static void PrintEntitiesAsTable(this List<Appointment> appointments, string noAppointmentsMessage)
        {
            Console.WriteLine(); //Adding a new line before anything is printed so the screen feels less cluttered
            List<Appointment> validAppointsToPrint = appointments.Where(a => a != null).ToList();

            Console.WriteLine(); //adding a line so the screen doesn't feel too crowded
            if (!appointments.IsNullOrEmpty())
            {
                Console.WriteLine("{0,-20} | {1,-20} | {2}", "Doctor", "Patient", "Description");
                PrintEntities(validAppointsToPrint); //The list cannot be null as we guard against nulls in the if statement so the null forgiving operator is used to stop the warning
            }
            else
            {
                Console.WriteLine(noAppointmentsMessage);
            }
        }

        //This is where the table rows are printed out as this logic is shared amongst all of the methods so moving it here helps enforce DRY principles and makes the code cleaners
        static void PrintEntities(IEnumerable<IPrintableAsTable> entityToPrints)
        {
            PrintSeperator();
            foreach (IPrintableAsTable entity in entityToPrints)
            {
                Console.WriteLine(entity.EntityAsTableRow);
            }
        }

        //This is in its own method because it helps enforce single responsibility as the methods that print the entities shouldn't be concerned with printing a seperator as that's different logic in my opinion
        static void PrintSeperator()
        {
            for(int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write('-');
            }
            Console.WriteLine();
        }

    }
}