using System;

namespace codeblackcrash.Security.Passphrase
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Passphrase Generator";

            Phrase passphrase = new();

            string result = passphrase.Generate();

            Console.WriteLine("Stuff needs to go here.");
            Console.WriteLine($"\nYour passphrase is:  {result}");
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey(true);
        }
    }
}
