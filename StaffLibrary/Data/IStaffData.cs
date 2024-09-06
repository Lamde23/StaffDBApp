
namespace StaffLibrary.Data
{
    public interface IStaffData
    {
        Task<List<StaffModel>> GetStaff();
        Task InsertStaffAsync(StaffModel data);
        Task InsertPaymentAsync(StaffPaymentModel data);

    }
}