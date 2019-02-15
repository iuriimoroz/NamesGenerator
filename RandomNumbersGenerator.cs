using System;
using System.Security.Cryptography;

namespace RandomPersonNamesGenerator
{
    public static class RandomSeedGenerator
    {
        // Strong random numbers seed generation method - details are in the link below:
        // https://stackoverflow.com/questions/2706500/how-do-i-generate-a-random-int-number-in-c
        public static int GetSeed()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var intBytes = new byte[4];
                rng.GetBytes(intBytes);
                return BitConverter.ToInt32(intBytes, 0);
            }
        }
    }
}
