using System.ComponentModel.DataAnnotations;

namespace ElevenIsland.Core;

public class Customer
{
    [Key]
    public Guid Id { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Email { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public string PasswordHash { get; set; }
}