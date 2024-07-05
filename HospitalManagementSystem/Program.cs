namespace ApplicationDotnetAssignment1;

class Program
{
    static void Main(string[] args)
    {
        Console.SetCursorPosition((Console.WindowWidth) / 2, Console.CursorTop); //This line is being used to place the "Login Please" text 
        Console.WriteLine("Login");
        Console.WriteLine("Please Enter Your Login Details Below:");

        Console.Write("ID: ");
        string? inputtedID = Console.ReadLine();

        Console.Write("Password:");

        string password = ""; //Empty string so that if a user presses enter right away then an empty string will be given to the user identifier.
        var keyPressed = Console.ReadKey(true);
        
        while(keyPressed.Key != ConsoleKey.Enter)
        {
            Console.Write("*");
            keyPressed = Console.ReadKey(true);
        }
    }
}
