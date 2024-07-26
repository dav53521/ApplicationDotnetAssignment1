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
                Console.WriteLine(listToPrint.First().TableHeader);
                consoleService.PrintSeperator();

                foreach (Patient item in listToPrint)
                {
                    Console.WriteLine(item.TableBody);
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
                Console.WriteLine(listToPrint.First().TableHeader);
                consoleService.PrintSeperator();

                foreach (Appointment item in listToPrint)
                {
                    Console.WriteLine(item.TableBody);
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
                Console.WriteLine(listToPrint.First().TableHeader);
                consoleService.PrintSeperator();

                foreach (Doctor item in listToPrint)
                {
                    Console.WriteLine(item.TableBody);
                }
            }
        }
    }
}
