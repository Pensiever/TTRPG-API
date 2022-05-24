CREATE TABLE [dbo].[Transgressions]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [message] NVARCHAR(250) NOT NULL, 
    [QuesterId] INT NOT NULL,

    CONSTRAINT [FK_Quester5] FOREIGN KEY (QuesterId) REFERENCES Questers(Id)
)
