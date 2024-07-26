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
        [Obsolete("This method is being moved into user service as user service will be used for printing of doctors, appointments and patients")]
        public void PrintTableHeaderForType(string tableType);
    }
}
