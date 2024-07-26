using ApplicationDotnetAssignment1.Models;
using ApplicationDotnetAssignment1.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.ExtensionMethods
{
    public static class ListExtension //Improve by passing in consoleHelper and also remove the need to 
    {
        public static void PrintAllValidElements(this List<Patient> list, IConsoleService consoleService)
        {
            //This LINQ expression is being used to filter out all the null elements so that only the elements that aren't null which ensures that a null reference exception won't be thrown if there is a null in the list as it's filtered out
            IEnumerable<Patient> listToPrint = list.Where(e => e != null);

            if(listToPrint.IsNullOrEmpty())
            {
                Console.WriteLine("There are no patients.");
            }
            else
            {
                Console.WriteLine("{0,-20} | {1,-20} | {2,-30} | {3,-30} | {4,-10}", "Name", "Doctor", "Email Address", "Address", "Phone");
                consoleService.PrintSeperator();

                foreach (Patient item in listToPrint)
                {
                    Console.WriteLine(item.GetPatientAsRow());
                }
            }
        }

        public static void PrintAllValidElements(this List<Appointment> list, IConsoleService consoleService)
        {
            //This LINQ expression is being used to filter out all the null elements so that only the elements that aren't null which ensures that a null reference exception won't be thrown if there is a null in the list as it's filtered out
            IEnumerable<Appointment> listToPrint = list.Where(e => e != null);

            if (listToPrint.IsNullOrEmpty())
            {
                Console.WriteLine("There are no appointments.");
            }
            else
            {
                Console.WriteLine("{0,-20} | {1,-20} | {2}", "Doctor", "Patient", "Description");
                consoleService.PrintSeperator();

                foreach (Appointment item in listToPrint)
                {
                    Console.WriteLine(item.GetAppointmentAsRow());
                }
            }
        }

        public static void PrintAllValidElements(this List<Doctor> list, IConsoleService consoleService)
        {
            //This LINQ expression is being used to filter out all the null elements so that only the elements that aren't null which ensures that a null reference exception won't be thrown if there is a null in the list as it's filtered out
            IEnumerable<Doctor> listToPrint = list.Where(e => e != null);

            if (listToPrint.IsNullOrEmpty())
            {
                Console.WriteLine("There are no doctors.");
            }
            else
            {
                Console.WriteLine("{0,-20} | {1,-30} | {2,-30} | {3,-10}", "Name", "Email Address", "Address", "Phone");
                consoleService.PrintSeperator();

                foreach (Doctor item in listToPrint)
                {
                    Console.WriteLine(item.GetDoctorAsRow());
                }
            }
        }
    }
}
