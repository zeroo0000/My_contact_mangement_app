using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.IO;
using ContactsManagement.Services;
 
var builder = WebApplication.CreateBuilder(args);
 
// Add services to the container.
builder.Services.AddControllers(); // Adds controller services to the application.
 
// Register services
builder.Services.AddScoped<IContactService, ContactService>(); // Registers the ContactService with a scoped lifetime.
 
// Add CORS (Cross-Origin Resource Sharing) policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDev", builder =>
    {
        builder.WithOrigins("http://localhost:4200") // Allows requests from the specified origin.
               .AllowAnyMethod() // Allows any HTTP method (GET, POST, etc.).
               .AllowAnyHeader(); // Allows any HTTP headers.
    });
});
 
var app = builder.Build(); // Builds the application pipeline.
 
app.UseHttpsRedirection(); // Redirects HTTP requests to HTTPS.
app.UseCors("AllowAngularDev"); // Applies the CORS policy defined earlier.
app.UseAuthorization(); // Adds authorization middleware.
app.MapControllers(); // Maps controller routes.
 
// Ensure Data directory exists
var dataPath = Path.Combine(app.Environment.ContentRootPath, "Data");
if (!Directory.Exists(dataPath))
{
    Directory.CreateDirectory(dataPath); // Creates the Data directory if it doesn't exist.
}
 
app.Run(); // Runs the application