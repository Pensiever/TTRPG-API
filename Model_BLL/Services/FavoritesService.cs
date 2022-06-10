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

        public IEnumerable<Favorite> GetAllGames(int Id)
        {
            return _repo.GetAllGames(Id).Select(x => x.toModel());
        }

        public IEnumerable<Favorite> GetAllGenres(int Id)
        {
            return _repo.GetAllGenres(Id).Select(x => x.toModel());
        }

        public Favorite GetGameById(int QuesterId, int GameId)
        {
            return _repo.GetGameById(QuesterId, GameId).toModel();
        }

        public Favorite GetGenreById(int QuesterId, int GenreId)
        {
            return _repo.GetGenreById(QuesterId, GenreId).toModel();
        }

        public void addFavoriteGame(Quester q, Game g)
        {
            _repo.InsertGame(q.toDal(), g.toDal());
        }

        public void addFavoriteGenre(Quester q, Genre g)
        {
            _repo.InsertGenre(q.toDal(), g.toDal());
        }

        public void DeleteGame(int QuesterId, int GameId)
        {
            _repo.DeleteGame(QuesterId, GameId);
        }

        public void DeleteGenre(int QuesterId, int GenreId)
        {
            _repo.DeleteGenre(QuesterId, GenreId);
        }
    }
}
