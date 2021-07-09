namespace Passphrase
{
    public class PhraseHandler
    {
        
        public string New(int wordCount = 4)
        {
            WordListHandler wordList = new WordListHandler();
            string wordListPath = wordList.GetListPath();
            string[] wordArray = new string[wordCount];

            for (int i = 0; i < wordArray.Length; i++)
            {
                NumberHandler numbers = new NumberHandler();
                
                int[] indexNumber = numbers.NewIndexNumber();
                string randomWord = wordList.GetWord(indexNumber, wordListPath);
                wordArray[i] = randomWord;
            }

            string completedPhrase = string.Join(" ", wordArray);

            return completedPhrase;
        }
    }
}