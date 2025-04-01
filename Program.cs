using System;

namespace ConsoleAppsBasicLevel
{
    class Program
    {
        static void Main(string[] args)
        {
            ContactManager contactManager = new ContactManager();
            contactManager.ReadContactsFromFile();
            bool exit = false;

            while (!exit) {
                Console.WriteLine("\nContact Manager");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Search by Name");
                Console.WriteLine("3. Display Contacts");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                if (!int.TryParse(Console.ReadLine(), out int userInput)) 
                {
                    System.Console.WriteLine("Invalid input! Please enter a number between 1 and 4");
                    continue;
                }

                switch(userInput) {
                    case 1:
                        Console.Write("Enter a Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter a Phone: ");
                        string phone = Console.ReadLine();
                        Console.Write("Enter an Email: ");
                        string? email = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(email)) email = null;
                        contactManager.AddContactToList(name, phone, email);
                        break;

                    case 2:
                        Console.Write("Enter a Name: ");
                        name = Console.ReadLine();
                        contactManager.SearchContactByName(name);
                        break;

                    case 3:
                        contactManager.DisplayAllContacts();
                        break;

                    case 4:
                        exit = true;
                        Console.WriteLine("Exiting program...");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;       
                }
            }

        }
    }
}
