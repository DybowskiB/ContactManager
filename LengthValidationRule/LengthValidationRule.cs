using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace ContactManager
{
    public interface IValidationL
    {
        string Name { get; }
        string Description { get; }
    }
    public class LengthValidationRule : ValidationRule, IValidationL
    {
        public string Name => "LengthValidationRule";

        public string Description => "Value must have at least 5 characters!";

        public int MinimumCharacters = 5;

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string valueToCheck = value as string;

            if (valueToCheck.Length < 5)
                return new ValidationResult(false, Description);

            return new ValidationResult(true, null);
        }
    }
}