using ApplicationDotnetAssignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.ExtensionMethods
{
    public static class ListExtension
    {
        public static void PrintAllValidElements(this List<Patient> list) 
        {
            Console.WriteLine("{0,-30} | {1,-30} | {2,-30} | {3,-50} | {4}", "Name", "Doctor", "Email Address", "Address", "Phone");

            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("-");
            }

            //This LINQ expression is being used to filter out all the null elements so that only the elements that aren't null which ensures that a null reference exception won't be thrown if there is a null in the list
            IEnumerable<Patient> listToPrint = list.Where(e => e != null);

            foreach (Patient item in listToPrint)
            {
                Console.WriteLine(item!.ToString());
            }
        }

        public static void PrintAllElements(this List<Appointment> list)
        {
            Console.WriteLine("{0,-30} | {1,-30} | {2}", "Doctor", "Patient", "Description");

            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("-");
            }

            //This LINQ expression is being used to filter out all the null elements so that only the elements that aren't null which ensures that a null reference exception won't be thrown if there is a null in the list
            IEnumerable<Appointment> listToPrint = list.Where(e => e != null);

            foreach (Appointment item in listToPrint)
            {
                Console.WriteLine(item!.ToString());
            }
        }

        public static void PrintAllElements(this List<Doctor> list)
        {
            Console.WriteLine("{0,-30} | {1,-30} | {2,-50} | {3}", "Name", "Email Address", "Phone", "Address");

            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("-");
            }

            //This LINQ expression is being used to filter out all the null elements so that only the elements that aren't null which ensures that a null reference exception won't be thrown if there is a null in the list
            IEnumerable<Doctor> listToPrint = list.Where(e => e != null);

            foreach (Doctor item in listToPrint)
            {
                Console.WriteLine(item!.ToString());
            }
        }
    }
}
