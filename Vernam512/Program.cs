using System;
using System.IO;
using System.Text;

namespace Vernam512
{
    public class Variables
    {
        public bool IsEncrypt { get; set; }
        public byte[] Key { get; set; }
        public byte[] InputFile { get; set; }
        public string OutputFile { get; set; }
        public int ByteSelection { get; set; }
    }

    class Program
    {
        private static string version = "1.0.2";

        static void Main(string[] args)
        {
            try
            {
                Variables v = ParseArgs(args);
                ValidateVariables(v);

                if (v.IsEncrypt)
                {
                    Console.WriteLine("Vernam512 Cipher " + version);
                    Console.WriteLine(Environment.NewLine);
                    v.Key = GetKey();
                    File.WriteAllBytes(v.OutputFile, VernamHash.Encrypt(v.Key, v.InputFile, v.ByteSelection));
                    Console.WriteLine("Encrypted.");
                }
                else
                {
                    Console.WriteLine("Vernam512 Cipher " + version);
                    Console.WriteLine(Environment.NewLine);
                    v.Key = GetKey();
                    File.WriteAllBytes(v.OutputFile, VernamHash.Decrypt(v.Key, v.InputFile, v.ByteSelection));
                    Console.WriteLine("Decrypted.");
                }
            }
            catch
            {
                Terminate("Invalid usage.");
            }
        }

        private static Variables ParseArgs(string[] args)
        {
            //Vernam512 -e -i plaintext.txt -o ciphertext.512 -b 0
            //Vernam512 -d -i ciphertext.512 -o plaintext.txt -b 0
            //Vernam512 -h

            if(args.Length == 7 && args[0] == "-e")
                return new Variables() { IsEncrypt = true, InputFile = File.ReadAllBytes(args[2]), OutputFile = args[4], ByteSelection = int.Parse(args[6]) };
            else if (args.Length == 7 && args[0] == "-d")
                return new Variables() { IsEncrypt = false, InputFile = File.ReadAllBytes(args[2]), OutputFile = args[4], ByteSelection = int.Parse(args[6]) };
            else if (args.Length == 1 && args[0] == "-h")
            {
                Console.WriteLine("Vernam512 Cipher " + version);
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("To encrypt:");
                Console.WriteLine("Vernam512 -e -k abc12345 -i plaintext.txt -o ciphertext.512 -b 0");
                Console.WriteLine("To decrypt:");
                Console.WriteLine("Vernam512 -d -k abc12345 -i ciphertext.512 -o plaintext.txt -b 0");
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("Parameters:");
                Console.WriteLine("-b                   - Byte selection (0-63)");
                Console.WriteLine("-d                   - Encrypt");
                Console.WriteLine("-e                   - Decrypt");
                Console.WriteLine("-h                   - Display help");
                Console.WriteLine("-o (filename)        - output file");
                Environment.Exit(0);
            }
            else
                Terminate("Incorrect parameters are being supplied");

            return null;  //Should never get here
        }

        private static void ValidateVariables(Variables v)
        {
            if (v.ByteSelection < 0 || v.ByteSelection > 63)
                Terminate("Byte selection must be between 0 and 63 inclusive.");

            if (v.InputFile == null)
                Terminate("No input file");

            if(string.IsNullOrEmpty(v.OutputFile))
                Terminate("Missing output file");
        }

        private static void Terminate(string message)
        {
            Console.WriteLine("Vernam512 Cipher " + version);
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(message);
            Console.WriteLine("Incorrect usage.  Please type 'Vernam512 -h' for help.");
            Environment.Exit(0);
        }

        private static byte[] GetKey()
        {
            byte[] key = null;

            while (key == null)
            {
                Console.WriteLine("Please input key and press ENTER when finished:");
                string result = Console.ReadLine();

                byte[] r = Encoding.Unicode.GetBytes(result);

                if (r.Length >= 64)
                    key = r;
                else
                    Console.WriteLine("Please enter a larger key (64 characters or more).");
            }

            return key;
        }
    }
}
