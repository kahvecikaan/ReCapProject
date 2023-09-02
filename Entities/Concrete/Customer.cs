using Core.Entities;

namespace Entities.Concrete;

// The design implies that the Customer entity is an extension of the User entity.
// Every customer is a user, but not every user is necessarily a customer.
public class Customer : IEntity
{
    public int CustomerId { get; set; }
    public int UserId { get; set; } // Foreign key
    public string? CompanyName { get; set; }  
}