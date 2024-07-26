using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Services.Interfaces
{
    public interface IConsoleService
    {
        public int GetIdFromUser(string userPrompt);
        public int GetNumberFromUser(string userPrompt, string errorMessage);
        public string GetMaskedInput(string userPrompt);
        public void PrintSeperator();
        public void WaitForKeyPress();
        public void PrintInCenter(string thingToPrint);
    }
}
