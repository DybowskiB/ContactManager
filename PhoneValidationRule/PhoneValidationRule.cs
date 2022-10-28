using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ContactManager
{
    public interface IValidationP
    {
        string Name { get; }
        string Description { get; }
    }
    public class PhoneValidationRule : ValidationRule, IValidationP
    {
        public string Name => "PhoneValidationRule";

        public string Description => "Value is not correct phone number!";

        public int MinimumCharacters = 5;

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string valueToCheck = value as string;

            if (!Regex.IsMatch(valueToCheck, @"[0-9][0-9][0-9]-[0-9][0-9][0-9]-[0-9][0-9][0-9]$"))
            {
                return new ValidationResult(false, Description);
            }

            return new ValidationResult(true, null);
        }
    }
}
