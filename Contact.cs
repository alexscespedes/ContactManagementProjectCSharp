namespace ConsoleAppsBasicLevel
{
    public class Contact {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email {get; set;}

        public string Category { get; set; }

        public Contact (string name, string phoneNumber, string? email, string category) {
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            Category = category;
        }
    }

}

