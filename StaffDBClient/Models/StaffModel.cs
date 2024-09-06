namespace StaffDBClient.Models
{
	public class StaffModel
	{
		public int Id { get; set; }
		public string firstName { get; set; }
		public string lastName { get; set; }
		public required string email { get; set; }
		public DateTime enrolledDate { get; set; }
		public bool active { get; set; }
		public string? bankAccount { get; set; }
	}
}
