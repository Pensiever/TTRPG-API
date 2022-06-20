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
        IEnumerable<Favorite> GetAllGames(int QuesterId);
        IEnumerable<Favorite> GetAllGenres(int QuesterId);
        void InsertGame(int QuesterId, int GameId);
        void InsertGenre(int QuesterId, int GenreId);
        bool DeleteGame(int FavoriteId);
        bool DeleteGenre(int FavoriteId);
    }
}
