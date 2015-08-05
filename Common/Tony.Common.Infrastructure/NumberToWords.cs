using System;
using System.Globalization;

namespace Tony.Common.Infrastructure
{
    public class NumberToEnglish 
    { 
        public static string ConvertToWords(double number, bool isConrrency)
        {
            if (number == 0) return "Zero";

            bool isNag = false, hasB = false, hasT = false, hasM = false, hasTh = false;
            double t = 0, b = 0, m = 0, h = 0;
             
            string dec = "";
            if (number.ToString(CultureInfo.InvariantCulture).Contains("."))
            {
                dec = number.ToString(CultureInfo.InvariantCulture).Split('.')[1];
                number = double.Parse(number.ToString(CultureInfo.InvariantCulture).Split('.')[0]);
            }

            if (number < 0) isNag = true;//checking if its -ve
            number = Math.Abs(number);
            string words = "";

            if (number >= 1000000000000)
            {
                t = (number - (number % 1000000000000)) / 1000000000000;
                words += GetHundred(t) + " Trillion";
                number %= 1000000000000;

                hasT = true;
            }

            if (number >= 1000000000)
            {
                b = (number - (number % 1000000000)) / 1000000000;
                if (hasT) words += ", ";
                words += GetHundred(b) + " Billion";
                number %= 1000000000;
                hasB = true;
            }

            if (number >= 1000000)
            {
                m = (number - (number % 1000000)) / 1000000;
                if (hasB) words += ", ";
                words += GetHundred(m) + " Million";
                number %= 1000000;
                hasM = true;
            }

            if (number >= 1000)
            {
                t = (number - (number % 1000)) / 1000;
                if (hasM) words += ", ";
                words += GetHundred(t) + " Thousand";
                number %= 1000;
                hasTh = true;
            }

            if (number > 0)
            {
                if (hasTh)
                {
                    if (number >= 100)
                        words += ", ";
                    else
                        words += " and ";
                }
                words += GetHundred(number);
            }

            if (isNag) words = "negative " + words;

            if (!isConrrency)
                words += " point " + GetHundred(double.Parse(dec), isConrrency);
            else
            {
                words += " Naira ";
                if (dec != "")
                {
                    double d = 0;
                    words += ", ";
                    if (dec.Length >= 2)
                    {
                        dec = dec.Substring(0, 2);
                        d = double.Parse(dec);
                    }
                    else if (dec.Length == 1)
                    {
                        d = double.Parse(dec) * 10;
                    }
                    words += GetHundred(d, isConrrency) + " Kobo ";
                }
                //words += "only";
            }
            return words;
        }

        static string[] unitsMap = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", 
                                       "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen",
                                       "Seventeen", "Eighteen", "Nineteen" };
        static string[] tensMap =  { "Zero", "Ten", "Twenty", "Thirty", "Forty", 
                                       "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        private static string GetHundred(double number, bool iscurrency = true)
        {
            string words = ""; bool hasHun = false, hasTen = false;
            if (number >= 100)
            {
                words += unitsMap[(int)(number / 100)] + " Hundred ";
                number %= 100;
                hasHun = true;
            }
            if (number >= 20)
            {
                if (hasHun) words += "and ";
                words += tensMap[(int)number / 10];
                number %= 10;
                hasTen = true;
            }
            if (number > 0)
            {
                if (hasTen) words += "-";
                else if(hasHun) words += "and ";
                words += unitsMap[(int)number];
            }
            return words;
        }

        static string[] monthMap = { "Invalid", "January", "February", "March", "April", "May", "June", "July", "August", "September",
                                       "Octomber", "November", "December"};
        /// <summary>
        /// takes a month in figure and return its string representation
        /// </summary>
        /// <param name="month">int representing the month</param>
        /// <returns>string representing the month</returns>
        public static string MonthInWords(int month)
        {
            if (month < 0 || month > 12)
                throw new ArgumentOutOfRangeException("Invalid month representation");
            return monthMap[month];
        }
    }
}
