using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADOToolbox;
using DAL.Interfaces;
using DAL.Models;
using DAL.Tools;
using Microsoft.Extensions.Configuration;

namespace DAL.Repositories
{
    public class FavoritesRepository : BaseRepository, IFavoritesRepository<Favorite>
    {

        public FavoritesRepository(IConfiguration config) : base(config)
        {
        }

        public bool DeleteGame(int QuesterId, int GameId)
        {
            Command cmd = new Command("DELETE FROM [FavoriteGames] WHERE QuesterId = @QuesterId AND GameId = @GameId");
            cmd.AddParameter("QuesterId", QuesterId);
            cmd.AddParameter("GameId", GameId);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }

        public bool DeleteGenre(int QuesterId, int GenreId)
        {
            Command cmd = new Command("DELETE FROM [FavoriteGenres] WHERE QuesterId = @QuesterId AND GenreId = @GenreId");
            cmd.AddParameter("QuesterId", QuesterId);
            cmd.AddParameter("GenreId", GenreId);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }

        public IEnumerable<Favorite> GetAllGames(int Id)
        {
            Command cmd = new Command("SELECT * FROM [FavoriteGames] WHERE QuesterId = @Id");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteReader<Favorite>(cmd, Converter.ConvertFavorite);
        }

        public IEnumerable<Favorite> GetAllGenres(int Id)
        {
            Command cmd = new Command("SELECT * FROM [FavoriteGenres] WHERE QuesterId = @Id");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteReader<Favorite>(cmd, Converter.ConvertFavorite);
        }

        public Favorite GetGameById(int QuesterId, int GameId)
        {
            Command cmd = new Command("SELECT * FROM [FavoriteGames] WHERE QuesterId = @QuesterId AND GameId = @GameId");
            cmd.AddParameter("QuesterId", QuesterId);
            cmd.AddParameter("GameId", GameId);
            return _connection.ExecuteReader(cmd, Converter.ConvertFavorite).FirstOrDefault();
        }

        public Favorite GetGenreById(int QuesterId, int GenreId)
        {
            Command cmd = new Command("SELECT * FROM [FavoriteGenres] WHERE QuesterId = @QuesterId AND GenreId = @GenreId");
            cmd.AddParameter("QuesterId", QuesterId);
            cmd.AddParameter("GenreId", GenreId);
            return _connection.ExecuteReader(cmd, Converter.ConvertFavorite).FirstOrDefault();
        }

        public void InsertGame(Quester q, Game g)
        {
            string query = "INSERT INTO [FavoriteGames] (QuesterId, GameId) VALUES(@questerId, @gameId)";
            Command cmd = new Command(query);
            cmd.AddParameter("questerId", q.Id);
            cmd.AddParameter("gameId", g.Id);

            _connection.ExecuteNonQuery(cmd);
        }

        public void InsertGenre(Quester q, Genre g)
        {
            string query = "INSERT INTO [FavoriteGenres] (QuesterId, GenreId) VALUES(@questerId, @genreId)";
            Command cmd = new Command(query);
            cmd.AddParameter("questerId", q.Id);
            cmd.AddParameter("genreId", g.Id);

            _connection.ExecuteNonQuery(cmd);
        }
    }
}