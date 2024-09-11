using System.ComponentModel.DataAnnotations;

namespace StaffDBFront.Models
{
	public class Staff
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "First name is required")]
		[MaxLength(50, ErrorMessage = "Max first name characters: 50")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Last name is required")]
		[MaxLength(50, ErrorMessage = "Maximum last name characters: 50")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Email is required")]
		[MaxLength(50, ErrorMessage = "Max Email characters: 50")]
		[EmailAddress(ErrorMessage = "Invalid Email Address")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Enrolled date required")]
		public DateTime EnrolledDate { get; set; } = DateTime.Today;
		public bool Active { get; set; }

		[RegularExpression(@"^\d{10}$|^$" , ErrorMessage = "Bank Account must be exactly 10 digits or empty")]
		public string? BankAccount { get; set; } = string.Empty;
	}
}
