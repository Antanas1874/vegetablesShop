CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY(Id), 
    [email] NCHAR(100) NULL, 
    [password] NCHAR(100) NULL, 
    [role] NCHAR(20) NULL
)
