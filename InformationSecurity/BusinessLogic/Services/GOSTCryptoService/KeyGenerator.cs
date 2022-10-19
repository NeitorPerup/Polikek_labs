using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationSecurity.BusinessLogic.Services.GOSTCryptoService
{
    public class KeyGenerator
    {
        private readonly int KeyLength;
        private Random rand;

        public KeyGenerator(EKeyVariant key)
        {
            if (key == EKeyVariant.Key)
                KeyLength = 256;
            if (key == EKeyVariant.S)
                KeyLength = 64;

            rand = new Random();
        }

        public byte[] GenerateKey()
        {
            char[] charsKey = new char[KeyLength];
            for (int i = 0; i < KeyLength; ++i)
                charsKey[i] = Convert.ToChar(rand.Next(0, 2));

            byte[] key = new byte[KeyLength / 8];
            string[] keyParts = new string[KeyLength / 8];
            int count = 0;

            for (int i = 0; i < KeyLength; i++)
            {
                if ((i % 8 == 0) && (i != 0))
                    count++;

                keyParts[count] += Convert.ToByte(charsKey[i]);
            }

            for (int i = 0; i < key.Length; i++)
                key[i] = Convert.ToByte(keyParts[i], 2);

            return key;
        }
    }

    public enum EKeyVariant
    {
        Key = 0,
        S = 1
    }
}
