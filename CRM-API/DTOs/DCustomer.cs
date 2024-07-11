namespace CRM_API.DTOs;

public class DCustomer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Mobile { get; set; }
    public string Address { get; set; }
    public int Age { get; set; }
    public DateTime CreatedAt { get; set; }
}