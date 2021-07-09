using System.Security.Cryptography;

namespace Passphrase
{
    public class NumberHandler
    {
        public int NewRandomNumber()
        {
            const int rngMin = 1;
            const int rngMax = 6;
            var randomNumber = RandomNumberGenerator.GetInt32(rngMin, rngMax);

            return randomNumber;
        }

        public int[] NewIndexNumber()
        {
            int[] indexNumber = new int[5];

            for (int i = 0; i < indexNumber.Length; i++)
            {
                indexNumber[i] = NewRandomNumber();
            }

            return indexNumber;
        }
    }
}