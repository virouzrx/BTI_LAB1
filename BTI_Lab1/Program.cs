using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Text;  
  
namespace Caesar_Cipher
{
    class Program
    {
        public static char cipher(char ch, int key)
        {
            if (!char.IsLetter(ch))
            {

                return ch;
            }

            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - d) % 26) + d);
        }

        public static string Encipher(string input, int key)
        {
            string output = string.Empty;

            foreach (char ch in input)
                output += cipher(ch, key);

            return output;
        }

        public static string Decipher(string input, int key)
        {
            return Encipher(input, 26 - key);
        }

        static void Main(string[] args)
        {
            bool condition = false;
            bool condition2 = false;
            string UserString = "";
            while (!condition2)
            {
                Console.Write("Type a string to encrypt: ");
                UserString = Console.ReadLine();
                if (String.IsNullOrEmpty(UserString))
                {
                    Console.WriteLine("String is empty");
                }
                else
                {
                    condition2 = true;
                }
            }
            
            while (!condition)
            {
                Console.Write("Enter your key: ");
                int key;
                var inputKey = Console.ReadLine();
                bool success = Int32.TryParse(inputKey, out key);

                if (success)
                {
                    Console.Write("Encrypted Data: ");

                    string cipherText = Encipher(UserString, key);
                    Console.WriteLine(cipherText);

                    Console.Write("Decrypted Data: ");

                    string t = Decipher(cipherText, key);
                    Console.WriteLine(t);
                    condition = true;
                }
                else
                {
                    Console.WriteLine("Incorrect key");
                }
            }
            Console.ReadKey();
        }
    }
}