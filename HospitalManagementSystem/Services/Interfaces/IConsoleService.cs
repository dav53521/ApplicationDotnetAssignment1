using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDotnetAssignment1.Services.Interfaces
{
    public interface IConsoleService
    {
        public int GetIntegerFromUser(string userPrompt, string errorMessage);
        public bool GetIntegerFromUser(string userPrompt, string errorMessage, char exitCharacter, out int gottenInteger);
        public string GetMaskedInput(string userPrompt);
        public void PrintSeperator();
        public void WaitForKeyPress();
        public void PrintInCenter(string thingToPrint);
        public void PrintTableHeaderForType(string tableType);
    }
}
