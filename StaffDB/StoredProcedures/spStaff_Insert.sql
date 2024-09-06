CREATE PROCEDURE [dbo].[spStaff_Insert]
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Email nvarchar(50),
	@EnrolledDate date,
	@Active bit,
	@BankAccount nchar(10)
AS
begin
	insert into Staff (FirstName, LastName, Email, EnrolledDate, Active, BankAccount)
	values (@FirstName, @LastName, @Email, @EnrolledDate, @Active, @BankAccount);
end