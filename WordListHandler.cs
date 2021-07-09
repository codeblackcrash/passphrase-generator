using System;
using System.IO;

namespace Passphrase
{
    public class WordListHandler
    {
        public string GetListPath(string listPath = "eff_large_wordlist.txt")
        {
            if (!File.Exists(listPath))
            {
                throw new ArgumentException(message: "Path not found.", paramName: nameof(listPath));
            }

            return listPath;
        }

        public string GetWord(int[] indexNumber, string listPath)
        {
            string parsedIndexNumber = string.Join("", indexNumber);
            string matchingWord = "";

            // Foreach loop to find the matching line in word list.
            foreach (string line in File.ReadAllLines(listPath))
            {
                if (line.Contains(parsedIndexNumber))
                {
                    matchingWord = line.Substring(parsedIndexNumber.Length).TrimStart();
                }
            }

            return matchingWord;
        }
    }
}