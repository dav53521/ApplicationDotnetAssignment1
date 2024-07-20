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
            //This LINQ expression is being used to filter out all the null elements so that only the elements that aren't null which ensures that a null reference exception won't be thrown if there is a null in the list
            IEnumerable<Patient> listToPrint = list.Where(e => e != null);

            foreach (Patient item in listToPrint)
            {
                Console.WriteLine(item!.ToString());
            }
        }

        public static void PrintAllElements(this List<Appointment> list)
        {
            //This LINQ expression is being used to filter out all the null elements so that only the elements that aren't null which ensures that a null reference exception won't be thrown if there is a null in the list
            IEnumerable<Appointment> listToPrint = list.Where(e => e != null);

            foreach (Appointment item in listToPrint)
            {
                Console.WriteLine(item!.ToString());
            }
        }

        public static void PrintAllElements(this List<Doctor> list)
        {
            //This LINQ expression is being used to filter out all the null elements so that only the elements that aren't null which ensures that a null reference exception won't be thrown if there is a null in the list
            IEnumerable<Doctor> listToPrint = list.Where(e => e != null);

            foreach (Doctor item in listToPrint)
            {
                Console.WriteLine(item!.ToString());
            }
        }
    }
}
