CREATE TABLE [dbo].[Staff]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(50) NOT NULL,
    [EnrolledDate] DATETIME NOT NULL, 
    [Active] BIT NOT NULL, 
    [BankAccount] NCHAR(10) NULL, 

)
