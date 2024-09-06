using Dapper;
using System.Data;

namespace StaffLibrary.Data;

public class StaffData : IStaffData
{
    private readonly ISqlDataAccess _db;

    public StaffData(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<List<StaffModel>> GetStaff()
    {
        var output =  await _db.LoadDataAsync<StaffModel, dynamic>("dbo.spStaff_GetAll", new { });
        return output;
    }

    public async Task InsertStaffAsync(StaffModel data)
    {
        DynamicParameters p = new DynamicParameters();
        p.Add("@FirstName", data.FirstName);
        p.Add("@LastName", data.LastName);
        p.Add("@Email", data.Email);
        p.Add("@EnrolledDate", data.EnrolledDate);
        p.Add("@Active", data.Active);
        p.Add("@BankAccount", data.BankAccount ?? null);

        await _db.InsertStaffAsync("dbo.spStaff_Insert", p);
    }

    public async Task InsertPaymentAsync(StaffPaymentModel data)
    {
        //Finds current staff otherwise creates new staff
        DynamicParameters p = new();
        p.Add("@StaffId", dbType: DbType.Int32, direction: ParameterDirection.Output);
        p.Add("@FirstName", data.FirstName);
        p.Add("@LastName", data.LastName);
        p.Add("@Email", data.Email);

        //DateOnly dateToday = DateOnly.FromDateTime(DateTime.Today);
        p.Add("@EnrolledDate", data.EnrolledDate);
        p.Add("@Active", data.Active);
        p.Add("@BankAccount", data.BankAccount ?? null);
        await _db.SaveDataAsync("dbo.spStaff_Upsert", p);

        int staffId = p.Get<int>("@StaffId");

        //inserts new payment to current staffId
        p = new();
        p.Add("StaffId", staffId);
        p.Add("@DatePaid", data.DatePaid);
        p.Add("@Amount", data.Amount);
        p.Add("@WorkFrom", data.WorkFrom);
        p.Add("@WorkTo", data.WorkTo);

        await _db.SaveDataAsync("dbo.spPayment_Insert", p);
    }
}
