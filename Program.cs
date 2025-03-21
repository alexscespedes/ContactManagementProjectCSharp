﻿using System;

namespace ConsoleAppsBasicLevel
{
    class Program
    {
        static void Main(string[] args)
        {
            ContactManager contactManager = new ContactManager();
            bool exit = false;

            while (!exit) {
                Console.WriteLine("\nContact Manager");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Display Contacts");
                Console.WriteLine("3. Exit");
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

                    // case 2: Continuing here...
                        
                                        
                }
            }



            contactManager.AddContactToList("Chris", "789-123-1596", "chris@gmail.com");
            contactManager.AddContactToList("Alexander", "809-479-9651", "alex@gmail.com");
            contactManager.AddContactToList("Stefan", "000-183-1696", "stefan@gmail.com");
            contactManager.AddContactToList("Damon", "963-852-7411", "damon@gmail.com");

            // contactManager.PrintContact();
            var result = contactManager.SearchContactByName("Al");
            Console.WriteLine(result?.ToString());
            // contactManager.DisplayAllContacts();


        }
    }
}
