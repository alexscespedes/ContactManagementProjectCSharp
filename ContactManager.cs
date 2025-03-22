using System.Globalization;
using System.Text.RegularExpressions;

namespace ConsoleAppsBasicLevel
{
        class ContactManager {
        private List<Contact> contacts = new List<Contact>();
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;


        public bool AddContactToList(string name, string phoneNumber, string? email) {
            if (ContactExists(name))
            {
                Console.WriteLine($"The contact already exists");
                return false;
            }
            if (!IsValidPhoneNumber(phoneNumber))
            {
                Console.WriteLine($"Invalid phone number format.");
                return false;
            }
            if (!string.IsNullOrEmpty(email) && !IsValidEmail(email))
            {
                Console.WriteLine($"Invalid email format.");
                return false;
            }

            contacts.Add(new Contact (name, phoneNumber, email));
            Console.WriteLine($"User {name} added succesfully.");
            return true;

        }

        public Contact? SearchContactByName(string name) {

            if (string.IsNullOrWhiteSpace(name))
            {
                System.Console.WriteLine("Error: the name cannot be empty");
                return null;
            }

            if (!Regex.IsMatch(name.Trim(), @"^[a-zA-Z\s]+$"))
            {
                Console.WriteLine("Error: contact name not valid");
                return null;
            }

            var contact = contacts.FirstOrDefault(c => c.Name.Equals(name.Trim(), StringComparison.OrdinalIgnoreCase));

            if (contact == null)
            {
                Console.WriteLine("Contact was not found");
            }

            return contact;
        }

        public void DisplayAllContacts() {
            if (contacts.Count == 0)
            {
                Console.WriteLine("The contact list is empty");
            }
            var sortedContacts = contacts.OrderBy(contact => contact.Name).ToList();

           foreach (var contact in sortedContacts)
            {
                Console.WriteLine($"Name: {contact.Name}, Phone: {contact.PhoneNumber}, Email: {contact.Email}");
            }
        }

        private bool ContactExists(string name) {
            return contacts.Exists(contact => contact.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    
        private bool IsValidPhoneNumber(string phoneNumber) {
            // Validate formats as +8091119966, (829) 789-9632, 849-999-9999
            string pattern = @"^\+?[0-9\s\-\(\)]{7,15}$";
            return Regex.IsMatch(phoneNumber, pattern);
        }

        private bool IsValidEmail(string email) {
            // General email validation regex
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }        

        public void PrintContact() {
            foreach (var contact in contacts)
            {
                Console.WriteLine($"{contact.Name} {contact.PhoneNumber} {contact.Email}");
            }
        }
    }
}

