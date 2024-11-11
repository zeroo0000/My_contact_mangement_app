namespace ContactsManagement.Models
{
    // Model class representing a contact
    public class Contact
    {
        public int Id { get; set; } // Unique identifier for the contact
        public string FirstName { get; set; } = string.Empty; // First name of the contact
        public string LastName { get; set; } = string.Empty; // Last name of the contact
        public string Email { get; set; } = string.Empty; // Email address of the contact
    }
}