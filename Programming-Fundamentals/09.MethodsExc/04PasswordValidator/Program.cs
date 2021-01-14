using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04PasswordValidator
{
    class Program
    {
        static bool isValid = true;
        static void Main(string[] args)
        {
            string pass = Console.ReadLine();

            CharactersCountValidator(pass);
            CharacterAndNumbersOnlyValidator(pass);
            AtLeastTwoDigitsPassValidator(pass);
            if (isValid)
            {
                Console.WriteLine("Password is valid");
            }

        }

        static void CharacterAndNumbersOnlyValidator(string pass)
        {
           bool isMatch = Regex.IsMatch(pass, @"^[a-zA-Z0-9]+$");
            if (isMatch == false)
            {
                Console.WriteLine("Password must consist only of letters and digits");
                isValid = false;
            }
        }
        static void CharactersCountValidator(string pass)
        {
            if(pass.Length<6 || pass.Length > 10)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                isValid = false;
            }
        }
        static void AtLeastTwoDigitsPassValidator(string pass)
        {
            int count = pass.Count(Char.IsDigit);

            if (count < 2)
            {
                Console.WriteLine("Password must have at least 2 digits");
                isValid = false;
            }
        }
    }
}
