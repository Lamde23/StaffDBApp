/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
if not exists (select * from dbo.Staff)
begin
    insert into dbo.Staff (FirstName, LastName, Email, EnrolledDate, Active, BankAccount)
    values
        ('Seymour', 'Skinner', 'Skinner@example.com', CAST(CAST(GETDATE() AS DATE) AS DATETIME), 1, '1234567890'),
        ('Edna', 'Krabappel', 'Krabappel@example.com', CAST(CAST(GETDATE() AS DATE) AS DATETIME), 1, '0987654321'),
        ('Willie', 'Groundskeeper', 'Willie@example.com', CAST(CAST(GETDATE() AS DATE) AS DATETIME), 1, '1122334455');
end