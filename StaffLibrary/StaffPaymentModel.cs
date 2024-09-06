namespace StaffLibrary;

public class StaffPaymentModel
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime EnrolledDate { get; set; }
    public bool Active { get; set; }
    public string? BankAccount { get; set; }


    public DateTime DatePaid { get; set; }  
    public decimal Amount { get; set; } 
    public DateTime WorkFrom { get; set; }
    public DateTime WorkTo { get; set; }

}
