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
    }
}