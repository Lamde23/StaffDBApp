using System.ComponentModel.DataAnnotations;

namespace StaffDBFront.Models
{
	public class Staff
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

		[Required(ErrorMessage = "Email is required")]
		[EmailAddress(ErrorMessage = "Invalid Email Address")]
		public string Email { get; set; } = string.Empty;
		public DateTime EnrolledDate { get; set; }
		public bool Active { get; set; }

		[RegularExpression(@"^\d{10}$|^$" , ErrorMessage = "Bank Account must be exactly 10 digits")]
		public string? BankAccount { get; set; } = string.Empty;
	}
}
