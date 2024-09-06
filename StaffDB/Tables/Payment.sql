CREATE TABLE [dbo].[Payment] (
    [Id]       INT      NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [StaffId]  INT      NOT NULL,
    [DatePaid] DATETIME NOT NULL,
    [Amount]   MONEY    NOT NULL,
    [WorkFrom] DATETIME NULL, 
    [WorkTo] DATETIME NULL, 
);

