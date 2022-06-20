using Model_BLL.Models;

namespace Model_BLL.Services.Interfaces
{
    public interface IFavoritesService
    {
        IEnumerable<Favorite> GetAllGames(int QuesterId);
        IEnumerable<Favorite> GetAllGenres(int QuesterId);
        void addFavoriteGame(int QuesterId, int GameId);
        void addFavoriteGenre(int QuesterId, int GenreId);
        void DeleteGame(int FavoriteId);
        void DeleteGenre(int FavoriteId);
    }
}
