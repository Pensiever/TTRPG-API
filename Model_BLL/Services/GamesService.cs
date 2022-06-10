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
    public class GamesService : IGamesService
    {
        IGamesRepository<dal.Game> _repo;
        public GamesService(IGamesRepository<dal.Game> GamesRepo)
        {
            _repo = GamesRepo;
        }

        public IEnumerable<Game> GetAll()
        {
            return _repo.GetAll().Select(x => x.toModel());
        }

        public Game GetById(int Id)
        {
            return _repo.GetById(Id).toModel();
        }

        public void CreateGame(Game g)
        {
            _repo.Insert(g.toDal());
        }

        public void Update(Game g)
        {
            _repo.Update(g.toDal());
        }

        public void Delete(int Id)
        {
            _repo.Delete(Id);
        }
    }
}