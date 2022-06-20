using DAL.Interfaces;
using dal = DAL.Models;
using Model_BLL.Models;
using Model_BLL.Tools;
using Model_BLL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_BLL.Services
{
    public class FavoritesService : IFavoritesService
    {
        IFavoritesRepository<dal.Favorite> _repo;
        public FavoritesService(IFavoritesRepository<dal.Favorite> FavoritesRepo)
        {
            _repo = FavoritesRepo;
        }

        public IEnumerable<Favorite> GetAllGames(int QuesterId)
        {
            return _repo.GetAllGames(QuesterId).Select(x => x.toModel());
        }

        public IEnumerable<Favorite> GetAllGenres(int QuesterId)
        {
            return _repo.GetAllGenres(QuesterId).Select(x => x.toModel());
        }

        public void addFavoriteGame(int QuesterId, int GameId)
        {
            _repo.InsertGame(QuesterId, GameId);
        }

        public void addFavoriteGenre(int QuesterId, int GenreId)
        {
            _repo.InsertGenre(QuesterId, GenreId);
        }

        public void DeleteGame(int FavoriteId)
        {
            _repo.DeleteGame(FavoriteId);
        }

        public void DeleteGenre(int FavoriteId)
        {
            _repo.DeleteGenre(FavoriteId);
        }
    }
}
