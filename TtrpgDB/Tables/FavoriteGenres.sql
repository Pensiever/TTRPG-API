CREATE TABLE [dbo].[FavoriteGenres]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [QuesterId] INT NOT NULL, 
    [GenreId] INT NOT NULL,
    
    CONSTRAINT [FK_Quester2] FOREIGN KEY (QuesterId) REFERENCES Questers(Id), 
    CONSTRAINT [FK_Genre] FOREIGN KEY (GenreId) REFERENCES Genres(Id)
)
