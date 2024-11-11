using System.Collections.Generic;
using System.Threading.Tasks;
using ContactsManagement.Models;
using ContactsManagement.DTOs;
 
namespace ContactsManagement.Services
{
    // Interface for contact service
    public interface IContactService
    {
        // Asynchronously gets all contacts
        Task<List<Contact>> GetAllContactsAsync();
 
        // Asynchronously gets a contact by its ID
        Task<Contact?> GetContactByIdAsync(int id);
 
        // Asynchronously creates a new contact from a DTO
        Task<Contact> CreateContactAsync(ContactDTO contactDto);
 
        // Asynchronously updates an existing contact by its ID using a DTO
        Task<Contact?> UpdateContactAsync(int id, ContactDTO contactDto);
 
        // Asynchronously deletes a contact by its ID
        Task<bool> DeleteContactAsync(int id);
    }
}