CREATE TABLE [dbo].[Backgrounds]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Image] NVARCHAR(50) NOT NULL, 
    [NavTop] VARCHAR(6) NOT NULL, 
    [NavTopFont] VARCHAR(6) NOT NULL, 
    [NavSide] VARCHAR(6) NOT NULL, 
    [NavSideFont] VARCHAR(6) NOT NULL, 
    [NavSideButton] VARCHAR(6) NOT NULL, 
    [Footer] VARCHAR(6) NOT NULL, 
    [FooterFont] VARCHAR(6) NOT NULL
)
