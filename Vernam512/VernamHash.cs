using System.Collections;
using System.Security.Cryptography;

namespace Vernam512
{
    public static class VernamHash
    {
        public static byte[] Encrypt(byte[] key, byte[] plainText, int byteSelection)
        {
            byte[] lookupTable = GenerateLookupTables(key, plainText.Length, byteSelection);
            byte[] ciphertext = VHEncrypt(lookupTable, plainText);

            return ciphertext;
        }

        public static byte[] Decrypt(byte[] key, byte[] cipherText, int byteSelection)
        {
            byte[] lookupTable = GenerateLookupTables(key, cipherText.Length, byteSelection);
            byte[] plaintext = VHDecrypt(lookupTable, cipherText);

            return plaintext;
        }

        private static byte[] GenerateLookupTables(byte[] key, int inputLength, int byteSelection)
        {
            byte[] tables = new byte[inputLength];
            byte[] b = key;

            using (SHA512 shaM = SHA512.Create())
            {
                for (int i = 0; i < inputLength; i++)
                {
                    b = shaM.ComputeHash(b);
                    tables[i] = b[byteSelection];
                }
            }

            return tables;
        }

        private static byte[] VHEncrypt(byte[] lookupTable, byte[] plainText)
        {
            BitArray plainTextBits = new BitArray(plainText);
            BitArray cipherTextBits = new BitArray(plainText.Length * 8);

            int index = 0;

            for (int i = 0; i < lookupTable.Length; i++)
            {
                byte[] l = new byte[1];
                l[0] = lookupTable[i];
                BitArray lookup = new BitArray(l);

                for (int j = 0; j < lookup.Length; j++)
                {
                    cipherTextBits[index] = lookup[j] ^ plainTextBits[index++];
                }
            }

            return Helpers.BitArrayToByteArray(cipherTextBits);
        }

        private static byte[] VHDecrypt(byte[] lookupTable, byte[] cipherText)
        {
            BitArray cipherTextBits = new BitArray(cipherText);
            BitArray plainTextBits = new BitArray(cipherText.Length * 8);

            int index = 0;

            for (int i = 0; i < lookupTable.Length; i++)
            {
                byte[] l = new byte[1];
                l[0] = lookupTable[i];
                BitArray lookup = new BitArray(l);

                for (int j = 0; j < lookup.Length; j++)
                {
                    plainTextBits[index] = lookup[j] ^ cipherTextBits[index++];
                }
            }

            return Helpers.BitArrayToByteArray(plainTextBits);
        }
    }
}
