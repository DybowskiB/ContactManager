using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContactManager
{
    /// <summary>
    /// Interaction logic for SetValidationSettingsPage.xaml
    /// </summary>
    public partial class SetValidationSettingsPage : Page
    {

        private NameModelString nameModelString = new NameModelString();
        private SurnameModelString surnameModelString = new SurnameModelString();
        private EMailModelString eMailModelString = new EMailModelString();
        private PhoneModelString viewModelString = new PhoneModelString();
        public SetValidationSettingsPage()
        {
            InitializeComponent();

            NameValidationCombobox.DataContext = nameModelString;
            SurnameValidationCombobox.DataContext = surnameModelString;
            EMailValidationCombobox.DataContext = eMailModelString;
            PhoneValidationCombobox.DataContext = viewModelString;
        }

        private void LockValidationSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("UnlockValidationSettingsPage.xaml", UriKind.RelativeOrAbsolute));
        }

    }

    public class ComboBoxItemString
    {
        public string ValueString { get; set; }
    }

    public static class NameValidationComboboxValue
    {
        public static string value { get; set; }
    }

    public static class SurnameValidationComboboxValue
    {
        public static string value { get; set; }
    }

    public static class EMailValidationComboboxValue
    {
        public static string value { get; set; }
    }

    public static class PhoneValidationComboboxValue
    { 
        public static string value { get; set; }
    }

    public class NameModelString : INotifyPropertyChanged
    {
        public NameModelString() { }

        public string Choice
        {
            get { return NameValidationComboboxValue.value; }
            set
            {
                if (NameValidationComboboxValue.value != value)
                {
                    NameValidationComboboxValue.value = value;
                    NotifyPropertyChanged("ColorString");
                }
            }
        }

        #region INotifyPropertyChanged Members
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }

    public class SurnameModelString : INotifyPropertyChanged
    {
        public SurnameModelString() { }

        public string Choice
        {
            get { return SurnameValidationComboboxValue.value; }
            set
            {
                if (SurnameValidationComboboxValue.value != value)
                {
                    SurnameValidationComboboxValue.value = value;
                    NotifyPropertyChanged("ColorString");
                }
            }
        }

        #region INotifyPropertyChanged Members
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }

    public class EMailModelString : INotifyPropertyChanged
    {
        public EMailModelString() { }

        public string Choice
        {
            get { return EMailValidationComboboxValue.value; }
            set
            {
                if (EMailValidationComboboxValue.value != value)
                {
                    EMailValidationComboboxValue.value = value;
                    NotifyPropertyChanged("ColorString");
                }
            }
        }

        #region INotifyPropertyChanged Members
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }

    public class PhoneModelString : INotifyPropertyChanged
    {
        public PhoneModelString() { }

        public string Choice
        {
            get { return PhoneValidationComboboxValue.value; }
            set
            {
                if (PhoneValidationComboboxValue.value != value)
                {
                    PhoneValidationComboboxValue.value = value;
                    NotifyPropertyChanged("ColorString");
                }
            }
        }

        #region INotifyPropertyChanged Members
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
