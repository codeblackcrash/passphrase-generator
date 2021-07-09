using System;

namespace Passphrase
{
    class Program
    {
        static void Main(string[] args)
        {
            PhraseHandler passphrase = new PhraseHandler();
            
            Console.Write("Desired passphrase length: ");

            var phraseLength = Console.ReadLine();
            int wordCount;

            while (string.IsNullOrEmpty(phraseLength))
            {
                Console.WriteLine("Input cannot be null or empty.");
                Console.WriteLine("Enter the desired passphrase length: ");

                phraseLength = Console.ReadLine();
            }

            while (!int.TryParse(phraseLength, out wordCount))
            {
                Console.WriteLine("Incorrect input- please enter a number.");

                phraseLength = Console.ReadLine();
            }

            Console.WriteLine(passphrase.New(wordCount));

        }
    }
}