using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;

namespace ContactManager
{
    /// <summary>
    /// Static class with common variables among windows - contactList.
    /// </summary>
    public static class ContactList
    {
        static public ObservableCollection<Contact> contacts;
    }


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            ContactList.contacts = new ObservableCollection<Contact>();
            this.DataContext = ContactList.contacts;
            InitializeComponent();
        }

        /// <summary>
        /// Buttons events.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This is a simple contact manager.", "Contact manager", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ContactList.contacts = new ObservableCollection<Contact>();
            this.DataContext = ContactList.contacts;
            contacts.ItemsSource = ContactList.contacts;
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var w = new AddContactWindow();
            w.Owner = this;
            IsEnabled = false;
            w.ShowDialog();
        }

        // Import contacts from .*files.
        private void ImportContacts_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog.Filter = "XML files (*.xml)|*.xml";

            if (openFileDialog.ShowDialog() == true)
            {
                StringBuilder stringBuilder = new StringBuilder(openFileDialog.FileName);
                StreamReader streamReader = new StreamReader(stringBuilder.ToString());
                var des = new XmlSerializer(typeof(ContactSerializable[]));
                ContactSerializable[] deserializedContacts = (ContactSerializable[])des.Deserialize(streamReader);
                ContactList.contacts = new ObservableCollection<Contact>();
                foreach (var contact in deserializedContacts)
                {
                    ContactList.contacts.Add(new Contact(contact));
                }
                this.DataContext = ContactList.contacts;
                contacts.ItemsSource = ContactList.contacts;
            }
        }

        // Export contacts to *.xml files.
        private void ExportContacts_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.CurrentDirectory;
            saveFileDialog.Filter = "XML files (*.xml)|*.xml";

            if (saveFileDialog.ShowDialog() == true)
            {
                List<ContactSerializable> cs = new List<ContactSerializable>();
                foreach (var c in ContactList.contacts.ToArray())
                {
                    cs.Add(new ContactSerializable(c));
                }
                var acs = cs.ToArray();
                StreamWriter sw = new StreamWriter(saveFileDialog.FileName);
                var aSerializer = new XmlSerializer(typeof(ContactSerializable[]));
                aSerializer.Serialize(sw, acs);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            ContactList.contacts.RemoveAt(this.contacts.SelectedIndex);
            this.contacts.ItemsSource = ContactList.contacts;
        }
    }

    // Data template selector
    public class ListDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;
            MainWindow mainWindow = Application.Current.Windows[0] as MainWindow;
            Contact selectedItem = (Contact)mainWindow.contacts.SelectedItem;

            if(ContactList.contacts.Count == 0) return element.FindResource("UnselectedDataTemplate") as DataTemplate;
            if ((Contact)item == selectedItem) return element.FindResource("SelectedDataTemplate") as DataTemplate;
            return element.FindResource("UnselectedDataTemplate") as DataTemplate;
        }
    }
}
