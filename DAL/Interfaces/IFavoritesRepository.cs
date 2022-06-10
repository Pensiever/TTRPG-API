using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IFavoritesRepository<Favorite>
    {
        IEnumerable<Favorite> GetAllGames(int Id);
        IEnumerable<Favorite> GetAllGenres(int Id);
        Favorite GetGameById(int QuesterId, int GameId);
        Favorite GetGenreById(int QuesterId, int GenreId);
        void InsertGame(Quester q, Game g);
        void InsertGenre(Quester q, Genre g);
        bool DeleteGame(int QuesterId, int GameId);
        bool DeleteGenre(int QuesterId, int GenreId);
    }
}
