using System;
using System.Globalization;
using System.Windows.Data;

namespace ContactManager
{
    public class DisplayConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            => (string)values[0] + " " + (string)values[1] + " " + (string)values[2] + " " + (string)values[3] + " " + (string)values[4];

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) 
            => throw new NotImplementedException();
    }

    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => (Gender)value == Gender.Male ? "\\Image\\man.png" : "\\Image\\woman.jpg";

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }

    public class ValidationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string choice = (string)value;

            if (choice == "Content length rule") return 0;
            if (choice == "E-Mail rule") return 1;
            if (choice == "Phone rule") return 2;
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
