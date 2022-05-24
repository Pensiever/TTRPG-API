CREATE TABLE [dbo].[FavoriteGames]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [QuesterId] INT NOT NULL, 
    [GameId] INT NOT NULL, 
    CONSTRAINT [FK_Quester3] FOREIGN KEY (QuesterId) REFERENCES Questers(Id), 
    CONSTRAINT [FK_Game] FOREIGN KEY (GameId) REFERENCES Games(Id)
)
