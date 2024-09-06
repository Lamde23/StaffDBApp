CREATE PROCEDURE [dbo].[spStaff_GetAll]
AS
begin
	select [Id], [FirstName], [LastName], [Email], [EnrolledDate], [Active], [BankAccount]
	from Staff
end