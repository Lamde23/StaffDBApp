--Queries if staff exists from DB and returns Id.
--Otherwise creates new staff, returns Id
--For use when querying staff and payment together. 

CREATE PROCEDURE [dbo].[spStaff_Upsert]
	@StaffId int output,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Email nvarchar(50),
	@EnrolledDate date,
	@Active bit,
	@BankAccount nchar(10)
AS
begin
	if exists (select 1 from Staff where Email = @Email)
	begin
		update Staff set
			FirstName = @FirstName,
			LastName = @LastName
		where Email = @Email;
		select @StaffId = Id from Staff	where Email = @Email;
	end
	else
	begin
		insert into Staff (FirstName, LastName, Email, EnrolledDate, Active, BankAccount)
		values (@FirstName, @LastName, @Email, @EnrolledDate, @Active, @BankAccount);
		--Takes lastest Id from current scope procedure(begin-end)
		select @StaffId = SCOPE_IDENTITY();
	end

end