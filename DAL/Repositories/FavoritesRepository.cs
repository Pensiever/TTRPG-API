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

        public bool DeleteGame(int FavoriteId)
        {
            Command cmd = new Command("DELETE FROM [FavoriteGames] WHERE FavoriteId = @Id");
            cmd.AddParameter("Id", FavoriteId);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }

        public bool DeleteGenre(int FavoriteId)
        {
            Command cmd = new Command("DELETE FROM [FavoriteGenres] WHERE FavoriteId = @Id");
            cmd.AddParameter("Id", FavoriteId);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }

        public IEnumerable<Favorite> GetAllGames(int QuesterId)
        {
            Command cmd = new Command("SELECT * FROM [FavoriteGames] WHERE QuesterId = @Id");
            cmd.AddParameter("Id", QuesterId);
            return _connection.ExecuteReader<Favorite>(cmd, Converter.ConvertFavoriteGame);
        }

        public IEnumerable<Favorite> GetAllGenres(int QuesterId)
        {
            Command cmd = new Command("SELECT * FROM [FavoriteGenres] WHERE QuesterId = @Id");
            cmd.AddParameter("Id", QuesterId);
            return _connection.ExecuteReader<Favorite>(cmd, Converter.ConvertFavoriteGenre);
        }

        public void InsertGame(int QuesterId, int GameId)
        {
            string query = "INSERT INTO [FavoriteGames] (QuesterId, GameId) VALUES(@questerId, @gameId)";
            Command cmd = new Command(query);
            cmd.AddParameter("questerId", QuesterId);
            cmd.AddParameter("gameId", GameId);

            _connection.ExecuteNonQuery(cmd);
        }

        public void InsertGenre(int QuesterId, int GenreId)
        {
            string query = "INSERT INTO [FavoriteGenres] (QuesterId, GenreId) VALUES(@questerId, @genreId)";
            Command cmd = new Command(query);
            cmd.AddParameter("questerId", QuesterId);
            cmd.AddParameter("genreId", GenreId);

            _connection.ExecuteNonQuery(cmd);
        }
    }
}