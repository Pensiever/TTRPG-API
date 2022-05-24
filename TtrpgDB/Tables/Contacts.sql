CREATE TABLE [dbo].[Contacts]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [QuesterId] INT NOT NULL, 
    [ContactId] INT NOT NULL, 
    CONSTRAINT [FK_Quester] FOREIGN KEY (QuesterId) REFERENCES Questers(Id), 
    CONSTRAINT [FK_Contact] FOREIGN KEY (ContactId) REFERENCES Questers(Id)
)
