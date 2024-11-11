using Microsoft.AspNetCore.Mvc;
using ContactsManagement.Services;
using ContactsManagement.DTOs;
using System.ComponentModel.DataAnnotations;
using ContactsManagement.Models;
 
namespace ContactsManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly ILogger<ContactsController> _logger;
 
        // Constructor to inject the contact service and logger
        public ContactsController(IContactService contactService, ILogger<ContactsController> logger)
        {
            _contactService = contactService;
            _logger = logger;
        }
 
        // GET: api/contacts
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<Contact>>>> GetContacts()
        {
            try
            {
                // Retrieve all contacts asynchronously
                var contacts = await _contactService.GetAllContactsAsync();
                // Return a successful response with the list of contacts
                return Ok(new ApiResponse<List<Contact>>
                {
                    Success = true,
                    Data = contacts,
                    Message = "Contacts retrieved successfully"
                });
            }
            catch (Exception ex)
            {
                // Log the error and return a 500 status code with an error message
                _logger.LogError(ex, "Error retrieving contacts");
                return StatusCode(500, new ApiResponse<List<Contact>>
                {
                    Success = false,
                    Message = "An error occurred while retrieving contacts"
                });
            }
        }
 
        // GET: api/contacts/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<Contact>>> GetContact(int id)
        {
            try
            {
                // Retrieve a contact by ID asynchronously
                var contact = await _contactService.GetContactByIdAsync(id);
                if (contact == null)
                {
                    // Return a 404 status code if the contact is not found
                    return NotFound(new ApiResponse<Contact>
                    {
                        Success = false,
                        Message = "Contact not found"
                    });
                }
 
                // Return a successful response with the contact data
                return Ok(new ApiResponse<Contact>
                {
                    Success = true,
                    Data = contact,
                    Message = "Contact retrieved successfully"
                });
            }
            catch (Exception ex)
            {
                // Log the error and return a 500 status code with an error message
                _logger.LogError(ex, "Error retrieving contact");
                return StatusCode(500, new ApiResponse<Contact>
                {
                    Success = false,
                    Message = "An error occurred while retrieving the contact"
                });
            }
        }
 
        // POST: api/contacts
        [HttpPost]
        public async Task<ActionResult<ApiResponse<Contact>>> CreateContact([FromBody] ContactDTO contactDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    // Return a 400 status code if the model state is invalid
                    return BadRequest(new ApiResponse<Contact>
                    {
                        Success = false,
                        Message = "Invalid contact data"
                    });
                }
 
                // Create a new contact asynchronously
                var contact = await _contactService.CreateContactAsync(contactDto);
                // Return a 201 status code with the created contact data
                return CreatedAtAction(nameof(GetContact), new { id = contact.Id },
                    new ApiResponse<Contact>
                    {
                        Success = true,
                        Data = contact,
                        Message = "Contact created successfully"
                    });
            }
            catch (Exception ex)
            {
                // Log the error and return a 500 status code with an error message
                _logger.LogError(ex, "Error creating contact");
                return StatusCode(500, new ApiResponse<Contact>
                {
                    Success = false,
                    Message = "An error occurred while creating the contact"
                });
            }
        }
 
        // PUT: api/contacts/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<Contact>>> UpdateContact(int id, [FromBody] ContactDTO contactDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    // Return a 400 status code if the model state is invalid
                    return BadRequest(new ApiResponse<Contact>
                    {
                        Success = false,
                        Message = "Invalid contact data"
                    });
                }
 
                // Update an existing contact asynchronously
                var contact = await _contactService.UpdateContactAsync(id, contactDto);
                if (contact == null)
                {
                    // Return a 404 status code if the contact is not found
                    return NotFound(new ApiResponse<Contact>
                    {
                        Success = false,
                        Message = "Contact not found"
                    });
                }
 
                // Return a successful response with the updated contact data
                return Ok(new ApiResponse<Contact>
                {
                    Success = true,
                    Data = contact,
                    Message = "Contact updated successfully"
                });
            }
            catch (Exception ex)
            {
                // Log the error and return a 500 status code with an error message
                _logger.LogError(ex, "Error updating contact");
                return StatusCode(500, new ApiResponse<Contact>
                {
                    Success = false,
                    Message = "An error occurred while updating the contact"
                });
            }
        }
 
        // DELETE: api/contacts/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteContact(int id)
        {
            try
            {
                // Delete a contact by ID asynchronously
                var success = await _contactService.DeleteContactAsync(id);
                if (!success)
                {
                    // Return a 404 status code if the contact is not found
                    return NotFound(new ApiResponse<bool>
                    {
                        Success = false,
                        Message = "Contact not found"
                    });
                }
 
                // Return a successful response indicating the contact was deleted
                return Ok(new ApiResponse<bool>
                {
                    Success = true,
                    Data = true,
                    Message = "Contact deleted successfully"
                });
            }
            catch (Exception ex)
            {
                // Log the error and return a 500 status code with an error message
                _logger.LogError(ex, "Error deleting contact");
                return StatusCode(500, new ApiResponse<bool>
                {
                    Success = false,
                    Message = "An error occurred while deleting the contact"
                });
            }
        }
    }
 
}