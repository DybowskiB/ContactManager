using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace ContactManager
{
    //public class PhoneValidationRule : ValidationRule, IValidation
    //{
    //    public string Name => "PhoneValidationRule";

    //    public string Description => "Value is not correct phone number!";

    //    public int MinimumCharacters = 5;

    //    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    //    {
    //        string valueToCheck = value as string;

    //        if (!Regex.IsMatch(valueToCheck, @"[0-9][0-9][0-9]-[0-9][0-9][0-9]-[0-9][0-9][0-9]$"))
    //        {
    //            return new ValidationResult(false, Description);
    //        }

    //        return new ValidationResult(true, null);
    //    }
    //}
}
