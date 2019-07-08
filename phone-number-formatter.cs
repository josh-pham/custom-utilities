using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Excercises
{
    class Program
    {
        static void Main(string[] args)
        {

            var Utility = new Utility();
            Console.WriteLine("Testing Utility...");
            Console.WriteLine("Type a phone number:  ");
            var phone = Utility.FormatPhoneNumber(Console.ReadLine());

            Console.WriteLine(phone);
            Console.ReadLine();

        }
    }


    class Utility
    {
        public string FormatPhoneNumber(string input)
        {

            var errors = new List<string>();
            // Check for input 
            if (input == null) { errors.Add("No valid input defined.");}
            // Check if input is already a valid formatted phone number.
            if ((Regex.Match(input, @"^((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$")).Success) { errors.Add("Input is already formatted as phone number (555)555-5555."); }

            // Sanitize the input 
            input = Regex.Replace(input, "[(|)|-|]", "");

            // Check for numbers only.
            foreach (var item in input)
            {
                int _digit;

                if (!(int.TryParse(item.ToString(), out _digit))) {
                    errors.Add(item + " is NOT a number.");    
                }
            }

            // Check the Digit Length.
            if (input.Length <= 9) { errors.Add("Digit length is not equal to 10.");}
            if (input.Length >= 10) { errors.Add("Digit length is too long."); }


            // Check if the input is present and has 10 characters.
            if (errors.Count == 0)
            {
                // Sanitize the input 
                input = Regex.Replace(input, "[(|)|-|]", "");
                
                
                var output = input.Insert(0, "(");
                    output += input.Insert(3, ")");
                    output += input.Insert(6, "-");

                return output;


            } else
            {
                return errors[0].ToString();
            }
        }
    }


}

