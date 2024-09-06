namespace StaffDBFront.Models
{
	public class Payment
	{	
		public int Id { get; set; }	
		public DateTime DatePaid { get; set; }
		public decimal Amount { get; set; }
		public DateTime WorkFrom { get; set; }
		public DateTime WorkTo { get; set; }
	}
}
