using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.ExtensionMethods
{
    public static class ListExtension
    {
        public static void PrintAllElements<T>(this List<T> list) 
        {
            //This LINQ expression is being used to filter out all the null elements so that only the elements that aren't null which ensures that a null reference exception won't be thrown if there is a null in the list
            IEnumerable<T> listToPrint = list.Where(e => e != null);

            foreach (T item in listToPrint)
            {
                Console.WriteLine(item!.ToString());
            }
        }
    }
}
