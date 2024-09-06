namespace StaffLibrary;

public class StaffModel
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public required string Email { get; set; }
    public DateTime EnrolledDate { get; set; }
    public bool Active { get; set; }
    public string? BankAccount { get; set; }
}
