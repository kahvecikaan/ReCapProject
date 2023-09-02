using Core.Entities;

namespace Entities.Concrete;

public class Customer : IEntity
{
    public int CustomerId { get; set; }
    public int UserId { get; set; } // Foreign key
    public string? CompanyName { get; set; }  
}