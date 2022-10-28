using System;

namespace ContactManager
{
    public enum Gender { Male, Female };
    public class Contact
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }

        public Contact() { }
        public Contact(string Name = "", string Surname = "", string EMail = "", string PhoneNumber = "", Gender Gender = Gender.Male)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.EMail = EMail;
            this.PhoneNumber = PhoneNumber;
            this.Gender = Gender;
        }
        public Contact(ContactSerializable contact)
        {
            this.Name = contact.Name;
            this.Surname = contact.Surname;
            this.EMail = contact.EMail;
            this.PhoneNumber = contact.PhoneNumber;
            this.Gender = contact.Gender;
        }
    }
    public class ContactSerializable
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public ContactSerializable()
        {
            this.Name = "";
            this.Surname = "";
            this.EMail = "";
            this.PhoneNumber = "";
            this.Gender = Gender.Male;
        }
        public ContactSerializable(Contact contact)
        {
            this.Name = contact.Name;
            this.Surname = contact.Surname;
            this.EMail = contact.EMail;
            this.PhoneNumber = contact.PhoneNumber;
            this.Gender = contact.Gender;
        }
    }
}
