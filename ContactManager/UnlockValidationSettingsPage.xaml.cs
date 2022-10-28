using System;
using System.Collections.Generic;
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
    /// Interaction logic for UnlockValidationSettingsPage.xaml
    /// </summary>
    public partial class UnlockValidationSettingsPage : Page
    {
        public UnlockValidationSettingsPage()
        {
            InitializeComponent();
        }

        private void UnlockValidationSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navigation = NavigationService.GetNavigationService(this);
            navigation.Navigate(new Uri("SetValidationSettingsPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
