using System;
using System.Security.Cryptography;
using System.Text;

namespace Tony.Common.Infrastructure
{
    public static class StringMethods
    {
        public static string RoundOff(string str, int digit)
        {
            string output = "";
            if (str.Length == digit)
                output = str;
            else if (str.Length > digit)
                output = str.Substring(0, digit);
            else
            {
                int diff = digit - str.Length;
                for (int i = 1; i <= diff; i++)
                    output += "0";
                output += str;
            }
            return output;
        }

        public static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = MD5.Create();  // SHA1.Create()
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

        public static string ToShort(this string input, int maxLength)
        {
            if (string.IsNullOrEmpty(input)) return input;
            return input.Length <= maxLength ? input : input.Substring(0, maxLength);
        }

        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        /// <summary>
        /// Generates a random string with the given length
        /// </summary>
        /// <param name="size">Size of the string</param>
        /// <param name="lowerCase">If true, generate lowercase string</param>
        /// <returns>Random string</returns>
        public static string RandomString(int size, bool lowerCase = false)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

    }
}
