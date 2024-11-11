namespace ContactsManagement.DTOs
{
    // Generic class for API responses
    public class ApiResponse<T>
    {
        public bool Success { get; set; } // Indicates if the API call was successful
        public string Message { get; set; } = string.Empty; // Message providing additional information about the response
        public T? Data { get; set; } // Generic data payload of the response, can be any type
    }
}