CREATE TABLE [dbo].[Questers]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Username] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(50) NOT NULL, 
    [Password] NVARCHAR(50) NOT NULL, 
    [BirthDate] DATETIME2 NOT NULL, 
    [IsActive] BIT NOT NULL DEFAULT 1, 
    [IsAdmin] BIT NOT NULL DEFAULT 0, 
    [IsBanned] BIT NOT NULL DEFAULT 0, 
    [Strikes] INT NOT NULL DEFAULT 0, 
    [BackgroundId] INT NOT NULL DEFAULT 1,
    [Bio] NVARCHAR(50) NULL,
    [OnlinePlay] BIT NOT NULL DEFAULT 0, 
    [OfflinePlay] BIT NOT NULL DEFAULT 0, 
    [PostalCode] INT NULL ,

    CONSTRAINT [FK_Background] FOREIGN KEY (BackgroundId) REFERENCES Backgrounds(Id)
)
