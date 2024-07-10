namespace CRM_API.Entities;

public class EUser : EBase
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Mobile { get; set; }
    public string Address { get; set; }
    public int Age { get; set; }
}