namespace ApplicationDotnetAssignment1.Services.Interfaces
{
    public interface IConsoleService
    {
        public int GetIdFromUser(string userPrompt);
        public int GetNumberFromUser(string userPrompt, string errorMessage);
        public string GetMaskedInputFromUser(string userPrompt);
        public void PrintInCenter(string thingToPrint);
        public string GetPhoneNumberFromUser();
        public string GetEmailFromUser();
        public string GetFullNameFromUser();
        public string GetAddressFromUser();
        public string GetUserInput(string userPrompt);
    }
}
