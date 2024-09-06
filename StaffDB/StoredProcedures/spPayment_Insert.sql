CREATE PROCEDURE [dbo].[spPayment_Insert]
	@StaffId int,
	@DatePaid date,
	@Amount money,
	@WorkFrom date,
	@WorkTo date
AS
begin
	INSERT into Payment(StaffId, DatePaid, Amount, WorkFrom, WorkTo)
	VALUES (@StaffId, @DatePaid, @Amount, @WorkFrom, @WorkTo);
end