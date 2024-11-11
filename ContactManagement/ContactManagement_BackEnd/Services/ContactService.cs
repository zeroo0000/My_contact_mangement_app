using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using ContactsManagement.Models;
using ContactsManagement.DTOs;
 
namespace ContactsManagement.Services
{
    public class ContactService : IContactService
    {
        private readonly string _dataPath = "Data/contacts.json"; // Path to the JSON file storing contacts.
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1); // Semaphore to ensure thread safety.
 
        public ContactService()
        {
            var directory = Path.GetDirectoryName(_dataPath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory); // Creates the directory if it doesn't exist.
            }
        }
 
        private async Task<List<Contact>> LoadContactsAsync()
        {
            if (!File.Exists(_dataPath))
            {
                return new List<Contact>(); // Returns an empty list if the file doesn't exist.
            }
 
            var jsonString = await File.ReadAllTextAsync(_dataPath); // Reads the JSON file.
            return JsonSerializer.Deserialize<List<Contact>>(jsonString) ?? new List<Contact>(); // Deserializes the JSON to a list of contacts.
        }
 
        private async Task SaveContactsAsync(List<Contact> contacts)
        {
            var jsonString = JsonSerializer.Serialize(contacts, new JsonSerializerOptions { WriteIndented = true }); // Serializes the list of contacts to JSON.
            await File.WriteAllTextAsync(_dataPath, jsonString); // Writes the JSON to the file.
        }
 
        public async Task<List<Contact>> GetAllContactsAsync()
        {
            await _semaphore.WaitAsync(); // Waits to enter the semaphore.
            try
            {
                return await LoadContactsAsync(); // Loads and returns all contacts.
            }
            finally
            {
                _semaphore.Release(); // Releases the semaphore.
            }
        }
 
        public async Task<Contact?> GetContactByIdAsync(int id)
        {
            await _semaphore.WaitAsync(); // Waits to enter the semaphore.
            try
            {
                var contacts = await LoadContactsAsync(); // Loads all contacts.
                return contacts.FirstOrDefault(c => c.Id == id); // Returns the contact with the specified ID.
            }
            finally
            {
                _semaphore.Release(); // Releases the semaphore.
            }
        }
 
        public async Task<Contact> CreateContactAsync(ContactDTO contactDto)
        {
            await _semaphore.WaitAsync(); // Waits to enter the semaphore.
            try
            {
                var contacts = await LoadContactsAsync(); // Loads all contacts.
                var newId = contacts.Any() ? contacts.Max(c => c.Id) + 1 : 1; // Determines the new contact ID.
 
                var contact = new Contact
                {
                    Id = newId,
                    FirstName = contactDto.FirstName,
                    LastName = contactDto.LastName,
                    Email = contactDto.Email
                };
 
                contacts.Add(contact); // Adds the new contact to the list.
                await SaveContactsAsync(contacts); // Saves the updated list of contacts.
 
                return contact; // Returns the newly created contact.
            }
            finally
            {
                _semaphore.Release(); // Releases the semaphore.
            }
        }
 
        public async Task<Contact?> UpdateContactAsync(int id, ContactDTO contactDto)
        {
            await _semaphore.WaitAsync(); // Waits to enter the semaphore.
            try
            {
                var contacts = await LoadContactsAsync(); // Loads all contacts.
                var contact = contacts.FirstOrDefault(c => c.Id == id); // Finds the contact with the specified ID.
 
                if (contact == null)
                    return null; // Returns null if the contact doesn't exist.
 
                contact.FirstName = contactDto.FirstName;
                contact.LastName = contactDto.LastName;
                contact.Email = contactDto.Email;
 
                await SaveContactsAsync(contacts); // Saves the updated list of contacts.
 
                return contact; // Returns the updated contact.
            }
            finally
            {
                _semaphore.Release(); // Releases the semaphore.
            }
        }
 
        public async Task<bool> DeleteContactAsync(int id)
        {
            await _semaphore.WaitAsync(); // Waits to enter the semaphore.
            try
            {
                var contacts = await LoadContactsAsync(); // Loads all contacts.
                var contact = contacts.FirstOrDefault(c => c.Id == id); // Finds the contact with the specified ID.
 
                if (contact == null)
                    return false; // Returns false if the contact doesn't exist.
 
                contacts.Remove(contact); // Removes the contact from the list.
                await SaveContactsAsync(contacts); // Saves the updated list of contacts.
 
                return true; // Returns true indicating the contact was deleted.
            }
            finally
            {
                _semaphore.Release(); // Releases the semaphore.
            }
        }
    }
 
}