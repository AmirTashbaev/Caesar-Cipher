using System;
using System.Linq;

namespace CaesarCipher
{
    class Program
    {
        public static char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};

        static void Main(string[] args)
        {


            Console.WriteLine("Enter a secret message");
            string userInput = Console.ReadLine();

            string encryptedMessage = Encrypt(userInput);
            Console.WriteLine(encryptedMessage);

            string decryptedMessage = Decrypt(encryptedMessage);
            Console.WriteLine(decryptedMessage);

        }

        static string Encrypt(string userInput)
        {
            // Converts input to lowercase
            userInput.ToLower();

            // Ignores characters that are not whitespaces and letters or digitsdotnet 
            userInput = new string((from c in userInput
                                    where char.IsWhiteSpace(c) || char.IsLetter(c)
                                    select c).ToArray());


            char[] userInputArray = userInput.ToCharArray();

            char[] encryptedArray = new char[userInputArray.Length];

            // Loop through each character to assign it to encryptedArray
            for (int i = 0; i < userInputArray.Length; i++)
            {
                char charOriginalMessage = userInputArray[i];
                int alphabetIndex = Array.IndexOf(
                    array: alphabet,
                    charOriginalMessage);


                // We take the modulo of alphabet to warp items, z will be c etc..
                int caesarIndex = (alphabetIndex + 3)
                    % alphabet.Length;
                char caesarChar = alphabet[caesarIndex];
                encryptedArray[i] = caesarChar;
            }
            string encryptedText = String.Join("", encryptedArray);
            return encryptedText;
        }

        // Decrypt use the same principle as Encrypt, but if statements for the 3 exceptions a, b, c
        static string Decrypt(string encryptedMessage)
        {
            char[] encryptedArray = encryptedMessage.ToCharArray();

            char[] decryptedMessage = new char[encryptedArray.Length];

            for (int j = 0; j < encryptedArray.Length; j++)
            {
                char charCaesar = encryptedArray[j];
                int alphabetIndex = Array.IndexOf(array: alphabet, charCaesar);

                int originalIndex;

                // dealing with a, b, c
                if (alphabetIndex == 1)
                {
                    originalIndex = 24;
                }
                else if (alphabetIndex == 2)
                {
                    originalIndex = 25;
                }
                else if (alphabetIndex == 3)
                {
                    originalIndex = 26;
                }
                else
                {
                    originalIndex = alphabetIndex - 3;
                }
                char originalChar = alphabet[originalIndex];
                decryptedMessage[j] = originalChar;
            }

            string decryptedString = String.Join("", decryptedMessage);
            return decryptedString;
        }
    }
}
