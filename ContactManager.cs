using System.Text.RegularExpressions;

namespace ConsoleAppsBasicLevel
{
        class ContactManager {
        private List<Contact> contacts = new List<Contact>();

        public bool AddContactToList(List<Contact> contacts, string name, string phoneNumber, string? email) {
            if (!ContactExists(name))
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
    }
}

