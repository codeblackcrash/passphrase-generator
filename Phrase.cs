using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace codeblackcrash.Security.Passphrase
{
    class Phrase
    {
        int WordCount;              // # of words to add
        int NumberCount;            // # of numbers to add
        bool AddSpecialChar;     // Add special character to end of phrase?
        bool CapitalizeWords;       // Should each word have its first letter capitalized?

        public Phrase(int wordCount = 3, int numberCount = 3, bool addSpecialChar = true, bool capitalizeWords = true)
        {
            WordCount = wordCount;
            NumberCount = numberCount;
            AddSpecialChar = addSpecialChar;
            CapitalizeWords = capitalizeWords;
        }

        public string Generate()
        {
            List<string> phraseElements = new List<string>();       // Empty list that we'll add all of our passphrase pieces into
            List<int> numbers = new List<int>();                    // Empty list that we'll add numbers to

            // for loop that adds a new word to phraseElements list
            for (int i = 0; i < WordCount; i++)
            {
                string wordIndex = String.Join("", GetWordIndex());
                string word = GetWord(wordIndex);

                // if CapitalizeWords is true, we need to capitalize the first letter of the word before adding it to the list
                if (CapitalizeWords)
                {
                    word = char.ToUpper(word[0]) + word.Substring(1);
                }

                phraseElements.Add(word);
            }

            // for loop that adds a new number to numbers list
            for (int i = 0; i < NumberCount; i++)
            {
                numbers.Add(GetNumber()); 
            }

            // Convert numbers list to string and then add it to our phraseElements list
            phraseElements.Add(String.Concat(numbers));

            // We'll join everything together in our phraseElements list
            string completedPhrase = String.Join(" ", phraseElements);

            // if AddSpecialChar is true, we need to add a special character at the very end
            if (AddSpecialChar)
            {
                completedPhrase = String.Concat(completedPhrase, GetSpecialChar());
            }

            return completedPhrase;
        }

        private int[] GetWordIndex()
        {
            int[] wordIndex = new int[5];     // Create blank int array to store 6 random numbers

            for (int i = 0; i < wordIndex.Length; i++)
            {
                wordIndex[i] = RandomNumberGenerator.GetInt32(1, 7);      // Use RandomNumberGenerator.GetInt32() method to fill current item in array with a random number between 1 and 6
            }

            return wordIndex;
        }

        private int GetNumber()
        {
            int number = RandomNumberGenerator.GetInt32(10);

            return number;
        }

        private string GetSpecialChar()
        {
            string[] specialChars = {"!", "@", "#", "$", "%", "^", "&", "*", "?", "~"};

            Console.WriteLine(specialChars.Length);
            
            int index = RandomNumberGenerator.GetInt32(specialChars.Length + 1);

            string result = specialChars[index];

            return result;
        }

        public string GetWord(string wordIndex)
        {
            const string ListPath = "eff_large_wordlist.txt";

            string word = "";

            foreach (string line in File.ReadAllLines(ListPath))
            {
                if (line.Contains(wordIndex))
                {
                    word = line.Substring(wordIndex.Length).TrimStart();    // String methods here clean up the index # and leading spaces
                }
            }

            return word;
        }
    }
}
