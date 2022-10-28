using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace ContactManager
{
    public interface IValidation
    {
        string Name { get; }
        string Description { get; }
    }

    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notify a property change
        /// </summary>
        /// <param name="propertyName">Name of property to update</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Notify a property change that uses CallerMemberName attribute
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="backingField">Backing field of property</param>
        /// <param name="value">Value to give backing field</param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected virtual bool OnPropertyChanged<T>(ref T backingField, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
                return false;

            backingField = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }

    public class ValidationValuesClass: ObservableObject
    {
        private string name;
        private string surname;
        private string eMail;
        private string phone;
        public string Name
        {
            get { return name; }
            set
            {
                OnPropertyChanged(ref name, value);
            }
        }

        public string Surname
        {
            get { return surname; }
            set
            {
                OnPropertyChanged(ref surname, value);
            }
        }

        public string EMail
        {
            get { return eMail; }
            set
            {
                OnPropertyChanged(ref eMail, value);
            }
        }

        public string Phone
        {
            get { return phone; }
            set
            {
                OnPropertyChanged(ref phone, value);
            }
        }
    }
}
