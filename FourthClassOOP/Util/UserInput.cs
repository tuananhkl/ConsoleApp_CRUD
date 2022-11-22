using System;
using System.Globalization;

namespace FourthClassOOP.Util
{
    public static class UserInput
    {
        public static string GetString(string message)
        {
            var output = "";
            var check = false;
            while (check == false)
            {
                Console.Write(message);
                var text = Console.ReadLine();

                if (String.IsNullOrWhiteSpace(text))
                {
                    Console.WriteLine("That was invalid value (string). Please try again.");
                }
                else
                {
                    output = text;
                    check = true;
                }
            }
            
            return output;
        }

        public static double GetDouble(string message)
        {
            Console.Write(message);
            var numberText = Console.ReadLine();
            double output;

            bool isDouble = double.TryParse(numberText, out output);

            while (!isDouble || output <= 0)
            {
                Console.WriteLine("That was invalid value (double). Please try again.");
                Console.Write(message);
                numberText = Console.ReadLine();
                
                isDouble = double.TryParse(numberText, out output);
            }
            
            return output;
        }
        
        public static int GetInt(string message)
        {
            var numberText = "";
            var check = false;
            while (check == false)
            {
                Console.Write(message);
                numberText = Console.ReadLine();

                if (String.IsNullOrWhiteSpace(numberText))
                {
                    Console.WriteLine("The value can't be null or white space. Please try again.");
                }
                else
                {
                    check = true;
                }
            }
            
            int output;

            bool isInt = int.TryParse(numberText, out output);

            while (!isInt || output <= 0)
            {
                Console.WriteLine("That was invalid value (int). Please try again.");
                Console.Write(message);
                numberText = Console.ReadLine();
                
                isInt = int.TryParse(numberText, out output);
            }
            
            return output;
        }

        public static string ConvertToTitleCase(string input)
        {
            var currentTextInfo = CultureInfo.CurrentCulture.TextInfo;

            var output = currentTextInfo.ToTitleCase(input.ToLower());
            
            return output;
        }
    }
}