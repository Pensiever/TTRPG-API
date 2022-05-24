CREATE TABLE [dbo].[Contributions]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [QuesterId] INT NOT NULL, 

    CONSTRAINT [FK_Quester4] FOREIGN KEY (QuesterId) REFERENCES Questers(Id)
)
