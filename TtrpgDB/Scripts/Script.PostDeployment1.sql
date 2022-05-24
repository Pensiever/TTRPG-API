INSERT INTO Backgrounds VALUES ('Default', '.\Backgrounds\Default Background.jpeg', '8c4930', 'ffffff', '6ab9c7', '000000', 'ffffff', '4c4c66', 'ffffff')

INSERT INTO Questers (Username, Email, [Password], BirthDate, isAdmin, Bio) VALUES ('Pensiever', 'ruben.ketsman@hotmail.be', 'Test1234=', '1998-01-31', 1, 'Owner of "Pensiever''s Tavern"')
INSERT INTO Questers (Username, Email, [Password], BirthDate, Bio) VALUES ('Test1', 'test@test.com', 'Test1234=', '1950-12-01', 'Pensiever''s Test Subject')

INSERT INTO Genres (Name) VALUES ('Fantastique')
INSERT INTO Genres (Name) VALUES ('Haute Fantaisie')
INSERT INTO Genres (Name) VALUES ('Horror')

INSERT INTO Games (Name) VALUES ('Dungeons&Dragons/D&D 5e')
INSERT INTO Games (Name) VALUES ('Call Of Cthulhu')
INSERT INTO Games (Name) VALUES ('Star Wars 5e')
INSERT INTO Games (Name) VALUES ('Kids on Brooms')

INSERT INTO FavoriteGames VALUES (1, 1)
INSERT INTO FavoriteGames VALUES (1, 2)
INSERT INTO FavoriteGames VALUES (2, 1)
INSERT INTO FavoriteGames VALUES (2, 4)

INSERT INTO FavoriteGenres VALUES (1, 2)
INSERT INTO FavoriteGenres VALUES (1, 3)
INSERT INTO FavoriteGames VALUES (2, 1)

INSERT INTO Contributions VALUES ('Medieval', 2)

INSERT INTO Transgressions VALUES ('Enculé', 2)
INSERT INTO Transgressions VALUES ('Je dois aller chier', 2)
INSERT INTO Transgressions VALUES ('Tu me fais chier', 2)
