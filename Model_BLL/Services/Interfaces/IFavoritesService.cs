using Model_BLL.Models;

namespace Model_BLL.Services.Interfaces
{
    public interface IFavoritesService
    {
        IEnumerable<Favorite> GetAllGames(int Id);
        IEnumerable<Favorite> GetAllGenres(int Id);
        Favorite GetGameById(int QuesterId, int GameId);
        Favorite GetGenreById(int QuesterId, int GenreId);
        void addFavoriteGame(Quester q, Game g);
        void addFavoriteGenre(Quester q, Genre g);
        void DeleteGame(int QuesterId, int GameId);
        void DeleteGenre(int QuesterId, int GenreId);
    }
}
