using Core.Entities;

namespace Entities.Concrete;

// The design implies that the Customer entity is an extension of the User entity.
// Every customer is a user, but not every user is necessarily a customer.
public class User : IEntity
{
    public int UserId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}