using System.Globalization;
using System.Text.RegularExpressions;

namespace ConsoleAppsBasicLevel
{
    public class ContactManager {
        private List<Contact> contacts = new List<Contact>();

        private Dictionary<string, List<Contact>> contactsByCategory = new Dictionary<string, List<Contact>>();
        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;


        public bool AddContactToList(string name, string phoneNumber, string? email, string category) {
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Error: Name cannot be empty");
                return false;
            }
            
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

            if (CategoryExists(category))
            {
                Console.WriteLine($"The Category already exists");
                return false;
            }

            if (string.IsNullOrWhiteSpace(category))
            {
                Console.WriteLine("Error: Category cannot be empty");
                return false;
            }

            contacts.Add(new Contact (name, phoneNumber, email, category));
            AddContactwithCategory(category, contacts);
            // SaveContactsToFile(contacts);   
            Console.WriteLine($"User {name} added succesfully.");
            return true;
        }

        public void ReadContactsFromFile() {
            string filePath = "/home/alexsc03/Documents/Projects/DotNet/MyCSharpProjects/ConsoleAppsBasicLevel/contacts.txt";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("No contacts file found. Starting with an empty list.");
            }

            try
            {
                using (StreamReader file = new StreamReader(filePath))
                {
                    string line;
                    string headerline = file.ReadLine();
                    while ((line = file.ReadLine()) != null) {
                        string[] items = line.Split(',');
                        if (items.Length >= 2)
                        {
                            contacts.Add(new Contact (items[0], items[1], items.Length > 2 ? items[2] : null, items[3]));
                        }
                    }
                }
               
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public void SaveContactsToFile(List<Contact> contacts) {
            string filePath = "/home/alexsc03/Documents/Projects/DotNet/MyCSharpProjects/ConsoleAppsBasicLevel/contacts.txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    foreach (var contact in contacts)
                    {
                        sw.WriteLine($"{contact.Name},{contact.PhoneNumber},{contact.Email}");
                    }
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Error saving contacts: " + e.Message);
            }
        }

        public bool SearchContactByName(string name) {

            if (string.IsNullOrWhiteSpace(name))
            {
                System.Console.WriteLine("Error: the name cannot be empty");
                return false;
            }

            if (!Regex.IsMatch(name.Trim(), @"^[a-zA-Z\s]+$"))
            {
                Console.WriteLine("Error: contact name not valid");
                return false;
            }

            // Checking if does not exist (name).
            var contactsPartialSearched = contacts.Where(c => c.Name.StartsWith(name.Trim(), StringComparison.InvariantCultureIgnoreCase)).ToList();

            if (contactsPartialSearched.Count == 0)
            {
                Console.WriteLine("Contact was not found");
                return false;
            }

            foreach (var item in contactsPartialSearched)
            {
                Console.WriteLine(item);
            }
            return true;
        }

        public void DisplayAllContacts() {
            if (contacts.Count == 0)
            {
                Console.WriteLine("The contact list is empty");
            }
            var sortedContacts = contacts.OrderBy(contact => contact.Name).ToList();

           foreach (var contact in sortedContacts)
            {
                Console.WriteLine($"Name: {contact.Name}, Phone: {contact.PhoneNumber}, Email: {contact.Email}, Category: {contact.Category}");
            }
        }

        public bool AddContactwithCategory(string category, List<Contact> contacts)
        {
            contactsByCategory.Add(category, contacts);
            return true;
        }

        // Check this method.
        public void DisplayContactsByCategory(string category) 
        {
            if (contactsByCategory.Count == 0)
            {
                Console.WriteLine("The contact dictionary is empty");
            }

            var dictionary = contactsByCategory.Where(dict => dict.Key == category).ToList();

            foreach (var dict in dictionary)
            {
                
                foreach (var contact in dict.Value)
                {
                    Console.WriteLine($"Name: {contact.Name}, Phone: {contact.PhoneNumber}, Email: {contact.Email}, Category: {contact.Category}");
                }
            }
        }

        private bool ContactExists(string name) {
            return contacts.Exists(contact => contact.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
            // Check this validation.
        private bool CategoryExists(string category) {
            return contacts.Exists(contact => contact.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
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

