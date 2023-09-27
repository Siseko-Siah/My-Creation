CREATE TABLE [dbo].[Makes] (
    [Name]   INT            IDENTITY (1, 1) NOT NULL,
    [Email] NVARCHAR (255) NOT NULL,
    [Address] NCHAR(10) NOT NULL, 
    [Phone] INT NOT NULL, 
    [Action] NCHAR(10) NOT NULL, 
    PRIMARY KEY CLUSTERED ([Name] ASC)
);

