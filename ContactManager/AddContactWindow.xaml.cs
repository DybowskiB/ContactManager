using System.Text.RegularExpressions;
using System.Windows;

namespace ContactManager
{
    /// <summary>
    /// Interaction logic for AddContactWindow.xaml
    /// </summary>
    public partial class AddContactWindow : Window
    {
        public AddContactWindow() => InitializeComponent();

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Application.Current.Windows[0] as MainWindow;
            mainWindow.IsEnabled = true;
            Close();
        }

        private void AddContactButton_Click(object sender, RoutedEventArgs e)
        {
            if (AddWindowName.Text.Length >= 5 && AddWindowSurname.Text.Length >= 5 &&
                Regex.IsMatch(AddWindowEMail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$") &&
                Regex.IsMatch(AddWindowPhone.Text, @"[0-9][0-9][0-9]-[0-9][0-9][0-9]-[0-9][0-9][0-9]$"))
            {
                ContactList.contacts.Add(new Contact(AddWindowName.Text, AddWindowSurname.Text, AddWindowEMail.Text, AddWindowPhone.Text,
                    (AddContactWindowGender.SelectedIndex == 0) ? Gender.Male : Gender.Female));
                MainWindow mainWindow = Application.Current.Windows[0] as MainWindow;
                mainWindow.IsEnabled = true;
                Close();
            }
        }
    }
}
