namespace ContactsManagement.DTOs
{
    // Data Transfer Object (DTO) class for a contact
    public class ContactDTO
    {
        public string FirstName { get; set; } = string.Empty; // First name of the contact
        public string LastName { get; set; } = string.Empty; // Last name of the contact
        public string Email { get; set; } = string.Empty; // Email address of the contact
    }
}