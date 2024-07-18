using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.ExtensionMethods
{
    public static class ListExtension
    {
        public static void printAll<T>(this List<T> list) 
        {
            foreach (T item in list)
            {
                item?.ToString();
            }
        }
    }
}
