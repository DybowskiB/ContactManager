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
    public interface IValidationE
    {
        string Name { get; }
        string Description { get; }
    }
    public class EMailValidationRule : ValidationRule, IValidationE
    {
        public string Name => "EMailValidationRule";

        public string Description => "Value is not correct e-mail address!";

        public int MinimumCharacters = 5;

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string valueToCheck = value as string;

            if (!Regex.IsMatch(valueToCheck, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                return new ValidationResult(false, Description);
            }

            return new ValidationResult(true, null);
        }
    }
}